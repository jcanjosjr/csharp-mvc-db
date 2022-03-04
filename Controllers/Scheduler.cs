using System;
using Models;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class SchedullerController
    {
        // Create a new Scheduler.
        public static Scheduler CreateScheduler(
            int PatientId,
            int DentistId,
            int RoomId,
            DateTime Date
        )
        {
            PatientController.GetPatient(PatientId);
            DentistController.GetDentist(DentistId);
            RoomController.GetRoom(RoomId);

            if(Date == null || Date <= DateTime.Now)
            {
                throw new Exception("Date can't be in the past.");
            }

            if(GetSchedulerConflict(0, DentistId, RoomId, Date))
            {
                throw new Exception("Sorry, we already have an Scheduler at this time.");
            }

            return new Scheduler(PatientId, DentistId, RoomId, Date);
        }

        // Check if have a Scheduler in the same Time and in the same Room, and with same Dentist
        private static bool GetSchedulerConflict(
            int ActualId,
            int DentistId,
            int RoomId,
            DateTime Date
        )
        {
            // Define a collection called schedulers.
            IEnumerable<Scheduler> schedulers =
                // For each Scheduler in Schedulers.
                from Scheduler in Scheduler.GetSchedulers()
                    // Where the date of scheduler is equals date of the parameter receive.
                    where Scheduler.Date == Date
                        // and DentistID is equals of the parameter receive.
                        && Scheduler.DentistId == DentistId
                        // and RoomID is equals of the parameter receive.
                        && Scheduler.RoomId == RoomId
                        // and Scheduler Id is different of the parameter receive.
                        && Scheduler.Id != ActualId
                    // select this.
                    select Scheduler;
                
                // Return the first Scheduler founds in a collection read-only.
                return schedulers.Count() > 0; 
        }

        // Alter a existing Scheduler.
        public static Scheduler UpdateScheduler(
            int Id,
            DateTime Date
        )
        {
            Scheduler scheduler = GetScheduler(Id);

            if (Date == null | Date < DateTime.Now)
            {
                throw new Exception("Invalid date.");
            }

            // Check if have a conflict on scheduler date.
            if (GetSchedulerConflict(
                scheduler.Id,
                scheduler.DentistId,
                scheduler.RoomId,
                Date
            ))
            {
                throw new Exception("Sorry, we already have an Scheduler at this time.");
            }

            scheduler.Date = Date;
            
            return scheduler;
        }

        // Delete a existing Scheduler.
        public static Scheduler DeleteScheduler(int Id)
        {
            try
            {
                Scheduler scheduler = GetScheduler(Id);
                Scheduler.RemoveScheduler(scheduler);
                return scheduler;
            }
            catch
            {
                throw new Exception("An error has occurred.");
            }
        }

        // Get all Scheduler in a list of Schedulers.
        public static List<Scheduler> GetAllSchedulers()
        {
            return Scheduler.GetSchedulers();
        }  

        // Return a Scheduler by Id.
        public static Scheduler GetScheduler(int Id)
        {
            Scheduler scheduler = (
                from Scheduler in Scheduler.GetSchedulers()
                    where Scheduler.Id == Id
                    select Scheduler
            ).First();

            if (scheduler == null)
            {
                throw new Exception("Scheduler don't found.");
            }

            return scheduler;
        }

        // Get the Scheduler by Pacient Id.
        public static IEnumerable<Scheduler> GetSchedulerByPatient(int PatientId)
        {
            try
            {
                return Scheduler.GetSchedulers().Where(Scheduler => Scheduler.PatientId == PatientId);
            }
            catch
            {
                throw new Exception("Patient don't found, or don't have schedulers.");
            }
        }

        // Confirm Scheduler.
        public static Scheduler ConfirmScheduler(int Id)
        {
            Scheduler scheduler = GetScheduler(Id);

            if (scheduler.PatientId != Auth.Patient.Id)
            {
                throw new Exception("Scheduler don't confimed, authentication errors occurs.");
            }

            scheduler.Confirm = true;

            return scheduler;
        }
    }
}
