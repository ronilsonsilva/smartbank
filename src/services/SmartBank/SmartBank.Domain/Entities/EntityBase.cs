using FluentValidation;
using FluentValidation.Results;
using SmartBank.Domain.EntitiesValidators;
using System;

namespace SmartBank.Domain.Entities
{
    public class EntityBase
    {
        public Guid Id { get; set; }
        public DateTime Cadastro { get; set; }
        public DateTime Atualizado { get; set; }

        public bool Valid
        {
            get { return this.Validate<EntityBase>(this, new BaseValidator<EntityBase>()); }
        }
        public bool Invalid => !Valid;
        public ValidationResult ValidationResult { get; private set; }

        public bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            ValidationResult = validator.Validate(model);
            return ValidationResult.IsValid;
        }
    }
}
