using AutoMapper;
using csharp_api_tutorial.Dto;
using csharp_api_tutorial.Models;

namespace csharp_api_tutorial.MapperProfile
{
    public class AutoMapperExcel : Profile
    {
        public AutoMapperExcel()
        {
            CreateMap<ExportUserDataExcelDTO, user_info>();
            CreateMap<user_info, ExportUserDataExcelDTO>();
        }
    }
}