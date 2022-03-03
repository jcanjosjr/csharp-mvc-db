using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Dentist : Person
    {
        // Attributes from the class os Dentist.
        public int IdDentist { set; get; }
        public string Register { set; get; }
        public double Wage { set; get; }
        public int IdSpeciality { set; get; }
        public Speciality Speciality { get; }

        // The public constructor, will be call when Dentist will instantiated.
        public Dentist(
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            string Register,
            double Wage,
            int IdSpeciality
        ) : base(Name, Cpf, Phone, Mail, Passwd)
        {
            this.Id = Id;
            this.IdDentist = IdDentist;
            this.Register = Register;
            this.Wage = Wage;

            this.IdSpeciality = IdSpeciality;
            // Check and find the Patient with the Same Id of the instantiated on 
            // this object, and gives to the attribute the Object found.
            this.Speciality = Speciality.GetSpecialities().Find(Speciality => Speciality.Id == IdSpeciality);

            // Add a Dentist in a List of Dentists Database.
            Context db = new Context();
            db.Dentists.Add(this);
            db.SaveChanges();
        }
        
        // The method ToString of Dentist, the base.ToString() is like a Super.
        public override string ToString()
        {
            return base.ToString()
                + $"\n + Register: {this.Register}"
                + $"\n + Wage: {this.Wage}"
                + $"\n * Descript of Speciality: {this.Speciality.Description}"
                + $"\n * Details of Speciality: {this.Speciality.Detail}";
        }

        // Method to check equality of two Dentist Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Dentist.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Dentist iterable = (Dentist) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Dentists.
        public static List<Dentist> GetDentists()
        {
            Context db = new Context();
            return (from Dentist in db.Dentists select Dentist).ToList();
        }

        // Method remove a Obeject Dentist from list of Dentists.
        public static void RemoveDentist(Dentist dentist)
        {
            Context db = new Context();
            db.Dentists.Remove(dentist);
        }
    }
}