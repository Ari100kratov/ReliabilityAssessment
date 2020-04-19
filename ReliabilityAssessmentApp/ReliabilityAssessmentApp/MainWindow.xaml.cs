using DevExpress.Spreadsheet.Charts;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Ribbon;
using ReliabilityAssessmentLibrary;
using ReliabilityAssessmentLibrary.Model;
using ReliabilityAssessmentLibrary.Model.ChartModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DXRibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void sbStart_Click(object sender, RoutedEventArgs e)
        {
            var valueList = this.teInput.Text.Split(' ').Select(x => Convert.ToDouble(x)).ToList();

            var variationSeriesMain = new VariationSeries(valueList);
            var variationSeriesLess = new VariationSeries(valueList, variationSeriesMain.IntervalCount - 1);
            var variationSeriesMore = new VariationSeries(valueList, variationSeriesMain.IntervalCount + 1);

            this.gcSeriesMain.ItemsSource = variationSeriesMain.ValueList;
            this.gcSeriesLess.ItemsSource = variationSeriesLess.ValueList;
            this.gcSeriesMore.ItemsSource = variationSeriesMore.ValueList;

            this.chartSampleLess.DataSource = variationSeriesLess.XYSampleList;
            this.chartSampleMain.DataSource = variationSeriesMain.XYSampleList;
            this.chartSampleMore.DataSource = variationSeriesMore.XYSampleList;

            this.chartFunctionLess.DataSource = variationSeriesLess.XYFunctionList;
            this.chartFunctionMain.DataSource = variationSeriesMain.XYFunctionList;
            this.chartFunctionMore.DataSource = variationSeriesMore.XYFunctionList;

            this.lblMathExpLess.Content = variationSeriesLess.CharactVariable.MathExpectation;
            this.lblDispersionLess.Content = variationSeriesLess.CharactVariable.Dispersion;
            this.lblSquareLess.Content = variationSeriesLess.CharactVariable.SquareDeviation;
            this.lblCoefVariationLess.Content = variationSeriesLess.CharactVariable.CoeffVariation;
            this.lblIntervalSizeLess.Content = variationSeriesLess.Interval;
            this.lblIntervalCountLess.Content = variationSeriesLess.IntervalCount;
            this.lblInversionCountLess.Content = variationSeriesLess.InversionCount;

            this.lblMathExpMain.Content = variationSeriesMain.CharactVariable.MathExpectation;
            this.lblDispersionMain.Content = variationSeriesMain.CharactVariable.Dispersion;
            this.lblSquareMain.Content = variationSeriesMain.CharactVariable.SquareDeviation;
            this.lblCoefVariationMain.Content = variationSeriesMain.CharactVariable.CoeffVariation;
            this.lblIntervalSizeMain.Content = variationSeriesMain.Interval;
            this.lblIntervalCountMain.Content = variationSeriesMain.IntervalCount;
            this.lblInversionCountMain.Content = variationSeriesMain.InversionCount;

            this.lblMathExpMore.Content = variationSeriesMore.CharactVariable.MathExpectation;
            this.lblDispersionMore.Content = variationSeriesMore.CharactVariable.Dispersion;
            this.lblSquareMore.Content = variationSeriesMore.CharactVariable.SquareDeviation;
            this.lblCoefVariationMore.Content = variationSeriesMore.CharactVariable.CoeffVariation;
            this.lblIntervalSizeMore.Content = variationSeriesMore.Interval;
            this.lblIntervalCountMore.Content = variationSeriesMore.IntervalCount;
            this.lblInversionCountMore.Content = variationSeriesMore.InversionCount;
        }
    }
}
