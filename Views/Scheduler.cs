using System;
using Models;
using Controllers;

namespace Views
{
    public class SchedulerView
    {
        public static void CreateScheduler()
        {
            int IdPatient;
            int IdDentist;
            int IdRoom;
            int IdProcedure;
            DateTime Date = DateTime.Now;
            Console.WriteLine("Inform ID from Patient to Scheduler: ");
            try
            {
                IdPatient = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }
            Console.WriteLine("Inform ID from Dentist to Scheduler: ");
            try
            {
                IdDentist = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }
            Console.WriteLine("Inform ID from Room to Scheduler:: ");
            try
            {
                IdRoom = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }
            Console.WriteLine("Inform ID from Procedure to Scheduler:: ");
            try
            {
                IdProcedure = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }

            SchedullerController.CreateScheduler(
                IdPatient,
                IdDentist,
                IdRoom,
                Date
            );

        }

        public static void UpdateScheduler()
        {
            int Id = 0;

            GetAllSchedulers();
            Console.WriteLine("+-------------------------------+");
            DateTime Date = DateTime.Now;
            Console.WriteLine("Inform the ID of Scheduler: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid ID.");
            }
            Console.WriteLine("Inform the date of Scheduler: ");
            try
            {
                Date = Convert.ToDateTime(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Date.");
            }

            SchedullerController.UpdateScheduler(
                Id,
                Date
            );

        }

        public static void DeleteScheduler()
        {
            int Id = 0;

            GetAllSchedulers();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Scheduler: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }
            
            SchedullerController.DeleteScheduler(Id);
        }

        public static void GetPatientScheduler(int IdPatient)
        {
            foreach (Scheduler scheduler in SchedullerController.GetSchedulerByPatient(IdPatient))
            {
                Console.WriteLine(scheduler);
            }
        }

        public static void GetAllSchedulers()
        {
            foreach (Scheduler scheduler in SchedullerController.GetAllSchedulers())
            {
                Console.WriteLine(scheduler);
            }
        }

        public static void ConfirmScheduler()
        {
            GetAllSchedulers();

            int Id = 0;
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Scheduler: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            Scheduler scheduler = SchedullerController.ConfirmScheduler(Id);

            Console.WriteLine("Confirmed: ");
            Console.WriteLine(scheduler);
        }
    }
}