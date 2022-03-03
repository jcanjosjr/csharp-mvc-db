using Models;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Controllers
{
    public class RoomController
    {
        // Create a new Room.
        public static Room CreateRoom(string Number, string Equipaments)
        {
            if (String.IsNullOrEmpty(Number))
            {
                throw new Exception("Invalid identifier.");
            }

            if (String.IsNullOrEmpty(Equipaments))
            {
                throw new Exception("Invalid equipaments.");
            }

            return new Room(Number, Equipaments);
        }

        // Alter a existing Room.
        public static Room UpdateRoom(int Id, string Number, string Equipaments)
        {
            Room room = GetRoom(Id);

            if (!String.IsNullOrEmpty(Number))
            {
                room.Number = Number;
            }

            if (!String.IsNullOrEmpty(Equipaments))
            {
                room.Equipaments = Equipaments;
            }

            return room;
        }

        // Delete Room by Id.
        public static Room DeleteRoom(int Id)
        {
            try
            {
                Room room = GetRoom(Id);
                Room.RemoveRoom(room);
                return room;
            }
            catch
            {
                throw new Exception("An error as occurred.");
            }
        }

        // Get all Rooms
        public static List<Room> GetAllRooms()
        {
            return Room.GetRooms();
        }

        // Get Room by Id.
        public static Room GetRoom(int Id)
        {
            // This works for read-only access to a collection.
            // But after the access, in Update we change the values.
            // Need to ask Jackson why.
            List<Room> roomsModels = Room.GetRooms();
            IEnumerable<Room> rooms = from Room in roomsModels
                where Room.Id == Id
                select Room;
            Room room = rooms.First();

            if (room == null)
            {
                throw new Exception("Room don't found");
            }

            return room;
        }
    }
}