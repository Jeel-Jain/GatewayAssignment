using AutoMapper;
using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_DAL.Repository
{
   public class HotelRepository :IHotelRepository
    {
        private readonly Database.HMEntities dbContext;

        public HotelRepository()
        {
            dbContext = new Database.HMEntities();
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
            
            List<Hotel> hotelDetails = new List<Hotel>();
            // GET all hotels sort by alphabetic order. Response: List of hotels 
            var data = dbContext.tbl_hotel.OrderBy(x => x.hotelName).ToList();


            if (data!=null)
            {
                
                foreach (var item in data)
                {
                    Hotel hotel = new Hotel();
                    hotel.hid = item.hid;
                    hotel.hotelName = item.hotelName;
                    hotel.address = item.address;
                    hotel.city = item.city;
                    hotel.pincode = item.pincode;
                    hotel.contactPerson = item.contactPerson;
                    hotel.contactNumber = item.contactNumber;
                    hotel.createdBy = item.createdBy;
                    hotel.createDate = item.createDate;
                    hotel.updatedBy = item.updatedBy;
                    hotel.updateDate = item.updateDate;
                    hotel.facebook = item.facebook;
                    hotel.Twitter = item.Twitter;
                    hotel.isActive = item.isActive;
                    hotel.website = item.website;

                    hotelDetails.Add(hotel);
                }
            }
            return hotelDetails;
        }

        public Hotel GetHotel()
        {
            Hotel hotel = new Hotel
            {
                hid = 2,
                hotelName = "Maggit",
                address = "Ahmedabad"

            };
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
