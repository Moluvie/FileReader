using System;
using System.IO;

namespace FileReader
{
    class Program
    {
        
        static void Main(string[] args)
        {
            try
            {
                var arguments = GetArguments(args);

                Person person = GetPersonFromFile(arguments.Path);
                var output = GetCommandOutput(person, arguments.Command);

                Console.Write(output);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error:");
                Console.Write(ex.Message); 
            }
        }        

        static (string Path, string Command) GetArguments(string[] args)
        {
            if (args.Length < 2)
                FileReaderException.Program.ThrowInsufficientParameters();

            var path = args[0];
            var command = args[1];

            if (!File.Exists(path))
                FileReaderException.Program.ThrowFileNotFound();

            return (path, command); 
        }

        static Person GetPersonFromFile(string path)
        {
            var fileManager = new FileManager(path);
            var parserType = ArgumentsConverter.GetFileParserType(path);
            var parser = new FileParserFactory(fileManager, parserType);
            return parser.GetPerson();
        }

        static string GetCommandOutput(Person person, string command)
        {
            var processType = ArgumentsConverter.GetPersonProcessType(command);

            switch (processType)
            {
                case PersonProcessType.Console:
                    return new PersonProcessConsole(person).GetOutput();
                case PersonProcessType.Database:
                    return new PersonProcessDatabase(person).GetInputSql("PersonTable") + "\n"; // add newline for output
                case PersonProcessType.Email:
                    return new PersonProcessEmail(person).GetBody();
                default:
                    throw new NotImplementedException(); 
            }

        }

    }
}
