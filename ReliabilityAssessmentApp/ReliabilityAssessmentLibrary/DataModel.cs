using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary
{
    public sealed class DataModel
    {
        /// <summary>
        /// Список результатов испытаний
        /// </summary>
        public List<double> ValueList { get; private set; }

        /// <summary>
        /// Математическое ожидание
        /// </summary>
        public double MathExpectation { get; private set; }

        /// <summary>
        /// Дисперсия
        /// </summary>
        public double Dispersion { get; private set; }

        /// <summary>
        /// Среднее квадратичное отклонение
        /// </summary>
        public double SquareDeviation { get; private set; }

        /// <summary>
        /// Коэффициент вариации
        /// </summary>
        public double CoeffVariation { get; private set; }

        public DataModel(List<double> valueList)
        {
            if (valueList == null)
                throw new ArgumentNullException(nameof(valueList));

            if (!valueList.Any())
                throw new ArgumentException("List of values is empty");

            this.ValueList = valueList;
        }

        /// <summary>
        /// Заполнить математическое ожидание
        /// </summary>
        /// <param name="value"></param>
        public void SetMathExpectation(double value)
        {
            this.MathExpectation = value;
        }

        /// <summary>
        /// Заполнить дисперсию
        /// </summary>
        /// <param name="value"></param>
        public void SetDispersion(double value)
        {
            this.Dispersion = value;
        }

        /// <summary>
        /// Заполнить среднее квадратичное отклонение
        /// </summary>
        /// <param name="value"></param>
        public void SetSquareDeviation(double value)
        {
            this.SquareDeviation = value;
        }

        /// <summary>
        /// Заполнить коэффициент вариации
        /// </summary>
        /// <param name="value"></param>
        public void SetCoeffVariation(double value)
        {
            this.CoeffVariation = value;
        }
    }
}
