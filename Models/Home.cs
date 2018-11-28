using System;
using System.Collections.Generic;

namespace Home.Api.Models
{
    public class Home : IHaveId
    {
        private Guid _id = Guid.NewGuid();
        private string _name;
        private List<Room> _rooms = new List<Room>();

        public Guid Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
        public List<Room> Rooms { get => _rooms; set => _rooms = value; }
    }
}
