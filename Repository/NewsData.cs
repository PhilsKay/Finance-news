using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Philnance.Models;

namespace Philnance.Repository
{
    public class NewsData : IFinanceNews
    {
        private readonly NewsUrl _newsUrl;
        public NewsData(IOptions<NewsUrl> newsUrl)
        {
            _newsUrl = newsUrl.Value;
        }

        FinanceNews IFinanceNews.GetFinanceNews(int offset)
        {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_newsUrl.Url);
                var parameters = string.Format("?apikey={0}&date={1}&sort={2}&offset={3}", _newsUrl.ApiKey,"today","desc", offset);
                    HttpResponseMessage response = client.GetAsync(parameters).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        return JsonConvert.DeserializeObject<FinanceNews>(result);
                    
                    }
                else
                {
                    return new FinanceNews() {
                        Data = new List<NewsArticle>(),
                    Pagination = new Pagination()
                        
                    };
                }
                }
        }
    }
}
