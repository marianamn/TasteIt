﻿namespace TasteIt.Web.Models.Manages
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }

        public ICollection<SelectListItem> Providers { get; set; }
    }
}