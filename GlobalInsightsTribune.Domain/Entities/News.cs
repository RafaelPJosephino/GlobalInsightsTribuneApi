using GlobalInsightsTribune.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GlobalInsightsTribune.Domain.Entities
{

    public class News
    {
        public int Id { get; private set; }
        public string Title { get; private set; } = string.Empty;
        public string Image { get; private set; } = string.Empty;
        public string Author { get; private set; } = string.Empty;
        public DateTime PublicationDate { get; private set; }
        public string Description { get; private set; } = string.Empty;

        public News(int id, string title, string image, string author, DateTime publicationDate, string description)
        {
            DomainExceptionValidation.When(id < 0, "Error: Invalid Id");

            Id = id;
            ValidateDomain(title, image, author, publicationDate, description);
        }

        public News(string title, string image, string author, DateTime publicationDate, string description)
        {
            ValidateDomain(title, image, author, publicationDate, description);
        }

        public void Update(string title, string image, string author, DateTime publicationDate, string description)
        {
            ValidateDomain(title, image, author, publicationDate, description);
        }

        public void ValidateDomain(string title, string image, string author, DateTime publicationDate, string description)
        {
            DomainExceptionValidation.When(title.Length > 200, "Error: Title exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(author.Length > 200, "Error: Author name exceeds maximum length of 200 characters");
            DomainExceptionValidation.When(description.Length > 2000, "Error: Description exceeds maximum length of 2000 characters");

            Title = title;
            Image = image;
            Author = author;
            PublicationDate = publicationDate;
            Description = description;
        }
    }
}
