using System;
using System.ComponentModel.DataAnnotations;
using Data.Entities;

namespace Entities.DTOs
{
    public class AuthorDto : IDto
    {
        [Key]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }

    }
}
