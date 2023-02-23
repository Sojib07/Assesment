using Assesment.Infrastructure.UnitOfWorks;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using AuthorBO = Assesment.Infrastructure.BusinessObjects.Author;
using AuthorEO = Assesment.Infrastructure.Entities.Author;

namespace Assesment.Infrastructure.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IApplicationUnitOfWork _applicationUnitOfWork;
        private readonly IMapper _mapper;
        private readonly string _connectionString;

        public AuthorService(IMapper mapper, IApplicationUnitOfWork applicationUnitOfWork, IConfiguration configuration)
        {
            _applicationUnitOfWork = applicationUnitOfWork;
            _mapper = mapper;
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IList<AuthorBO>> GetAllAuthors()
        {
            IList<AuthorEO> authors= _applicationUnitOfWork.Authors.GetAll();
            IList<AuthorBO> authorsBO=new List<AuthorBO>();
            foreach(AuthorEO author in authors)
            {
                var authorBO = _mapper.Map<AuthorBO>(author);
                authorsBO.Add(authorBO);
            }

            return authorsBO;
        }

        public async Task<IList<AuthorBO>> GetAllAuthorsWithStoredProcedure()
        {
            var authorsEO = await _applicationUnitOfWork.Authors.GetAuthorsAsync(_connectionString, "GetAuthors");
            var authorsBO = new List<AuthorBO>();
            foreach (var author in authorsEO)
            {
                var authorBO = _mapper.Map<AuthorBO>(author);
                authorsBO.Add(authorBO);
            }
            return authorsBO;
        }
    }
}