using BusinesLayer.Attributes;

namespace SPP.Validation.PresentasionLayer
{
    public class User
    {
        [Required("Str2")]
        public static string Str2 { get; set; }

        [StringLength(2, "")]
        public string Str { get; set; }

        [IntValueRange(1, 10, "Num")]
        private int Num { get; set; }

        public User
        (
            string str,
            byte num,
            string str2
        )
        {
            Str2 = str2;
            Str = str;
            Num = num;
        }
    }
}
