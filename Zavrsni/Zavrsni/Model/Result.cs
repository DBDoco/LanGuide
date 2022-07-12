using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Zavrsni.Model
{
    public class Result
    {
        public int id_user { get; set; }
        public string email { get; set; }
        public string create_time { get; set; }
        public string id_exercise { get; set; }
        public int result_percent { get; set; }
        public int result_score { get; set; }
        public int result_max { get; set; }
        public string skill { get; set; }
        public string language { get; set; }
        public string result_date { get; set; }

        public async static Task<List<Result>> GetResults()
        {
            List<Result> results = new List<Result>();
            var url = new Uri ("https://www.idt.mdh.se/personal/plt01/languide/?get=results&limit=500");

            HttpClient client = new HttpClient();
            
                var response = client.GetAsync(url).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();

                    var resultRoot = JsonConvert.DeserializeObject<ResultRoot>(json);
                    results = resultRoot.data as List<Result>;
                }
            
            return results;
        }
    }

    public class ResultRoot
    {
        public int error { get; set; }
        public string msg { get; set; }
        public IList<Result> data { get; set; }
    }
}
