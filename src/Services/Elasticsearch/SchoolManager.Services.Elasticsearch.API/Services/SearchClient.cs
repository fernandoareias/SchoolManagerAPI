using Elasticsearch.Models.Filters;
using Elasticsearch.Models.Teacher;
using Microsoft.Extensions.Configuration;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Elasticsearch.Services
{
    public class SearchClient : ISearchClient
    {
        private readonly ElasticClient client;

        public SearchClient(IConfiguration configuration)
        {
            var node = new Uri(configuration.GetValue<string>("ElasticCloud:Endpoint"));
            var settings = new ConnectionSettings(node);//.BasicAuthentication(configuration.GetValue<string>("ElasticCloud:BasicAuthUser"),
                        //configuration.GetValue<string>("ElasticCloud:BasicAuthPassword"));
            client = new ElasticClient(settings);
        }

        public async Task<Teacher> Create(Teacher teacher)
        {
            try
            {
                var response = await client.IndexAsync(teacher, idx => idx.Index("teacherindex"));

              

                return teacher;
            
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<Teacher> GetById(string id)
        {
            try
            {

                var response = client.Get<Teacher>(id, idx => idx.Index("teacherindex"));
                return await Task.FromResult(response.Source);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<List<Teacher>> Search(string name)
        {
            var response = await client.SearchAsync<Teacher>(
                s => s.Index("teacherindex").
                Query(
                    q => 
                        q.Match(
                            m => 
                                m.Field(
                                    f => f.Name.FirstName
                                ).Query(name)
                            )
                        )
                );

            return response.Documents.ToList();
        }

        public async Task<List<Teacher>> GetAll()
        {
            var response = await client.SearchAsync<Teacher>(
                s => 
                    s.Index("teacherindex")
                        .MatchAll());

            return response.Documents.ToList();

        }

        public async Task<object> GetByName(){
           return null;// var response = await client.SearchAsync<Teacher>(s => s.Query(q => q.Nested()))
        }
        public async Task<List<Teacher>> Search(Filters filtro)
        {
            var predicate = new List<Func<QueryContainerDescriptor<Teacher>, QueryContainer>>();

            if(!string.IsNullOrEmpty(filtro.id)){
                predicate.Add(t => t.Match(m => m.Field( f => f.Id).Query(filtro.id)));
            }

            if(!string.IsNullOrEmpty(filtro.courseId)){
                predicate.Add(t => t.Match(m => m.Field( f => f.CourseId).Query(filtro.courseId)));
            }

            if(!string.IsNullOrEmpty(filtro.nome)){
                predicate.Add(t => t.Match(m => m.Field( f => f.Name.FirstName).Query(filtro.nome)));
            }

            if(!string.IsNullOrEmpty(filtro.sobrenome)){
                predicate.Add(t => t.Match(m => m.Field( f => f.Name.LastName).Query(filtro.sobrenome)));
            }

            if(!string.IsNullOrEmpty(filtro.email)){
                predicate.Add(t => t.Match(m => m.Field( f => f.Email.Address).Query(filtro.email)));
            }

            var response = await client.SearchAsync<Teacher>(
                s => s.Index("teacherindex").Query(q => q.Bool(b => b.Filter(predicate)))
            );

            return response.Documents.ToList();
        }
    }
}
