using Data.Entities;

namespace Entities.Concrete
{
   public class User:IEntity
    {
        public int  Id{ get; set; }
        public string UserName{ get; set; }
        public string Password { get; set; }
        public string  EMail  { get; set; }
        public string  Token { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted{ get; set; }
    }
}
