using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NogometneIkone.Model
{
    public class Answer : EntityBase
    {
        public string AnswerText { get; set; }
        public bool IsCorretAnswer { get; set; }
        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }
    }
}
