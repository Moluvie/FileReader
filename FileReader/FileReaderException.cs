using System;
using System.Collections.Generic;
using System.Text;

namespace FileReader
{    
    public class FileReaderException : Exception
    {
        public FileReaderException(string message) : base(message)
        {
        }

       
       public static class Program
       {
            public static void ThrowInsufficientParameters() => 
                 throw new FileReaderException($@"Parameters need to be filename and command. Example:  c:\MyFiles\Joe.json /c.  Commands: /c Console  /d Database  /e Email");
            public static void ThrowFileNotFound() =>
                 throw new FileReaderException($@"File not found or path is invalid.");
        }

        public static class ArgumentConverter
        {
            public static void ThrowCommandNotValid(string command) =>
                 throw new FileReaderException($@"{command} is invalid.  Valid Commands: /c Console  /d Database  /e Email");
        }

        public static class FileManager
        {
            public static void ThrowTimeout(int timeout) =>
                throw new FileReaderException($"{nameof(FileManager)} read failed.  Timeout after {timeout} milliseconds.");
        }

        public static class FileParserBase
        {
            public static void ThrowNameValueParseFailed(string nameValue) =>
                throw new FileReaderException($"{nameof(FileParserBase)} failed. '{nameValue}' not parsable.");
            public static void ThrowPropertyNameNotFound(string name) =>
                throw new FileReaderException($"{nameof(FileParserBase)} failed. '{name}' property not found.");
        }

    }
}
