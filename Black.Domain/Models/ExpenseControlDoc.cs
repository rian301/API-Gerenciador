using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class ExpenseControlDoc : EntityLog<ExpenseControlDoc, Guid>
	{
		public int ExpenseControlId { get; private set; }
		public string FileName { get; private set; }
		public string Container { get; private set; }
		public string Extension { get; private set; }
		public bool Active { get; private set; }
		public TypeDocEnum TypeDoc { get; private set; }

		public ExpenseControl ExpenseControl { get; set; }

		public ExpenseControlDoc()
		{
		}

		public ExpenseControlDoc(string filename, string extension, TypeDocEnum typedoc, string container, int mentoredId)
		{
			Id = Guid.NewGuid();
			FileName = filename;
			Extension = extension;
			Container = container;
			ExpenseControlId = mentoredId;
			TypeDoc = typedoc;
			Active = true;		
		}

		public void SetActive(bool active) { Active = active; }

		public override bool IsValid()
		{
			RuleFor(c => c.FileName)
				.NotEmpty().WithMessage("Nome do arquivo é obrigatório");

			ValidationResult = Validate(this);
			return ValidationResult.IsValid;
		}

	}
}
