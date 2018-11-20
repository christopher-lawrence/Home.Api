using System.Collections.Generic;

namespace Home.Api
{
    public class Home
    {
        private IEnumerable<Room> _rooms;

        public IEnumerable<Room> Rooms
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
