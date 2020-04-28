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

        /// <summary>
        /// Показатель асимметрии
        /// </summary>
        public double Asymmetry { get; set; }

        /// <summary>
        /// Коэффициент асимметрии Пирсона
        /// </summary>
        public double CoeffAsymmetryPirson { get; set; }

        /// <summary>
        /// Эксцесс
        /// </summary>
        public double Excess { get; set; }

        /// <summary>
        /// Cредняя квадратическая ошибка коэффициента эксцесса
        /// </summary>
        public double MeanSquareCoeffExcess { get; set; }

        /// <summary>
        /// Cущественность эксцесса
        /// </summary>
        public double EstimateExcess { get; set; }
    }
}
