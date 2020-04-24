
namespace ReliabilityAssessmentLibrary.Model
{
    /// <summary>
    /// Характеристики случайной величины
    /// </summary>
    public class CharactVariable
    {
        /// <summary>
        /// Математическое ожидание
        /// </summary>
        public double MathExpectation { get; set; }

        /// <summary>
        /// Дисперсия
        /// </summary>
        public double Dispersion { get; set; }

        /// <summary>
        /// Среднее квадратичное отклонение
        /// </summary>
        public double SquareDeviation { get; set; }

        /// <summary>
        /// Коэффициент вариации
        /// </summary>
        public double CoeffVariation { get; set; }
    }
}
