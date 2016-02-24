namespace TatseIt.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TasteIt.Services.Web.Contracts;
    using TatseIt.Services.Data.Contracts;

    public class OccasionsService : IOccasionsService
    {
        private readonly IIdentifierProvider identifierProvider;
        private IDbRepository<Occasion> occasins;

        public OccasionsService(IDbRepository<Occasion> occasins, IIdentifierProvider identifierProvider)
        {
            this.occasins = occasins;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Occasion> GetAll()
        {
            var allOccasins = this.occasins.All();

            return allOccasins;
        }
    }
}
