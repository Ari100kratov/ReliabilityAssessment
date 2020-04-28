using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary.Model
{
    /// <summary>
    /// Закон распределения
    /// </summary>
    public class DistributionLaw
    {
        /// <summary>
        /// Нижний интервал по правилу 3 сигм
        /// </summary>
        public double LowerBoundByRuleSigm { get; set; }

        /// <summary>
        /// Верхний интервал по правилу 3 сигм
        /// </summary>
        public double UpperBoundByRuleSigm { get; set; }
    }
}
