using _9.FacadePattern.Attributes;

namespace _9.FacadePattern
{
    internal class PrescribeResult
    {
        public  string PatientId { get; set; }
        public string[] Cases { get; set; }
        public string Prescription { get; set; }
        public DateTime CaseTime { get; set; }
    }
}
