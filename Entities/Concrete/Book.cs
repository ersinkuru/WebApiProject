using System;
using System.Collections.Generic;
using Data.Entities;

namespace Entities.Concrete
{
    public class Book:IEntity
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string Publisher { get; set; }
        public int AuthorId{ get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNo { get; set; }
        public int NumberOfPage { get; set; }
        public bool IsDeleted { get; set; }

      

    }
}
