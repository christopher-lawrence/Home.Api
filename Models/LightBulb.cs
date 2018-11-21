using System;

namespace Home.Api
{
    public class LightBulb : IHaveId
    {
        private Guid _id;
        private LightBulbType _type;
        private string _size;

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

        public LightBulbType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public string Size
        {
            get
            {
                return _size;
            }
            set
            {
                _size = value;
            }
        }

    }
}
