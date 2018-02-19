using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class PersonProcessConsole 
    {
        public Person Person { get; private set; }
        public PersonProcessConsole(Person person)
        {
            Person = person;
        }
        public void WriteOutput()
        {
            Console.Write(GetOutput()); 
        }
        public string GetOutput()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(Person.FirstName);
            sb.AppendLine(Person.LastName);
            return sb.ToString();
        }
    }
}
