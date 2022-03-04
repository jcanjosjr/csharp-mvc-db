using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Procedure
    {
        public int Id { set; get; }
        [Required]
        public string Description { set; get; }
        [Required]
        public double Price { set; get; }
        public int SchedulerId { set; get; }
        public Scheduler Scheduler { get; }

        // The public constructor, will be call when Procedure will instantiated.
        public Procedure() { }
        public Procedure(
            string Description,
            double Price,
            int SchedulerId
        ) 
        {
            this.Description = Description;
            this.Price = Price;

            this.SchedulerId = SchedulerId;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            // this.Scheduler = Scheduler.GetSchedulers().Find(Scheduler => Scheduler.Id == SchedulerId);
                        
            // Add a Procedure in a List of Procedures on Database.
            Context db = new Context();
            db.Procedures.Add(this);
            db.SaveChanges();
            // Add Procedure in a list of associate Schedulers.
            Scheduler.AddProcedure(this);
        }

        // The method ToString of Procedure.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Description: {this.Description}."
                + $"\n - Price: ${this.Price}"
                + $"\n - Scheduler ID: {this.Scheduler.Id}"
                + $"\n - Scheduler Date: {this.Scheduler.Date}";
        }

        // Method to check equality of two Procedure Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Procedure.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Procedure iterable = (Procedure) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Procedures.
        public static List<Procedure> GetProcedures()
        {
            Context db = new Context();
            return (from Procedure in db.Procedures select Procedure).ToList();
        }

        // Method remove a Object Procedure from list of Procedures.
        public static void RemoveProcedure(Procedure procedure)
        {
            Context db = new Context();
            db.Procedures.Remove(procedure);
        }
    }
}