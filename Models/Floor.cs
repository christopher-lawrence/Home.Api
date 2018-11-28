using System;

namespace Home.Api.Models
{
    public class Floor : IHaveId
    {
        private Guid _id = Guid.NewGuid();

        private Guid _roomId;
        private Room _room = new Room();
        private Guid? _colorId;
        private Color _color = new Color();

        public Guid Id { get => _id; set => _id = value; }

        public Guid RoomId { get => _roomId; set => _roomId = value; }
        public Room Room { get => _room; set => _room = value; }
        public Guid? ColorId { get => _colorId; set => _colorId = value; }
        public Color Color { get => _color; set => _color = value; }

    }
}
