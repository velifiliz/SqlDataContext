using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace _test
{
    public partial class Form1 : Form
    {
        DataContext Sql = new DataContext()
        {
            ConnectionString = @"Data Source=XXXXXXXXX;Initial Catalog=Example;Persist Security Info=True;User ID=SA;Password=XXXXXXXX"
        };

        public Form1()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {

            // COMMAND
            /* Veri Ekleme Silme veya Güncelleme Ýþlemleri Ýçin Kullanabileceðiniz Boolean Türünde Metod */
            Sql.GetCommand("INSERT INTO Number (Value) VALUES ('10')");


            // DATATABLE
            /* Veritablosu Çekebileceðiniz DataTable Türünde Metod */
            Sql.GetDataTable("SELECT * FROM Number");
            // Örn 
            // gridview1.datasource = Sql.GetDataTable("SELECT * FROM Number");

            // DATAROW 
            Sql.GetDataRow("SELECT * FROM Number");
            // Örn
            //DataRow dr = Sql.GetDataRow("SELECT * FROM Number WHERE Id=1");
            //string d = dr["Value"].ToString();


            // DATACELL
            /* Verdiðimiz Þarta Baðlý Olarak Tablomuzun Ýstediðimiz Satýrýna Baðlý Olan Hücreyi String Türünde Geri Döndrürür */
            Sql.GetDataCell("SELECT Value FROM Number WHERE Id=1");
            // Örn
            // string bilgi = Sql.GetDataCell("SELECT Value FROM Number WHERE Id=1");

            // DATASET
            /* Bunu Hepiniz Biliyorsunuzdur Zaten  */
            Sql.GetDataSet("SELECT * FROM Number");
            // Örn
            //DataSet ds = Sql.GetDataSet("SELECT * FROM Number");
            //foreach (DataRow item in ds.Tables[0].Rows)
            //{
            //    MessageBox.Show(item["Value"].ToString());
            //}

            //DATA JSON
            /* Sorgumuza Baðlý Olarak Tablomuzu JSON Türünde Bize Geri Döndürür */
            Sql.GetDataJson("SELECT * FROM Number");

            //DATA XML
            /* Sorgumuza Baðlý Olarak Tablomuzu XML Türünde Bize Geri Döndürür */
            Sql.GetDataXml("SELECT * FROM Number");




            SqlConnection Con = Sql.Connection;
            Con.ConnectionString = Sql.ConnectionString;

            SqlCommand Com = Sql.Command;
            Com.Connection = Con;
            Com.Connection.Open();

            Com.CommandText = "INSERT INTO Number (Value) VALUES (@Params)";
            Com.Parameters.AddWithValue("@Params", "20");
            Com.ExecuteNonQuery();

            Com.Connection.Close();
            Com.Dispose();

            // Dilerseniz Yukarýdaki Gibide SqlConnection ve SqlCommand Neslerinin Bütün Özelliklerini Kullanabilirsiniz.

        }
    }
}
