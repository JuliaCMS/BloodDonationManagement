using BloodDonationManagement.Models;

namespace BloodDonationManagement.Interfaces
{
    public interface IDonorRepository
    {
        Task<IEnumerable<Donor>> GetAll();
        Task<Donor> GetByIdAsync(int id);
        Task<Donor> GetByIdAsyncNoTracking(int id);
        Task<IEnumerable<Donor>> GetDonorByBloodType(string aboRhType);
        bool Add(Donor donor);
        bool Update(Donor donor);
        bool Delete(Donor donor);
        bool Save();
    }
}
