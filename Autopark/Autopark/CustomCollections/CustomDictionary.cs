using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Autopark.CustomCollections
{
    public sealed class CustomDictionary
    {
        public CustomDictionary(string path)
        {
            if (File.Exists(path))
            {
                foreach (var line in File.ReadLines(path, Encoding.Unicode))
                {
                    string[] parts = line.Split(",");
                    foreach (var part in parts)
                    {
                        try
                        {
                            _dictionary.Add(part, 1);
                        }
                        catch (ArgumentException)
                        {
                            ++_dictionary[part];
                        }
                    }
                }
            }
            else
                throw new FileNotFoundException($"file with name {path} doesn't exists");
        }

        public void Add(string key)
        {
            try
            {
                _dictionary.Add(key, 1);
            }
            catch (ArgumentException)
            {
                ++_dictionary[key];
            }
        }

        public bool Delete(string key) => _dictionary.Remove(key);

        public void Print()
        {
            foreach (var keyValuePair in _dictionary)
            {
                Console.WriteLine("{0,10} - {1, 5}",
                    keyValuePair.Key,
                    keyValuePair.Value
                    );
            }
        }

        private Dictionary<string, int> _dictionary = new Dictionary<string, int>();
    }
}
