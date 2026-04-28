namespace GoalZoneProject.WepApi.Dtos.MatchEventDtos
{
    public class ResultMatchEventDto
    {
        public int MatchEventId { get; set; }
        public int FixtureId { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public string EventType { get; set; }
        public string TeamSide { get; set; }
    }
}
