using Repository;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Room
    {
        public int Id { set; get; }
        [Required]
        public string Number { set; get; }
        [Required]
        public string Equipaments { set; get; }

        // The public constructor, will be call when Room will instantiated.
        public Room(
            string Number,
            string Equipaments
        )
        {
            this.Id = Id;
            this.Number = Number;
            this.Equipaments = Equipaments;

            // Add a Room in a List of Rooms on Database. 
            Context db = new Context();
            db.Rooms.Add(this);
            db.SaveChanges();
        }

        // The method ToString of Room.
        public override string ToString()
        {
            return $"ID: {this.Id}"
                + $"\n - Identifier: {this.Number}"
                + $"\n - Equipaments: {this.Equipaments}";
        }

        // Method to check equality of two Room Objects.
        public override bool Equals(object obj)
        {
            if (obj == null || !Room.ReferenceEquals(this, obj))
            {
                return false;
            } 

            Room iterable = (Room) obj;
            return iterable.Id == this.Id;
        }

        // Give the numeric identifier of object.
        // Good to quick checks object equality.
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        // Method to return all List of Rooms.
        public static List<Room> GetRooms()
        {
            Context db = new Context();
            return (from Room in db.Rooms select Room).ToList();
        }

        // Method remove a Obeject Room from list of Rooms.
        public static void RemoveRoom(Room room)
        {
            Context db = new Context();
            db.Rooms.Remove(room);
        }
    }
}