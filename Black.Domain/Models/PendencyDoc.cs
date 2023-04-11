using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
    public class PendencyDoc : EntityLog<PendencyDoc, Guid>
	{
		public int PendencyId { get; private set; }
		public string FileName { get; private set; }
		public string Container { get; private set; }
		public string Extension { get; private set; }
		public bool Active { get; private set; }
		public TypeDocEnum TypeDoc { get; private set; }

		public Pendency Pendency { get; set; }

		public PendencyDoc()
		{
		}

		public PendencyDoc(string filename, string extension, TypeDocEnum typedoc, string container, int mentoredId)
		{
			Id = Guid.NewGuid();
			FileName = filename;
			Extension = extension;
			Container = container;
			PendencyId = mentoredId;
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
