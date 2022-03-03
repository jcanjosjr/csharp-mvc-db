namespace Models
{
    public class Auth
    {
        // Attributs of the Class Auth(entication)
        public static Patient Patient;
        public static Dentist Dentist;
        // This Attribute, is check if the Login is succesffully.
        public static bool IsLogeed;

        // Method to try effetuate a Login.
        public static void PatientLogin(string Mail, string Passwd)
        {
            // Check for a patient in a list of patients, and find
            // the patient with the same mail and crypt passwd.
            Patient patient = Patient.GetPatients()
                .Find(Patient => Patient.Mail == Mail && BCrypt.Net.BCrypt.Verify(Passwd, Patient.Passwd));
        

            if (patient != null)
            {
                IsLogeed = true;
                Patient = patient;
                Dentist = null;
            }
            else
            {
                Logout();
            }
        }

        public static void DentistLogin(string Mail, string Passwd)
        {
            // Check for a patient in a list of patients, and find
            // the patient with the same mail and crypt passwd.
            Dentist dentist = Dentist.GetDentists()
                .Find(Dentist => Dentist.Mail == Mail && BCrypt.Net.BCrypt.Verify(Passwd, Dentist.Passwd));
        

            if (dentist != null)
            {
                IsLogeed = true;
                Dentist = dentist;
                Patient = null;
            }
            else
            {
                Logout();
            }
        }

        // Logout anyone with invalid login.
        public static void Logout()
        {
            IsLogeed = false;
            Dentist = null;
            Patient = null;
        }
    }
}