using GoalZoneProject.WepApi.Context;
using GoalZoneProject.WepApi.Dtos.MatchEventDtos;
using GoalZoneProject.WepApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GoalZoneProject.WepApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchEventsController : ControllerBase
    {
        private readonly ApiContext _context;

        public MatchEventsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult MatchEventList()
        {
            var values = _context.MatchEvents.ToList();
            return Ok(values);
        }
        //seçili maça ait detayları getirmek için
        [HttpGet("GetByFixture/{fixtureId}")]
        public IActionResult GetByFixture(int fixtureId)
        {
            var values = _context.MatchEvents
                        .Where(x => x.FixtureId == fixtureId)
                        .OrderBy(x => x.Minute)
                        .ToList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateMathcEvent(CreateMatchEventDto createMatchEventDto)
        {
            var value = new MatchEvent()
            {
                EventType = createMatchEventDto.EventType,
                FixtureId = createMatchEventDto.FixtureId,
                PlayerName = createMatchEventDto.PlayerName,
                Minute = createMatchEventDto.Minute,
                TeamSide = createMatchEventDto.TeamSide
            };
            _context.MatchEvents.Add(value);
            _context.SaveChanges();
            return Ok("Maç olayı eklendi");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteMatchEvent(int id)
        {
            var value = _context.MatchEvents.Find(id);
            _context.MatchEvents.Remove(value);
            _context.SaveChanges();
            return Ok("Silme başarılı");
        }
    }
}
