// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace MarshalApp.Net.Security.API.Infrastructure.Data.Entities
{
    public partial class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool CanAccessAuthors { get; set; }
        public bool CanAddAuthor { get; set; }
        public bool CanSaveAuthor { get; set; }
        public bool CanAccessBooks { get; set; }
        public bool CanAccessStudent { get; set; }
        public bool CanAddStudent { get; set; }
        public bool CanSaveStudent { get; set; }
        public bool CanAccessGrades { get; set; }
    }
}