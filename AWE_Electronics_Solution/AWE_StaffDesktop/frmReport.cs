using System;
using System.Windows.Forms;
using AWE_BLL;
using System.Windows.Forms.DataVisualization.Charting;

namespace AWE_StaffDesktop
{
    public partial class frmReport : Form
    {
        public frmReport()
        {
            InitializeComponent();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {
            LoadStats();
        }

        private void LoadStats()
        {
            try
            {
                StatisticBLL bll = new StatisticBLL();

                // 1. Hiển thị số liệu tổng quan
                var general = bll.GetGeneralReport();
                lblRevenue.Text = "TOTAL REVENUE: " + general.TotalRevenue.ToString("N0") + " VNĐ";
                lblWarning.Text = "OUT OF STOCK (<10): " + general.LowStockCount;

                // 2. Vẽ biểu đồ tròn (Pie Chart)
                var chartData = bll.GetChartData();

                chartStock.Series.Clear(); 
                Series series = new Series("Stock");
                series.ChartType = SeriesChartType.Pie; 

                foreach (var item in chartData)
                {
                    // Thêm dữ liệu vào biểu đồ
                    series.Points.AddXY(item.CategoryName, item.TotalStock);
                }

                // Hiển thị nhãn giá trị trên biểu đồ
                series.IsValueShownAsLabel = true;
                chartStock.Series.Add(series);
                chartStock.Titles.Add(" Inventory turnover");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while load report: " + ex.Message);
            }
        }
    }
}