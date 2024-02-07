using _9.FacadePattern.Attributes;
namespace _9.FacadePattern
{
    internal class Prescription
    {
        [StringLengthRange(4,30)]
        public string Name { get; set; }
        [StringLengthRange(3, 100)]
        public string PotentialDisease { get; set; }
        [StringLengthRange(3, 30)]
        public string Medicines { get; set; }
        [StringLengthRange(0, 1000)]
        public string Usage { get; set; }
    }
}
