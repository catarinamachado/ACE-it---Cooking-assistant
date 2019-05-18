using System;

namespace ACE_it.Helper
{
    public class PromoCodeViewModel
    {
        public string Code { get; set; }
        
        public DateTime ExpireDate { get; set; }

        public PromoCodeViewModel(
            string code,
            DateTime expireDate)
        {
            Code = code;
            ExpireDate = expireDate;
        }
    }
}
