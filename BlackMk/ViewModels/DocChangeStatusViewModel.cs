using Black.Domain.Enums;
using System;

namespace BlackMk.ViewModels
{
    public class DocChangeStatusViewModel
    {
        public Guid DocId { get; set; }
        public int MentoredId { get; set; }
        //public int CompanyId { get; set; }
        public TypeDocEnum Type { get; set; }
        public bool Active { get; set; }
    }
}
