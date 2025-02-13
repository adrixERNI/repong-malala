using System;

namespace quiz_api.DTO.AnswerDTOs;

public class AnswerDTO{

    public string Option {get; set;}
    public bool Is_True {get; set;}

    public int QuizId {get; set;}
 
}
