using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NogometneIkone.Model.DTO
{
    [NotMapped]
    public class QuizDTO
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public int TotalScore { get; set; }
        public Difficulty Difficulty { get; set; }
        public List<QuestionDTO> QuestionIDs { get; set; }
    }
}
