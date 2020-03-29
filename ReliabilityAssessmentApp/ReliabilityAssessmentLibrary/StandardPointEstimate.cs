using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReliabilityAssessmentLibrary
{
    public sealed class StandardPointEstimate : IStandardPointEstimate
    {
        private readonly DataModel _dataModel;

        public StandardPointEstimate(DataModel dataModel)
        {
            this._dataModel = dataModel ?? throw new ArgumentException(nameof(dataModel));
        }

        public double GetMathematicalExpectation()
        {
            var mathExpectation = this._dataModel.ValueList.Sum()
                / this._dataModel.ValueList.Count;

            this._dataModel.SetMathExpectation(mathExpectation);
            return mathExpectation;
        }

        public double GetEstimationVariance()
        {
            var estimateVariance = 1 / (this._dataModel.ValueList.Count() - 1)
                * this._dataModel.ValueList.Select(x => Math.Pow(x, 2)).Sum()
                - this._dataModel.ValueList.Count * Math.Pow(this._dataModel.MathExpectation, 2);

            this._dataModel.SetDispersion(estimateVariance);
            return estimateVariance;
        }

        public double GetMeanSquareDeviation()
        {
            var meanSquareDeviation = Math.Sqrt(this._dataModel.Dispersion);
            this._dataModel.SetSquareDeviation(meanSquareDeviation);
            return meanSquareDeviation;
        }

        public double CoefficientVariation()
        {
            var coeffVariation = this._dataModel.SquareDeviation / this._dataModel.MathExpectation;
            this._dataModel.SetCoeffVariation(coeffVariation);
            return coeffVariation;
        }
    }
}
