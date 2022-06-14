using ainat_closet.Data.Entities;
using ainat_closet.Enums;
using ainat_closet.Helpers;

namespace ainat_closet.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCategoriesAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("Tania", "Durinda", "ainat_closet@hotmail.com", "3218120633", "No Disponible", UserType.Admin);
        }

        private async Task<User> CheckUserAsync(
        string firstName,
        string lastName,
        string email,
        string phone,
        string address,
        UserType userType)
        {
            User user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new User
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    City = _context.Cities.FirstOrDefault(),
                    UserType = userType,
                };

                await _userHelper.AddUserAsync(user, "ainatcloset123");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }


        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States =  new List<State>()
                    {
                        new State
                        {
                            Name = "Antioquia",
                            Cities = new List<City>()
                            {
                                new City { Name = "Medellín"},
                                new City { Name = "Envigado"},
                                new City { Name = "Itagui"},
                                new City { Name = "Bello"},
                                new City { Name = "Rionegro"},
                                new City { Name = "Caldas"},
                            }
                        },
                        new State
                        {
                            Name = "Amazonas",
                            Cities = new List<City>()
                            {
                                
                            }
                        },
                        new State
                        {
                            Name = "Arauca",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Atlántico",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Bogotá",
                            Cities = new List<City>()
                            {
                                new City() { Name = "Usaquen" },
                                new City() { Name = "Champinero" },
                                new City() { Name = "Santa fe" },
                                new City() { Name = "Useme" },
                                new City() { Name = "Bosa" },
                                new City() { Name = "Chia"},
                                new City() { Name = "Funza"},
                            }
                        },
                        new State
                        {
                            Name = "Bolívar",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Boyacá",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Caldas",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Caquetá",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Casanare",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Cauca",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Cesar",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Chocó",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Córdoba",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Cundinamarca",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Guainía",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Guaviare",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Huila",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "La Guajira",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Magdalena",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Meta",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Nariño",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Norte de Santander",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Putumayo",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Quindío",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Risaralda",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "San Andrés y Providencia",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Santander",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Sucre",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Tolima",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Valle del cauca",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Vaupés",
                            Cities = new List<City>()
                            {

                            }
                        },
                        new State
                        {
                            Name = "Vichada",
                            Cities = new List<City>()
                            {

                            }
                        }
                    }
                });
                _context.Countries.Add(new Country
                {
                    Name = "Estados Unidos",
                    States = new List<State>()
                    {
                        new State()
                        {
                            Name = "Florida",
                            Cities = new List<City>() {
                                new City() { Name = "Orlando" },
                                new City() { Name = "Miami" },
                                new City() { Name = "Tampa" },
                                new City() { Name = "Fort Lauderdale" },
                                new City() { Name = "Key West" },
                            }
                        },
                        new State()
                        {
                            Name = "Texas",
                            Cities = new List<City>() {
                                new City() { Name = "Houston" },
                                new City() { Name = "San Antonio" },
                                new City() { Name = "Dallas" },
                                new City() { Name = "Austin" },
                                new City() { Name = "El Paso" },
                            }
                        },
                    }
                });
            }
            await _context.SaveChangesAsync();
        }

        private async Task CheckCategoriesAsync()
        {
            if(!_context.Categories.Any())
            {
                _context.Categories.Add(new Category { Name = "Accesorios" });
                _context.Categories.Add(new Category { Name = "Pantalones" });
                _context.Categories.Add(new Category { Name = "Jean" });
                _context.Categories.Add(new Category { Name = "Chaquetas" });
                _context.Categories.Add(new Category { Name = "Vestidos" });
                _context.Categories.Add(new Category { Name = "Blusas" });
                _context.Categories.Add(new Category { Name = "Faldas" });
                _context.Categories.Add(new Category { Name = "Busos" });
                _context.Categories.Add(new Category { Name = "Short" });
                _context.Categories.Add(new Category { Name = "Ropa Interior" });
                _context.Categories.Add(new Category { Name = "Corsets" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
