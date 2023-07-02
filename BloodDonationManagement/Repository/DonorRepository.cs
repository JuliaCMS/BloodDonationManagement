using BloodDonationManagement.DataAcessLayer;
using BloodDonationManagement.Interfaces;
using BloodDonationManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace BloodDonationManagement.Repository
{
    public class DonorRepository : IDonorRepository
    {
        private readonly DBContext _context;

        public DonorRepository(DBContext context)
        {
            _context = context;
        }

        public bool Add(Donor donor)
        {
            _context.Add(donor);
            return Save();
        }

        public bool Delete(Donor donor)
        {
            _context.Remove(donor);
            return Save();
        }

        public async Task<IEnumerable<Donor>> GetAll()
        {
            return await _context.Donors.Include(i => i.Address).Include(i => i.BloodType).ToListAsync();
        }

        public async Task<Donor> GetByIdAsync(int id)
        {
            return await _context.Donors.Include(i => i.Address).Include(i => i.BloodType).FirstOrDefaultAsync(i => i.Id == id);
        }

		public async Task<Donor> GetByIdAsyncNoTracking(int id)
		{
			return await _context.Donors.Include(i => i.Address).Include(i => i.BloodType).AsNoTracking().FirstOrDefaultAsync(i => i.Id == id);
		}

		public async Task<IEnumerable<Donor>> GetDonorByBloodType(string aboRhType)
        {
            return await _context.Donors.Where(d => d.BloodType.AboRhType.Contains(aboRhType)).ToListAsync();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }              

        public bool Update(Donor donor)
        {
            _context.Update(donor);
            return Save();
        }

    }
}
