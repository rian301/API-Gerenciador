using Black.API.Admin.ViewModels;
using Black.Domain.Core.Utils;
using Black.Domain.Enums;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BlackMk.ViewModels
{
    public class MentoredViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? EndSubscriptionDate { get; set; }
        public decimal TotalAmountContract { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string PhoneNumber { get; set; }
        public string Street { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Complement { get; set; }
        public int? Number { get; set; }
        public string Instagram { get; set; }
        public string Note { get; set; }
        public bool IsPartner { get; set; }
        public IEnumerable<int?> Partners { get; set; }
        public IEnumerable<MentoredCompanyViewModel> MentoredCompanies { get; set; }
        // TODO: Mudar Dados empresa
        public string CompanyName { get; set; }
        public string CNPJ { get; set; }
        public string CompanyZipCode { get; set; }
        public string CompanyStreet { get; set; }
        public string CompanyNumber { get; set; }
        public string CompanyComplement { get; set; }
        public string CompanyDistrict { get; set; }
        public string CompanyCity { get; set; }
        public string CompanyState { get; set; }
        public string CompanyNote { get; set; }
        public MentoredStatusEnum? Status { get; set; }
        public MentoredCompanyStatusEnum? CompanyStatus { get; set; }
        public string StatusDescription { get { return EnumUtil.GetDescriptions(Status); } }
    }
}
