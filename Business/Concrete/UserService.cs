using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Business.Abstract;
using Business.Helpers;
using Data.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Business.Concrete
{
    public class UserService : IUserService
    {

        private readonly AppSettings _appSettings;
        private readonly IUserDal _userDal;

        public UserService(IUserDal userDal, IOptions<AppSettings> appSettings)
        {
            _userDal = userDal;
            _appSettings = appSettings.Value;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new Result(true);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new Result(true);
        }

        public IDataResult<List<User>> GetAll()
        {
            var userList = _userDal.GetAll().Select(x =>
             {
                 x.Password = null;
                 return x;
             });
            return new SuccessDataResult<List<User>>(userList.ToList());
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new Result(true);
        }
    

        public User Authenticate(string userName, string password)
        {
            var user = _userDal.GetAll().SingleOrDefault(x => x.UserName == userName && x.Password == password);


            if (user == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = null;

            return user;
        }


       
    }
}
