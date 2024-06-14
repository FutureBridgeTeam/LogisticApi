﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogisticApi.Application.DTOs
{
    public record SettingCreateDto
    {
        public string Key { get; set; } = null!;
        public string Value { get; set; } = null!;
    }
}
