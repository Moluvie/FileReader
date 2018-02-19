using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class FileParserCSV : FileParserBase
    {
        public FileParserCSV(FileManager manager) : base(manager)
        {

        }
        public override Person GetPerson()
        {
            var line = FileManager.GetLines()[0]; // first line 
            return GetPersonFromLine(line); 
        }        
        private Person GetPersonFromLine(string line)
        {
            Person person = new Person();
            foreach (var nameValue in line.Split(','))
            {
                SetProperty(person, nameValue);
            }
            return person;
        }
        
    }
}
