using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LeaderboardController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LeaderboardController(ApplicationDbContext context)
        {
            _context = context;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Controller Leaderboard initialisé");
            Console.ResetColor();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<object>>> GetLeaderboard()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Endpoint GetLeaderboard appelé");
            Console.ResetColor();

            var leaderboard = await _context.Users
                .OrderByDescending(u => u.Score)
                .Select(u => new
                {
                    u.Username,
                    u.Score
                })
                .ToListAsync();

            return Ok(leaderboard);
        }
    }
}
