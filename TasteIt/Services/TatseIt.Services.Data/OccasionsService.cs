using System;
using System.Collections.Generic;
using System.Linq;
namespace TatseIt.Services.Data
{
    using TasteIt.Data.Models;
    using TasteIt.Data.Repositories;
    using TasteIt.Services.Web.Contracts;
    using TatseIt.Services.Data.Contracts;

    public class OccasionsService : IOccasionsService
    {
        private IDbRepository<Occasion> occasins;
        private readonly IIdentifierProvider identifierProvider;

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
