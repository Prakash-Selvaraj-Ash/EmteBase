using System;
namespace Emte.Core.DomainModels
{
    /// <summary>
    /// Represents identifier contract
    /// </summary>
    public interface IWithId
    {
        /// <summary>
        /// Gets or sets the identifier
        /// </summary>
        Guid Id { get; set; }
    }
}

