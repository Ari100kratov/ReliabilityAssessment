using ReliabilityAssessmentLibrary.Model;

namespace ReliabilityAssessmentLibrary.Factory
{
    /// <summary>
    /// Интерфейс фабрики элемента вариационного ряда
    /// </summary>
    public interface IRowElementFactory
    {
        /// <summary>
        /// Создать элемент
        /// </summary>
        /// <param name="number">Порядковый номер</param>
        /// <param name="lowerBound">Нижняя граница</param>
        /// <param name="interval">Интервал</param>
        /// <param name="hitCount">Количество попаданий результатов испытаний</param>
        /// <returns>Элемент вариационного ряда</returns>
        RowElement Create(int number, double lowerBound, double interval, int hitCount);
    }
}
