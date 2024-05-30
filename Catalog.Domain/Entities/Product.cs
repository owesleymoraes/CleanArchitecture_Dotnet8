using Catalog.Domain.Validation;

namespace Catalog.Domain.Entities
{
    public sealed class Product : Entity
    {
        public Product(string name, string description, decimal price, string imageUrl,
            int stoke, DateTime dateRegister)
        {
            ValidateDomain(name, description, price, imageUrl, stoke, dateRegister);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public string ImageUrl { get; private set; }
        public int Stoke { get; private set; }
        public DateTime DateRegister { get; private set; }

        public void Update(string name, string description, decimal price, string imageUrl,
            int stoke, DateTime dateRegister, int categoryId)
        {
            ValidateDomain(name, description, price, imageUrl, stoke, dateRegister);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, string imageUrl,
            int stoke, DateTime dateRegister)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(description.Length < 5,
                "A descrição deve ter no mínimo 5 caracteres");

            DomainExceptionValidation.When(price < 0, "Valor do preço inválido");

            DomainExceptionValidation.When(imageUrl?.Length > 250,
                "O nome da imagem não pode exceder 250 caracteres");

            DomainExceptionValidation.When(stoke < 0, "Estoque inválido");

            Name = name;
            Description = description;
            Price = price;
            ImageUrl = imageUrl;
            Stoke = stoke;
            DateRegister = dateRegister;

        }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}