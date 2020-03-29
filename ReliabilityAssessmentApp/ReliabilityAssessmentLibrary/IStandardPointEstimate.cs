
namespace ReliabilityAssessmentLibrary
{
    public interface IStandardPointEstimate
    {
        /// <summary>
        /// Найдем оценку математического ожидания 
        /// </summary>
        /// <returns></returns>
        double GetMathematicalExpectation();

        /// <summary>
        /// Расcчитаем оценку дисперсии
        /// </summary>
        /// <returns></returns>
        double GetEstimationVariance();

        /// <summary>
        /// Рассчитаем среднее квадратичное отклонение
        /// </summary>
        /// <returns></returns>
        double GetMeanSquareDeviation();

        /// <summary>
        /// Рассчитаем коэффициент вариации
        /// </summary>
        /// <returns></returns>
        double CoefficientVariation();
    }
}
