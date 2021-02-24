using System.Collections.Generic;
using System.Threading.Tasks;
using AdvertApi.SearchApi.Models;

namespace AdvertApi.SearchApi.Services
{
    public interface ISearchService
    {
        Task<List<AdvertType>> Search(string keyword);
    }
}