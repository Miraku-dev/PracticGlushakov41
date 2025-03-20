class Hospital
{
    private Patient[] patients;

    public Hospital(Patient[] patients)
    {
        this.patients = patients;
    }

    public Patient[] GetPatientsByDiagnosis(string diagnosis)
    {
        return patients.Where(p => p.Diagnosis.Equals(diagnosis, StringComparison.OrdinalIgnoreCase)).ToArray();
    }

    public Patient GetOldestPatient()
    {
        return patients.OrderByDescending(p => p.Age).FirstOrDefault();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество пациентов: ");
        int count = int.Parse(Console.ReadLine() ?? "0");

        var patients = new Patient[count];

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"Введите данные пациента {i + 1}:");
            Console.Write("Имя: ");
            string name = Console.ReadLine() ?? "0";
            Console.Write("Возраст: ");
            int age = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Диагноз: ");
            string diagnosis = Console.ReadLine() ?? "0";

            patients[i] = new Patient { Name = name, Age = age, Diagnosis = diagnosis };
        }

        var hospital = new Hospital(patients);

        Console.Write("Введите диагноз для поиска пациентов: ");
        string searchDiagnosis = Console.ReadLine() ?? "0";
        var patientsByDiagnosis = hospital.GetPatientsByDiagnosis(searchDiagnosis);

        Console.WriteLine($"Пациенты с диагнозом '{searchDiagnosis}':");
        foreach (var patient in patientsByDiagnosis)
        {
            Patient.DisplayPatientInfo(patient);
        }

        var oldestPatient = hospital.GetOldestPatient();
        Console.WriteLine("Самый старший пациент:");
        Patient.DisplayPatientInfo(oldestPatient);
    }
}