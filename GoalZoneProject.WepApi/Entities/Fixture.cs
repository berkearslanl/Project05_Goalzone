namespace GoalZoneProject.WepApi.Entities
{
    public class Fixture
    {
        public int FixtureId { get; set; }

        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }

        public int HomeTeamHalfScore { get; set; }
        public int AwayTeamHalfScore { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public string Stadium { get; set; }
        public DateTime MatchDate { get; set; }
        public string ImageUrl { get; set; }
        public string Status { get; set; }  // "Tamamlandı", "Oynanıyor", "Henüz Oynanmadı"
        public int WeekNumber { get; set; }

        public List<MatchEvent> MatchEvents { get; set; }

    }
}
