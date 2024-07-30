using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechnicalAxos_NahuelSalomon.Models;

namespace TechnicalAxos_NahuelSalomon.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetAllAsync();
    }
}
