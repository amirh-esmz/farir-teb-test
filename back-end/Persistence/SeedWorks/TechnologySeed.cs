using Domain.Models.TechnologyAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedWorks
{
    public class TechnologySeed
    {
        private readonly HttpClient _httpClient;
        private readonly DataBaseContext _dataBaseContext;

        public TechnologySeed(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _httpClient = new HttpClient();
        }

        private IEnumerable<Technology> GetTechnologies()
        {
            var url = "https://app.ifs.aero/EternalBlue/api/technologies";
            return _httpClient.GetFromJsonAsync<IEnumerable<Technology>>(url)
                .GetAwaiter().GetResult() ?? new List<Technology>();
        }

        private bool DataExist()
        {
            return _dataBaseContext.Technologies.Any();
        }

        private void InsertData()
        {
            var data = GetTechnologies();

            _dataBaseContext.Technologies.AddRange(data);
            _dataBaseContext.SaveChanges();
        }

        public void Initial()
        {
            if (!DataExist())
                InsertData();
        }
    }
}
