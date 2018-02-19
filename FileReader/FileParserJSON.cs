using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class FileParserJSON : FileParserBase
    {
        public FileParserJSON(FileManager manager) : base(manager)
        {

        }
        public override Person GetPerson()
        {
            return JsonConvert.DeserializeObject<Person>(FileManager.GetAllText()); 
        }
    }
}
