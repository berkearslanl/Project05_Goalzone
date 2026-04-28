using GoalZoneProject.WebUI.Dtos.TeamDtos;

namespace GoalZoneProject.WebUI.Dtos.FixtureDtos
{
    public class ResultFixtureDto
    {
        public int FixtureId { get; set; }
        public int HomeTeamId { get; set; }
        public ResultTeamDto HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public ResultTeamDto AwayTeam { get; set; }
        public int HomeTeamHalfScore { get; set; }
        public int AwayTeamHalfScore { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public string Stadium { get; set; }
        public DateTime MatchDate { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }
        public int WeekNumber { get; set; }
    }
}
