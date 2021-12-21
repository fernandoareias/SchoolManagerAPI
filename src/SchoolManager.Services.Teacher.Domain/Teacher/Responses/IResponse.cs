using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Response
{
     public interface IResponse
    {
      
        bool IsSuccess { get; set; } 
        string Menssage { get; set; }        
    }
}
