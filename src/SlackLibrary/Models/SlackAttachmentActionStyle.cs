﻿using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;

namespace SlackLibrary.Models
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SlackActionStyle
    {
        [EnumMember(Value = "default")]
        Default,
        [EnumMember(Value = "primary")]
        Primary,
        [EnumMember(Value = "danger")]
        Danger
    }
}