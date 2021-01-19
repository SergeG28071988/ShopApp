using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;


namespace ShopApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "myCorpDataSet.Director". При необходимости она может быть перемещена или удалена.
            this.directorTableAdapter.Fill(this.myCorpDataSet.Director);
            cartesianChart1.LegendLocation = LegendLocation.Bottom;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.directorTableAdapter.Fill(this.myCorpDataSet.Director);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            SeriesCollection series = new SeriesCollection();

            ChartValues<int> directValues = new ChartValues<int>();

            List<string> dates = new List<string>();

            foreach (var directRow in myCorpDataSet.Director)
            {
                directValues.Add(directRow.Profit);

                dates.Add(directRow.Date.ToShortDateString());
            }
            cartesianChart1.AxisX.Clear();

            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Даты",
                Labels = dates
            });

            LineSeries directLine = new LineSeries();

            directLine.Title = "Продажи";

            directLine.Values = directValues;

            series.Add(directLine);

            cartesianChart1.Series = series;
        }
    }
}
