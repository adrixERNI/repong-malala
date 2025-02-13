using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using quiz_api.Data;
using quiz_api.Entites;

namespace quiz_api.Repositories.AnswerRepository;

public class AnswerRepository : IAnswerRepository{

    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public AnswerRepository(ApplicationDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Answer>> GetAllAsync()
    {
        return await _context.Answers.ToListAsync();
    }

    public async Task<Answer> GetByIdAsync(int id)
    {
        return await _context.Answers.FindAsync(id);
    }   
}
