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

        public string bookRoom(Booking model)
        {
            try
            {
                if (model != null)
                {


                    
                    Database.tbl_booking book = new Database.tbl_booking();

                    book.bookingDate = model.bookingDate;
                    book.roomid = model.roomid;
                    book.statusOfBooking = "Definitive";
                    book.hotelid = model.hotelid;

                                     
                    dbContext.tbl_booking.Add(book);
                    dbContext.SaveChanges();
                    return "Booked Successfully.";
                }
                return "Model is Null.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        public List<Booking> checkBooking(Booking model)
        {

            List<Booking> bookingDetails = new List<Booking>();

            var entityy = dbContext.tbl_booking.Where(x=>x.bookingDate==model.bookingDate);
            foreach (var item in entityy)
            {



                Booking book = new Booking();
                book.roomid = item.roomid;
                book.hotelid = item.hotelid;
                book.bookingId = item.bookingId;
                book.bookingDate = item.bookingDate;
                if(item.statusOfBooking== "Definitive")
                {
                    book.statusOfBooking = "False";
                }
                else 
                {
                    book.statusOfBooking = "True";
                }
                

                bookingDetails.Add(book);

                
            }
            return bookingDetails;
        }

        public string createHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {


                    Database.tbl_hotel entities = new Database.tbl_hotel();

                    entities.hotelName = model.hotelName;
                    entities.address = model.address;
                    entities.city = model.city;
                    entities.pincode = model.pincode;
                    entities.contactPerson = model.contactPerson;
                    entities.contactNumber = model.contactNumber;
                    entities.createdBy = model.createdBy;
                    entities.createDate = DateTime.Now;
                    entities.updatedBy = model.updatedBy;
                    entities.updateDate = DateTime.Now;
                    entities.facebook = model.facebook;
                    entities.Twitter = model.Twitter;
                    entities.isActive = "0";
                    entities.website = model.website;


                    dbContext.tbl_hotel.Add(entities);
                    dbContext.SaveChanges();
                    return "Data Submitted Successfully.";
                }
                return "Model is Null.";

            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }

        public string createRoom(Room model)
        {
            try
            {
                if (model != null)
                {


                    Database.tbl_room entities = new Database.tbl_room();
                   

                    entities.hotelid = model.hotelid;
                    entities.category = model.category;
                    entities.price = model.price;
                    entities.createdBy = model.createdBy;
                    entities.createdDate = DateTime.Now;
                    entities.updatedBy = model.updatedBy;
                    entities.updateDate =DateTime.Now;
                    entities.roomName = model.roomName;
                    entities.isActive = 0;
                                      

                  

                    dbContext.tbl_room.Add(entities);
                  
                    dbContext.SaveChanges();
                    return "Room Booked Successfully.";
                }
                return "Model is Null.";

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
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
            try
            {
                var entity = dbContext.tbl_hotel.Find(id);
                 if(entity!=null)
                {
                    Hotel hotel = new Hotel();
                    hotel.hid = entity.hid;
                    hotel.hotelName = entity.hotelName;
                    hotel.address = entity.address;
                    hotel.city = entity.city;
                    hotel.pincode = entity.pincode;
                    hotel.contactPerson = entity.contactPerson;
                    hotel.contactNumber = entity.contactNumber;
                    hotel.createdBy = entity.createdBy;
                    hotel.createDate = entity.createDate;
                    hotel.updatedBy = entity.updatedBy;
                    hotel.updateDate = entity.updateDate;
                    hotel.facebook = entity.facebook;
                    hotel.Twitter = entity.Twitter;
                    hotel.isActive = entity.isActive;
                    hotel.website = entity.website;

                    return hotel;
                }
                return null;
            }
            catch(Exception ex)
            {
                throw ex;
            }
      
        }

        public string updateHotel(Hotel model)
        {
            throw new NotImplementedException();
        }
    }
}
