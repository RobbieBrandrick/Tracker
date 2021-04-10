using System.Linq;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Core.Services.ExerciseTracker
{
    public class ExerciseService
    {
        private readonly TrackerDbContext _dbContext;

        public ExerciseService(TrackerDbContext dbContext)
        {
            
            _dbContext = dbContext;
            
        }

        public IQueryable<Exercise> Get()
        {
            return _dbContext.Exercises;
        }
        
        public async Task<Exercise> Add(string name)
        {

            Exercise exercise = new Exercise()
            {
                Name = name
            };

            await _dbContext.Exercises.AddAsync(exercise);

            await _dbContext.SaveChangesAsync();

            return exercise;

        }
        
    }
}