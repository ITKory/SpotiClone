using Newtonsoft.Json;
using RestSharp;
using RestSharp.Authenticators.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotiClone.MVVM.Model.DataBase
{
    public class DataBaseModel
    {
        private RestClient _client;
        private RestRequest _request;

        public DataBaseModel()
        {
            _client = new();
            _client.Authenticator = new OAuth2AuthorizationRequestHeaderAuthenticator("token", "Bearer");

        }

         public void SendRequest( string path)
        {
            _request = new RestRequest(path, Method.Get);
            _request.AddHeader("Accept", "aplication/json");
            _request.AddHeader("Content-Type", "aplication/json");
        }

        public T GetResponse<T>()
        {
            var response = _client.GetAsync(_request).Result;
            var data = JsonConvert.DeserializeObject<T>(response.Content);
            if (data is null)
                throw new NullReferenceException($"track list is null; response status code:{response.StatusCode}");
            return data;
        }

 

    }

}
