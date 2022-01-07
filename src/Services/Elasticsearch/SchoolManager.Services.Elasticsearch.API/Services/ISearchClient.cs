using Elasticsearch.Models.Teacher;
using Nest;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Elasticsearch.Services
{
    public interface ISearchClient
    {
        Task<Teacher> GetById(string id);
        Task<List<Teacher>> Search(Elasticsearch.Models.Filters.Filters filtro);
        Task<List<Teacher>> GetAll();
        Task<object> GetByName();

        Task<Teacher> Create(Teacher teacher);
    }
}
