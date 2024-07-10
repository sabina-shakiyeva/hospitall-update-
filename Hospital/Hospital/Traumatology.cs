using hospitall;

namespace ConsoleApp8;

public class Traumatology : Department
{

    List<Doctor> doctorsT = new List<Doctor>();

    public Traumatology(string name, List<Doctor> doctors) : base(name, doctors)
    {
    }

    //public override string ToString() =>
    //$"Name:{Name}\nSurname:{Surname}\nWorkExperience:{WorkExperience}";



}