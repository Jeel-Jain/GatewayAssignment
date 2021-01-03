using HM_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HM_BAL.Interface
{
    public interface IHotelManager
    {
        Hotel GetHotel();
        Hotel GetHotel(int id);

        List<Hotel> GetAllHotels();

        String createHotel(Hotel model);

        String updateHotel(Hotel model);

        String deleteHotel(int id);
    }
}
