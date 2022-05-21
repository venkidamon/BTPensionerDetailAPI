using AutoMapper;
using PensionerDetail.Dtos;
using PensionerDetail.Entities;

namespace PensionerDetail
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserDto, PensionerDetails>();
                config.CreateMap<PensionerDetails, UserDto>();
            });
            return mappingConfig;
        }
    }
}
