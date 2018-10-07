using BusinesLayer.Attributes;

namespace ValidationService.Test.TestEntities
{
    class User
    {
        [Required("Obj")]
        private object Obj { get; set; }

        [StringLength(2, "Str")]
        private string Str { get; set; }

        [IntValueRange(1, 10, "Num")]
        private int Num { get; set; }


        public User(object obj, string str, byte num)
        {
            Obj = obj;
            Str = str;
            Num = num;
        }
    }
}
