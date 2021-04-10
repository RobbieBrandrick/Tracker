using System;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Core.Services.ExerciseTracker
{
    public class SessionService
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
        
        public async Task<Session> Add()
        {

            Session session = new Session()
            {
                CreateDate = DateTime.Now
            };

            await _dbContext.Sessions.AddAsync(session);

            await _dbContext.SaveChangesAsync();

            return session;

        }        
    }
}