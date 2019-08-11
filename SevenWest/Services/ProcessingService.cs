using System;
using System.Collections.Generic;
using System.Linq;
using NLog;
using SevenWest.Models;
using SevenWest.Repositories;

namespace SevenWest.Services
{
    public class ProcessingService : IProcessor
    {
        private readonly IRepository<IList<Person>> _repository;
        private readonly ILogger _logger;

        public ProcessingService(IRepository<IList<Person>> repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void Process()
        {
            _logger.Info("Start processing");

            var persons = _repository.GetAllData();

            //The users full name for id=42
            var usersId42 = persons
                .Where(person => person.Id == 42);

            Console.WriteLine("Users with ID=42");
            foreach (var user in usersId42)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
            Console.WriteLine("#################");

            //All the users first names (comma separated) who are 23
            var usersAge23 = persons
                .Where(person => person.Age == 23);

            Console.WriteLine("Users aged 23");

            var names = string.Join(",", usersAge23.Select(users => users.FirstName));
            Console.WriteLine(names);
            Console.WriteLine("#################");

            //The number of genders per Age, displayed from youngest to oldest
            var groupedUsers = persons
                .GroupBy(g => g.Age)
                .OrderBy(o => o.Key);

            foreach (var groupedUser in groupedUsers)
            {
                var users = groupedUser.ToList();
                var numberMales = users.Count(user => user.Gender == Gender.Male);
                var numberFemales = users.Count(user => user.Gender == Gender.Female);

                Console.WriteLine($"Age: {groupedUser.Key} Female: {numberFemales} Male: {numberMales}");
            }
        }
    }
}
