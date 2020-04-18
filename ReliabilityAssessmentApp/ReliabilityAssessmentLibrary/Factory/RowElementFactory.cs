using ReliabilityAssessmentLibrary.Model;
using System;

namespace ReliabilityAssessmentLibrary.Factory
{
    /// <summary>
    /// Фабрика создания элемента вариационного ряда
    /// </summary>
    public class RowElementFactory : IRowElementFactory
    {
        /// <summary>
        /// Создать элемент
        /// </summary>
        /// <param name="number">Порядковый номер</param>
        /// <param name="lowerBound">Нижняя граница</param>
        /// <param name="interval">Интервал</param>
        /// <param name="hitCount">Количество попаданий результатов испытаний</param>
        /// <returns>Элемент вариационного ряда</returns>
        public RowElement Create(int number, double lowerBound, double interval, int hitCount)
        {
            if (interval <= 0)
                throw new ArgumentOutOfRangeException(nameof(interval), "Can't be less or equal 0");

            var upperBound = lowerBound + interval;
            var midInterval = (lowerBound + upperBound) / 2;

            var rowElement = new RowElement
            {
                Number = number,
                LowerBound = lowerBound,
                UpperBound = upperBound,
                MidInterval = midInterval,
                HitCount = hitCount
            };

            return rowElement;
        }
    }
}
