using System;
using Models;
using Controllers;

namespace Views
{
    public class PatientView
    {
        public static void CreatePatient()
        {
            DateTime BirthDate = DateTime.Now;
            Console.WriteLine("Inform the name of Patient: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Inform the CPF of Patient: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Inform the phone of Patient: ");
            string Phone = Console.ReadLine();
            Console.WriteLine("Inform the Mail of Patient: ");
            string Mail = Console.ReadLine();
            Console.WriteLine("Inform the password of Patient: ");
            string Passwd = Console.ReadLine();
            Console.WriteLine("Inform the birth date of Patient: ");
            try
            {
                BirthDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid birth date.");
            }

            PatientController.CreatePatient(
                Name,
                Cpf,
                Phone,
                Mail,
                Passwd,
                BirthDate
            );
        }

        public static void UpdatePatient()
        {
            int Id = 0;
            DateTime BirthDate = DateTime.Now;

            GetAllPatients();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Patient: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            Console.WriteLine("Inform the name of Patient: ");
            string Name = Console.ReadLine();
            Console.WriteLine("Inform the CPF of Patient: ");
            string Cpf = Console.ReadLine();
            Console.WriteLine("Inform the phone of Patient: ");
            string Phone = Console.ReadLine();
            Console.WriteLine("Inform the Mail of Patient: ");
            string Mail = Console.ReadLine();
            Console.WriteLine("Inform the password of Patient: ");
            string Passwd = Console.ReadLine();
            Console.WriteLine("Inform the birth date of Patient: ");
            try
            {
                BirthDate = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid birth date.");
            }

            PatientController.UpdatePatient(
                Id,
                Name,
                Cpf,
                Phone,
                Mail,
                Passwd,
                BirthDate
            );
        }

        public static void DeletePatiet()
        {
            int Id = 0;

            GetAllPatients();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Patient: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }

            PatientController.DeletePatient(Id);
        }

        public static void GetAllPatients()
        {
            foreach (Patient patient in PatientController.GetAllPatients())
            {
                Console.WriteLine(patient);
            }
        }
    }
}