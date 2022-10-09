namespace TestWork.Model
{

    public record Circle(double Radius) : IFigure
    {
        public double Area() => Math.PI * Radius * 2;
    }

    public record Triangle(double A, double B, double C) : IFigure
    {
        public double Area()
        {
            var P = (A + B + C) / 2;
            return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
        }
    }

    public interface IFigure
    {
        double Area();
    }
}
