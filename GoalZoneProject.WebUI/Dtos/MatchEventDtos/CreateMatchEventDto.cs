namespace GoalZoneProject.WebUI.Dtos.MatchEventDtos
{
    public class CreateMatchEventDto
    {
        public int FixtureId { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public string EventType { get; set; }
        public string TeamSide { get; set; }
    }
}
