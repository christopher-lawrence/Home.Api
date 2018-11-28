using System;

namespace Home.Api.Models
{
    public interface IHaveId
    {
        Guid Id { get; set; }
    }
}
