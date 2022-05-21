using PensionerDetail.Dtos;

namespace PensionerDetail.Repository
{
    public interface IPensionerRepository
    {
        Task<IEnumerable<UserDto>> GetPensioners();
        Task<UserDto> GetPensionerByAadhar(string aadharNumber);
        Task<UserDto> CreateUpdatePensioner(UserDto userDto);
        Task<bool> DeletePensioner(string aadharNumber);
    }
}
