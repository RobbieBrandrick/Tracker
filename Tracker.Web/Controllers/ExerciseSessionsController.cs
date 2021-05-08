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
    public class ExerciseSessionsController : Controller
    {
        private readonly ISessionService _sessionService;

        public ExerciseSessionsController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Session>> GetAll()
        {
            IEnumerable<Session> sessions = await _sessionService
                .Get()
                .ToListAsync();

            return sessions;
        }

        [HttpPost]
        public async Task SaveSession(SessionDto session)
        {
            
            await _sessionService.AddOrUpdate(session.ToDomain());

        }
    }
}