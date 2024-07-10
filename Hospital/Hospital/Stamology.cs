using hospitall;

namespace ConsoleApp8;

public class Stamology : Department
{

    List<Doctor> doctorsS = new List<Doctor>();

    public Stamology(string name, List<Doctor> doctors) : base(name, doctors)
    {
    }

    //public override string ToString() =>
    //$"Name:{Name}\nSurname:{Surname}\nWorkExperience:{WorkExperience}";
}