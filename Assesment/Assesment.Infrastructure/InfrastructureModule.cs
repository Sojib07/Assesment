using Autofac;
using Assesment.Infrastructure.DbContexts;
using Assesment.Infrastructure.Repositories;
using Assesment.Infrastructure.Services;
using Assesment.Infrastructure.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assesment.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public InfrastructureModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorService>().As<IAuthorService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookService>().As<IBookService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<AuthorRepository>().As<IAuthorRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<StackOverflowService>().As<IStackOverflowService>()
                .InstancePerLifetimeScope();

            builder.RegisterType<BookRepository>().As<IBookRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ApplicationUnitOfWork>().As<IApplicationUnitOfWork>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DataUtility>().As<IDataUtility>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}