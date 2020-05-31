using DevExpress.Xpf.Ribbon;
using ReliabilityAssessmentLibrary.Model;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace ReliabilityAssessmentApp
{
    /// <summary>
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : DXRibbonWindow
    {
        private VariationSeries _variationSeries;
        private int _rightCount = 0;
        public ResultWindow()
        {
            InitializeComponent();
        }

        public static void Execute(VariationSeries variationSeries)
        {
            var window = new ResultWindow();
            window._variationSeries = variationSeries ?? throw new ArgumentNullException(nameof(variationSeries));
            window.Show();
        }

        private void DXRibbonWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                tbWeightedAVG.Text = Math.Round(this._variationSeries.IndicatorsCenter.WeightedAVG, Settings.Default.Round).ToString();
                tbMode.Text = Math.Round(this._variationSeries.IndicatorsCenter.Mode, Settings.Default.Round).ToString();
                tbMedian.Text = Math.Round(this._variationSeries.IndicatorsCenter.Median, Settings.Default.Round).ToString();
                tbQuartils.Text = $"{Math.Round(this._variationSeries.IndicatorsCenter.Q1, Settings.Default.Round)} {Math.Round(this._variationSeries.IndicatorsCenter.Q2, Settings.Default.Round)} {Math.Round(this._variationSeries.IndicatorsCenter.Q3, Settings.Default.Round)}";
                tbDecils.Text = $"{Math.Round(this._variationSeries.IndicatorsCenter.D1, Settings.Default.Round)} {Math.Round(this._variationSeries.IndicatorsCenter.D9, Settings.Default.Round)}";
                tbQuartilCoeff.Text = Math.Round(this._variationSeries.IndicatorsCenter.QuartilCoeff, Settings.Default.Round).ToString();

                tbScope.Text = Math.Round(this._variationSeries.IndicatorsVariation.Scope, Settings.Default.Round).ToString();
                tbAVGLinearDeviation.Text = Math.Round(this._variationSeries.IndicatorsVariation.AVGLinearDeviation, Settings.Default.Round).ToString();
                tbDispersion.Text = Math.Round(this._variationSeries.IndicatorsVariation.Dispersion, Settings.Default.Round).ToString();
                tbUnbiasedDispersion.Text = Math.Round(this._variationSeries.IndicatorsVariation.UnbiasedDispersion, Settings.Default.Round).ToString();
                tbMeanSquareDeviation.Text = Math.Round(this._variationSeries.IndicatorsVariation.MeanSquareDeviation, Settings.Default.Round).ToString();
                tbEstimationMeanSquareDeviation.Text = Math.Round(this._variationSeries.IndicatorsVariation.EstimationMeanSquareDeviation, Settings.Default.Round).ToString();
                tbCoefVariation.Text = Math.Round(this._variationSeries.IndicatorsVariation.CoefVariation, Settings.Default.Round).ToString() + "%";
                tbLinearCoefVariation.Text = Math.Round(this._variationSeries.IndicatorsVariation.LinearCoefVariation, Settings.Default.Round).ToString() + "%";
                tbCoefOscillation.Text = Math.Round(this._variationSeries.IndicatorsVariation.CoefOscillation, Settings.Default.Round).ToString() + "%";

                tbQuartilleVariation.Text = Math.Round(this._variationSeries.IndicatorsForm.QuartilleVariation, Settings.Default.Round).ToString() + "%";
                tbCoeffAsymmetry.Text = Math.Round(this._variationSeries.IndicatorsForm.CoeffAsymmetry, Settings.Default.Round).ToString();
                tbMeanSquareeCoeffAsymmetry.Text = Math.Round(this._variationSeries.IndicatorsForm.MeanSquareeCoeffAsymmetry, Settings.Default.Round).ToString();
                tbCoeffAsymmetryPirson.Text = Math.Round(this._variationSeries.IndicatorsForm.CoeffAsymmetryPirson, Settings.Default.Round).ToString();
                tbExcess.Text = Math.Round(this._variationSeries.IndicatorsForm.Excess, Settings.Default.Round).ToString();
                tbMeanSquareCoeffExcess.Text = Math.Round(this._variationSeries.IndicatorsForm.MeanSquareCoeffExcess, Settings.Default.Round).ToString();

                this.tbValuesIsEquals.Background = this.CompareValues() > 20 ? Brushes.IndianRed : Brushes.LightGreen;

                var interval = this.CalculateRuleThreeSigm();
                var outValues = this._variationSeries.ExpDataList.FindAll(x => x < interval.Item1 && x > interval.Item2);
                var percentCountOutsideValues = (double)outValues.Count() / this._variationSeries.ExpDataList.Count * 100;
                this.tbRule3Sigm.Background = percentCountOutsideValues > 10 ? Brushes.IndianRed : Brushes.LightGreen;

                var coeffAssymetryAndExcessIsEqualsZero = (this._variationSeries.IndicatorsForm.CoeffAsymmetry > -1 && this._variationSeries.IndicatorsForm.CoeffAsymmetry < 1)
                    && (this._variationSeries.IndicatorsForm.Excess > -1 && this._variationSeries.IndicatorsForm.Excess < 1);
                this.tbCoeffAssymetryAndExcessEqualsZero.Background = !coeffAssymetryAndExcessIsEqualsZero ? Brushes.IndianRed : Brushes.LightGreen;

                this.tbInsignificantDeviation.Background = this._variationSeries.IndicatorsForm.Excess
                    / this._variationSeries.IndicatorsForm.MeanSquareCoeffExcess > 3
                    ? Brushes.IndianRed : Brushes.LightGreen;

                this.tbAsAndEx.Background = !this.CalculateAsAndEx() ? Brushes.IndianRed : Brushes.LightGreen;

                if (this.tbRule3Sigm.Background == Brushes.LightGreen)
                    this._rightCount++;

                if (this.tbCoeffAssymetryAndExcessEqualsZero.Background == Brushes.LightGreen)
                    this._rightCount++;

                if (this.tbInsignificantDeviation.Background == Brushes.LightGreen)
                    this._rightCount++;

                if (this.tbAsAndEx.Background == Brushes.LightGreen)
                    this._rightCount++;

                if (this.tbValuesIsEquals.Background == Brushes.LightGreen)
                    this._rightCount++;

                this.ShowResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show("УПС! Что-то пошло не так." + Environment.NewLine + ex.Message, "Возникла непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Сравнить показатели Мат. ожидания, моды и меданы
        /// </summary>
        /// <returns>Процентное отличие показателей</returns>
        private double CompareValues()
        {
            var weightAVG = this._variationSeries.IndicatorsCenter.WeightedAVG;
            var mode = this._variationSeries.IndicatorsCenter.Mode;
            var median = this._variationSeries.IndicatorsCenter.Median;

            var diffOne = Math.Abs((weightAVG - mode) / ((weightAVG + mode) / 2)) * 100;
            var diffTwo = Math.Abs((weightAVG - median) / ((weightAVG + median) / 2)) * 100;
            var diffThree = Math.Abs((mode - median) / ((median + median) / 2)) * 100;

            return (diffOne + diffTwo + diffThree) / 3;
        }

        /// <summary>
        /// Вычислить интервал по правилу 3 сигм
        /// </summary>
        /// <returns>Интервал</returns>
        private Tuple<double, double> CalculateRuleThreeSigm()
        {
            var lowerBound = this._variationSeries.IndicatorsCenter.WeightedAVG - 3 * this._variationSeries.IndicatorsVariation.MeanSquareDeviation;
            var upperBound = this._variationSeries.IndicatorsCenter.WeightedAVG + 3 * this._variationSeries.IndicatorsVariation.MeanSquareDeviation;

            return Tuple.Create(lowerBound, upperBound);
        }

        /// <summary>
        /// Проверим гипотезу о том, что Х распределено по нормальному закону с помощью показателей As и Ex
        /// </summary>
        private bool CalculateAsAndEx()
        {
            var coeffAsymmetry = Math.Abs(this._variationSeries.IndicatorsForm.CoeffAsymmetry) < 3 * this._variationSeries.IndicatorsForm.MeanSquareeCoeffAsymmetry;
            var coeffExcess = Math.Abs(this._variationSeries.IndicatorsForm.Excess) < 3 * this._variationSeries.IndicatorsForm.MeanSquareCoeffExcess;

            return coeffAsymmetry && coeffExcess;
        }

        /// <summary>
        /// Заполнить вкладку "Выводы"
        /// </summary>
        private void ShowResults()
        {
            this.tbResultQuartils.Text = $"Таким образом, 25% единиц совокупности будут меньше величины " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.Q1, Settings.Default.Round)}, 25% будут заключены между " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.Q1, Settings.Default.Round)} и " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.Q2, Settings.Default.Round)}, 25% - между " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.Q2, Settings.Default.Round)} и " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.Q3, Settings.Default.Round)}. Остальные 25% превосходят " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.Q3, Settings.Default.Round)}.";

            this.tbResultDecils.Text = $"Исходя из Децилей 10% единиц совокупности будут меньше величины " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.D1, Settings.Default.Round)}; 80% будут заключены между " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.D1, Settings.Default.Round)} и " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.D9, Settings.Default.Round)}; остальные 10% превосходят " +
                $"{Math.Round(this._variationSeries.IndicatorsCenter.D9, Settings.Default.Round)}.";

            this.tbRateVariations.Text = this._variationSeries.IndicatorsVariation.CoefVariation <= 30
                ? $"Поскольку коэффициент асимметрии ≤ 30%, то совокупность однородна, а вариация слабая. Полученным результатам можно доверять."
                : $"Поскольку коэффициент асимметрии > 30%, то совокупность неоднородна, а вариация сильная.";

            this.tbRateAsymmetry.Text = this._variationSeries.IndicatorsForm.CoeffAsymmetry < 0
                ? "Отрицательный знак коэффициента асиммметрии свидетельствует о наличии левосторонней асимметрии."
                : "Положительный знак коэффициента асиммметрии свидетельствует о наличии правостронней асимметрии.";

            if (this._variationSeries.IndicatorsForm.CoeffAsymmetry == 0)
                this.tbRateAsymmetry.Text = "То, что коэффициент асимметрии равен нулю свидетельствует о том, что асимметрия отсутствует";

            this.tbAsymmetryValue.Text = this._variationSeries.IndicatorsForm.CoeffAsymmetry
                / this._variationSeries.IndicatorsForm.MeanSquareeCoeffAsymmetry <= 3
                ? "В анализируемом ряду распределения наблюдается несущественная асимметрия."
                : "В анализируемом ряду распределения наблюдается существенная асимметрия. Распределение признака в генеральной совокупности не является симметричным.";

            if (this._variationSeries.IndicatorsForm.CoeffAsymmetry == 0)
                this.tbAsymmetryValue.Text = "В анализируемом ряду асимметрия не наблюдается.";

            if (this._rightCount > 2)
                this.tbLaw.Text = $"Исходя из полученных результатов принадлежность опытных данных нормальному закону не отвергается. Оценка параметра σ равна оценке среднего квадратического отклонения выборки и равна " +
                    $"{Math.Round(this._variationSeries.IndicatorsVariation.EstimationMeanSquareDeviation, Settings.Default.Round)}. Оценка параметра Mt, представляющего собой среднее значение случайной величины t" +
                    $", равна оценке математического ожидания выборки {Math.Round(this._variationSeries.IndicatorsCenter.WeightedAVG, Settings.Default.Round)}";
            else
                this.tbLaw.Text = $"Исходя из полученных результатов принадлежность опытных данных экспоненциальному (показательному) закону не отвергается. Оценка параметра распределения, λ, находится по формуле 1 / μ и равна {1 / this._variationSeries.IndicatorsCenter.WeightedAVG}";
        }
    }
}
