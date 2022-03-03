using System;
using Models;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Controllers
{
    public class ProcedureController
    {
        // Create a new Procedure.
        public static Procedure CreateProcedure(string Description, double Price, int SchedulerId)
        {
            if(string.IsNullOrEmpty(Description))
            {
                throw new Exception("Invalid description.");
            }

            Regex rxPrice = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxPrice.IsMatch(Convert.ToString(Price)))
            {
                throw new Exception("Invalid price.");
            }
            
            SchedullerController.GetScheduler(SchedulerId);

            return new Procedure(Description, Price, SchedulerId);
        }

        // Alter a existing Procedure.
        public static Procedure UpdateProcedure(
            int Id,
            string Description,
            double Price
        )
        {
            Procedure procedure = GetProcedure(Id);

            if (!String.IsNullOrEmpty(Description))
            {
                procedure.Description = Description;
            }

            Regex rxPrice = new Regex("(?!0$)[0-9]+(?:\\.[0-9]+)?");
            if (!rxPrice.IsMatch(Convert.ToString(Price)))
            {
                throw new Exception("Invalid price.");
            }

            return procedure;
        }

        // Delete Procedure by Id.
        public static Procedure DeleteProcedure(int Id)
        {
            try
            {
                Procedure procedure = GetProcedure(Id);
                Procedure.RemoveProcedure(procedure);
                return procedure;
            }
            catch
            {
                throw new Exception("An error has occurred.");
            }
        }

        // Get all Procedures.
        public static List<Procedure> GetAllProcedures()
        {
            return Procedure.GetProcedures();
        }

        // Get Procedure by Id.
        public static Procedure GetProcedure(int Id)
        {
            Procedure procedure = (
                from Procedure in Procedure.GetProcedures()
                    where Procedure.Id == Id
                    select Procedure
            ).First();

            if (procedure == null)
            {
                throw new Exception("Procedure don't found.");
            }

            return procedure;
        }
    }
}