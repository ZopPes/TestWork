using NetTopologySuite;

namespace TestWork.Model
{
    /// <summary>
    /// класс описывающий круг
    /// </summary>
    public class Circle : IFigure
    {
        public double Radius { get; set; }
        public Result<string> Area() =>new() { Value = (Math.PI * Radius * 2).ToString() };

        IFigureResult IFigure.Area()
        {
            return Area();
        }
    }

    /// <summary>
    /// класс описывающий треугольник
    /// </summary>
    /// <param name="A"></param>
    /// <param name="B"></param>
    /// <param name="C"></param>
    public record Triangle(double A, double B, double C) : IFigure
    {
        public Result<string> Area()
        {
            var r = new Result<string>();
            var P = (A + B + C) / 2;
            var t = P * (P - A) * (P - B) * (P - C);
            if (t<=0)
            {
                r.Exception = new Exception("треугольник не существует");
                return r;
            }
            r.Value= Math.Sqrt(t).ToString();
            return r;
        }

        IFigureResult IFigure.Area()
        {
            return Area();
        }
    }

    public class Result<T> : IFigureResult<T>
    {
        private T value;

        public T Value { get=>value; set=> this.value = value; }
        public Exception? Exception { get; set; }
        object IFigureResult.Value { get => value; set => this.value =(T) value; }
    }

    /// <summary>
    /// класс для описания финуры которая возвращяет площадь
    /// </summary>
    public interface IFigure
    {
        /// <summary>
        /// площадь фигуры
        /// </summary>
        /// <returns></returns>
        IFigureResult Area();
    }

    
    public interface IFigureResult
    {
        Exception? Exception { get; set; }

        object Value { get; set; }
    }

    
    public interface IFigureResult<T> : IFigureResult
    {
        T Value { get; set; }
    }
}
