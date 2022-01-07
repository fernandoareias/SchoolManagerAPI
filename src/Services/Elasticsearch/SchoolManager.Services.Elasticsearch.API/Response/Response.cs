using Elasticsearch.Models.Teacher;
using System.Collections.Generic;

namespace Elasticsearch.Response
{
    public class Response
    {
        public string SearchText { get; set; }

        public List<Teacher> Results { get; set; }
    }
}
