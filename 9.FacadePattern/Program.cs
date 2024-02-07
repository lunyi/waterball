using Newtonsoft.Json;

namespace _9.FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var db = new PatientDatabase();
            var patients = db.Parents;
        }
    }
}