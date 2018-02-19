using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{
    public class FileParserFactory : FileParserBase
    {
        public FileParserType Type { get; private set; }

        public FileParserFactory(FileManager manager, FileParserType type) : base(manager)
        {
            Type = type; 
        }

        public FileParserBase GetParser()
        {
            switch(Type)
            {
                case FileParserType.TXT:
                    return new FileParserTXT(FileManager); 
                case FileParserType.CSV:
                    return new FileParserCSV(FileManager);
                case FileParserType.JSON:
                    return new FileParserJSON(FileManager);
                default:
                    throw new NotImplementedException(); 
            }
        }

        public override Person GetPerson()
        {
            return GetParser().GetPerson(); 
        }

    }
}
