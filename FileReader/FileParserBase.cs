using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public abstract class FileParserBase
    {
        protected FileManager FileManager; 
        public FileParserBase(FileManager manager)
        {
            FileManager = manager;
        }
        public abstract Person GetPerson();

        protected void SetProperty(Person person, string nameValue) // could use reflection
        {
            var parts = nameValue.Split(':');
            if (parts.Length != 2)
                FileReaderException.FileParserBase.ThrowNameValueParseFailed(nameValue); 

            var name = parts[0].Trim();
            var value = parts[1].Trim();

            switch (name)
            {
                case "FirstName":
                    person.FirstName = value;
                    break;
                case "LastName":
                    person.LastName = value;
                    break;
                default:
                    FileReaderException.FileParserBase.ThrowPropertyNameNotFound(name);
                    break;
            }
        }

    }
}
