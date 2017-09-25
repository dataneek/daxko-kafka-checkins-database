namespace SeedApp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Bogus;
    using Bogus.DataSets;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Models;

    class Program
    {
        static int[] SourceIdentifiers = new[] { 1, 2, 3 };

        static void Main(string[] args)
        {
            var connectionString = GetConnectionString();

            var batchId = Guid.NewGuid();
            var members = GenerateRandomMembers(100, batchId);
            var locations = GenerateRandomLocations(20, batchId);
            var locationCheckins = GenerateRandomLocationCheckins(200, members, locations, batchId);


            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                foreach (var member in members)
                    context.Members.Add(member);

                foreach (var location in locations)
                    context.Locations.Add(location);

                foreach (var t in locationCheckins)
                    context.LocationCheckins.Add(t);

                context.SaveChanges();
            }
        }

        static string GetConnectionString()
        {
            var configuration =
                new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();

            return configuration.GetConnectionString("Default");
        }

        static Member[] GenerateRandomMembers(int numberToGenerate, Guid batchId)
        {
            return
                Enumerable.Range(0, numberToGenerate)
                    .Select(t =>
                    {
                        var gender = (t % 2) == 0 ? Name.Gender.Male : Name.Gender.Female;

                        return
                            new Faker<Member>()
                                .RuleFor(r => r.FirstName, s => s.Name.FirstName(gender))
                                .RuleFor(r => r.LastName, s => s.Name.LastName(gender))
                                .RuleFor(r => r.SourceId, s => s.PickRandom(SourceIdentifiers))
                                .RuleFor(r => r.SourceRowId, s => Guid.NewGuid())
                                .RuleFor(r => r.BatchId, batchId)
                                .Generate();
                    })
                    .ToArray();
        }

        static Location[] GenerateRandomLocations(int numberToGenerate, Guid batchId)
        {
            return
                Enumerable.Range(0, numberToGenerate)
                    .Select(t =>
                    {
                        return
                            new Faker<Location>()
                                 .RuleFor(r => r.LocationName, s => s.Company.CompanyName())
                                 .RuleFor(r => r.SourceId, s => s.PickRandom(SourceIdentifiers))
                                 .RuleFor(r => r.SourceRowId, Guid.NewGuid())
                                 .RuleFor(r => r.BatchId, batchId)
                                 .Generate();
                    })
                    .ToArray();
        }

        static LocationCheckin[] GenerateRandomLocationCheckins(int numberToGenerate, IEnumerable<Member> members, IEnumerable<Location> locations, Guid batchId)
        {
            var random = new Randomizer();
            return
                Enumerable.Range(0, numberToGenerate)
                    .Select(t =>
                    {
                        var sourceId = random.ArrayElement(SourceIdentifiers);
                        return
                            new Faker<LocationCheckin>()
                                .RuleFor(r => r.Member, s => s.PickRandom(members.Where(e => e.SourceId == sourceId).ToList()))
                                .RuleFor(r => r.Location, s => s.PickRandom(locations.Where(e => e.SourceId == sourceId).ToList()))
                                .RuleFor(r => r.CheckinCompleted, s => s.Date.Between(DateTime.Now.AddYears(-1), DateTime.Now))
                                .RuleFor(r => r.SourceId, sourceId)
                                .RuleFor(r => r.SourceRowId, Guid.NewGuid())
                                .RuleFor(r => r.BatchId, batchId)
                                .Generate();
                    })
                    .ToArray();
        }
    }
}