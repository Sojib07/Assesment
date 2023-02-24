using Assesment.Web.Models;
using Autofac;

namespace Assesment.Web
{
    public class WebModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<QuestionModel>().AsSelf();
            builder.RegisterType<AnswerModel>().AsSelf();

            base.Load(builder);
        }
    }
}