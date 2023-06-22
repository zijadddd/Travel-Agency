namespace Travel_Agency.Models.In {
    public record VehicleIn {
        public VehicleIn(string Name, int TheYearOfProduction, string Description, int Seats)
        {
            this.Name = Name;
            this.TheYearOfProduction = TheYearOfProduction;
            this.Description = Description;
            this.Seats = Seats;
        }

        public string Name { get; init; }
        public int TheYearOfProduction { get; init; }
        public string Description { get; init; }
        public int Seats { get; init; }
    }
}
