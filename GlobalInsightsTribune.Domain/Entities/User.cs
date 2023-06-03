using GlobalInsightsTribune.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace GlobalInsightsTribune.Domain.Entities
{
    public class User
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Username { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public bool IsAdmin { get; private set; }

        public User(int id, string name, string username, string email, string password, bool isAdmin)
        {
            DomainExceptionValidation.When(id < 0, "Error: Invalid Id");

            Id = id;
            ValidateDomain(name, username, email, password, isAdmin);
        }

        public User(string name, string username, string email, string password, bool isAdmin)
        {
            ValidateDomain(name, username, email, password, isAdmin);
        }

        public void Update(string name, string username, string email, string password, bool isAdmin) 
        {
            ValidateDomain(name, username, email, password, isAdmin);
        }

        public void ValidateDomain(string name, string username, string email, string password, bool isAdmin)
        {
            DomainExceptionValidation.When(name.Length > 200, "Error: Name exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(username.Length > 200, "Error: Username exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(email.Length > 200, "Error: Email exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(password.Length > 200, "Error: Password exceeds maximum length of 200 characters");

            Name = name;
            Username = username;
            Email = email;
            Password = password;
            IsAdmin = isAdmin;
        }
    }
}
