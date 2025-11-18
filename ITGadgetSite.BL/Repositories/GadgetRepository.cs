using ITGadgetSite.Database.Data;
using ITGadgetSite.Database.Interfaces;
using ITGadgetSite.Model.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace ITGadgetSite.BL.Repositories
{
    public class GadgetRepository(AppDbContext dbContext) : IGadgetRepository
    {
        public async Task<ITGadget> AddAsync(ITGadget iTGadget, CancellationToken cancellationToken)
        {
            dbContext.Gadgets.AddAsync(iTGadget);
            await dbContext.SaveChangesAsync();
            return iTGadget;
        }

        public async Task DeleteAsync(ITGadget iTGadget, CancellationToken cancellationToken)
        {
            dbContext.Gadgets.Remove(iTGadget);
            await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<ITGadget>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await dbContext.Gadgets.ToListAsync();
        }

        public async Task<ITGadget> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await dbContext.Gadgets.FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task<ITGadget> GetByNameAsync(string name, CancellationToken cancellationToken)
        {
            return await dbContext.Gadgets.FirstOrDefaultAsync(i => i.GadgetName == name);
        }

        public Task UpdateAsync(ITGadget iTGadget, CancellationToken cancellationToken)
        {
            dbContext.Gadgets.Update(iTGadget);
            return dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
