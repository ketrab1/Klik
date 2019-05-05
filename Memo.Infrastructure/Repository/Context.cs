using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using Memo.Core;
using Memo.Domain.WordAggregate;
using Memo.Domain.WordsModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Memo.Infrastructure.Repository
{
    public class Context : DbContext
    {
        private readonly IMediator _mediator;

        public Context(DbContextOptions<Context> options) : base(options)
        {
  
        }

        public DbSet<Word> Words { get; set; }
        public DbSet<WordStatistic> WordStatistics { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Word>()
                .HasOne(x => x.WordStatistic)
                .WithOne(y => y.Word)
                .HasForeignKey<WordStatistic>(x => x.WordId);
            modelBuilder.Entity<Word>().Property(x => x.CreateDate);
            modelBuilder.Entity<Word>().Property(x => x.Value);
            modelBuilder.Entity<Word>().Property(x => x.Translation);
            modelBuilder.Entity<Word>().Property(x => x.DifficultyWord);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            await DispatchDomainEventsAsync();
           return await base.SaveChangesAsync(cancellationToken);
        }


        public async Task DispatchDomainEventsAsync()
        {
            var domainEntities = ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.Events != null && x.Entity.Events.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.Events)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomianEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await _mediator.Publish(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }

  
}
