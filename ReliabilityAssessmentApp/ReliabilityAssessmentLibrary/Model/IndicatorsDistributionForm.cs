using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary.Model
{
    /// <summary>
    /// Показатели формы распределения
    /// </summary>
    public class IndicatorsDistributionForm
    {
        /// <summary>
        /// Показатель квартильной вариации
        /// </summary>
        public double QuartilleVariation { get; set; }

        /// <summary>
        /// Моментный коэффициент ассимметрии
        /// </summary>
        public double CoeffAsymmetry { get; set; }

        /// <summary>
        /// Средняя квадратичная ошибка коэффициента асимметрии
        /// </summary>
        public double MeanSquareeCoeffAsymmetry { get; set; }
    }
}
