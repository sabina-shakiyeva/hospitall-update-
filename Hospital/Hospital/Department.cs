using ConsoleApp8;

namespace hospitall;

public class Department
{
    public Department(string name, List<Doctor> doctors)
    {
        Name = name;
        Doctors = doctors;
    }

    public string Name { get; set; }
    public List<Doctor> Doctors { get; set; }

    public void showDoctor()
    {
        for (int i = 0; i < Doctors.Count; i++)
        {
            Console.WriteLine($"{i + 1}.{Doctors[i]}");
        }
    }
}