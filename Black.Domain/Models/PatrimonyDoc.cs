using Black.Domain.Core.Models;
using Black.Domain.Enums;
using FluentValidation;
using System;

namespace Black.Domain.Models
{
	public class PatrimonyDoc : EntityLog<PatrimonyDoc, Guid>
	{
		public int PatrimonyId { get; private set; }
		public string FileName { get; private set; }
		public string Container { get; private set; }
		public TypeDocEnum TypeDoc { get; private set; }
		public string Extension { get; private set; }
		public bool Active { get; private set; }

		public Patrimony Patrimony { get; set; }

		public PatrimonyDoc()
		{
		}

		public PatrimonyDoc(string filename, string extension, TypeDocEnum typedoc, string container, int patrimonyId)
		{
			Id = Guid.NewGuid();
			FileName = filename;
			Extension = extension;
			TypeDoc = typedoc;
			Container = container;
			PatrimonyId = patrimonyId;
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
