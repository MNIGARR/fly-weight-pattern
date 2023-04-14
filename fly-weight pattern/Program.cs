namespace fly_weight_pattern
{
    public interface IGalaxy
    {
        void SetBrightness(double brightness);
        void Position(int x, int y);
    }

    public class Ellipse
    {
        public readonly int height;
        public readonly int width;
        public readonly string color;
        public Ellipse(int Height, int Width, string Color)
        {
            this.height = Height;
            this.width = Width;
            this.color = Color;
        }
    }

    public enum PlanetType { Star, Planet }

    public class Planet : IGalaxy
    {
        public static Ellipse StarShape = new Ellipse(30, 30, "qirmizi"); 
        int positionX;
        int positionY;
        double brightness;
        public void SetBrightness(double Brightness)
        {
            this.brightness = Brightness;
        }
        public void Position(int x, int y)
        {
            positionX = x;
            positionY = y;
        }
        public override string ToString()
        {
            return string.Format($"\nPlanetin yerlersdiyi koordinatlar: [{positionX},{positionY}]. Parlaqliq dercesi: {brightness}%");
        }
    }

    public class Star : IGalaxy
    {
        public static Ellipse StarShape = new Ellipse(10, 10, "blue"); 

        int positionX;
        int positionY;
        double brightness;

        public void SetBrightness(double Brightness)
        {
            this.brightness = Brightness;
        }

        public void Position(int PositionX, int PositionY)
        {
            positionX = PositionX;
            positionY = PositionY;
        }

        public override string ToString()
        {
            return string.Format($"\nUlduz [{positionX},{positionY}] koordinatlardadir ve parlama derecesi: {brightness}% ");
        }
    }


    public class GalaxyFactory
    {
        private static Dictionary<PlanetType, IGalaxy> planetObjects = new Dictionary<PlanetType, IGalaxy>();

        public static IGalaxy GetPlanetoryObject(PlanetType planetoryObject)
        {
            if (planetObjects.ContainsKey(planetoryObject))
                return planetObjects[planetoryObject];

            else
            {
                IGalaxy NewObject = null;
                if (planetoryObject == PlanetType.Star)
                {
                    NewObject = new Star();
                    planetObjects.Add(PlanetType.Star, NewObject);
                }
                else
                {
                    NewObject = new Planet();
                    planetObjects.Add(PlanetType.Planet, NewObject);
                }
                return NewObject;
            }
        }
    }



    class Client
    {
        static void Main(string[] args)
        {
            IGalaxy star = GalaxyFactory.GetPlanetoryObject(PlanetType.Star);
            star.SetBrightness(10);
            star.Position(20, 80);
            Console.WriteLine(star);


            IGalaxy planet = GalaxyFactory.GetPlanetoryObject(PlanetType.Planet);
            planet.SetBrightness(67);
            planet.Position(120, 85);
            Console.WriteLine(planet);


            IGalaxy star2 = GalaxyFactory.GetPlanetoryObject(PlanetType.Star);
            star2.SetBrightness(65);
            star2.Position(67, 23);
            Console.WriteLine(star2);
        }
    }
}