using Console.Models;
using eHealthApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eHealthApp.Business
{
    public interface IProviderService
    {
        void AddProvider(Provider provider);
        void LinkProviderToClaim(int providerId, MedicalClaim claim);
    }
}
