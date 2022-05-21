using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PensionerDetail.Data;
using PensionerDetail.Dtos;
using PensionerDetail.Entities;

namespace PensionerDetail.Repository
{
    public class PensionerRepository : IPensionerRepository
    {
        private readonly DataContext _db;
        private IMapper _mapper;

        public PensionerRepository(DataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateUpdatePensioner(UserDto userDto)
        {
            PensionerDetails pensioner = _mapper.Map<UserDto, PensionerDetails>(userDto);
            if (pensioner.Id > 0)
            {
                _db.Pensioners.Update(pensioner);
            }
            else
            {
                _db.Pensioners.Add(pensioner);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<PensionerDetails, UserDto>(pensioner);
        }

        public async Task<bool> DeletePensioner(string aadharNumber)
        {
            try
            {
                PensionerDetails pensioner = await _db.Pensioners.FirstOrDefaultAsync(x => x.AadharNumber == aadharNumber);
                if (pensioner == null)
                {
                    return false;
                }
                _db.Pensioners.Remove(pensioner);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<UserDto> GetPensionerByAadhar(string aadharNumber)
        {
            PensionerDetails pensioner = await _db.Pensioners.Where(x => x.AadharNumber == aadharNumber).FirstOrDefaultAsync();
            return _mapper.Map<UserDto>(pensioner);
        }

        public async Task<IEnumerable<UserDto>> GetPensioners()
        {
            List<PensionerDetails> pensioners = await _db.Pensioners.ToListAsync();
            return _mapper.Map<List<UserDto>>(pensioners);
        }
    }
}
