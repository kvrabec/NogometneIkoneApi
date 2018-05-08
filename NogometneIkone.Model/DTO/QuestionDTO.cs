using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace NogometneIkone.Model.DTO
{
    [NotMapped, DataContract]
    public class QuestionDTO
    {
        [DataMember]
        public string QuestionText { get; set; }
        [DataMember]
        public int Time { get { return 60 / ((int)Difficulty + 1); } }
        [DataMember]
        public int Score { get { return ((int)Difficulty + 1) * 10; } }
        [DataMember]
        public Difficulty Difficulty { get; set; }
        [DataMember]
        public List<AnswerDTO> Answers { get; set; }
        
    }
}
