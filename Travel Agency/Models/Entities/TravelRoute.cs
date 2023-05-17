namespace Travel_Agency.Models.Entities {
    public class TravelRoute {
        public int Id { get; set; } 
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public Vehicle Vehicle { get; set; }
        public int FreeSeats { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
