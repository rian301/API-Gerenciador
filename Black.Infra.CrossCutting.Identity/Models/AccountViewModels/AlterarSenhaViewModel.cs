﻿using System.ComponentModel.DataAnnotations;

namespace Black.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class AlterarSenhaViewModel
    {

        [Required]
        [DataType(DataType.Password)]
        public string SenhaAtual { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Senha { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Senha", ErrorMessage = "Senha e confirmação de senha estão diferentes.")]
        public string ConfirmarSenha { get; set; }

    }
}
