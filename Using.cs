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
            /* Veri Ekleme Silme veya G�ncelleme ��lemleri ��in Kullanabilece�iniz Boolean T�r�nde Metod */
            Sql.GetCommand("INSERT INTO Number (Value) VALUES ('10')");


            // DATATABLE
            /* Veritablosu �ekebilece�iniz DataTable T�r�nde Metod */
            Sql.GetDataTable("SELECT * FROM Number");
            // �rn 
            // gridview1.datasource = Sql.GetDataTable("SELECT * FROM Number");

            // DATAROW 
            Sql.GetDataRow("SELECT * FROM Number");
            // �rn
            //DataRow dr = Sql.GetDataRow("SELECT * FROM Number WHERE Id=1");
            //string d = dr["Value"].ToString();


            // DATACELL
            /* Verdi�imiz �arta Ba�l� Olarak Tablomuzun �stedi�imiz Sat�r�na Ba�l� Olan H�creyi String T�r�nde Geri D�ndr�r�r */
            Sql.GetDataCell("SELECT Value FROM Number WHERE Id=1");
            // �rn
            // string bilgi = Sql.GetDataCell("SELECT Value FROM Number WHERE Id=1");

            // DATASET
            /* Bunu Hepiniz Biliyorsunuzdur Zaten  */
            Sql.GetDataSet("SELECT * FROM Number");
            // �rn
            //DataSet ds = Sql.GetDataSet("SELECT * FROM Number");
            //foreach (DataRow item in ds.Tables[0].Rows)
            //{
            //    MessageBox.Show(item["Value"].ToString());
            //}

            //DATA JSON
            /* Sorgumuza Ba�l� Olarak Tablomuzu JSON T�r�nde Bize Geri D�nd�r�r */
            Sql.GetDataJson("SELECT * FROM Number");

            //DATA XML
            /* Sorgumuza Ba�l� Olarak Tablomuzu XML T�r�nde Bize Geri D�nd�r�r */
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

            // Dilerseniz Yukar�daki Gibide SqlConnection ve SqlCommand Neslerinin B�t�n �zelliklerini Kullanabilirsiniz.

        }
    }
}
