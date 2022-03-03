namespace Models
{
    public class Person
    {
        // Attributes from class Person.
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string Passwd { get; set; }

        // Public Method Constructor for the Class Person.
        public Person(
            string Name,
            string Cpf,
            string Phone,
            string Mail,
            string Passwd
        )
        {
            this.Id++;
            this.Name = Name;
            this.Cpf = Cpf;
            this.Mail = Mail;
            this.Passwd = Passwd;
        }

        // Method ToString from the Class Person.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Name: {this.Name}"
                + $"\n - CPF: {this.Cpf}"
                + $"\n - Phone: {this.Phone}"
                + $"\n - Mail: {this.Mail}";
        }

        // Method to check equality of two Person Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Person.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Person iterable = (Person) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}