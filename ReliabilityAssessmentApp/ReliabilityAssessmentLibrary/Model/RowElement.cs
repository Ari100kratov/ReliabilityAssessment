
using System;

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
        /// (x - xср)^3 * f 
        /// </summary>
        public double XMinusXMultiplyCube { get; set; }

        /// <summary>
        /// (x - xср)^4 * f 
        /// </summary>
        public double XMinusXMultiplyFour { get; set; }

        /// <summary>
        /// Относительная частота
        /// </summary>
        public double RelativeFrequance { get; set; }


        public string Bounds => $"{Math.Round(this.LowerBound, Settings.Default.Round)} - {Math.Round(this.UpperBound, Settings.Default.Round)}";

        public double MidIntervalR => Math.Round(this.MidInterval, Settings.Default.Round);

        public double XMultiplyFR => Math.Round(this.XMultiplyF, Settings.Default.Round);

        public double XMinusXMultiplyFR => Math.Round(this.XMinusXMultiplyF, Settings.Default.Round);

        public double XMinusXMultiplyFSquareR => Math.Round(this.XMinusXMultiplyFSquare, Settings.Default.Round);

        public double XMinusXMultiplyCubeR => Math.Round(this.XMinusXMultiplyCube, Settings.Default.Round);

        public double XMinusXMultiplyFourR => Math.Round(this.XMinusXMultiplyFour, Settings.Default.Round);

        public double RelativeFrequanceR => Math.Round(this.RelativeFrequance, Settings.Default.Round);

    }
}
