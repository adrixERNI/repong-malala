using System;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using quiz_api.Data;
using quiz_api.DTO;
using quiz_api.Entites;

namespace quiz_api.Repositories;

public class QuizRepository : IQuizRepository{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public QuizRepository(ApplicationDbContext context, IMapper mapper){
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<Quiz>> GetAllAsync()
    {
        return await _context.Quizzes.ToListAsync();
    }

    public async Task<Quiz> GetByIdAsync(int id)
    {
        return await _context.Quizzes.FindAsync(id);
    }

    public async Task<Quiz> CreateAsync (Quiz quiz){
        await _context.Quizzes.AddAsync(quiz);
        await _context.SaveChangesAsync();
        return quiz;
    } 

    public async Task<Quiz> UpdateAsync (int id, QuizUpdateDTO quiz){
        var existingQuiz = await _context.Quizzes.FindAsync(id);
        if (existingQuiz == null){
            return null;
        }

        _mapper.Map(quiz, existingQuiz);
        await _context.SaveChangesAsync();
        return existingQuiz;

    }

    public async Task<Quiz> DeleteAsync(int id){
        var existingQuiz = await _context.Quizzes.FirstOrDefaultAsync(x => x.QuizId == id);
        if(existingQuiz == null) {
            return null;
        }

        _context.Quizzes.Remove(existingQuiz);
        await _context.SaveChangesAsync();
        return existingQuiz;
    }



}
