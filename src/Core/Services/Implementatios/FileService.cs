using Core.Dtos;
using Core.Services.Interfaces;
using Newtonsoft.Json;

namespace Core.Services.Implementatios
{
    public class FileService : IFileService
    {
        public async Task<IList<DataFileDto>> GetDataFile()
        {
            // esta seria la api que tardaria 20 minutos
            var url = "https://localhost:7153/api/file";

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            var jsoncontent = await response.Content.ReadAsStringAsync();

            var dtoList = JsonConvert.DeserializeObject<IList<DataFileDto>>(jsoncontent);

            return dtoList;
        }
    }
}
