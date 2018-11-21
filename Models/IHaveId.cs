using System;

namespace Home.Api
{
    public interface IHaveId
    {
        Guid Id { get; set; }
    }
}
