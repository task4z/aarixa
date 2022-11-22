using Aarixa.Models;

namespace Aarixa.Services.CitiesCommand
{
    public interface ICitiesCommand
    {
        Task<IEnumerable<City>> Get();
        Task Create(City city);
        Task Delete(int id);
        Task Update(City city);
    }
}
