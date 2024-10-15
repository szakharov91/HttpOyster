using HttpOyster.UI.Utils.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpOyster.UI.ViewModels
{
    public class MainViewModel: UserControlNotified
    {
        private string? _requestUrl;
        private string? _errorMessage;

        public string? RequestUrl 
        { 
            get => _requestUrl;
            set => SetProperty(ref _requestUrl, value);
        }

        public string? ErrorMessage
        {
            get => _errorMessage;
            set => SetProperty(ref _errorMessage, value);
        }

        public async void SendRequest()
        {
            if (string.IsNullOrEmpty(_requestUrl))
                return;

            try
            {
                using var http = new HttpClient();

                using var request = new HttpRequestMessage()
                {
                    RequestUri = new Uri(_requestUrl),
                    Method = HttpMethod.Get,
                };

                var response = await http.SendAsync(request);
            }
            catch (Exception exception)
            {
                ErrorMessage = $"{exception.Message}";
            }
        }
    }
}
