﻿using ainat_closet.Data.Entities;
using ainat_closet.Enums;
using ainat_closet.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ainat_closet.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private readonly IBlobHelper _blobHelper;

        public SeedDb(DataContext context, IUserHelper userHelper, IBlobHelper blobHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _blobHelper = blobHelper;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckCountriesAsync();
            await CheckRolesAsync();
            await CheckUserAsync("Ainat", "Closet", "ainat_closet@hotmail.com", "0000000000", "No Disponible", UserType.Admin);
        }

        private async Task CheckCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                _context.Countries.Add(new Country
                {
                    Name = "Colombia",
                    States = new List<State>()
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
            }
            await _context.SaveChangesAsync();
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

                string token = await _userHelper.GenerateEmailConfirmationTokenAsync(user);
                await _userHelper.ConfirmEmailAsync(user, token);
            }
            return user;
        }

        private async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

    }
}
