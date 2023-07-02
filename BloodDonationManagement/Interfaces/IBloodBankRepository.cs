using BloodDonationManagement.Models;

namespace BloodDonationManagement.Interfaces
{
    public interface IBloodBankRepository
    {
        Task<IEnumerable<BloodBank>> GetAll();
        Task<BloodBank> GetByIdAsync(int id);
		Task<BloodBank> GetByIdAsyncNoTracking(int id);
		bool Add(BloodBank bloodBank);
        bool Update(BloodBank bloodBank);
        bool Delete(BloodBank bloodBank);
        bool Save();
    }
}
