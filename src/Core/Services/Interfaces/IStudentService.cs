﻿using Core.Dtos;
using Core.Entities;

namespace Core.Services.Interfaces
{
    public interface IStudentService
    {
        Task<StudentDto> Get(long id);
        Task<IList<StudentDto>> GetAll();
        Task Add(StudentAddDto entity);
        Task Update(Student entity);
        Task Delete(Student entity);
    }
}
