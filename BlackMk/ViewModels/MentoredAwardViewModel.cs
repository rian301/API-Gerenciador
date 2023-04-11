using Black.API.Admin.ViewModels;
using System;

namespace BlackMk.ViewModels
{
    public class MentoredAwardViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public DateTime DateSend { get; set; }
        public DateTime? DateReceiving { get; set; }
        public string Note { get; set; }
        public int MentoredId { get; set; }
        public int AwardId { get; set; }
    }
}
