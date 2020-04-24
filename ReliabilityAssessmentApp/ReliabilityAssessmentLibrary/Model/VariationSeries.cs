using ReliabilityAssessmentLibrary.Factory;
using ReliabilityAssessmentLibrary.Model.ChartModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReliabilityAssessmentLibrary.Model
{
    /// <summary>
    /// Модель вариационного ряда
    /// </summary>
    public class VariationSeries
    {
        /// <summary>
        /// Список экспериментальных данных
        /// </summary>
        public List<double> ExpDataList { get; private set; }

        /// <summary>
        /// Характеристики случайной величины
        /// </summary>
        public CharactVariable CharactVariable { get; private set; }

        /// <summary>
        /// Показатели центра распределения вариационного ряда
        /// </summary>
        public IndicatorsDistributionCenter DistributionCenter { get; set; }

        /// <summary>
        /// Показатели вариации
        /// </summary>
        public IndicatorsVariation IndicatorsVariation { get; set; }

        /// <summary>
        /// Список значений вариационного ряда
        /// </summary>
        public List<RowElement> ValueList { get; private set; }

        /// <summary>
        /// Количество интервалов
        /// </summary>
        public int IntervalCount { get; private set; }

        /// <summary>
        /// Количество инверсий
        /// </summary>
        public int InversionCount { get; private set; }

        /// <summary>
        /// Ширина интервала
        /// </summary>
        public double Interval { get; private set; }

        /// <summary>
        /// Список значений для гистограммы выборки
        /// </summary>
        public List<XYPoint> XYSampleList { get; private set; }

        /// <summary>
        /// Список значений для гистограммы интегральной функции распределения
        /// </summary>
        public List<XYPoint> XYFunctionList { get; private set; }

        public VariationSeries(List<double> expData, int intervalCount = 0)
        {
            if (expData == null)
                throw new ArgumentNullException(nameof(expData));

            if (!expData.Any())
                throw new ArgumentException("List is empty");

            if (intervalCount < 0)
                throw new ArgumentOutOfRangeException(nameof(intervalCount), "Can't be less 0");

            this.IntervalCount = intervalCount;
            this.ExpDataList = expData;
            this.CreateVariationSeries();
            this.CalculateCharactVariable();
            this.CalculateIndicatorsDistributionCenter();
            this.CalculateIndicatorsVariations();
            this.CalculateCharactVariable();
            this.FillXYDiagramList();
        }

        /// <summary>
        /// Создать вариационный ряд на основе экспериментальных данных
        /// </summary>
        private void CreateVariationSeries()
        {
            if (this.IntervalCount == 0)
                this.IntervalCount = (int)Math.Floor(1 + 3.3 * Math.Log10(this.ExpDataList.Count()));

            if (this.IntervalCount == 0)
                throw new Exception("Count of intervals can't be 0");

            this.ExpDataList.Sort();
            this.Interval = (this.ExpDataList.Max() - this.ExpDataList.Min()) / this.IntervalCount;
            this.ValueList = new List<RowElement>();
            var rowElementFactory = new RowElementFactory();

            var lowerBound = this.ExpDataList.Min();

            for (var i = 1; i <= this.IntervalCount; i++)
            {
                var upperBound = lowerBound + this.Interval;
                var hitCount = this.ExpDataList.FindAll(x => x >= lowerBound && x <= upperBound).Count();

                var rowElement = rowElementFactory.Create(i, lowerBound, this.Interval, hitCount);
                this.ValueList.Add(rowElement);

                lowerBound = upperBound;
            }

            var cumulativeHitCount = 0;
            var averageMidInterval = this.ExpDataList.Sum() / this.ExpDataList.Count();

            foreach (var row in this.ValueList)
            {
                cumulativeHitCount += row.HitCount;

                row.CumulativeFrequance = cumulativeHitCount;
                row.XMinusXMultiplyF = (Math.Abs(row.MidInterval - averageMidInterval)) * row.HitCount;
                row.XMinusXMultiplyFSquare = (Math.Pow(row.MidInterval - averageMidInterval, 2)) * row.HitCount;
                row.RelativeFrequance = row.HitCount / (double)this.ExpDataList.Count();
            }
        }

        /// <summary>
        /// Рассчитать характеристики случайной величины
        /// </summary>
        private void CalculateCharactVariable()
        {
            var charactVariableFactory = new CharactVariableFactory();
            var mathExpectation = this.ValueList.Select(x => x.MidInterval * x.HitCount).Sum() / this.ValueList.Count();
            var dispersion = (1 / ((double)this.ValueList.Count() - 1)) / (this.ValueList.Select(x => Math.Pow(x.MidInterval - mathExpectation, 2) * x.HitCount).Sum());

            this.CharactVariable = charactVariableFactory.Create(mathExpectation, dispersion);
        }

        /// <summary>
        /// Рассчитать показатели центра распределения
        /// </summary>
        private void CalculateIndicatorsDistributionCenter()
        {
            var indicators = new IndicatorsDistributionCenter();

            var hitCountSum = this.ValueList.Select(x => x.HitCount).Sum();

            // Средняя взвешенная
            var weightedAVG = this.ValueList.Select(x => x.XMultiplyF).Sum() / hitCountSum;

            // Мода
            var rowElementMode = this.ValueList.Find(r => r.HitCount == this.ValueList.Max(x => x.HitCount));
            var preRowElementHitCount = this.ValueList.Find(x => x.UpperBound == rowElementMode.LowerBound)?.HitCount ?? 0;
            var nextRowElementHitCount = this.ValueList.Find(x => x.LowerBound == rowElementMode.UpperBound)?.HitCount ?? 0;
            var intervalMode = rowElementMode.UpperBound - rowElementMode.LowerBound;

            var mode = rowElementMode.LowerBound
                + (intervalMode * ((double)(rowElementMode.HitCount - preRowElementHitCount)
                / ((rowElementMode.HitCount - preRowElementHitCount) + (rowElementMode.HitCount - nextRowElementHitCount))));

            // Медиана
            var rowElementMedian = this.ValueList.Find(x => x.CumulativeFrequance > (double)hitCountSum / 2);
            var intervalMedian = rowElementMedian.UpperBound - rowElementMedian.LowerBound;
            var preRowElementHitCountMedian = rowElementMedian.CumulativeFrequance - rowElementMedian.HitCount;

            var median = rowElementMedian.LowerBound
                + ((intervalMedian / rowElementMedian.HitCount)
                * (((double)hitCountSum / 2) - preRowElementHitCountMedian));

            //Q1
            var rowElementQ1 = this.ValueList.Find(x => x.UpperBound == rowElementMedian.LowerBound);
            var preRowElementHitCountQ1 = this.ValueList.Find(x => x.UpperBound == rowElementQ1.LowerBound)?.HitCount ?? 0;
            var intervalQ1 = rowElementQ1.UpperBound - rowElementQ1.LowerBound;
            var preRowCumulativeQ1 = this.ValueList.Find(x=>x.UpperBound == rowElementQ1.LowerBound)?.CumulativeFrequance??0;

            var q1 = rowElementQ1.LowerBound 
                + ((intervalQ1 / rowElementQ1.HitCount) 
                * (((double)hitCountSum / 4) - preRowCumulativeQ1));

            //Q2
            var q2 = median;

            //Q3
            var rowElementQ3 = this.ValueList.Find(x => x.LowerBound == rowElementMedian.UpperBound);
            var preRowElementHitCountQ3 = this.ValueList.Find(x => x.UpperBound == rowElementQ3.LowerBound)?.HitCount ?? 0;
            var intervalQ3 = rowElementQ3.UpperBound - rowElementQ3.LowerBound;
            var preRowCumulativeQ3 = this.ValueList.Find(x => x.UpperBound == rowElementQ3.LowerBound)?.CumulativeFrequance ?? 0;

            var q3 = rowElementQ3.LowerBound
                + ((intervalQ3 / rowElementQ3.HitCount)
                * (((double)hitCountSum * 3 / 4) - preRowCumulativeQ3));

            //D1
            var findD1 = (double)1 / 10 * hitCountSum;
            var rowElementD1 = this.ValueList.Find(x => x.CumulativeFrequance >= findD1);
            var intervalD1 = rowElementD1.UpperBound - rowElementD1.LowerBound;
            var preRowCumulativeD1 = this.ValueList.Find(x => x.UpperBound == rowElementD1.LowerBound)?.CumulativeFrequance ?? 0;

            var d1 = rowElementD1.LowerBound
                + ((intervalD1 / rowElementD1.HitCount)
                * (((double)hitCountSum / 10) - preRowCumulativeD1));

            //D9
            var findD9 = (double)9 / 10 * hitCountSum;
            var rowElementD9 = this.ValueList.Find(x => x.CumulativeFrequance >= findD9);
            var intervalD9 = rowElementD9.UpperBound - rowElementD9.LowerBound;
            var preRowCumulativeD9 = this.ValueList.Find(x => x.UpperBound == rowElementD9.LowerBound)?.CumulativeFrequance ?? 0;

            var d9 = rowElementD9.LowerBound
                + ((intervalD9 / rowElementD9.HitCount)
                * (((double)hitCountSum * 9 / 10) - preRowCumulativeD9));

            indicators.WeightedAVG = weightedAVG;
            indicators.Mode = mode;
            indicators.Median = median;
            indicators.Q1 = q1;
            indicators.Q2 = q2;
            indicators.Q3 = q3;
            indicators.D1 = d1;
            indicators.D9 = d9;

            this.DistributionCenter = indicators;
        }

        /// <summary>
        /// Рассчитать показатели вариации
        /// </summary>
        private void CalculateIndicatorsVariations()
        {
            // рахмах вариации
            var scope = this.ValueList.LastOrDefault().UpperBound - this.ValueList.FirstOrDefault().LowerBound;

            // среднеее линейное отклонение
            var avgLinearDeviation = this.ValueList.Select(x => x.XMinusXMultiplyF).Sum() / this.ValueList.Select(x => x.HitCount).Sum();

            // дисперсия
            var dispersion = this.ValueList.Select(x => x.XMinusXMultiplyFSquare).Sum() / this.ValueList.Select(x => x.HitCount).Sum();

            // несмещенная оценка дисперсии
            var unbiasedDispersion = this.ValueList.Select(x => x.XMinusXMultiplyFSquare).Sum() / (this.ValueList.Select(x => x.HitCount).Sum() - 1);

            // среднее квадратичное отклонение
            var meanSquareDeviation = Math.Sqrt(dispersion);

            // оценка среднее квадратичное отклонение
            var estimationMeanSquareDeviation = Math.Sqrt(unbiasedDispersion);


            // коэффициент вариации
            var coefVariation = meanSquareDeviation / this.DistributionCenter.WeightedAVG * 100;

            // линейный коэффициент вариации
            var linearCoefVariation = avgLinearDeviation / this.DistributionCenter.WeightedAVG * 100;

            // коэффициент осцилляции
            var coefOscillation = scope / this.DistributionCenter.WeightedAVG * 100;

            var indicatorsVariation = new IndicatorsVariation
            {
                Scope = scope,
                AVGLinearDeviation = avgLinearDeviation,
                Dispersion = dispersion,
                UnbiasedDispersion = unbiasedDispersion,
                MeanSquareDeviation = meanSquareDeviation,
                EstimationMeanSquareDeviation = estimationMeanSquareDeviation,
                CoefVariation = coefVariation,
                LinearCoefVariation = linearCoefVariation,
                CoefOscillation = coefOscillation
            };

            this.IndicatorsVariation = indicatorsVariation;
        }

        /// <summary>
        /// Рассчитать показатели формы распределения
        /// </summary>
        private void CalculateIndicatorsDistributionForm()
        {
            //var quartilleVariation = 
        }

        /// <summary>
        /// Заполнить списки для диаграмм выборки и графика интегральной функции
        /// Также происходит рассчет количества инверсий
        /// </summary>
        private void FillXYDiagramList()
        {
            var xySampleList = new List<XYPoint>();
            var xyFunctionList = new List<XYPoint>();

            int valuePointFunction = 0;
            foreach (var row in this.ValueList)
            {
                var argument = $"X{row.Number}";
                valuePointFunction += row.HitCount;

                var xyPointSample = new XYPoint
                {
                    Argument = argument,
                    Value = row.HitCount / (this.ExpDataList.Count() * this.Interval)
                };

                var xyPointFunction = new XYPoint
                {
                    Argument = argument,
                    Value = valuePointFunction
                };

                xyFunctionList.Add(xyPointFunction);
                xySampleList.Add(xyPointSample);
            }

            double preValue = 0;
            var inversionCount = 0;
            foreach (var point in xySampleList)
            {
                if (point.Value < preValue)
                    inversionCount++;

                preValue = point.Value;
            }

            this.XYSampleList = xySampleList;
            this.XYFunctionList = xyFunctionList;
            this.InversionCount = inversionCount;
        }
    }
}
