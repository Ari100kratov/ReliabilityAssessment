using ReliabilityAssessmentLibrary.Factory;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReliabilityAssessmentLibrary.Model
{
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


        public VariationSeries(List<double> expData)
        {
            if (expData == null)
                throw new ArgumentNullException(nameof(expData));

            if (!expData.Any())
                throw new ArgumentException("List is empty");

            this.ExpDataList = expData;
            this.CreateVariationSeries();
        }

        /// <summary>
        /// Создать вариационный ряд на основе экспериментальных данных
        /// </summary>
        private void CreateVariationSeries()
        {
            this.ValueList = new List<RowElement>();
            var rowElementFactory = new RowElementFactory();

            var intervalCount = Math.Floor(1 + 3.3 * Math.Log10(this.ExpDataList.Count()));

            if (intervalCount == 0)
                throw new Exception("Count of intervals can't be 0");

            this.ExpDataList.Sort();
            var interval = (this.ExpDataList.Max() - this.ExpDataList.Min()) / intervalCount;
            var lowerBound = this.ExpDataList.Min();

            for (var i = 1; i <= intervalCount; i++)
            {
                var upperBound = lowerBound + interval;
                var hitCount = this.ExpDataList.FindAll(x => x >= lowerBound && x <= upperBound).Count();

                var rowElement = rowElementFactory.Create(i, lowerBound, interval, hitCount);
                this.ValueList.Add(rowElement);

                lowerBound = upperBound;
            }
        }
    }
}
