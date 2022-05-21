using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PensionerDetail.Data;
using PensionerDetail.Dtos;
using PensionerDetail.Repository;

namespace PensionerDetail.Controllers
{
    [Authorize]
    [Route("api/pensionerDetailByAadhar")]
    public class PensionerDetailController : ControllerBase
    {
        private IPensionerRepository _pensionerRepository;

        public PensionerDetailController(IPensionerRepository pensionerRepository)
        {
            this._pensionerRepository = pensionerRepository;
        }

        [HttpGet]
        public async Task<object> GetPensioners()
        {
            try
            {
                IEnumerable<UserDto> userDtos = await _pensionerRepository.GetPensioners();
                return userDtos;
            }
            catch (Exception ex)
            {
                throw new Exception("Error --> " + ex.Message);
            }

            
        }
        [HttpGet]
        [Route("{aadharNumber}")]
        public async Task<object> GetPensionerByAadhar(string aadharNumber)
        {
            try
            {
                UserDto userDto = await _pensionerRepository.GetPensionerByAadhar(aadharNumber);
                return userDto;
            }
            catch (Exception ex)
            {
                throw new Exception("Error --> " + ex.Message);
            }
            
        }

        [HttpPost]
        public async Task<object> Post([FromBody] UserDto userDto)
        {
            try
            {
                UserDto userDtos = await _pensionerRepository.CreateUpdatePensioner(userDto);
                return userDtos;
            }
            catch (Exception ex)
            {

                throw new Exception("Error --> " + ex.Message);

            }
            
        }


        [HttpPut]
        public async Task<object> Put([FromBody] UserDto userDto)
        {
            try
            {
                UserDto userDtos = await _pensionerRepository.CreateUpdatePensioner(userDto);
                return userDtos;
            }
            catch (Exception ex)
            {

                throw new Exception("Error --> " + ex.Message);

            }
                       
        }

        [HttpDelete]
        public async Task<object> Delete(string aadharNumber)
        {
            try
            {
                bool userDtos = await _pensionerRepository.DeletePensioner(aadharNumber);
                return userDtos;
            }
            catch (Exception ex)
            {

                throw new Exception("Error --> " + ex.Message);

            }
            
        }


      
    }
}
