using hospitall;

namespace ConsoleApp8;

public class Pediatry : Department
{

    List<Pediatry> doctorsP = new List<Pediatry>();

    public Pediatry(string name, List<Doctor> doctors) : base(name, doctors)
    {
    }

    //public override string ToString() =>

    //$"Name:{Name}\nSurname:{Surname}\nWorkExperience:{WorkExperience}";


}