using System;

namespace Black.Domain.Helpers
{
    public static class CardExpirationHelper
    {
        public static bool IsValid(this object value)
        {
            var date = ToDatetime(value);
            if (date.HasValue)
                return date > DateTime.UtcNow;

            return false;
        }

        public static DateTime? ToDatetime(object mmAA)
        {
            try
            {
                if (mmAA == null)
                    return null;

                var mes = mmAA.ToString().Split('/')[0];
                var ano = $"20{mmAA.ToString().Split('/')[1]}";

                if (int.TryParse(mes, out var month) &&
                    int.TryParse(ano, out var year))
                {
                    return new DateTime(year, month, 1);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }            
        }
    }
}
