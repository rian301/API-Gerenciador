using Black.API.Admin.ViewModels;
using System;

namespace BlackMk.ViewModels
{
    public class ClassViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string LinkClass { get; set; }
        public string LinkInfo { get; set; }
        public string LinkCopy { get; set; }
        public string LinkCreative { get; set; }
        public string LinkTraffic { get; set; }
        public string LinkRegister { get; set; }
    }
}
