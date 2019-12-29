using AutoMapper;
using HotelManagementSystem.Entities;
using HotelManagementSystem.Model;
using HotelManagementSystem.Services;
using HotelManagementSystem.Services.api;
using HotelManagementSystem.ViewModel.api;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HotelManagementSystem.Controllers.api
{
    [AllowAnonymous]
    [Route("api/Room")]
    public class ApiRoomController : Controller
    {
        private readonly IMapper mapper;
        private readonly AppDbContext context;

        public ApiRoomController(IRoomServices roomServices, IMapper mapper,AppDbContext Context)
        {
            RoomServices = roomServices;
            this.mapper = mapper;
            context = Context;
        }
        public IRoomServices RoomServices { get; }
        [HttpGet("image/{ImageId}")]
        public async Task<IActionResult> GetAllImage(string ImageId,  CancellationToken ct)
        {
            var query = await RoomServices.GetAllImage(ImageId,ct);
            var image = System.IO.File.OpenRead(query);
            return File(image, "image/jpeg");
        }
        [HttpGet("imageIds")]
        public async Task<IActionResult> GetAllImageId(CancellationToken ct)
        {
            List<string> query = await RoomServices.GetAllImageIds(ct);
            return Ok(query);
        }

        [HttpGet("getimage/{RoomTypeId}")]
        public async Task<IActionResult> GetRandomRoomImagesForRoomTypeId(string RoomTypeId, CancellationToken ct  )
        {
            var query = await RoomServices.GetRandomRoomImagesForRoomTypeId(RoomTypeId, ct);
            var image = System.IO.File.OpenRead(query.ImagePath);
            return File(image, "image/jpeg");
        }
        [HttpGet("getfeature/{RoomTypeId}")]
        public async Task<IActionResult> GetRoomFeatures(string RoomTypeId, CancellationToken ct)
        {
            var query = await RoomServices.GetRoomFeatures(RoomTypeId, ct);
            return Ok(query);
        }
        [HttpGet("getroomtype")]
        public async Task<IActionResult> GetRoomRoomTypes(CancellationToken ct)
        {
            List<RoomTypeDto> model = new List<RoomTypeDto>();
           var query = await RoomServices.GetRoomRoomTypes(ct);
            foreach(var res  in query)
            {
                var rtdto = new RoomTypeDto()
                {
                    BasePrice = res.BasePrice,
                    Description = res.Description,
                    ID = res.ID,
                    Name = res.Name,
                };
                model.Add(rtdto);
            }
            //var model = mapper.Map<IEnumerable<RoomTypeDto>>(query);
            return Ok(model);
        }
        [HttpGet("Price/{roomTId}")]
        public async Task<IActionResult> GetRoomTypesPrice(string roomTId,CancellationToken ct)
        {
            var query = await RoomServices.GetRoomTypesPrice(roomTId,ct);
            return Ok(query);
        }

        [HttpPost("Contact")]
        public IActionResult ContactFrom(CreateBookingViewModel model)
        {
            return Ok();
        }

        [HttpPost("UserContact")]
        public IActionResult ContactFrom([FromBody]ContactViewModel model, CancellationToken ct)
        {
            if (model == null)
            {
              return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return StatusCode(422);
            }
            UserContact contact = new UserContact
            {
                UserContactId = Guid.NewGuid().ToString(),
                DateTime = DateTime.Now,
                Email = model.Email,
                Message =model.Message,
                Name=model.Name,
                Subject=model.Subject, 
                Reply = false
            };
             RoomServices.CreateContactFromForUser(contact);
            return Ok();
        }
        [HttpPost("SendEmailForRoomFeaturesAsync/{RoomTypeId}")]
        public bool SendEmailForRoomFeaturesAsync(string RoomTypeId,[FromBody]string email)
        {
            try
            {

                bool status =  RoomServices.SendEmailForRoomFeaturesAsync(email, RoomTypeId);
                return status;
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        [HttpGet("Availiable/{RoomTypeId}")]
        public IActionResult GetAnyRoomAvailiableForRoomTypeID(string RoomTypeId)
        {
            try
            {
                var model = RoomServices.GetAnyRoomAvailiableForRoomTypeID(RoomTypeId);
                return Ok(model);
            }
            catch (Exception)
            {

                return Ok();
            }
        
        }

        [HttpPost("Booking")]
        public  IActionResult AddBookingAsync([FromBody]CreateBookingViewModel book)
        {
            try
            {
                var booking = new Booking
                {
                    CustomerName = book.CustomerEmail,
                    CheckIn = book.CheckIn,
                    CheckOut = book.CheckOut,
                    DateCreated = DateTime.Now,
                    ID = Guid.NewGuid().ToString(),
                    CustomerEmail = book.CustomerEmail,
                    Guests = book.Adults + book.Children,
                    TotalFee = book.TotalFee,
                };
                RoomServices.CreateBookingForRoom(booking, book.RoomID);
                // hotelService.AddBookingForRoom(booking, book.RoomID);
                return Ok(true);
            }
            catch(Exception e)
            {
                return Ok(true);

            }

        }

        [HttpGet("CheckRoom/{RoomTypeId}")]
        public async Task<IActionResult> CheckAvailablity(string RoomTypeId, CancellationToken ct)
        {
            bool checkkresult = await RoomServices.CheckRoomAvaliabilityAsync(RoomTypeId, ct);
            return Ok(checkkresult);
        }

        [HttpGet("RoomDescription/{roomTId}")]
        public async Task<IActionResult> GetRoomDescriptionForType(string roomTId, CancellationToken ct)
        {
            if (roomTId == null)
            {
                return BadRequest();
            }
           List<string> model = await RoomServices.GetRoomDescriptionForType(roomTId,ct);
            return Ok(model);
        }

    }

}
