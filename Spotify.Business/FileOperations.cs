using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotify.Business
{
    public static class FileOperations
    {
        public static string BasePath = @"C:\Users\yarenbenhur\Desktop\Lessons\c#\Spotify\Spotify.Business\Data\";

        public static void CreateFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path);
            }
        }

        public static void WriteDataToFile(string path, string data)
        {
            File.AppendAllLines(path, new string[] { data });
        }

        public static List<T> ReadAllData<T>(string path)
        {
            string[] lines = File.ReadAllLines(path);
            List<T> result = new List<T>();
            foreach (string item in lines)
            {
                T itemObject = JsonConvert.DeserializeObject<T>(item);
                result.Add(itemObject);
            }

            return result;
        }
    }
}
