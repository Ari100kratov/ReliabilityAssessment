using DevExpress.Spreadsheet.Charts;
using DevExpress.Xpf.Charts;
using DevExpress.Xpf.Ribbon;
using ReliabilityAssessmentLibrary;
using ReliabilityAssessmentLibrary.Model;
using ReliabilityAssessmentLibrary.Model.ChartModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
        private VariationSeries _variationSeriesMain;
        private VariationSeries _variationSeriesLess;
        private VariationSeries _variationSeriesMore;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void sbStart_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.WorkerReportsProgress = true;
                worker.DoWork += worker_DoWork;
                worker.ProgressChanged += worker_ProgressChanged;
                Settings.Default.Round = Convert.ToInt32(this.seRound.Value);
                Settings.Default.Save();
                var separator = string.IsNullOrEmpty(this.teSeparator.Text) ? " " : this.teSeparator.Text;
                var valueList = this.teInput.Text.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                if (valueList.Count < 10)
                {
                    MessageBox.Show("Пожалуйста, введите не менее 10 значений для более качественного анализа"
                        , "Некоррeктность ввода"
                        , MessageBoxButton.OK
                        , MessageBoxImage.Warning);

                    return;
                }

                foreach (var value in valueList)
                {
                    if (!double.TryParse(value, out var correctValue))
                    {
                        MessageBox.Show("Не все введденные значения являются числами"
                            , "Некоррeктность ввода"
                            , MessageBoxButton.OK
                            , MessageBoxImage.Warning);

                        return;
                    }
                }

                var expData = valueList.Select(x => Convert.ToDouble(x)).ToList();

                this._variationSeriesMain = new VariationSeries(expData, Settings.Default.Round);
                this._variationSeriesLess = new VariationSeries(expData, Settings.Default.Round, this._variationSeriesMain.IntervalCount - 1);
                this._variationSeriesMore = new VariationSeries(expData, Settings.Default.Round, this._variationSeriesMain.IntervalCount + 1);
                var annotation = new Annotation();
                annotation.Content = "Моя аннтотация";
                this.pbLoading.Visibility = Visibility.Visible;
                this.chartSampleLess.Annotations.Add(annotation);
                this.tbLoading.Visibility = Visibility.Visible;
                worker.RunWorkerAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show("УПС! Что-то пошло не так." + Environment.NewLine + ex.Message, "Возникла непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i <= 1000; i++)
                {

                    (sender as BackgroundWorker).ReportProgress(i);
                    Thread.Sleep(2);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("УПС! Что-то пошло не так." + Environment.NewLine + ex.Message, "Возникла непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                pbLoading.Value = e.ProgressPercentage;
                var calcValue = (double)e.ProgressPercentage / 10 + 0.01;
                var percent = $"{calcValue.ToString("00.00")} %";
                var text = string.Empty;

                if (e.ProgressPercentage < 250)
                {
                    this.lblIntervalSizeLess.Content = Math.Round(_variationSeriesLess.Interval, Settings.Default.Round);
                    this.lblIntervalCountLess.Content = _variationSeriesLess.IntervalCount;
                    this.lblInversionCountLess.Content = _variationSeriesLess.InversionCount;

                    this.lblIntervalSizeMain.Content = Math.Round(_variationSeriesMain.Interval, Settings.Default.Round);
                    this.lblIntervalCountMain.Content = _variationSeriesMain.IntervalCount;
                    this.lblInversionCountMain.Content = _variationSeriesMain.InversionCount;

                    this.lblIntervalSizeMore.Content = Math.Round(_variationSeriesMore.Interval, Settings.Default.Round);
                    this.lblIntervalCountMore.Content = _variationSeriesMore.IntervalCount;
                    this.lblInversionCountMore.Content = _variationSeriesMore.InversionCount;
                    text = "Создаем вариационный ряд...";
                }
                else if (e.ProgressPercentage < 500)
                {
                    this.gcSeriesMain.ItemsSource = _variationSeriesMain.ValueList;
                    this.gcSeriesLess.ItemsSource = _variationSeriesLess.ValueList;
                    this.gcSeriesMore.ItemsSource = _variationSeriesMore.ValueList;
                    text = "Строим гистограммы выборки и полигоны...";
                }
                else if (e.ProgressPercentage < 750)
                {
                    this.chartSampleLess.DataSource = _variationSeriesLess.XYSampleList;
                    this.chartSampleMain.DataSource = _variationSeriesMain.XYSampleList;
                    this.chartSampleMore.DataSource = _variationSeriesMore.XYSampleList;
                    text = "Создаем графики интегральных функций...";
                }
                else if (e.ProgressPercentage < 1000)
                {
                    this.chartFunctionLess.DataSource = _variationSeriesLess.XYFunctionList;
                    this.chartFunctionMain.DataSource = _variationSeriesMain.XYFunctionList;
                    this.chartFunctionMore.DataSource = _variationSeriesMore.XYFunctionList;
                    text = "Рассчитываем характеристики распределения...";
                }
                else
                {
                    this.tbLoading.Visibility = Visibility.Collapsed;
                    this.pbLoading.Visibility = Visibility.Collapsed;
                    this.tbLoading.Text = string.Empty;
                    this.pbLoading.Value = 0;
                }

                tbLoading.Text = $"{text} {percent}%";
            }
            catch (Exception ex)
            {
                MessageBox.Show("УПС! Что-то пошло не так." + Environment.NewLine + ex.Message, "Возникла непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void sbLoadFromFile_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Create OpenFileDialog 
                Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

                // Set filter for file extension and default file extension 
                dlg.DefaultExt = ".txt";
                //dlg.Filter = "(*.*)";

                // Display OpenFileDialog by calling ShowDialog method 
                var result = dlg.ShowDialog();

                // Get the selected file name and display in a TextBox 
                if (result == true)
                {
                    // Open document 
                    if (!File.Exists(dlg.FileName))
                    {
                        MessageBox.Show("Такого файла не существует", "Файл не выбран", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return;
                    }

                    using (StreamReader sr = new StreamReader(dlg.FileName))
                    {
                        string line = await sr.ReadToEndAsync();
                        teInput.Text = line;
                    }
                }
            }
            catch (IOException ex)
            {
                MessageBox.Show("УПС! Нельзя прочитать выбранный файл." + Environment.NewLine + ex.Message, "Ошибка чтения файла", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("УПС! Что-то пошло не так." + Environment.NewLine + ex.Message, "Возникла непредвиденная ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
