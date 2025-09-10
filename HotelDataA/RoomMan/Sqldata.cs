using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelDataA.DataBase;
using HotelDataA.Moudls;

namespace HotelDataA.RoomMan;

public class Sqldata : IdataDb
{
    private readonly IDapAcasses _db;

    public Sqldata(IDapAcasses db)
    {
        _db = db;
    }
    private const string cName = "SqlDb";
    public List<RoomType> GeAvlRoomType(DateTime stratData, DateTime endDate)
    {
        return _db.loedData<RoomType, dynamic>("spBookigs_GetAvlebeleRooms", new {startDate= stratData, endDate }, cName, true);
    }
    public RoomType GetRoomType(string name)
    {
     var t=   _db.loedData<RoomType,dynamic>("spRoomType_GetByName", new {name},cName, true).FirstOrDefault();
        return t;
    }
    public void bookRoom(string firstName, string lastName, string RoomName, DateTime stratData, DateTime endDate)
    {
        var gusest = new Gusest() { FirstName = firstName, LastName = lastName };
        
        _db.Save("spGusest_Creat", new {  firstName, lastName }, cName,true);
           string  sql = "select Id from dbo.gusest where FirstName=@firstName and LastName=@lastName";
        gusest.Id = _db.loedData<Gusest, dynamic>(sql, new { firstName= firstName,lastName= lastName }, cName).FirstOrDefault().Id;
        sql = "select* from dbo.RoomType t where t.name=@RoomName;";
        var type = _db.loedData<RoomType, dynamic>(sql, new {  RoomName }, cName).ToList().First();
      TimeSpan timeSpan       = endDate.Date.Subtract(stratData.Date);

         


        var room = _db.loedData<Room, dynamic>("spRoom_getRoom", new { startDate=stratData,endDate
            , Typeid = type.Id }, cName, true).FirstOrDefault();

        var booking = new Bookings()
        {
            GuestId = gusest.Id,
            RoomId = room.ID,
            RoomNumber = room.RoomNumber,
            StartDate = stratData,
            EndDate = endDate,
           
           Price = timeSpan.Days*type.Price,
        };


        _db.Save("spBooking-book",
                 new { startDate = booking.StartDate, EndDate = booking.EndDate, booking.RoomId, booking.RoomNumber, totelPrice = booking.Price, guestId = booking.GuestId },
                 cName,
                 true);
    }
    public List<Bookings> GetBookings(string lastName)
    {

        
        
        
        
        
        var bookings = _db.loedData<Bookings, dynamic>("spBooking_GetBookings_", new
        {
            lastName,
            Today =DateTime.Now,
        }, cName, true);
        return bookings;
    }
    public void Chakin(int bookingId)
    {

        string sql = "Updat dbo.bookings set isChekedin=1 where  Id=@id; ";
        _db.Save(sql, new { id = bookingId }, cName, true);
    }
}
       


    
    
