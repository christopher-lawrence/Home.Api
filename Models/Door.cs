using System;

namespace Home.Api
{
    public class Door : IHaveId, IDimensions, IHaveColor
    {
        private Guid _id;
        private int _height;
        private int _width;
        private string _colorName;
        private string _colorCode;

        private Guid _roomId;
        private Room _room;

        public Guid Id { get => _id; set => _id = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public string ColorName { get => _colorName; set => _colorName = value; }
        public string ColorCode { get => _colorCode; set => _colorCode = value; }

        public Guid RoomId { get => _roomId; set => _roomId = value; }
        public Room Room { get => _room; set => _room = value; }
    }
}
