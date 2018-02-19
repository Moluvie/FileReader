using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class PersonProcessEmail 
    {
        public Person Person { get; private set; }
        public PersonProcessEmail(Person person)
        {
            Person = person;
        }

        public void SendEmail()
        {
            throw new NotImplementedException(); 
        }
        public string GetBody()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Person.FirstName);
            sb.AppendLine(Person.LastName);
            return sb.ToString();
        }
    }
}
