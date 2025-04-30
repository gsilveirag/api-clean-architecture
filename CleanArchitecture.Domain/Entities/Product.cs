using CleanArchitecture.Domain.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }

        //Construtor: garantir que certos dados sejam obrigatórios ou inicializar propriedades corretamente.
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain (string name, string description, decimal price, int stock, string image) 
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required.");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Name is too short.");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Invalid name. Description is required.");
            DomainExceptionValidation.When(description.Length < 3, "Invalid name. Name is too short.");

            DomainExceptionValidation.When(price < 0, "Invalid price value.");

            DomainExceptionValidation.When(stock < 0, "Invalid stock value.");

            DomainExceptionValidation.When(image.Length > 250, "Invalid image. Image is too long.");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }

        public int CategoryId { get; set; }
        public Category Category { get; set; }


        //So foi criado para popular a tabela via codigo.
        public Product(Guid id, string name, string description, decimal price, int stock, string image)
        {
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }
    }
}
