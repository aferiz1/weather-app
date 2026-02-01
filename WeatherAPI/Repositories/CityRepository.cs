using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;

namespace WeatherAPI.Repositories;

public class CityRepository : ICityRepository
{
    private readonly ApplicationDbContext _context;

    public CityRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<City>> GetAllAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task<City?> GetByNameAsync(string name)
    {
        return await _context.Cities
            .FirstOrDefaultAsync(c => c.Name.ToLower() == name.ToLower());
    }

    public async Task<City> AddAsync(City city)
    {
        _context.Cities.Add(city);
        await _context.SaveChangesAsync();
        return city;
    }
}


 

 

