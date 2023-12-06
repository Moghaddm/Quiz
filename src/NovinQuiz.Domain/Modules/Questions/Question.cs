using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities;

namespace NovinQuiz.Modules.Questions
{
    public class Question : Entity<string>
    {
        public byte Score { get; set; }
    }
}
