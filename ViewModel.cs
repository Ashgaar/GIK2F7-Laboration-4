using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections.ObjectModel;

namespace Laboration_4
{
    class ViewModel
    {
        public FileHandler handler = new();

        public List<User> users = new();
        public string firstName { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string pathFile { get; set; }

        public async Task<List<User>> UpdateList(string filePath)
        {
            pathFile = filePath;
            var usersTask = handler.ReadAsync(filePath);
            users = await usersTask;
            return users;
        }

        public async Task<int> AddUsers(string firstName, string surname, string email)
        {
            if(firstName.Length > 0 && surname.Length > 0 && email.Length > 0)
            {
                await handler.WriteAsync(firstName, surname, email, pathFile);
                return 1;
            } else
            {
                return 0;
            }
        }
    }
}
