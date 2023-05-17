namespace Travel_Agency.Models.Entities {
    public class Vehicle {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int TheYearOfProduction { get; set; }
        public string Description { get; set; } = string.Empty;
        public int Seats { get; set; }
    }
}
