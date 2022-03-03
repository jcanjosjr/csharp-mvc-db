using System;
using Models;
using Controllers;

namespace Views
{
    public class DentistView
    {
        public static void CreateDentist()
        {
            double Wage = 0;
            int IdSpeciality = 0;
            Console.WriteLine("Inform the name of Dentist: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Inform the CPF of Dentist: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Inform the phone of Dentist: ");
            string Phone = Console.ReadLine();
            Console.WriteLine("Inform the Mail of Dentist: ");
            string Mail = Console.ReadLine();
            Console.WriteLine("Inform the password of Dentist: ");
            string Passwd = Console.ReadLine();
            Console.WriteLine("Inform the register C.R.O of Dentist: ");
            string Register = Console.ReadLine();
            Console.WriteLine("Inform the Wage of the Dentist: ");
            try
            {
                Wage = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid wage.");
            }
            SpecialityView.GetAllSpecialities();
            Console.WriteLine("Choose a existing Speciality by ID: ");
            try
            {
                IdSpeciality = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            DentistController.CreateDentist(
                Name,
                Cpf,
                Phone,
                Mail,
                Passwd,
                Register,
                Wage,
                IdSpeciality
            );
        }

        public static void UpdateDentist()
        {
            int Id = 0;
            double Wage = 0;

            GetAllDentists();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Dentist: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            Console.WriteLine("Inform the name of Dentist: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Inform the CPF of Dentist: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Inform the phone of Dentist: ");
            string Phone = Console.ReadLine();
            Console.WriteLine("Inform the Mail of Dentist: ");
            string Mail = Console.ReadLine();
            Console.WriteLine("Inform the password of Dentist: ");
            string Passwd = Console.ReadLine();
            Console.WriteLine("Inform the register C.R.O of Dentist: ");
            string Register = Console.ReadLine();
            Console.WriteLine("Inform the Wage of the Dentist: ");
            try
            {
                Wage = Convert.ToDouble(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid wage.");
            }

            DentistController.UpdateDentist(
                Id,
                Name,
                Cpf,
                Phone,
                Mail,
                Passwd,
                Register,
                Wage
            );
        }

        public static void DeleteDentist()
        {
            int Id = 0;

            GetAllDentists();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Dentist: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }

            DentistController.DeleteDentist(Id);
        }

        public static void GetAllDentists()
        {
            foreach (Dentist dentist in DentistController.GetAllDentists())
            {
                Console.WriteLine(dentist);
            }
        }
    }
}