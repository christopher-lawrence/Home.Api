using System;

namespace Home.Api
{
    public class LightBulb : IHaveId
    {
        private Guid _id;
        private LightBulbType _type;
        private string _size;

        // Relationships
        private Guid _roomId;
        private Room _room;

        public Guid Id { get => _id; set => _id = value; }
        public LightBulbType Type { get => _type; set => _type = value; }
        public string Size { get => _size; set => _size = value; }

        // Relationships
        public Guid RoomId { get => _roomId; set => _roomId = value; }
        public Room Room { get => _room; set => _room = value; }
    }
}
