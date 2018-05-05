using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NogometneIkone.Model.DTO
{
    [NotMapped]
    public class QuestionDTO
    {
        public string QuestionText { get; set; }
        public int Time { get { return 60 / ((int)Difficulty + 1); } }
        public int Score { get { return ((int)Difficulty + 1) * 10; } }
        public Difficulty Difficulty { get; set; }
        public List<AnswerDTO> Answers { get; set; }
        
    }
}
