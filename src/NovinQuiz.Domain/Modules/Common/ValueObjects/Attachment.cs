using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Values;

namespace NovinQuiz.Modules.Common.ValueObjects
{
    public class Attachment : Entity<string>
    {
        public string Address { get; private set; }
        public string FileName { get; private set; }
        public string Alt { get; private set; }

        public Attachment(string address) => Address = Check.NotNullOrEmpty(address, nameof(address));

        public static implicit operator string(Attachment instance) => instance.Address;
    }
}
