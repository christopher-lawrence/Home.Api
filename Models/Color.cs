using System;

namespace Home.Api.Models
{
    public class Color : IHaveId
    {
        private Guid _id = Guid.NewGuid();
        private string _colorName;
        private string _colorCode;

        public Guid Id { get => _id; set => _id = value; }
        string ColorName { get => _colorName; set => _colorName = value; }
        string ColorCode { get => _colorCode; set => _colorCode = value; }
    }
}
