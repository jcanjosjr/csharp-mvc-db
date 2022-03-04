using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Speciality
    {
        public int Id { set; get; }
        public string Description { set; get; }
        public string Detail { set; get; }

        // The public constructor, will be call when Procedure will instantiated.
        public Speciality() { }
        public Speciality(
            string Description,
            string Detail
        )
        {
            this.Id = Id;
            this.Description = Description;
            this.Detail = Detail;

            // Add a Speciality in a List of Specialities on Database.
            Context db = new Context();
            db.Specialities.Add(this);
            db.SaveChanges();
        }

        // The method ToString of Speciality.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Description: {this.Description}."
                + $"\n - Detail: {this.Detail}.";
        }

        // Method to check equality of two Speciality Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Speciality.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Speciality iterable = (Speciality) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Procedures.
        public static List<Speciality> GetSpecialities()
        {
            Context db = new Context();
            return (from Speciality in db.Specialities select Speciality).ToList();
        }

        // Method remove a Object Speciality from list of Specialities.
        public static void RemoveSpeciality(Speciality speciality)
        {
            Context db = new Context();
            db.Specialities.Remove(speciality);
        }
    }
}