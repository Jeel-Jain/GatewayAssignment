using HM_BAL.Interface;
using HM_Model;
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
        public List<Hotel> Get()
        {

            var hotel=_IHotelManager.GetAllHotels();
            return hotel;
        }

        // GET: api/Booking/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Booking
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        { 
        }
    }
}
