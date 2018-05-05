using System;
using System.Collections.Generic;
using System.Text;

namespace NogometneIkone.Model
{
    public class Quiz : EntityBase
    {
        public string Name { get; set; }
        public int Time { get; set; }
        public int TotalScore { get; set; }
        public Difficulty Difficulty { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
