using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Zavrsni.Model
{

    public class User
    {
        public string id_user { get; set; }
        public string email { get; set; }
        public string create_time { get; set; }


        public async static Task<List<User>> GetUsers()
        {
            List<User> users = new List<User>();
            var url = "https://www.idt.mdh.se/personal/plt01/languide/?get=users";

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var json = await response.Content.ReadAsStringAsync();

                var userRoot = JsonConvert.DeserializeObject<UserRoot>(json);
                users = userRoot.data as List<User>;
            }
            return users;
        }
    }

    public class UserRoot
    {
        public int error { get; set; }
        public string msg { get; set; }
        public IList<User> data { get; set; }
    }
}
