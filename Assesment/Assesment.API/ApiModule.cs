using Assesment.API.Models;
using Autofac;

namespace FirstDemo.Api
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookModel>().AsSelf();

            builder.RegisterType<AuthorModel>().AsSelf();

            base.Load(builder);
        }
    }
}
