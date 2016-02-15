namespace TasteIt.Web.Controllers
{
    using AutoMapper;
    using System.Web.Mvc;
    using TasteIt.Web.Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        //public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}