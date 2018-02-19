using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FileReader
{
    public class FileManager
    {
        private int _timeout = 2000;
        private string _path;    

        public FileManager(string path)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
        }
        public FileManager(string path, int timeout)
        {
            _path = path ?? throw new ArgumentNullException(nameof(path));
            if (timeout < 0)
                throw new ArgumentOutOfRangeException(nameof(timeout), "timeout must be greater than zero.");
            _timeout = timeout;
        }

        public string[] GetLines()
        {
            return GetLinesAsync().Result; 
        }
        public async Task<string[]> GetLinesAsync()
        {
            var readAsync = Task.Run(
                () => File.ReadAllLines(_path)
                );           

            if (!readAsync.Wait(_timeout))
                FileReaderException.FileManager.ThrowTimeout(_timeout);

            return await readAsync;
        }
        public string GetAllText()
        {
            return GetAllTextAsync().Result; 
        }
        public async Task<string> GetAllTextAsync()
        {
            var readAsync = Task.Run(
                () => File.ReadAllText(_path)
                );

            if (!readAsync.Wait(_timeout))
                FileReaderException.FileManager.ThrowTimeout(_timeout);

            return await readAsync;
        }
    }
}
