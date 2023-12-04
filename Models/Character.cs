namespace Models
{
    public class Character
    {
        public int id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public Image image { get; set; }
        public _Links _links { get; set; }
    }
}
