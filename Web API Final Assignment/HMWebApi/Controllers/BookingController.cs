using HM_BAL.Interface;
using HM_Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HMWebApi.Controllers
{
    public class BookingController : ApiController
    {
        private readonly IHotelManager _IHotelManager;

        public BookingController(IHotelManager hotelManager)
        {
            this._IHotelManager = hotelManager;
        }

        // GET: api/Booking
        
        public List<Hotel> GetHotels()
        {

            var hotel=_IHotelManager.GetAllHotels();
            return hotel;
        }

        // GET: api/Booking/5
        public HttpResponseMessage GetHotelById(int id)
        {
            var hotel = _IHotelManager.GetHotel(id);
            return Request.CreateResponse<Hotel> (HttpStatusCode.OK, hotel);
        }

        // POST: api/Booking
        public string createHotel([FromBody]Hotel model)
        {
            return _IHotelManager.createHotel(model);
        }

        // POST: api/Booking
        
        public string createRoom([FromBody] Room model)
        {
            return _IHotelManager.createRoom(model);
        }
        public string bookRoom([FromBody] Booking model)
        {
            return _IHotelManager.bookRoom(model);
        }
        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        { 
        }

        public List<Booking> checkAvailability([FromBody] Booking model)
        {

            var booking = _IHotelManager.checkBooking(model);

            return booking;

            // Your Code goes here
        }


    }
}
