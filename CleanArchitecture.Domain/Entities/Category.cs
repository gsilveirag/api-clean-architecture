using CleanArchitecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
        }
        public ICollection<Product> Products { get; set; }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3,
                "Invalid name, too short.");

            Name = name;
        }

        //So foi criado para popular a tabela via codigo.
        public Category(Guid id, string name)
        {
            Id = id;
            ValidationDomain(name);
        }
    }
}
