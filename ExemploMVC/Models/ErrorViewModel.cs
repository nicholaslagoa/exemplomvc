using System;

namespace ExemploMVC.Models
{
    public class ErrorViewModel//model de erro criado pela IDE, default
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
