using SchoolManager.Services.Teacher.Domain.Teacher.HttpActions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Services.Teacher.Domain.Teacher.Interfaces
{
    public interface IBaseService : IDisposable
    {
        Task<T> SendAsync<T>(ApiRequest apiRequest);
    }
}
