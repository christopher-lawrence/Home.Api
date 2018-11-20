using System.Collections.Generic;

namespace Home.Api
{
    public class Room
    {
        private int _height;
        private int _width;
        private int _length;
        private IEnumerable<LightBulb> _lightBulbs;
        private IEnumerable<string> _colors;

        //TODO: Add windows

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

        public IEnumerable<LightBulb> LightBulbs
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

        public IEnumerable<string> Colors
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
    }
}
