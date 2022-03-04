using System;
using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Patient : Person
    {
        // Attributes for the Patient.
        private static List<Patient> Patients = new List<Patient>();
        public DateTime BirthDate { set; get; }

        // The public constructor, will be call when Patient will instantiated.
        public Patient() { }

        public Patient(
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            DateTime BirthDate
        ) : base(Name, Cpf, Phone, Mail, Passwd)
        {
            this.BirthDate = BirthDate;

            // Add a Patient in a List of Patients.
            Context db = new Context();
            db.Patients.Add(this);
            db.SaveChanges();
        }

        // The method ToString of Patient, the base.ToString() is like a Super.
        public override string ToString()
        {
            return base.ToString()
                + $"\n + Birth Date: {this.BirthDate}";
        }

        // Method to check equality of two Patients Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Patient.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Patient iterable = (Patient) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Patients.
        public static List<Patient> GetPatients()
        {
            Context db = new Context();
            return (from Patient in db.Patients select Patient).ToList();
        }

        // Method remove a Obeject Patient from list of Patients.
        public static void RemovePatient(Patient patient)
        {
            Context db = new Context();
            db.Patients.Remove(patient);
        }
    }
}