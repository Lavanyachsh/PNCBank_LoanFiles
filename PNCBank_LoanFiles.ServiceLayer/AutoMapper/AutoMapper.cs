using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNCBank_LoanFiles.BusinessEntities;
using PNCBank_LoanFiles.RepositoryLayer;

namespace PNCBank_LoanFiles.ServiceLayer
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<FileUploadDTO, FileUpload>();
            CreateMap<FileUpload, FileUploadDTO>();

            //CreateMap<PgAccountDTO, PgAccount>();
            //CreateMap<PgAccount, PgAccountDTO>();
        }
    }
}
