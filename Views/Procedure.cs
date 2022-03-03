using System;
using Models;
using Controllers;

namespace Views
{
    public class ProcedureView
    {
        public static void CreateProcedure()
        {
            Console.WriteLine("Inform the description of Procedure: ");
            string Description = Console.ReadLine();
            Console.WriteLine("Inform the Price of Procedure: ");
            double Price = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine("Inform the Scheduler ID associate with this Procedure: ");
            int SchedulerId = Convert.ToInt32(Console.ReadLine());

            ProcedureController.CreateProcedure(Description, Price, SchedulerId);
        }

        public static void UpdateProcedure()
        {
            int Id = 0;

            GetAllProcedures();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Procedure: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            Console.WriteLine("Inform the description of Procedure: ");
            string Description = Console.ReadLine();
            Console.WriteLine("Inform the Price of Procedure: ");
            double Price = Convert.ToSingle(Console.ReadLine());

            ProcedureController.UpdateProcedure(Id, Description, Price);
        }

        public static void DeleteProcedure()
        {
            int Id = 0;

            GetAllProcedures();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Procedure: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }

            ProcedureController.DeleteProcedure(Id);
        }

        public static void GetAllProcedures()
        {
            foreach (Procedure procedure in ProcedureController.GetAllProcedures())
            {
                Console.WriteLine(procedure);
            }
        }
    }
}