using GoalZoneProject.WebUI.Dtos.FixtureDtos;
using GoalZoneProject.WebUI.Dtos.StandingDtos;
using GoalZoneProject.WebUI.Dtos.TeamDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace GoalZoneProject.WebUI.Controllers
{
    public class TeamController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TeamController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> TeamList()
        {
            var client = _httpClientFactory.CreateClient();
            //takımlar
            var teamResponse = await client.GetAsync("https://localhost:7194/api/Teams");
            var teamJson = await teamResponse.Content.ReadAsStringAsync();
            var teams = JsonConvert.DeserializeObject<List<ResultTeamDto>>(teamJson);
            //fikstürler
            var fixtureResponse = await client.GetAsync("https://localhost:7194/api/Fixtures");
            var fixtureJson = await fixtureResponse.Content.ReadAsStringAsync();
            var fixtures = JsonConvert.DeserializeObject<List<ResultFixtureDto>>(fixtureJson);

            var completed = fixtures.Where(x => x.Status == "Tamamlandı").ToList();

            var standings = teams.Select(team =>
            {
                var home = completed.Where(x => x.HomeTeamId == team.TeamId).ToList();
                var away = completed.Where(x => x.AwayTeamId == team.TeamId).ToList();

                int wins = 0, draws = 0, loses = 0, gf = 0, ga = 0;

                //ev sahibiiçin
                foreach (var x in home)
                {
                    gf += x.HomeTeamScore;
                    ga += x.AwayTeamScore;
                    if (x.HomeTeamScore > x.AwayTeamScore)
                    {
                        wins++;
                    }
                    else if (x.HomeTeamScore == x.AwayTeamScore)
                    {
                        draws++;
                    }
                    else
                    {
                        loses++;
                    }
                }
                //deplasman için
                foreach (var x in away)
                {
                    gf += x.AwayTeamScore;
                    ga += x.HomeTeamScore;
                    if (x.AwayTeamScore > x.HomeTeamScore)
                    {
                        wins++;
                    }
                    else if (x.AwayTeamScore == x.HomeTeamScore)
                    {
                        draws++;
                    }
                    else
                    {
                        loses++;
                    }
                }

                //son 5 maç
                var allMatches = home.Concat(away)
                                    .OrderByDescending(x => x.MatchDate)
                                    .Take(5)
                                    .ToList();
                var form = allMatches.Select(x =>
                {
                    if (x.HomeTeamId == team.TeamId)
                    {
                        return x.HomeTeamScore > x.AwayTeamScore ? "G" : x.HomeTeamScore == x.AwayTeamScore ? "B" : "M";
                    }
                    else
                    {
                        return x.AwayTeamScore > x.HomeTeamScore ? "G" : x.AwayTeamScore == x.HomeTeamScore ? "B" : "M";
                    }
                }).Reverse().ToList();

                return new StandingDto
                {
                    TeamId = team.TeamId,
                    TeamName = team.TeamName,
                    LogoUrl = team.LogoUrl,
                    MatchesPlayed = home.Count + away.Count,
                    Wins = wins,
                    Draws = draws,
                    Losses = loses,
                    GoalsFor = gf,
                    GoalsAgainst = ga,
                    Form = form
                };
            }).OrderByDescending(x => x.Points)
            .ThenByDescending(x => x.GoalDifference)
            .ThenByDescending(x => x.GoalsFor)
            .ToList();
            return View(standings);
        }
    }
}
