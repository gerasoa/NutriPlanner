using CCRS.Core.Data;
using CCRS.Core.DomainObjects;
using CCRS.Core.Mediator;
using CCRS.Core.Messages;
//using CCRS.User.API.Models.Models;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace CCRS.User.API.Models.Data
{
    public sealed class UserProfessionalContext : DbContext, IUnifOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public UserProfessionalContext(DbContextOptions<UserProfessionalContext> options, IMediatorHandler mediatorHandler) 
            : base(options)
        {
            _mediatorHandler = mediatorHandler;
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        // Table mappings EF
        public DbSet<UserProfessional> UserProfessional { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(200)");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserProfessionalContext).Assembly);
        }

        public async Task<bool> Commit()
        {
            var success = await base.SaveChangesAsync() > 0;
            if(success) await _mediatorHandler.PublishEvents(this);

            return success;
        }
    }

    public static class MediatorExtension
    {
        public static async Task PublishEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Notifications != null && x.Entity.Notifications.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Notifications)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.CleanEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) =>
                {
                    await mediator.EventPublish(domainEvent);
                });

            //foreach (var task in domainEvents)
            //{
            //    await mediator.EventPublish(task);
            //}

            await Task.WhenAll(tasks);
        }
    }

}
