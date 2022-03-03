using System;
using Models;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class SpecialityController
    {
        // Create e new Speciliaty.
        public static Speciality CreateSpeciality(string Description, string Detail)
        {
            if (String.IsNullOrEmpty(Description))
            {
                throw new Exception("Invalid description.");
            }

            if (String.IsNullOrEmpty(Detail))
            {
                throw new Exception("Invalid details");
            }

            return new Speciality(Description, Detail);
        }

        // Alter a existing Specialist.
        public static Speciality UpdateSpeciality(
            int Id,
            string Description,
            string Detail
        )
        {
            Speciality speciality = GetSpeciliaty(Id);

            if (!String.IsNullOrEmpty(Description))
            {
                speciality.Description = Description;
            }
            
            if (!String.IsNullOrEmpty(Detail))
            {
                speciality.Detail = Detail;
            }

            return speciality;
        }

        // Delete Speciliaty by Id.
        public static Speciality DeleteSpeciliaty(int Id)
        {
            try
            {
                Speciality speciality = GetSpeciliaty(Id);
                Speciality.RemoveSpeciality(speciality);
                return speciality;
            }
            catch
            {
                throw new Exception("An error has occurred.");
            }
        }

        // Get all Specialities.
        public static List<Speciality> GetAllSpecialities()
        {
            return Speciality.GetSpecialities();
        }

        // Get Speciliaty by Id.
        public static Speciality GetSpeciliaty(int Id)
        {
            Speciality speciality = (
                from Speciality in Speciality.GetSpecialities()
                    where Speciality.Id == Id
                    select Speciality
            ).First();

            if (speciality == null)
            {
                throw new Exception("Speciality don't found.");
            }

            return speciality;
        } 
    }
}
