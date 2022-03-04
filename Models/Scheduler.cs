using System;
using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Scheduler
    {
        public int Id { set; get; }
        public int PatientId { set; get; }
        public Patient Patient { get; }
        public int DentistId { set; get; }
        public Dentist Dentist { set; get; }
        public int RoomId { set; get; }
        public Room Room { get; }
        public static List<Procedure> Procedures = new List<Procedure>();
        public DateTime Date { set; get; }
        public bool Confirm { set; get; }

        // The public constructor, will be call when Room will instantiated.
        public Scheduler() { }
        public Scheduler(
            int PatientId,
            int DentistId,
            int RoomId,
            DateTime Date
        ) 
        {
            this.Id = Id;
        
            this.PatientId = PatientId;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            // this.Patient = Patient.GetPatients().Find(Patient => Patient.Id == PatientId);

            this.DentistId = DentistId;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            // this.Dentist = Dentist.GetDentists().Find(Dentist => Dentist.Id == DentistId);

            this.RoomId = RoomId;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            // this.Room = Room.GetRooms().Find(Room => Room.Id == RoomId);

            this.Date = Date;

            // Add a Scheduler in a List of Schedulers on Database.
            Context db = new Context();
            db.Schedulers.Add(this);
            db.SaveChanges();
        }

        // The method ToString of Scheduler.
        public override string ToString()
        {
            // To calculate the Total Price paid.
            double totalPrice = 0;

            string printScheduler = $"ID: {this.Id}"
                + $"\n - Patient: {this.Patient.Name}"
                + $"\n - Dentist: {this.Dentist.Name}"
                + $"\n - Room: {this.Room.Number}"
                + $"\n - Date: {this.Date}"
                + $"\n - Scheduled: {(this.Confirm ? "Confirm scheduler." : "Don't scheduleded.")}";

                // This, walks into a List of Procedures, and return all itens, in String.
                foreach (Procedure item in Procedures)
                {
                    printScheduler += $"\nProcedure ID: {item.Id}"
                            + $"\n - Description: {item.Description}."
                            + $"\n - Price: ${item.Price}";
                    
                    totalPrice += item.Price;
                }

                printScheduler += $"\n^ Total: ${totalPrice}";

                return printScheduler;
        }

        // Method to check equality of two Scheduler Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Scheduler.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Scheduler iterable = (Scheduler) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Schedulers.
        public static List<Scheduler> GetSchedulers()
        {
            Context db = new Context();
            return (from Scheduler in db.Schedulers select Scheduler).ToList();
        }

        // Method remove a Object Scheduler from list of Schedulers.
        public static void RemoveScheduler(Scheduler scheduler)
        {
            Context db = new Context();
            db.Schedulers.Remove(scheduler);
        }

        // Method to Add Procedure into Scheduler.
        public static void AddProcedure(Procedure procedure)
        {
            Procedures.Add(procedure);
        }
    }
}
