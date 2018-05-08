using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Text;

namespace NogometneIkone.Model.DTO
{
    [NotMapped, DataContract]
    public class AnswerDTO
    {
        [DataMember]
        public string AnswerText { get; set; }
        [DataMember]
        public bool IsCorretAnswer { get; set; }
    }
}
