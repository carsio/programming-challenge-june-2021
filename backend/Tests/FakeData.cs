using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Tests
{
    public static class FakeData
    {
        private static async Task<string> GetJson(string name)
        {
            var fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "Resources/" + name + ".json",
                FileMode.Open);

            using var streamReader = new StreamReader(fileStream, Encoding.UTF8);
            var json = await streamReader.ReadToEndAsync();
            return json;
        }

        public static IEnumerable<T> GetFakeDataByClass<T>() where T : class
        {
            var typeClass = typeof(T);
            var jsonName = typeClass.Name.Split('.').Last();
            var json = GetJson(jsonName).Result;
            var result = JsonConvert.DeserializeObject<List<T>>(json);
            return result;
        }

        public static IEnumerable<T> GetFakeDataByName<T>(string nameJson) where T : class
        {
            var json = GetJson(nameJson).Result;
            var result = JsonConvert.DeserializeObject<List<T>>(json);
            return result;
        }
    }
}