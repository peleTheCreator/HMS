using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Serialization;
using HotelFrontEnd.Models;
using HotelFrontEnd.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using static System.Net.Mime.MediaTypeNames;

namespace HotelFrontEnd.Services
{
    public interface IHotelServices
    {
        Task<List<RoomType>> GetAllRoomType();
        Task<List<string>> GetRoomFeatures(string RoomTypeId);
        Task<List<string>> GetAllInageIdsAsync();
        Task<bool> CheckAvalibilityAsync(string RoomTypeId);
        Task<decimal> GetRoomTypesPrice(string roomTId);
        Task<bool> CreateUserContectFormAsync(ContactViewModel contact);
        Task<RoomTypeViewModel> GetRoomTypeAsync();
        Task<bool> SendEmailForRoomFeaturesAsync(string email, string RoomTypeId);
        Task<List<string>> GetRoomDescriptionForType(string roomTId);
        Task<Room> GetAnyRoomAvailiableForRoomTypeID(string roomTypeId);
        Task<bool> AddBookingAsync(CreateBookingViewModel booking);
     }

    public class HotelServices : IHotelServices
    {
        private static HttpClient _httpClient = new HttpClient();
        public HotelServices()
        {
            _httpClient.BaseAddress = new Uri("https://localhost:44349/");
            _httpClient.Timeout = new TimeSpan(0, 0, 30);
            _httpClient.DefaultRequestHeaders.Clear();
        }
       

        public async Task<bool> AddBookingAsync(CreateBookingViewModel booking)
        {
            var serializedcontactToCreate = JsonConvert.SerializeObject(booking);
            var request = new HttpRequestMessage(HttpMethod.Post, "api/Room/Booking");
            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            request.Content = new StringContent(serializedcontactToCreate);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await _httpClient.SendAsync(request);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var book = JsonConvert.DeserializeObject<bool>(content);
           return book;          
        }

        public async  Task<bool> CheckAvalibilityAsync(string RoomTypeId)
        {
            var path = "api/Room/CheckRoom/"+RoomTypeId;
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var check = false;
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                check = JsonConvert.DeserializeObject<bool>(content);
            }
            return check;
        }

        public async Task<bool> CreateUserContectFormAsync(ContactViewModel contact)
        {
            bool status = false;
            try
            {
                var serializedcontactToCreate = JsonConvert.SerializeObject(contact);
                var request = new HttpRequestMessage(HttpMethod.Post, "api/Room/UserContact");
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedcontactToCreate);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                status = true;
                var content = await response.Content.ReadAsStringAsync();
                var createdMovie = JsonConvert.DeserializeObject<ContactViewModel>(content);
                return status;
            }
            catch (Exception)
            {

                return status;
            }
        }

        public async Task<List<string>> GetAllInageIdsAsync()
        {
            var response = await _httpClient.GetAsync("api/Room/imageIds");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var imgids = new List<string>();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                imgids = JsonConvert.DeserializeObject<List<string>>(content);
            }
            return imgids;
        }

        public async Task<List<RoomType>> GetAllRoomType()
        {
            var response = await _httpClient.GetAsync("api/Room/getroomtype");
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var roomTypes = new List<RoomType>();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                roomTypes = JsonConvert.DeserializeObject<List<RoomType>>(content);
            }
            return roomTypes;
        }

        public async Task<Room> GetAnyRoomAvailiableForRoomTypeID(string roomTypeId)
        {
            var path = "api/Room/Availiable/" + roomTypeId;
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                var Room = JsonConvert.DeserializeObject<Room>(content);
                return Room;
            }
            return null;
        }

        public async  Task<List<string>> GetRoomDescriptionForType(string roomTId)
        {
            var path = "api/Room/RoomDescription/"+roomTId;

            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var roomDescription = new List<string>();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                roomDescription = JsonConvert.DeserializeObject<List<string>>(content);
            }
            return roomDescription;
        }

        public async Task<List<string>> GetRoomFeatures(string RoomTypeId)
        {
            var path = "api/Room/getfeature/" + RoomTypeId;
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var roomTypes = new List<string>();
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                roomTypes = JsonConvert.DeserializeObject<List<string>>(content);
            }
            return roomTypes;
        }

        public async Task<RoomTypeViewModel> GetRoomTypeAsync()
        {
            var rmType = await GetAllRoomType();
            var rmTypeSelectLists = new List<SelectListItem>();
            foreach(var rmt in rmType)
            {
                rmTypeSelectLists.Add(new SelectListItem(rmt.Name, rmt.ID));
            }
            return  new RoomTypeViewModel() { RoomTypes = rmTypeSelectLists };
        }

        public async Task<decimal> GetRoomTypesPrice(string roomTId)
        {
            var path = "api/Room/Price/"+roomTId;
            var response = await _httpClient.GetAsync(path);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var price = (decimal)00.00;
            if (response.Content.Headers.ContentType.MediaType == "application/json")
            {
                  price = JsonConvert.DeserializeObject<decimal>(content);
                return price;
            }
            return price;
        }
       

        public async Task<bool> SendEmailForRoomFeaturesAsync(string email, string RoomTypeId)
        {
            bool status = false;
            try
            {
                var serializedcontactToCreate = JsonConvert.SerializeObject(email);
                var request = new HttpRequestMessage(HttpMethod.Post, "api/Room/SendEmailForRoomFeaturesAsync/"+RoomTypeId);
                request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                request.Content = new StringContent(serializedcontactToCreate);
                request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                 status = JsonConvert.DeserializeObject<bool>(content);
                return status;
            }
            catch (Exception)
            {

                return status;
            }
        }

       
    }
}
