using System;
using quiz_api.Entites;

namespace quiz_api.DTO.AnswerDTOs;

public class AnswerGETDTO{
    public int AnswerId {get; set;}
    public string Option {get; set;}
    public bool Is_True {get; set;}

    public int QuizId {get; set;}
    public Quiz Quiz {get; set;}
}
