using System;
using System.Linq;
using System.Threading.Tasks;
using Tracker.Core.Data;
using Tracker.Core.Models.ExerciseTracker;

namespace Tracker.Core.Services.ExerciseTracker
{
    public interface IExerciseTypesService
    {
        IQueryable<ExerciseType> Get();
        Task<ExerciseType> Add(string name);
    }

    public class ExerciseTypesService : IExerciseTypesService
    {
        
        private readonly TrackerDbContext _dbContext;

        public ExerciseTypesService(TrackerDbContext dbContext)
        {
            
            _dbContext = dbContext;
            
        }

        public IQueryable<ExerciseType> Get()
        {
            
            return _dbContext.ExerciseTypes;
            
        }
        
        public async Task<ExerciseType> Add(string name)
        {

            if (Get().Any(e => e.Name.ToLower() == name.ToLower()))
            {
                throw new InvalidOperationException("Exercise Already Exists");
            }

            ExerciseType exerciseType = new ExerciseType()
            {
                Name = name
            };

            await _dbContext.ExerciseTypes.AddAsync(exerciseType);

            await _dbContext.SaveChangesAsync();

            return exerciseType;

        }
        
    }
}