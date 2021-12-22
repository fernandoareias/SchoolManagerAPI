using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Application.Responses
{
    internal class ResponseView : IResponse
    {
        public ResponseView(bool isSuccess, string menssage, object data)
        {
            IsSuccess = isSuccess;
            Menssage = menssage;
            Data = data;
        }

        public bool IsSuccess { get; set; }
        public string Menssage { get; set; }
        public object Data { get; set; }
    }
}
