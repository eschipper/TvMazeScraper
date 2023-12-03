namespace Models
{

    public class Show
    {
        public string id { get; set; }
        public string url { get; set; }
        public string name { get; set; }
        public string type { get; set; }
        public string language { get; set; }
        public string[] genres { get; set; }
        public string status { get; set; }
        public int? runtime { get; set; }
        public int? averageRuntime { get; set; }
        public string premiered { get; set; }
        public string ended { get; set; }
        public string officialSite { get; set; }
        public Schedule schedule { get; set; }
        public Rating rating { get; set; }
        public int weight { get; set; }
        public Network network { get; set; }
        public Webchannel webChannel { get; set; }
        public Dvdcountry dvdCountry { get; set; }
        public Externals externals { get; set; }
        public Image image { get; set; }
        public string summary { get; set; }
        public int updated { get; set; }
        public _Links _links { get; set; }
    }

    public class _Links
    {
        public Self self { get; set; }
        public Previousepisode previousepisode { get; set; }
        public Nextepisode nextepisode { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
    }

    public class Previousepisode
    {
        public string href { get; set; }
    }

    public class Nextepisode
    {
        public string href { get; set; }
    }

}
