using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
	public class DailyPaymentDoc : EntityLog<DailyPaymentDoc, Guid>
	{
		public int DailyPaymentId { get; private set; }
		public string FileName { get; private set; }
		public string Container { get; private set; }
		public TypeDocEnum TypeDoc { get; private set; }
		public string Extension { get; private set; }
		public bool Active { get; private set; }

		public DailyPayment DailyPayment { get; set; }

		public DailyPaymentDoc()
		{
		}

		public DailyPaymentDoc(string filename, string extension, TypeDocEnum typedoc, string container, int mentoredId)
		{
			Id = Guid.NewGuid();
			FileName = filename;
			Extension = extension;
			TypeDoc = typedoc;
			Container = container;
			DailyPaymentId = mentoredId;
			Active = true;
		}

		public void SetActive(bool active) { Active = active; }

		public override bool IsValid()
		{
			RuleFor(c => c.TypeDoc)
				.NotEmpty().WithMessage("Tipo do arquivo é obrigatório");

			ValidationResult = Validate(this);
			return ValidationResult.IsValid;
		}

	}
}
