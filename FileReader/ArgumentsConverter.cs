using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FileReader
{
    public static class ArgumentsConverter
    {
        public static FileParserType GetFileParserType(string path)
        {
            switch (Path.GetExtension(path).ToLower())
            {
                case ".csv":
                    return FileParserType.CSV;
                case ".txt":
                    return FileParserType.TXT;
                case ".json":
                    return FileParserType.JSON;
                default:
                    throw new NotImplementedException();
            }
        }

        public static PersonProcessType GetPersonProcessType(string command)
        {
            switch (command)
            {
                case "/c":
                    return PersonProcessType.Console;
                case "/d":
                    return PersonProcessType.Database;
                case "/e":
                    return PersonProcessType.Email;
                default:
                    throw new FileReaderException($@"{command} is invalid.  Valid Commands: /c Console  /d Database  /e Email");
            }
        }
    }
}
