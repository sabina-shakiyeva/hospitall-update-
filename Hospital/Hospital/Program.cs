using ConsoleApp8;

using Hospital;
using Newtonsoft.Json;

class Program
{

    static void Main(string[] args)
    {


        List<User> users = new List<User>();

        List<Doctor> doctorsP = new List<Doctor>();
        Doctor doctorp1 = new Doctor("Farida", "Shakiyeva", 5);
        Doctor doctorp2 = new Doctor("Arzu", "Aliyeva", 7);
        Doctor doctorp3 = new Doctor("Sevil", "Sevileva", 8);
        doctorsP.Add(doctorp1);
        doctorsP.Add(doctorp2);
        doctorsP.Add(doctorp3);

        Pediatry pediatry = new Pediatry("Pediatry", doctorsP);

        List<Doctor> doctorsT = new List<Doctor>();
        Doctor doctort1 = new Doctor("Zefer", "Haciyev", 5);
        Doctor doctort2 = new Doctor("Hikmet", "Qurbanov", 3);
        doctorsT.Add(doctort1);
        doctorsT.Add(doctort2);

        Traumatology traumatology = new Traumatology("Traumatology", doctorsT);

        List<Doctor> doctorsS = new List<Doctor>();
        Doctor doctors1 = new Doctor("Rovsen", "Rovsenov", 6);
        doctorsS.Add(doctors1);

        Stamology stamology = new Stamology("Stamology", doctorsS);

        while (true)
        {
            Console.WriteLine("Asagidakilarindan birini secin:");
            Console.WriteLine("1.Add User");
            Console.WriteLine("2.Add Reserve");
            short choice = 0;
            Console.Write("choice:");
            choice = short.Parse(Console.ReadLine());


            if (choice == 1)
            {
                Console.Write("Enter name:");
                string name = Console.ReadLine();

                Console.Write("Enter surname:");
                string surname = Console.ReadLine();

                Console.Write("Email:");
                string email = Console.ReadLine();

                Console.Write("Number:");
                string number = Console.ReadLine();


                User user = new User(name, surname, email, number);
                users.Add(user);


            }
            else if (choice == 2)
            {
                if (users.Count == 0)
                {
                    Console.WriteLine("Zehmet olmasa istifadeci elave edin!");
                    continue;
                }
                Console.WriteLine("Istifadeciler:");
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{users[i].Name}{users[i].Surname}");
                }
                Console.WriteLine("Istifadeci secin:");
                int userIndex = int.Parse(Console.ReadLine()) - 1;
                if(userIndex<0 || userIndex >= users.Count)
                {
                    throw new UserException("Istifadeci tapilmadi!");
                }
                User selectedU = users[userIndex];
                Console.WriteLine("Asagida qeyd olunan sobelerden birini secin");
                Console.Write("Secimi daxil edin-->1)Pediatriya 2)Stamotologiya 3)Travmatologiya:");
                short choiceDoct = 0;
                Console.Write("choice:");
                choiceDoct = short.Parse(Console.ReadLine());
                if (choiceDoct == 1)
                {

                    pediatry.showDoctor();
                    Console.WriteLine("Hansi hekimi isteyirsiniz?(sirasini daxil edin reqemle)");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < pediatry.Doctors.Count)
                    {
                        Doctor selected = pediatry.Doctors[index];
                        while (true)
                        {
                            try
                            {
                                Console.WriteLine("Zehmet olmasa vaxt rezerv edin!");
                                selected.showHours();
                                int reservee = int.Parse(Console.ReadLine());

                                if ((reservee == 1 && selected.Saat1 == false) || (reservee == 2 && selected.Saat2 == false) || (reservee == 3 && selected.Saat3 == false))
                                {
                                    selected.Reserve(reservee);
                                    string timee = "";
                                    if (reservee == 1)
                                    {
                                        timee = "09:00-11:00";
                                    }
                                    else if (reservee == 2)
                                    {
                                        timee = "12:00-14:00";
                                    }
                                    else if (reservee == 3)
                                    {
                                        timee = "15:00-17:00";
                                    }
                                    Console.WriteLine($"Tesekkurler {selectedU.Name}{selectedU.Surname},siz saat {timee} de {selected.Name}{selected.Surname} hekimin qebuluna yazildiniz");

                                    var reservvInfo = new
                                    {
                                        User = selectedU,
                                        Doctor = selected,
                                        Time = timee

                                    };
                                    string json =JsonConvert.SerializeObject( reservvInfo ,Formatting.Indented);
                                    File.WriteAllText("reservation.json", json);

                                    break;
                                }






                            }
                            catch(ReservationException ex)
                            {
                                Console.WriteLine(ex.Message);
                            }
                            catch(Exception ex)
                            {
                                Console.WriteLine($"Xeta :{ex.Message}");
                            }
                        }

                    }

                }

                if (choiceDoct == 2)
                {

                    stamology.showDoctor();
                    Console.WriteLine("Hansi hekimi isteyirsiniz?(sirasini daxil edin reqemle)");
                    Console.Write("choice:");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < stamology.Doctors.Count)
                    {
                        Doctor selected = stamology.Doctors[index];
                        while (true)
                        {
                            Console.WriteLine("Zehmet olmasa vaxt rezerv edin!");
                            selected.showHours();
                            int reservee = int.Parse(Console.ReadLine());

                            if ((reservee == 1 && selected.Saat1 == false) || (reservee == 2 && selected.Saat2 == false) || (reservee == 3 && selected.Saat3 == false))
                            {
                                selected.Reserve(reservee);
                                string timee = "";
                                if (reservee == 1)
                                {
                                    timee = "09:00-11:00";
                                }
                                else if (reservee == 2)
                                {
                                    timee = "12:00-14:00";
                                }
                                else if (reservee == 3)
                                {
                                    timee = "15:00-17:00";
                                }
                                Console.WriteLine($"Tesekkurler {selectedU.Name}{selectedU.Surname},siz saat {timee} de {selected.Name}{selected.Surname} hekimin qebuluna yazildiniz");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hemin vaxt tutulub");
                            }
                        }

                    }

                }

                if (choiceDoct == 3)
                {

                    traumatology.showDoctor();
                    Console.WriteLine("Hansi hekimi isteyirsiniz?(sirasini daxil edin reqemle)");
                    Console.Write("choice:");
                    int index = int.Parse(Console.ReadLine()) - 1;
                    if (index >= 0 && index < traumatology.Doctors.Count)
                    {
                        Doctor selected = traumatology.Doctors[index];
                        while (true)
                        {
                            Console.WriteLine("Zehmet olmasa vaxt rezerv edin!");
                            selected.showHours();
                            int reservee = int.Parse(Console.ReadLine());

                            if ((reservee == 1 && selected.Saat1 == false) || (reservee == 2 && selected.Saat2 == false) || (reservee == 3 && selected.Saat3 == false))
                            {
                                selected.Reserve(reservee);
                                string timee = "";
                                if (reservee == 1)
                                {
                                    timee = "09:00-11:00";
                                }
                                else if (reservee == 2)
                                {
                                    timee = "12:00-14:00";
                                }
                                else if (reservee == 3)
                                {
                                    timee = "15:00-17:00";
                                }
                                Console.WriteLine($"Tesekkurler {selectedU.Name}{selectedU.Surname},siz saat {timee} de {selected.Name}{selected.Surname} hekimin qebuluna yazildiniz");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Hemin vaxt tutulub");
                            }
                        }

                    }

                }



            }
        }


    }
}