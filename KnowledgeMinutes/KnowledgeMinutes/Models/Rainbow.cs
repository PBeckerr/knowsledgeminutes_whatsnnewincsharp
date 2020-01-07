namespace KnowledgeMinutes.Models
{
    public enum Rainbow
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }
    
    internal class RGBColor
    {
        public int Red { get; }
        public int Green { get; }
        public int Blue { get; }

        public RGBColor(int red, int green, int blue)
        {
            this.Red = red;
            this.Green = green;
            this.Blue = blue;
        }
    }
}