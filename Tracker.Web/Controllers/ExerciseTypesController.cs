using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracker.Core.Models.ExerciseTracker;
using Tracker.Core.Services.ExerciseTracker;
using Tracker.Web.Dtos.ExerciseTracker;

namespace Tracker.Web.Controllers
{
    [Route("[controller]")]
    public class ExerciseTypesController : Controller

    {
        private readonly IExerciseTypesService _exerciseTypesService;

        public ExerciseTypesController(IExerciseTypesService exerciseTypesService)
        {
            _exerciseTypesService = exerciseTypesService;
        }

        [HttpGet]
        public async Task<IEnumerable<ExerciseType>> GetAll()
        {
            IEnumerable<ExerciseType> types = await _exerciseTypesService
                .Get()
                .ToListAsync();

            return types;
        }

        [HttpPost]
        public async Task Add([FromBody] ExerciseTypeDto type)
        {
            await _exerciseTypesService.Add(type.Type);
        }
    }
}