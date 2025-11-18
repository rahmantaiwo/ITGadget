using ITGadgetSite.Model.Entities;

namespace ITGadgetSite.Database.Interfaces
{
    public interface IGadgetRepository
    {
        Task<ITGadget> AddAsync(ITGadget iTGadget, CancellationToken cancellationToken);
        Task UpdateAsync(ITGadget iTGadget, CancellationToken cancellationToken);
        Task DeleteAsync(ITGadget iTGadget, CancellationToken cancellationToken);
        Task<IEnumerable<ITGadget>> GetAllAsync(CancellationToken cancellationToken);
        Task<ITGadget> GetByIdAsync(Guid id,  CancellationToken cancellationToken);
        Task<ITGadget> GetByNameAsync(string name, CancellationToken cancellationToken);
    }
}
