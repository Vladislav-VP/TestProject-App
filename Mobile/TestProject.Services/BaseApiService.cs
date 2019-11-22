﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestProject.Entities;
using TestProject.Services.Interfaces;

namespace TestProject.Services
{
    public class BaseApiService : IBaseApiService
    {
        protected string _url;

        public async Task<IEnumerable<T>> GetObjectsList<T>(string requestUri = null) where T : class
        {
            HttpClient client = GetClient();
            if (requestUri == null)
            {
                requestUri = _url;
            }
            string result = await client.GetStringAsync(requestUri);
            IEnumerable<T> entities = JsonConvert.DeserializeObject<IEnumerable<T>>(result);
            return entities;
        }

        public async Task<T> Get<T>(int id, string requestUri = null) where T : class
        {
            HttpClient client = GetClient();
            if (string.IsNullOrEmpty(requestUri))
            {
                requestUri = $"{_url}/{id}";
            }
            string result = await client.GetStringAsync(requestUri);
            T entity = JsonConvert.DeserializeObject<T>(result);
            return entity;
        }

        public async Task<TResponse> Post<TRequest, TResponse>(TRequest entity, string requestUri) where TResponse : class
        {
            HttpClient client = GetClient();
            string content = JsonConvert.SerializeObject(entity);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(requestUri, stringContent);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            string serializedObject = await response.Content.ReadAsStringAsync();
            TResponse deserializedObject = JsonConvert.DeserializeObject<TResponse>(serializedObject);
            return deserializedObject;
        }

        public async Task<T> Update<T>(T entity) where T : class
        {
            HttpClient client = GetClient();
            string contentUri = $"{_url}/";
            string content = JsonConvert.SerializeObject(entity);
            var stringContent = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(contentUri, stringContent);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            string serializedObject = await response.Content.ReadAsStringAsync();
            T updatedEntity = JsonConvert.DeserializeObject<T>(serializedObject);
            return updatedEntity;
        }

        public async Task<T> Delete<T>(int id) where T : class
        {
            HttpClient client = GetClient();
            string requestUri = $"{_url}/{id}";
            var response = await client.DeleteAsync(requestUri);
            if (response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            string serializedObject = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(serializedObject);
        }

        protected HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        //public Task<TResponse> Post<TResponse, TRequest>(TResponse entity, string requestUri) where TResponse : class
        //{
        //    throw new System.NotImplementedException();
        //}
    }
}
