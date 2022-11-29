using System;
namespace Emte.Core.DomainModels
{
    public interface IWithStatus
    {
        public Guid StatusId { get; set; }
    }
}

