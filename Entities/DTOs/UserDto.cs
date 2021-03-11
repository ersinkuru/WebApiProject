using System;
using System.Collections.Generic;
using System.Text;
using Data.Entities;

namespace Entities.DTOs
{
  public  class UserDto:IDto
    {
      
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }

    }
}
