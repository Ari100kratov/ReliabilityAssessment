using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary.Model
{
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
