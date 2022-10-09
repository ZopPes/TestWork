using System.Runtime.CompilerServices;
using TestWork.Model;

namespace TestWork
{
    public static class ApiExtension
    {
        public static WebApplication AddFigure<FigureType>(this WebApplication application) where FigureType : IFigure 
        {
            var name = typeof(FigureType).Name;
            application.MapGet($"/{name}",(FigureType f)=>f.Area());
            return application;
        }
    }
}
