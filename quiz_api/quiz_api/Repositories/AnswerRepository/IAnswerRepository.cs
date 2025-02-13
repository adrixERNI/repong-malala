using System;
using quiz_api.Entites;

namespace quiz_api.Repositories.AnswerRepository;

public interface IAnswerRepository
{
       Task<List<Answer>> GetAllAsync();
         Task<Answer> GetByIdAsync(int id);
}
