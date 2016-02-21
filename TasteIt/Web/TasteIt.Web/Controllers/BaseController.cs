﻿namespace TasteIt.Web.Controllers
{
    using System.Web.Mvc;
    using AutoMapper;
    using Services.Web.Contracts;
    using TasteIt.Web.Infrastructure.Mapping;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }

        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}