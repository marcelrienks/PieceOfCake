using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Data.Models;

namespace Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        /// <summary>
        ///     Overrides the Seed method with custom seeds
        /// </summary>
        /// <param name="context"></param>
        protected override void Seed(Context context)
        {
            SeedRoles(context);
            SeedUsers(context);
        }

        /// <summary>
        ///     This method seeds the database with Roles
        /// </summary>
        /// <param name="context"></param>
        private void SeedRoles(Context context)
        {
            if (context.Roles.Any()) return;

            var roles = new List<Role>
            {
                new Role
                {
                    Title = "Administrator",
                    Description = "God like access"
                },
                new Role
                {
                    Title = "Team Member",
                    Description = "Person who does all the grunt work"
                },
            };

            roles.ForEach(role => context.Roles.AddOrUpdate(roleType => roleType.Id, role));
            context.SaveChanges();
        }

        /// <summary>
        ///     This method seeds the database with Users
        /// </summary>
        /// <param name="context"></param>
        private void SeedUsers(Context context)
        {
            if (context.Users.Any()) return;

            var users = new List<User>
            {
                new User
                {
                    Name = "Marcel Rienks",
                    Username = "marcelr",
                    Password = "E3mc2rd!",
                    Email = "marcelrienks@gmail.com",
                    Roles =
                        context.Roles.Where(role => role.Title == "Administrator" || role.Title == "Team Member")
                            .ToList()
                }
            };

            users.ForEach(user => context.Users.AddOrUpdate(userType => userType.Id, user));
            context.SaveChanges();
        }
    }
}