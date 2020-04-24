using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary.Model
{
    /// <summary>
    /// Показатели центра распределения
    /// </summary>
    public class IndicatorsDistributionCenter
    {
        /// <summary>
        /// Средняя взвешенная
        /// </summary>
        public double WeightedAVG { get; set; }

        /// <summary>
        /// Мода
        /// </summary>
        public double Mode { get; set; }

        /// <summary>
        /// Медиана
        /// </summary>
        public double Median { get; set; }

        /// <summary>
        /// Квартильный коэффициент дифференциации
        /// </summary>
        public double QuartilCoeff { get; set; }

        public double Q1 { get; set; }

        public double Q2 { get; set; }

        public double Q3 { get; set; }

        public double D1 { get; set; }

        public double D9 { get; set; }
    }
}
