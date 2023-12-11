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
    public sealed class Attachment(string address, string fileName, string alt, string type) : Entity<int>
    {
        public string Address { get; } = Check.NotNullOrEmpty(address, nameof(address));
        public string FileName { get; } = Check.NotNullOrEmpty(fileName, nameof(fileName));
        public string Alt { get; } = Check.NotNullOrEmpty(alt, nameof(alt));
        public string Type { get; } = Check.NotNullOrEmpty(type, nameof(type));

        public static implicit operator string(Attachment instance) => instance.Address;
    }
}
