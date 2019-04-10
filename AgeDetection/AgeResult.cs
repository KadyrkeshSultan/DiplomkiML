namespace AgeDetection
{
    public class AgeResult
    {
        public Age[] age { get; set; }
        public Bbox bbox { get; set; }
        public int person { get; set; }
    }

    public class Bbox
    {
        public int bottom { get; set; }
        public int left { get; set; }
        public int right { get; set; }
        public int top { get; set; }
    }

    public class Age
    {
        public AgeRange ageRange { get; set; }
        public double confidence { get; set; }
    }

    public class AgeRange
    {
        public int max { get; set; }
        public int min { get; set; }
    }
}
