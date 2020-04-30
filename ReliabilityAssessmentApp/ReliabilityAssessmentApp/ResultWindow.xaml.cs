using DevExpress.Xpf.Ribbon;
using ReliabilityAssessmentLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ReliabilityAssessmentApp
{
    /// <summary>
    /// Логика взаимодействия для ResultWindow.xaml
    /// </summary>
    public partial class ResultWindow : DXRibbonWindow
    {
        private VariationSeries _variationSeries;
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
            tbCoefVariation.Text = Math.Round(this._variationSeries.IndicatorsVariation.Scope, Settings.Default.Round).ToString() + "%";
            tbLinearCoefVariation.Text = Math.Round(this._variationSeries.IndicatorsVariation.LinearCoefVariation, Settings.Default.Round).ToString() + "%";
            tbCoefOscillation.Text = Math.Round(this._variationSeries.IndicatorsVariation.CoefOscillation, Settings.Default.Round).ToString() + "%";

            tbQuartilleVariation.Text = Math.Round(this._variationSeries.IndicatorsForm.QuartilleVariation, Settings.Default.Round).ToString() + "%";
            tbCoeffAsymmetry.Text = Math.Round(this._variationSeries.IndicatorsForm.CoeffAsymmetry, Settings.Default.Round).ToString();
            tbMeanSquareeCoeffAsymmetry.Text = Math.Round(this._variationSeries.IndicatorsForm.MeanSquareeCoeffAsymmetry, Settings.Default.Round).ToString();
            tbCoeffAsymmetryPirson.Text = Math.Round(this._variationSeries.IndicatorsForm.CoeffAsymmetryPirson, Settings.Default.Round).ToString();
            tbExcess.Text = Math.Round(this._variationSeries.IndicatorsForm.Excess, Settings.Default.Round).ToString();
            tbMeanSquareCoeffExcess.Text = Math.Round(this._variationSeries.IndicatorsForm.MeanSquareCoeffExcess, Settings.Default.Round).ToString();
        }
    }
}
