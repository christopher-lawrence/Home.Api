using System;

namespace Home.Api
{
    public class Window : IDimensions, IHaveId
    {
        private Guid _id;
        private int _height;
        private int _width;

        private Guid _roomId;
        private Room _room;

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

        public Guid RoomId
        {
            get
            {
                return _roomId;
            }
            set
            {
                _roomId = value;
            }
        }

        public Room Room
        {
            get
            {
                return _room;
            }
            set
            {
                _room = value;
            }
        }

        public int Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }
        public int Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }
    }
}
