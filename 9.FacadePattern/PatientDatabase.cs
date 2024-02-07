using Newtonsoft.Json;

namespace _9.FacadePattern
{
    internal class PatientDatabase
    {
        public List<Patient> Parents { get; private set; }
        public PatientDatabase() 
        {
            string file = "patients.json";
            string currentDirectory = Directory.GetCurrentDirectory();
            string filePath = Path.Combine(currentDirectory, file);

            string json = File.ReadAllText(filePath);
            Parents = JsonConvert.DeserializeObject<List<Patient>>(json);
        }
    }
}
