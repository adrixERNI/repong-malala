using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using quiz_api.DTO.AnswerDTOs;
using quiz_api.Entites;
using quiz_api.Repositories.AnswerRepository;

namespace quiz_api.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class AnswerController : ControllerBase{
    private readonly IAnswerRepository _answerRepo;
    private readonly IMapper _mapper;

    private AnswerController(IAnswerRepository answerRepo, IMapper mapper){
        _answerRepo = answerRepo;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(){
        var answer = await _answerRepo.GetAllAsync();
        var answer_dto = _mapper.Map<List<AnswerDTO>>(answer);
        return Ok(answer_dto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByid(int id){
        var answer = await _answerRepo.GetByIdAsync(id);
        if(answer == null){
            return NotFound(new {message = "Id Not Found"});
        }
        var answer_dto = _mapper.Map<AnswerDTO>(answer);
        return Ok(answer_dto);
    }

}
