
namespace ReliabilityAssessmentLibrary.Model
{
    /// <summary>
    /// Элемент вариационного ряда
    /// </summary>
    public class RowElement
    {
        /// <summary>
        /// Номер интервала
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// Нижняя граница
        /// </summary>
        public double LowerBound { get; set; }

        /// <summary>
        /// Верхняя граница
        /// </summary>
        public double UpperBound { get; set; }

        /// <summary>
        /// Середина интервала
        /// </summary>
        public double MidInterval { get; set; }

        /// <summary>
        /// Число попаданий
        /// </summary>
        public int HitCount { get; set; }
    }
}
