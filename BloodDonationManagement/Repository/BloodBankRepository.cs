using BloodDonationManagement.DataAcessLayer;
using BloodDonationManagement.Interfaces;
using BloodDonationManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManagement.Repository
{
    public class BloodBankRepository : IBloodBankRepository
    {
        private readonly DBContext _context;

        public BloodBankRepository(DBContext context)
        {
            _context = context;
        }

        public bool Add(BloodBank bloodBank)
        {
            _context.Add(bloodBank);
            return Save();
        }

        public bool Delete(BloodBank bloodBank)
        {
            _context.Remove(bloodBank);
            return Save();
        }

        public async Task<IEnumerable<BloodBank>> GetAll()
        {
            return await _context.BloodBanks.Include(i => i.Address).Include(i => i.BloodInventory).ToListAsync();
        }

        public async Task<BloodBank> GetByIdAsync(int id)
        {
            return await _context.BloodBanks.Include(i => i.Address).Include(i => i.BloodInventory).FirstOrDefaultAsync(i => i.Id == id);
            //return await _context.BloodBanks.FirstOrDefaultAsync();
        }

		public async Task<BloodBank> GetByIdAsyncNoTracking(int id)
		{
			return await _context.BloodBanks.Include(i => i.Address).Include(i => i.BloodInventory).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
		}

		public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(BloodBank bloodBank)
        {
            _context.Update(bloodBank);
            return Save();
        }
    }
}
