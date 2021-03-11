using System;
using Data.Entities;

namespace Entities.DTOs
{
   public class BookDto:IDto
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookType { get; set; }
        public string Publisher { get; set; }
        public string AuthorName{ get; set; }
        public DateTime ReleaseDate { get; set; }
        public string IsbnNo { get; set; }
        public int NumberOfPage { get; set; }

    }
}

