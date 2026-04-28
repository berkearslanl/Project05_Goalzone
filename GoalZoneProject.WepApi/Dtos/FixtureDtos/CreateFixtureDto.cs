namespace GoalZoneProject.WepApi.Dtos.FixtureDtos
{
    public class CreateFixtureDto
    {
        public int HomeTeamId { get; set; }
        public int AwayTeamId { get; set; }
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
