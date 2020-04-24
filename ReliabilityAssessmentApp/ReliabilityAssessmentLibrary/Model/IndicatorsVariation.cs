using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary.Model
{
    /// <summary>
    /// Показатели вариации
    /// </summary>
    public class IndicatorsVariation
    {
        #region Абсолютные показатели

        /// <summary>
        /// Рахмах вариации
        /// </summary>
        public double Scope { get; set; }

        /// <summary>
        /// Среднее линейное отклонение
        /// </summary>
        public double AVGLinearDeviation { get; set; }

        /// <summary>
        /// Дисперсия
        /// </summary>
        public double Dispersion { get; set; }

        /// <summary>
        /// Несмещенная оценка дисперсии
        /// </summary>
        public double UnbiasedDispersion { get; set; }

        /// <summary>
        /// Среднее квадратичное отклонение
        /// </summary>
        public double MeanSquareDeviation { get; set; }

        /// <summary>
        /// Оценка среднее квадратичное отклонение
        /// </summary>
        public double EstimationMeanSquareDeviation { get; set; }


        #endregion

        #region Относительные показатели

        /// <summary>
        /// Коэффициент вариации
        /// </summary>
        public double CoefVariation { get; set; }

        /// <summary>
        /// Линейный коэффициент вариации
        /// </summary>
        public double LinearCoefVariation { get; set; }

        /// <summary>
        /// Коэффициент осцилляции
        /// </summary>
        public double CoefOscillation { get; set; }

        #endregion
    }
}
