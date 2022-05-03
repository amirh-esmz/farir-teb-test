using Domain.Models.CandidateAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedWorks
{
    public class CandidateSeed
    {
        private readonly HttpClient _httpClient;
        private readonly DataBaseContext _dataBaseContext;

        public CandidateSeed(DataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
            _httpClient = new HttpClient();
        }

        private IEnumerable<Candidate> GetCandidates() {
            var url = "https://app.ifs.aero/EternalBlue/api/candidates";
            return _httpClient.GetFromJsonAsync<IEnumerable<Candidate>>(url)
                .GetAwaiter().GetResult() ?? new List<Candidate>();
        }

        private bool DataExist() {
            return _dataBaseContext.Candidates.Any();
        }

        private void InsertData()
        {
            var data = GetCandidates();

            _dataBaseContext.Candidates.AddRange(data);
            _dataBaseContext.SaveChanges();
        }

        public void Initial()
        {
            if(!DataExist())
                InsertData();
        }
    }
}
