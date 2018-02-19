using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class FileParserTXT : FileParserBase
    {
        public FileParserTXT(FileManager manager) : base(manager)
        {

        }
        public override Person GetPerson()
        {
            var lines = FileManager.GetLines(); 
            return GetPersonFromMultipleNameValues(lines[0], lines[1]);
        }
        private Person GetPersonFromMultipleNameValues(string nameValue1, string nameValue2)
        {
            Person person = new Person();
            SetProperty(person, nameValue1);
            SetProperty(person, nameValue2);
            return person;
        }

    }
}
