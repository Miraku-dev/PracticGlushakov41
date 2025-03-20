partial class Patient
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Diagnosis { get; set; }

    public static void DisplayPatientInfo(Patient patient)
    {
        Console.WriteLine($"Имя: {patient.Name}, Возраст: {patient.Age}, Диагноз: {patient.Diagnosis}");
    }
}