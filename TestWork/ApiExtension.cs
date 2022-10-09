using System.Runtime.CompilerServices;
using TestWork.Model;

namespace TestWork
{
    /// <summary>
    /// Класс расширение для синтаксического сахара
    /// </summary>
    public static class ApiExtension
    {
        /// <summary>
        /// метд расширения создаёт Put запрос на основе фигуры
        /// если pattern is null то используеться имя класса
        /// </summary>
        /// <typeparam name="FigureType">Фигура</typeparam>
        /// <param name="application"></param>
        /// <param name="pattern"></param>
        /// <returns>возвращяет тот же самый WebApplication для создания цепочки методов</returns>
        public static WebApplication AddFigure<FigureType>(this WebApplication application, string? pattern = null) where FigureType : IFigure
        {
            application.MapPut(pattern ?? typeof(FigureType).Name, (FigureType f) => f.Area());
            return application;
        }
    }
}
