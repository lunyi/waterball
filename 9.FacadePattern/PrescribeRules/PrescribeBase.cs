namespace _9.FacadePattern.PrescribeRules
{
    internal interface IPrescribe
    {
        public Prescription GetPrescribe(string id, string symptions);
    }
}
