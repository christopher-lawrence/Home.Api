namespace Home.Api
{
    public class LightBulb
    {
        private LightBulbType _type;
        private string _size;

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
