﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetSlackMailAPI
{
    public class undefinedResponseException : Exception
    {
        public undefinedResponseException(string responseType, string Response) 
            : base ($"No response type of type {responseType} Found. Response: {Response}")
        {}
    }

    class ErrorResponseException : Exception
    {
        public string ErrorMessage { get; set; }
        public ErrorResponseException(string error, string responseType) : base($"Not OK response received for {responseType}, error message: {error}")
        {
            ErrorMessage = error;
        }
    }
}
