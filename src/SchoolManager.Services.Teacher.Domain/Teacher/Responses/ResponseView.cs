using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Response
{
    public class ResponseView : IResponse
    {
        public ResponseView()
        {

        }

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
