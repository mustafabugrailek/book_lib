
using System;

namespace book_lib.Entities
{
    public class Member
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public Member(int id, string fullName, string email)
        {
            Id = id;
            FullName = fullName;
            Email = email;
        }

        public override string ToString()
        {
            return $"{FullName} (ID: {Id}, Email: {Email})";
        }
    }
}