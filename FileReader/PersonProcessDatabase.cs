using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class PersonProcessDatabase 
    {
        public Person Person { get; private set; }
        public PersonProcessDatabase(Person person)
        {
            Person = person;
        }

        public void Insert()
        {
            throw new NotImplementedException();
        }
        public string GetInputSql(string tablename)
        {
            return $"INSERT INTO {tablename} (FirstName, LastName) VALUES ('{Person.FirstName}', '{Person.LastName}')";
        }
    }
}
