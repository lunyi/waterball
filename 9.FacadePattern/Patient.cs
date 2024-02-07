using _9.FacadePattern.Attributes;

namespace _9.FacadePattern
{
    internal class Patient
    {
        [IdentityLimit]
        public  string Id { get; set; }
        [StringLengthRange(1,30)]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        [IntRange(1,180)]
        public int Age { get; set; }
        [FloatRange(1,500)]
        public float Height { get; set; }
        [FloatRange(1, 500)]
        public float Weight { get; set; }
        public List<string> Cases { get; set; }


    }

    internal enum Gender
    { 
        Female = 0,
        Male = 1
    }
}
