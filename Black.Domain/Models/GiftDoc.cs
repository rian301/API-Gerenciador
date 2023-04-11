using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class GiftDoc : EntityLog<GiftDoc, Guid>
	{
		public int GiftId { get; private set; }
		public string FileName { get; private set; }
		public string Container { get; private set; }
		public string Extension { get; private set; }
		public bool Active { get; private set; }
		public TypeDocEnum TypeDoc { get; private set; }

		public Gift Gift { get; set; }

		public GiftDoc()
		{
		}

		public GiftDoc(string filename, string extension, TypeDocEnum typedoc, string container, int mentoredId)
		{
			Id = Guid.NewGuid();
			FileName = filename;
			Extension = extension;
			Container = container;
			GiftId = mentoredId;
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
