using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record SettingUpdateDto
    {
        public string Value { get; set; } = null!;
    }
}
