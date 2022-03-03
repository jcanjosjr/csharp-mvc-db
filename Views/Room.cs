using System;
using Controllers;
using Models;

namespace Views
{
    public class RoomView
    {
        public static void CreateRoom()
        {
            Console.WriteLine("Inform the identifier of the room: ");
            string Number = Console.ReadLine();
            Console.WriteLine("Inform the Equipaments of the room: ");
            string Equipaments = Console.ReadLine();

            RoomController.CreateRoom(
                Number,
                Equipaments
            );
        }

        public static void UpdateRoom()
        {
            int Id = 0;

            GetAllRooms();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Room: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }

            Console.WriteLine("Inform the identifier of the room: ");
            string Number = Console.ReadLine();
            Console.WriteLine("Inform the Equipaments of the room: ");
            string Equipaments = Console.ReadLine();

            RoomController.UpdateRoom(
                Id,
                Number,
                Equipaments
            );
        }

        public static void DeleteRoom()
        {
            int Id = 0;

            GetAllRooms();
            Console.WriteLine("+-------------------------------+");
            Console.WriteLine("   Inform the ID of Room: ");
            try
            {
                Id = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                throw new Exception("Invalid Id.");
            }
            
            RoomController.DeleteRoom(Id);
        }

        public static void GetAllRooms()
        {
            foreach (Room room in RoomController.GetAllRooms())
            {
                Console.WriteLine(room);
            }
        }
    }
}