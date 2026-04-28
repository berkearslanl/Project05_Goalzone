namespace GoalZoneProject.WebUI.Dtos.StandingDtos
{
    public class StandingDto
    {
        //takım bilgileri
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string LogoUrl { get; set; }
        //takım istatistikleri
        public int MatchesPlayed { get; set; }
        public int Wins { get; set; }
        public int Draws { get; set; }
        public int Losses { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference => GoalsFor - GoalsAgainst;
        public int Points => (Wins * 3) + (Draws * 1);
        public List<string> Form { get; set; } = new();
    }
}
