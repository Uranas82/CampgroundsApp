﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RestAPI.Models.Firebase.ResponseModels
{
    public class ErrorResponseModel
    {
        [JsonPropertyName("error")]
        public ErrorContent Error { get; set; }
    }
}
