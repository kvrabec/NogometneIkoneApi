using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace NogometneIkone.Model.DTO
{
    [NotMapped, DataContract]
    public class QuizDTO
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Time { get; set; }
        [DataMember]
        public int TotalScore { get; set; }
        [DataMember]
        public Difficulty Difficulty { get; set; }
        [DataMember]
        public List<QuestionDTO> QuestionIDs { get; set; }
    }
}
