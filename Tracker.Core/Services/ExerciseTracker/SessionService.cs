using System;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Core.Services.ExerciseTracker
{
    public interface ISessionService
    {
        IQueryable<Session> Get();
        Task<Session> AddOrUpdate(Session session);
    }

    public class SessionService : ISessionService
    {
        private readonly TrackerDbContext _dbContext;

        public SessionService(TrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Session> Get()
        {
            return _dbContext.Sessions;
        }

        public async Task<Session> AddOrUpdate(Session session)
        {
            await _dbContext.Sessions.AddAsync(session);

            await _dbContext.SaveChangesAsync();

            return session;
        }
    }
}