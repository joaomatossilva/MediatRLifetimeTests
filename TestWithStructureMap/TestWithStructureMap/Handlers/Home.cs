using System;
using System.Threading.Tasks;
using MediatR;

namespace TestWithStructureMap.Handlers
{
    public static class Home
    {
        public class Query : IAsyncRequest<Model>
        {
            
        }

        public class Model
        {
            public DateTime Now { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Model>
        {
            public DateTime CreateDateTime;

            public QueryHandler()
            {
                CreateDateTime = DateTime.UtcNow;
            }

            public Task<Model> Handle(Query message)
            {
                return Task.FromResult(new Model {Now = CreateDateTime });
            }
        }
    }
}