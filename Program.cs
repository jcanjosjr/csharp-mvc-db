using System;
using Views;
using Controllers;
using Models;

namespace ConsultorioOdontologico
{
    public class Program
    {
        public static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    Console.Write("*");
                    password += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        // remove one character from the list of password characters
                        password = password.Substring(0, password.Length - 1);
                        // get the location of the cursor
                        int pos = Console.CursorLeft;
                        // move the cursor to the left by one character
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                        // replace it with space
                        Console.Write(" ");
                        // move the cursor to the left by one character again
                        Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    }
                }
                info = Console.ReadKey(true);
            }

            // add a new line because user pressed enter at the end of their password
            Console.WriteLine();
            return password;
        }

        public static void Main(string[] args)
        {
            SpecialityController.CreateSpeciality("General Clinic", "General practitioner dentist is usually the first dental professional to be in contact with the patient");
            DentistController.CreateDentist("José do Carmo", "111.111.111-11", "47 99999-9999", "jose.carmo@dentista.com", "123456", "12345/SC", 15000, 1);
            PatientController.CreatePatient("Amélia da Silva", "111.111.111-11", "47 88888-8888", "amelia.silva@paciente.com", "123456", Convert.ToDateTime("1990-01-01"));
            RoomController.CreateRoom("B135", "RaioX");
            SchedullerController.CreateScheduler(1, 1, 1, Convert.ToDateTime("2022-04-05"));
            ProcedureController.CreateProcedure("General diagnosis", 300, 1);
            //MenuPrincipal();

            do
            {
                Console.WriteLine("Username: ");
                string Mail = Console.ReadLine();
                Console.WriteLine("Password: ");
                string Password = ReadPassword();
                
                try
                {
                    Auth.DentistLogin(Mail, Password);
                    if (Auth.Dentist != null)
                    {
                        PrincipalMenu();
                    }
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
                try
                {
                    Auth.PatientLogin(Mail, Password);
                    if (Auth.Patient != null) {
                        PatientMenu();
                    }
                    Auth.Logout();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err);
                }
            } while (!Auth.IsLogeed);
        }

        public static void PatientMenu()
        {
            Console.WriteLine($" ============= Welcome Patient {Auth.Patient.Name} ============ ");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("| Operation | Description             |");
            Console.WriteLine("|-----------|-------------------------|");
            Console.WriteLine("|     0     | Quit                    |");
            Console.WriteLine("|     1     | View Schedulers         |");
            Console.WriteLine("|     2     | Confirm Schedulers      |");
            Console.WriteLine("+-------------------------------------+");
            int opt = 0;

            do
            {
                Console.WriteLine("Inform your operation: ");
                try
                {
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                switch (opt)
                {
                    case 0:
                        Console.WriteLine("Bye bye.");
                        break;
                    case 1:
                        SchedulerView.GetPatientScheduler(Auth.Patient.Id);
                        break;
                    case 2:
                        SchedulerView.ConfirmScheduler();
                        break;
                    default:
                        Console.WriteLine("Invalid operation.");
                        break;
                }  
            } while (opt != 0);
        }

        public static void PrincipalMenu()
        {
            Console.WriteLine($" ============= WELCOME {Auth.Dentist.Name} ============ ");
            Console.WriteLine("+-------------------------------------+");
            Console.WriteLine("| Operation |  Description            |");
            Console.WriteLine("|-----------|-------------------------|");
            Console.WriteLine("|  0        |  Quit                   |");
            Console.WriteLine("|  1        |  Create Dentist         |");
            Console.WriteLine("|  2        |  Create Patient         |");
            Console.WriteLine("|  3        |  Create Room            |");
            Console.WriteLine("|  4        |  Create Scheduler       |");
            Console.WriteLine("|  5        |  Create Procedure       |");
            Console.WriteLine("|  6        |  Create Speciality      |");
            Console.WriteLine("|  7        |  Update Dentist         |");
            Console.WriteLine("|  8        |  Update Patient         |");
            Console.WriteLine("|  9        |  Update Room            |");
            Console.WriteLine("|  10       |  Update Scheduler       |");
            Console.WriteLine("|  11       |  Update Procedure       |");
            Console.WriteLine("|  12       |  Update Speciality      |");
            Console.WriteLine("|  13       |  Delete Dentist         |");
            Console.WriteLine("|  14       |  Delete Patient         |");
            Console.WriteLine("|  15       |  Delete Room            |");
            Console.WriteLine("|  16       |  Delete Scheduler       |");
            Console.WriteLine("|  17       |  Delete Procedure       |");
            Console.WriteLine("|  18       |  Delete Speciality      |");
            Console.WriteLine("|  19       |  View Dentists          |");
            Console.WriteLine("|  20       |  View Patients          |");
            Console.WriteLine("|  21       |  View Rooms             |");
            Console.WriteLine("|  22       |  View Schedulers        |");
            Console.WriteLine("|  23       |  View Procedures        |");
            Console.WriteLine("|  24       |  View Specialities      |");
            Console.WriteLine("+-------------------------------------+");

            int opt = 0;

            do
            {
                try
                {
                    Console.WriteLine("Inform your operation: ");
                    opt = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    opt = 99;
                }
                try{
                    switch (opt)
                    {
                        case 0:
                        {
                            Console.WriteLine("Bye bye.");
                            break;
                        }
                        case 1:
                        {
                            DentistView.CreateDentist();
                            break;
                        }
                        case 2:
                        {
                            PatientView.CreatePatient();
                            break;
                        }
                        case 3:
                        {
                            RoomView.CreateRoom();
                            break;
                        }
                        case 4:
                        {
                            SchedulerView.CreateScheduler();
                            break;
                        }
                        case 5:
                        {
                            ProcedureView.CreateProcedure();
                            break;
                        }
                        case 6:
                        {
                            SpecialityView.CreateSpeciality();
                            break;
                        }
                        case 7:
                        {
                            DentistView.UpdateDentist();
                            break;
                        }
                        case 8:
                        {
                            PatientView.UpdatePatient();
                            break;
                        }
                        case 9:
                        {
                            RoomView.UpdateRoom();
                            break;
                        }
                        case 10:
                        {
                            SchedulerView.UpdateScheduler();
                            break;
                        }
                        case 11:
                        {
                            ProcedureView.UpdateProcedure();
                            break;
                        }
                        case 12:
                        {
                            SpecialityView.UpdateSpeciality();
                            break;
                        }
                        case 13:
                        {
                            DentistView.DeleteDentist();
                            break;
                        }
                        case 14:
                        {
                            PatientView.DeletePatiet();
                            break;
                        }
                        case 15:
                        {
                            RoomView.DeleteRoom();
                            break;
                        }
                        case 16:
                        {
                            SchedulerView.DeleteScheduler();
                            break;
                        }
                        case 17:
                        {
                            ProcedureView.DeleteProcedure();
                            break;
                        }
                        case 18:
                        {
                            SpecialityView.DeleteSpeciliaty();
                            break;
                        }
                        case 19:
                        {
                            DentistView.GetAllDentists();
                            break;
                        }
                        case 20:
                        {
                            PatientView.GetAllPatients();
                            break;
                        }
                        case 21:
                        {
                            RoomView.GetAllRooms();
                            break;
                        }
                        case 22:
                        {
                            SchedulerView.GetAllSchedulers();
                            break;
                        }
                        case 23:
                        {
                            ProcedureView.GetAllProcedures();
                            break;
                        }
                        case 24:
                        {
                            SpecialityView.GetAllSpecialities();
                            break;
                        }
                        default:
                        {
                            Console.WriteLine("Invalid operation.");
                            break;
                        }
                    }
                } 
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);
                    opt = 99;
                }
            } while (opt != 0);
        }
    }
}
