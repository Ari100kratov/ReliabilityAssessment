using ReliabilityAssessmentLibrary.Factory;
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
        /// Список значений вариационного ряда
        /// </summary>
        public List<RowElement> ValueList { get; private set; }

        /// <summary>
        /// Количество интервалов
        /// </summary>
        public int IntervalCount { get; private set; }

        /// <summary>
        /// Ширина интервала
        /// </summary>
        public double Interval { get; private set; }

        public VariationSeries(List<double> expData, int intervalCount = 0)
        {
            if (expData == null)
                throw new ArgumentNullException(nameof(expData));

            if (!expData.Any())
                throw new ArgumentException("List is empty");

            if (intervalCount < 0)
                throw new ArgumentOutOfRangeException(nameof(intervalCount), "Can't be less 0");

            this.IntervalCount = IntervalCount;
            this.ExpDataList = expData;
            this.CreateVariationSeries();
            this.CalculateCharactVariable();
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
        }

        /// <summary>
        /// Рассчитать характеристики случайной величины
        /// </summary>
        private void CalculateCharactVariable()
        {
            var charactVariableFactory = new CharactVariableFactory();
            var mathExpectation = this.ValueList.Select(x => x.MidInterval * x.HitCount).Sum() / this.ValueList.Count();
            var dispersion = (1 / (this.ValueList.Count() - 1)) / (this.ValueList.Select(x => Math.Pow(x.MidInterval - mathExpectation, 2) * x.HitCount).Sum());

            this.CharactVariable = charactVariableFactory.Create(mathExpectation, dispersion);
        }
    }
}
