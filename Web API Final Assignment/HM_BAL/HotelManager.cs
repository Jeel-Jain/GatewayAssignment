using HM_BAL.Interface;
using HM_DAL.Repository;
using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_BAL
{
    public class HotelManager : IHotelManager
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public string createHotel(Hotel model)
        {
            throw new NotImplementedException();
        }

        public string deleteHotel(int id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel> GetAllHotels()
        {
            var data = _hotelRepository.GetAllHotels();
            return data;
        }

        public Hotel GetHotel()
        {
            var hotel = _hotelRepository.GetHotel();
           
            return hotel;
        }

        public Hotel GetHotel(int id)
        {
            throw new NotImplementedException();
        }

        public string updateHotel(Hotel model)
        {
            throw new NotImplementedException();
        }
    }
}
