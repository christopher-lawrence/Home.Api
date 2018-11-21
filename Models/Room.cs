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
        private List<LightBulb> _lightBulbs;
        private List<string> _colors;
        private List<Window> _windows;

        /** Relations */
        private Guid _homeId;
        private Home _home;

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

        public Guid HomeId
        {
            get
            {
                return _homeId;
            }
            set
            {
                _homeId = value;
            }
        }

        public Home Home
        {
            get
            {
                return _home;
            }
            set
            {
                _home = value;
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

        public int Length
        {
            get
            {
                return _length;
            }
            set
            {
                _length = value;
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

        public List<LightBulb> LightBulbs
        {
            get
            {
                return _lightBulbs;
            }
            set
            {
                _lightBulbs = value;
            }
        }

        public List<string> Colors
        {
            get
            {
                return _colors;
            }
            set
            {
                _colors = value;
            }
        }

        public List<Window> Windows
        {
            get
            {
                return _windows;
            }
            set
            {
                _windows = value;
            }
        }

    }
}
