using GoalZoneProject.WepApi.Context;
using GoalZoneProject.WepApi.Dtos.TeamDtos;
using GoalZoneProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GoalZoneProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        private readonly ApiContext _context;

        public TeamsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult TeamList()
        {
            var values = _context.Teams.ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateTeam(CreateTeamDto createTeamDto)
        {
            var values = new Team()
            {
                TeamName = createTeamDto.TeamName,
                LogoUrl = createTeamDto.LogoUrl
            };
            _context.Teams.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme başarılı.");
        }
        [HttpDelete]
        public IActionResult DeleteTeam(int id)
        {
            var value = _context.Teams.Find(id);
            if (value != null)
                _context.Teams.Remove(value);
            _context.SaveChanges();
            return Ok("Silme başarılı.");
        }
    }
}
