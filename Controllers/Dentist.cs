using System;
using Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class DentistController
    {
        // Create a new Dentist.
        public static Dentist CreateDentist(
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            string Register,
            double Wage,
            int IdSpeciality
        )
        {
            SpecialityController.GetSpeciliaty(IdSpeciality);
            
            if (String.IsNullOrEmpty(Name))
            {
                throw new Exception("Invalid name.");
            }

            Regex rxCpf = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (String.IsNullOrEmpty(Cpf) || !rxCpf.IsMatch(Cpf))
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

            if (String.IsNullOrEmpty(Register))
            {
                throw new Exception("Invalid register.");
            }

            Regex rxWage = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxWage.IsMatch(Convert.ToString(Wage)))
            {
                throw new Exception("Invalid wage.");
            }

            return new Dentist(Name, Cpf, Phone, Mail, Passwd, Register, Wage, IdSpeciality);
        }

        // Alter a existing Dentist, without alter you're speciliaty.
        public static Dentist UpdateDentist(
            int Id,
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd,
            string Register,
            double Wage
        )
        {
            Dentist dentist = GetDentist(Id);

            if (!String.IsNullOrEmpty(Name))
            {
                dentist.Name = Name;
            }

            Regex rx = new Regex("(^\\d{3}\\.\\d{3}\\.\\d{3}\\-\\d{2}$)|(^\\d{2}\\.\\d{3}\\.\\d{3}\\/\\d{4}\\-\\d{2}$)");
            if (!String.IsNullOrEmpty(Cpf) || rx.IsMatch(Cpf))
            {
                dentist.Cpf = Cpf;
            }

            if (!String.IsNullOrEmpty(Phone))
            {
                dentist.Phone = Phone;
            }

            if (!String.IsNullOrEmpty(Mail))
            {
                dentist.Mail = Mail;
            }

            if (!String.IsNullOrEmpty(Passwd))
            {
                dentist.Passwd = BCrypt.Net.BCrypt.HashPassword(Passwd);
            }
            else
            {
                Passwd = BCrypt.Net.BCrypt.HashPassword(Passwd);
            }

            Regex rxWage = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxWage.IsMatch(Convert.ToString(Wage)))
            {
                throw new Exception("Invalid wage.");
            }

            return dentist;
        }

        // Delete Dentist by Id.
        public static Dentist DeleteDentist(int Id)
        {
            try
            {
                Dentist dentist = GetDentist(Id);
                Dentist.RemoveDentist(dentist);
                return dentist;
            }
            catch
            {
                throw new Exception("An error has occurred.");
            }
        }

        // Get all Dentists.
        public static List<Dentist> GetAllDentists()
        {
            return Dentist.GetDentists();
        }

        // Get Dentist by Id.
        public static Dentist GetDentist(int Id)
        {
            Dentist dentist = (
                from Dentist in Dentist.GetDentists()
                    where Dentist.Id == Id
                    select Dentist
            ).First();

            if (dentist == null)
            {
                throw new Exception("Dentist don't found.");
            }

            return dentist;
        }
    }

}