using System;
using System.Collections.Generic;

namespace Home.Api
{
    public class Room : IDimensions, IHaveId
    {
        private Guid _id;
        private int _height;
        private int _width;
        private int _length;
        private string _name;
        private List<LightBulb> _lightBulbs = new List<LightBulb>();
        private List<IHaveColor> _colors = new List<IHaveColor>();
        private List<Window> _windows = new List<Window>();
        private List<Door> _doors = new List<Door>();

        /** Relations */
        private Guid _homeId;
        private Home _home;

        public Guid Id { get => _id; set => _id = value; }
        public Guid HomeId { get => _homeId; set => _homeId = value; }
        public Home Home { get => _home; set => _home = value; }
        public int Height { get => _height; set => _height = value; }
        public int Width { get => _width; set => _width = value; }
        public int Length { get => _length; set => _length = value; }
        public string Name { get => _name; set => _name = value; }
        public List<LightBulb> LightBulbs { get => _lightBulbs; set => _lightBulbs = value; }
        public List<IHaveColor> Colors { get => _colors; set => _colors = value; }
        public List<Window> Windows { get => _windows; set => _windows = value; }
        public List<Door> Doors { get => _doors; set => _doors = value; }

    }
}
