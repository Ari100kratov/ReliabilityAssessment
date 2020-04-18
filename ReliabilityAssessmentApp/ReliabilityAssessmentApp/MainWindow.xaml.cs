using DevExpress.Xpf.Ribbon;
using ReliabilityAssessmentLibrary;
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
            //var dataModel = new DataModel(valueList);
            //var standardCalculation = new StandardPointEstimate(dataModel);

            //this.lbResult.Items.Add($"Оценка математического ожидания {standardCalculation.GetMathematicalExpectation()}");
            //this.lbResult.Items.Add($"Оценка дисперсии {standardCalculation.GetEstimationVariance()}");
            //this.lbResult.Items.Add($"Среднее квадратичное отклонение {standardCalculation.GetMeanSquareDeviation()}");
            //this.lbResult.Items.Add($"Коэффициент вариации {standardCalculation.CoefficientVariation()}");

            var variationSeries2 = new VariationSeries(valueList);
            var variationSeries1 = new VariationSeries(valueList, variationSeries2.IntervalCount - 1);
            var variationSeries3 = new VariationSeries(valueList, variationSeries2.IntervalCount + 1);

            this.gcSeriesMain.ItemsSource = variationSeries2.ValueList;
            this.gcSeriesLess.ItemsSource = variationSeries1.ValueList;
            this.gcSeriesMore.ItemsSource = variationSeries3.ValueList;

        }
    }
}
