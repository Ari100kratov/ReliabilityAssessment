
namespace ReliabilityAssessmentLibrary
{
    public interface IStandardPointEstimate
    {
        /// <summary>
        /// Найдем оценку математического ожидания 
        /// </summary>
        double GetMathematicalExpectation();

        /// <summary>
        /// Расcчитаем оценку дисперсии
        /// </summary>
        double GetEstimationVariance();

        /// <summary>
        /// Рассчитаем среднее квадратичное отклонение
        /// </summary>
        double GetMeanSquareDeviation();

        /// <summary>
        /// Рассчитаем коэффициент вариации
        /// </summary>
        double CoefficientVariation();
    }
}
