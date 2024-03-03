using RequestsContracts.Interfaces;
using RequestsContracts.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace RequestsImplementations
{
    public class ExaminationsRequestCreator : IExaminationsRequestCreator
    {
        public HttpRequestMessage CreateBaseRequest(DateTime startPeriod)
        {
            HttpRequestMessage request = new(HttpMethod.Post, string.Empty);
            SetHeaders(request);
            SetContent(request, startPeriod);
            return request;
        }

        private void SetHeaders(HttpRequestMessage request)
        {
            var headers = request.Headers;
            headers.Add("Accept", "application/json, text/plain, */*");
            headers.Add("Accept-Language", "ru,en;q=0.9,sr;q=0.8");
            headers.Add("Connection", "keep-alive");
            headers.Add("Origin", "https://dom.gosuslugi.ru");
            headers.Add("Referer", "https://dom.gosuslugi.ru/");
            headers.Add("Request-GUID", "bd82ecfc-0223-458e-8a95-25b48a101421");
            headers.Add("Sec-Fetch-Dest", "empty");
            headers.Add("Sec-Fetch-Mode", "cors");
            headers.Add("Sec-Fetch-Site", "same-origin");
            headers.Add("Session-GUID", "69c3fdf9-6ad7-4bc9-8f11-0a62aabedeab");
            headers.Add("State-GUID", "/rp");
            headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 YaBrowser/24.1.0.0 Safari/537.36");
            headers.Add("X-KL-kfa-Ajax-Request", "Ajax_Request");
            headers.Add("sec-ch-ua", "\"Not_A Brand\";v=\"8\", \"Chromium\";v=\"120\", \"YaBrowser\";v=\"24.1\", \"Yowser\";v=\"2.5\"");
            headers.Add("sec-ch-ua-mobile", "?0");
            headers.Add("sec-ch-ua-platform", "\"Windows\"");
        }

        private void SetContent(HttpRequestMessage request, DateTime startPeriod)
        {
            var filter = new PostRequestFilter(startPeriod);
            var content = JsonContent.Create(filter);
            request.Content = content;
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}
