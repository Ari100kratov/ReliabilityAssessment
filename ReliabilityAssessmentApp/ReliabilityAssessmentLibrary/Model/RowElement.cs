
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

        /// <summary>
        /// xi * fi
        /// </summary>
        public double XMultiplyF { get; set; }

        /// <summary>
        /// Накопленная частота
        /// </summary>
        public int CumulativeFrequance { get; set; }

        /// <summary>
        /// |x - xср| * fi
        /// </summary>
        public double XMinusXMultiplyF { get; set; }

        /// <summary>
        /// (x-xср)^2·fi
        /// </summary>
        public double XMinusXMultiplyFSquare { get; set; }

        /// <summary>
        /// Относительная частота
        /// </summary>
        public double RelativeFrequance { get; set; }

        public string Bounds => $"{this.LowerBound} - {this.UpperBound}";

    }
}
