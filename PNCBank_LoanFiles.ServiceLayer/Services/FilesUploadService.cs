using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PNCBank_LoanFiles.RepositoryLayer;
using PNCBank_LoanFiles.BusinessEntities;
using PNCBank_LoanFiles.BusinessEntities.Interfaces;
using AutoMapper;
using System.Security.Principal;
namespace PNCBank_LoanFiles.ServiceLayer.Services
{
    public class FilesUploadService : IFilesUploadService
    {
        public readonly IFilesUploadRepository _filesUploadRepository;
        private readonly IMapper _mapper;
        public FilesUploadService(IFilesUploadRepository filesUploadRepository, IMapper mapper)
        {
            this._filesUploadRepository = filesUploadRepository;
            this._mapper = mapper;
        }
        public  async Task<List<FileUploadDTO>> GetFileUploadList()
        {
            var fileUploadList = await _filesUploadRepository.GetFileUploadList();
            return _mapper.Map<List<FileUploadDTO>>(fileUploadList);
        }
        public async Task<FileUploadResponse> AddFileUpload(FileUploadDTO fileUploadDTO)//sourcemodelobject
        {
            // 1)Auto mapper is used to create a mapping between  to source model object to destination model object
            FileUpload obj = new FileUpload();//destinationmodelclass object
            _mapper.Map(fileUploadDTO,obj);
            var result = await _filesUploadRepository.AddFileUpload(obj);
            return result;

        }

        public async Task<FileUploadDTO> GetFileUploadDetailsById(int Id)
        {
            var result = await _filesUploadRepository.GetFileUploadDetailsById(Id);
            FileUploadDTO fileUploadDTO = new FileUploadDTO();
            fileUploadDTO.ModifiedFilename = result.ModifiedFilename;
            return fileUploadDTO;
        }
    }
}
