using Core.Domain.BillingInfo;
using Core.Domain.ContactInfo;

namespace Core.Domain.Entity
{
    /// <summary>
    /// Represents an Entity-Company able to receive or issue an invoice
    /// </summary>
    public interface IEntityDefinition
    {
        /// <summary>
        /// Unique identifier for entity instance
        /// </summary>
        IObjectIdentifier<ulong> Id { get; }

        /// <summary>
        /// Data set necessary to issue an invoice
        /// </summary>
        IBillingInfoDefinition BillingInfo { get; }

        /// <summary>
        /// Contact information provided by entity
        /// </summary>
        IContactInfoDefinition ContactInfo { get; }
    }

}