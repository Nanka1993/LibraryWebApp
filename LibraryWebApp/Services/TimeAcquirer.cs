using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LibraryWebApp.Services
{
    public interface ITimeAcquirer
    {
        Task<DateTime> GetCurrentAsync(CancellationToken token);
    }

    public class WcaTimeAcquirer : ITimeAcquirer
    {
        public async Task<DateTime> GetCurrentAsync(CancellationToken token)
        {
            var decide = await DecideAsync();

            await DoSomethingAsync();

            var result = await Url.Combine(@"http://worldclockapi.com/api/json/utc/now")
                .GetJsonAsync<WcaResponse>(cancellationToken: token);
            if (decide)
            {
                return DateTime.UtcNow;
            }
            return result.CurrentDateTime;
        }

        private Task DoSomethingAsync()
        {
            return Task.CompletedTask;
        }

        private Task<bool> DecideAsync()
        {
            return Task.FromResult(true);
        }

    }

    public class WcaResponse
    {
        [JsonProperty("$id")] public string Id { get; set; }
        public DateTime CurrentDateTime { get; set; }
        public string UtcOffset { get; set; }
        public bool IsDayLightSavingsTime { get; set; }
        public string DayOfTheWeek { get; set; }
        public string TimeZoneName { get; set; }
        public long CurrentFileTime { get; set; }
        public string OrdinalDate { get; set; }
        public object ServiceResponse { get; set; }
    }
}