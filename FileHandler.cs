using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;


namespace Laboration_4
{
    class FileHandler
    {
        public async Task WriteAsync(string firstname, string surname, string email, string filePath)
        {
            string text = $"{firstname} {surname} {email}";

            using StreamWriter file = new(filePath, append: true);
            await file.WriteLineAsync(text);
        }

        public async Task<List<User>> ReadAsync(string filePath)
        {
            string[] data = await File.ReadAllLinesAsync(filePath, Encoding.UTF8);

            var usersList = new List<User>();

            foreach (string line in data)
            {
                var refinedOutputFirstName = Regex.Replace(line.Split()[0], @"[^0-9a-zA-Z\ ]+", "");
                var refinedOutputSurname = Regex.Replace(line.Split()[1], @"[^0-9a-zA-Z\ ]+", "");
                var refinedOutputEmail = Regex.Replace(line.Split()[2], @"^[\w!#$%&'*+/=?`{|}~^.-]+@[A-Z0-9.-]+$", "");
                Debug.WriteLine($"First name:{refinedOutputFirstName} Surname:{refinedOutputSurname} Email:{refinedOutputEmail}");
                
                usersList.Add(new User() { firstName = refinedOutputFirstName, surname = refinedOutputSurname, email = refinedOutputEmail });
            }

            return usersList;
        }
    }
}
