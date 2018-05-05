using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NogometneIkone.Model.DTO
{
    [NotMapped]
    public class AnswerDTO
    {
        public string AnswerText { get; set; }
        public bool IsCorretAnswer { get; set; }
    }
}
