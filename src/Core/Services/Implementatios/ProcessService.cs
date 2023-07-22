using Core.Dtos;
using Core.Services.Interfaces;

namespace Core.Services.Implementatios
{
    public class ProcessService
    {
        private readonly IFileService _fileService;

        public ProcessService(IFileService service)
        {
            _fileService = service;
        }

        public async Task<IList<DataFileDto>> Process()
        {
            var data = await _fileService.GetDataFile();


            var dataFiltered = new List<DataFileDto>();
            
            // logica de negocio
            foreach(var d in data)
            {
                if (d.Value.ToLower().Equals("tavella"))
                    continue;

                dataFiltered.Add(d);
            }


            return dataFiltered;
        }
    }
}
