namespace PropertyApi.Models{

public class Transportation
    {
        public string Type { get; set; }
        public string Line { get; set; }
        public string Distance { get; set; }
        public string Station { get; set; }  // Optional property for Bike Share station
    }
}