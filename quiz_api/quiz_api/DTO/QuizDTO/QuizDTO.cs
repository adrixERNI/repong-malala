using System;
using quiz_api.DTO.AnswerDTOs;
using quiz_api.Entites;

namespace quiz_api.DTO;

public class QuizDTO{

   public string Question {get; set;}
    public ICollection<AnswerDTO> Answers { get; set; } 
    
}
