using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary.Model.ChartModel
{
    public class XYPoint
    {
        public string Argument { get; set; }

        public double Value { get; set; }

        public double ValueRound => Math.Round(this.Value, Settings.Default.Round);
    }
}
