using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NogometneIkone.Model
{
    public enum Difficulty
    {
        Beginner,
        Amateur,
        Normal,
        Professional,
        [Display(Name = "Top player")] TopPlayer,
        Superstar
    }

    public enum QuestionType
    {
        SingleAnswer, 
        MultipleAnswer,
        ABDC_Answer
    }
}
