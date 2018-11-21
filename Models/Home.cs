using System;
using System.Collections.Generic;

namespace Home.Api
{
    public class Home : IHaveId
    {
        private Guid _id;
        private string _name;
        private List<Room> _rooms;

        public Guid Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public List<Room> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                _rooms = value;
            }
        }
    }
}
