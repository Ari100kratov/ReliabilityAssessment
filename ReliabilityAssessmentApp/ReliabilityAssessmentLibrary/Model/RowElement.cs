using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary.Model
{
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
