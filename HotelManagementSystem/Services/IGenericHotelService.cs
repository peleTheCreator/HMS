using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HotelManagementSystem.Entities;
using HotelManagementSystem.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementSystem.Services
{
    public interface IGenericHotelService<TEntity>
    {
        Task<IEnumerable<TEntity>> GetAllItemsAsync();

        Task<TEntity> GetItemByIdAsync(string id);

        Task<IEnumerable<TEntity>> SearchFor(Expression<Func<TEntity, bool>> expression);

        Task CreateItemAsync(TEntity entity);

        Task EditItemAsync(TEntity entity);

        Task DeleteItemAsync(TEntity entity);
        RoomAdminIndexViewModel GetAllTheRoomAndRole();
        IEnumerable<Room> GetAllRooms();
        Task<RoomFeaturesAndImagesViewModel> GetRoomFeaturesAndImagesAsync(Room room);
        Task<IEnumerable<RoomType>> GetAllRoomTypesAsync();
        List<SelectedRoomFeatureViewModel> PopulateSelectedFeaturesForRoom(Room room);
        void UpdateRoomFeaturesList(Room room, string[] SelectedFeatureIDs);
        void UpdateRoomImagesList(Room room, string[] imageIDs);
        IEnumerable<Room> GetAllRoomsWithFeature(string feature);
        Task<AddImagesViewModel> AddImagesAsync(List<IFormFile> files);
        Task RemoveImageAsync(Image image);
        Room GetRoomByID(string roomID);
        bool GetBookingStatus(string v);
        void AddBookingForRoom(Booking booking, string roomID);
        IEnumerable<Booking> GetAllBooking();
        Booking GetBookingById(string id);
        IEnumerable<Image> GetAllImages();
        bool RoomBookedCheckOutDate(string roomID);
        void UpdatBookingForRoom(Booking booking, string roomID);
    }
}
