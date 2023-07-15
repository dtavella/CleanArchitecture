using Core.Entities;
using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Core.Services.Implementatios
{
    public class StudentService
    {
        private readonly DefaultContext2 _context;
        private readonly IConfiguration _configuration;
        private readonly ILogger<StudentService> _logger;
        private readonly CountryService _countryService;

        public StudentService(DefaultContext2 context, ILogger<StudentService> logger, CountryService countryService) 
        {
            _context = context;
            //_configuration = configuration;
            _logger = logger;
            _countryService = countryService;
        }

        public List<Student> GetAll()
        {
            var students = _context.Students
                            .Include(q => q.Country)
                            //.Where(q => q.DocumentNumber == "232323232")
                            .ToList();


            return students;
        }
    }
}
