namespace PropertyApi.Models{

    public class Property {
        public string PropertyId { get; set; }
        public string PropertyName { get; set; }
        public List<string> Features { get; set; }
        public List<string> Highlights { get; set; }
        public List<Transportation> Transportations { get; set; }
        public List<Space> Spaces { get; set; }
    }
}