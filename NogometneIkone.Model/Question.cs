using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NogometneIkone.Model
{
    public class Question : EntityBase
    {
        public string QuestionText { get; set; }
        public string Fact { get; set; }
        public string FactURL { get; set; }
        public int Time { get; set; }
        public int Score { get; set; }

        public Difficulty Difficulty { get; set; }

        public QuestionType QuestionType { get; set; }
        public virtual ICollection<Answer> Answers { get; set; }
        [ForeignKey("Quiz")]
        public int QuizID { get; set; }
        public virtual Quiz Quiz { get; set; }
    }
}
