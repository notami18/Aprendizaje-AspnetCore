using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private WorldContext _context;
        private UserManager<WorldUser> _userManager;

        public WorldContextSeedData(WorldContext context, UserManager<WorldUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnsureSeedDate()
        {
            if (await _userManager.FindByEmailAsync("sam.hastings@theworld.com") == null)
            {
                var user = new WorldUser()
                {
                    UserName = "samhastings", 
                    Email = "sam.hastings@theworld.com"
                };

                await _userManager.CreateAsync(user, "P@ssw0rd!");
            }

            if (!_context.Trips.Any())
            {
                var ustrip = new Trip()
                {
                    DateCreate = DateTime.UtcNow,
                    Name = "US Trip",
                    UserName = "samhastings",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Milton", Arrival = new DateTime(2017, 08, 4), Latitude = 33.451245,  Order = 0},
                        new Stop() { Name = "Jose", Arrival = new DateTime(2017, 08, 5), Latitude = 33.451245,  Order = 1},
                        new Stop() { Name = "Carlos", Arrival = new DateTime(2017, 08, 23), Latitude = 33.451245,  Order = 2},
                        new Stop() { Name = "Andrea", Arrival = new DateTime(2017, 08, 12), Latitude = 33.451245,  Order = 3},
                        new Stop() { Name = "Esteban", Arrival = new DateTime(2017, 08, 12), Latitude = 33.451245,  Order = 4},
                        new Stop() { Name = "Cristian", Arrival = new DateTime(2017, 08, 6), Latitude = 33.451245,  Order = 5}
                    }
                };
                _context.Trips.Add(ustrip);
                _context.Stops.AddRange(ustrip.Stops);

                var wordlTrip = new Trip()
                {
                    DateCreate = DateTime.UtcNow, 
                    Name = "WorldTrip",
                    UserName = "samhastings",
                    Stops = new List<Stop>()
                    {
                        new Stop() { Name = "Milton", Arrival = new DateTime(2017, 08, 4), Latitude = 33.451245,  Order = 0},
                        new Stop() { Name = "Jose", Arrival = new DateTime(2017, 08, 5), Latitude = 33.4512452,  Order = 1},
                        new Stop() { Name = "Carlos", Arrival = new DateTime(2017, 08, 23), Latitude = 33.5653665,  Order = 2},
                        new Stop() { Name = "Andrea", Arrival = new DateTime(2017, 08, 12), Latitude = 33.765676,  Order = 3},
                        new Stop() { Name = "Esteban", Arrival = new DateTime(2017, 08, 12), Latitude = 33.754554,  Order = 4},
                        new Stop() { Name = "Cristian", Arrival = new DateTime(2017, 08, 6), Latitude = 33.6543456,  Order = 5},

                        new Stop() { Name = "Roberto", Arrival = new DateTime(2017, 08, 4), Latitude = 33.546655,  Order = 6},
                        new Stop() { Name = "Micols", Arrival = new DateTime(2017, 08, 5), Latitude = 33.4776764,  Order = 7},
                        new Stop() { Name = "Rosa", Arrival = new DateTime(2017, 08, 23), Latitude = 33.4875676,  Order = 8},

                    }
                };

                _context.Trips.Add(wordlTrip);
                _context.Stops.AddRange(wordlTrip.Stops);

                await _context.SaveChangesAsync();

            }
        }
    }
}
