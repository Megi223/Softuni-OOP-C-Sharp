using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    public class Department
    {
        private List<Room> rooms;

        public Department(string name)
        {
            this.rooms = new List<Room>();
            this.Name = name;
            InitializeRooms();
        }

        public string Name { get; set; }
        public IReadOnlyCollection<Room> Rooms => this.rooms;

        public Room GetFirstFreeRoom()
        {
            return this.rooms.First(x => x.Count < 3);
        }
        public void InitializeRooms()
        {
            for (int i = 1; i <= 20; i++)
            {
                this.rooms.Add(new Room(i));
            }
        }
    }
}
