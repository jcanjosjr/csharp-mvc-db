using System;
using Models;
using Controllers;

namespace Views
{
    public class SpecialityView
    {
        public static void CreateSpeciality()
        {
            Console.WriteLine("Inform the description of Speciality: ");
            string Description = Console.ReadLine();
            Console.WriteLine("Inform details about the Speciality: ");
            string Detail = Console.ReadLine();

            SpecialityController.CreateSpeciality(Description, Detail);
        }

        public static void UpdateSpeciality()
        {
            int Id = 0;

            GetAllSpecialities();

            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Speciality: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            Console.WriteLine("Inform the description of Specialisty: ");
            string Description = Console.ReadLine();
            Console.WriteLine("Inform the details of Specialisty: ");
            string Detail = Console.ReadLine();

            SpecialityController.UpdateSpeciality(Id, Description, Detail);
        }

        public static void DeleteSpeciliaty()
        {
            int Id = 0;

            GetAllSpecialities();

            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Speciality: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }

            SpecialityController.DeleteSpeciliaty(Id);
        }

        public static void GetAllSpecialities()
        {
            foreach (Speciality speciality in SpecialityController.GetAllSpecialities())
            {
                Console.WriteLine(speciality);
            }
        }
    }
}