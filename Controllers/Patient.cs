using System;
using Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class PatientController
    {
        // Create a new Patient.
        public static Patient CreatePatient(
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            DateTime BirthDate
        )
        {
            if (String.IsNullOrEmpty(Name))
            {
                throw new Exception("Invalid name.");
            }

            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (String.IsNullOrEmpty(Cpf) || !rx.IsMatch(Cpf))
            {
                throw new Exception("Cpf inválido");
            }

            if (String.IsNullOrEmpty(Phone))
            {
                throw new Exception("Invalid phone number.");
            }

            if (String.IsNullOrEmpty(Mail))
            {
                throw new Exception("Invalid e-mail.");
            }

            if (String.IsNullOrEmpty(Passwd))
            {
                throw new Exception("Invalid password.");
            }
            else
            {
                // Stock the passwd encrypted.
                Passwd = BCrypt.Net.BCrypt.HashPassword(Passwd);
            }

            if (BirthDate == null || BirthDate > DateTime.Now)
            {
                throw new Exception("Invalid birth date.");
            }

            return new Patient(Name, Cpf, Phone, Mail, Passwd, BirthDate);
        }

        // Alter a existing Patient.
        public static Patient UpdatePatient(
            int Id,
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            DateTime BirthDate
        )
        {
            Patient patient = GetPatient(Id);

            if (!String.IsNullOrEmpty(Name))
            {
                patient.Name = Name;
            }

            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (!String.IsNullOrEmpty(Cpf) && rx.IsMatch(Cpf))
            {
                patient.Cpf = Cpf;
            }

            if (!String.IsNullOrEmpty(Phone))
            {
                patient.Phone = Phone;
            }

            if (!String.IsNullOrEmpty(Mail))
            {
                patient.Mail = Mail;
            }

            if (!String.IsNullOrEmpty(Passwd))
            {
                patient.Passwd = BCrypt.Net.BCrypt.HashPassword(Passwd);
            }
            else
            {
                Passwd = BCrypt.Net.BCrypt.HashPassword(Passwd);
            }

            if (BirthDate == null || BirthDate > DateTime.Now)
            {
                throw new Exception("Invalid birth date.");
            }
            else
            {
                patient.BirthDate = BirthDate;
            }

            return patient;
        }

        // Delete Patient by Id.
        public static Patient DeletePatient(int Id)
        {
            try
            {
                Patient patient = GetPatient(Id);
                Patient.RemovePatient(patient);
                return patient;
            }
            catch
            {
                throw new Exception("An error has occurred.");
            }
        }

        // Get all Patients.
        public static List<Patient> GetAllPatients()
        {
            return Patient.GetPatients();
        }

        // Get Patient by Id.
        public static Patient GetPatient(int Id)
        {
            Patient patient = (
                from Patient in Patient.GetPatients()
                    where Patient.Id == Id
                    select Patient
            ).First();

            if (patient == null)
            {
                throw new Exception("Patient don't found.");
            }

            return patient;
        }
    }

}