using Console.Models;
using eHealthApp.Business;
using eHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Services.Data
{
    public class ProviderService : IProviderService
    {
        private readonly List<Provider> _providers = new();
        private readonly List<MedicalClaim> _claims = new();

        public IEnumerable<Provider> GetAll() => _providers;

        public Provider? GetById(int id) => _providers.FirstOrDefault(p => p.Id == id);

        public void AddProvider(Provider provider)
        {
            _providers.Add(provider);
        }

        public void LinkProviderToClaim(int providerId, MedicalClaim claim)
        {
            var provider = GetById(providerId);
            if (provider != null)
            {
                claim.ProviderId = providerId;
                claim.Provider = provider;
                _claims.Add(claim);
            }
        }
    }
}
