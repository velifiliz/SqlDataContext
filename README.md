# SqlDataContext


<snippet>
  <content><![CDATA[
# ${1:Project Name}

.NET ile Yazdığınız Projelerinizde Sql İşlemlerinizi Yapmak İçin Kullanabileceğiniz Dll Kütüphanesi.

## Kurulum

İndirdiğiniz Dll Dosyasını Projenize Dahil Ediniz.

## Kullanım

        DataContext Sql = new DataContext()
        {
            ConnectionString = @"Data Source=XXXXXXXXX;Initial Catalog=Example;Persist Security Info=True;User ID=SA;Password=XXXXXXXX"
        };

            // COMMAND
            /* Veri Ekleme Silme veya Güncelleme İşlemleri İçin Kullanabileceğiniz Boolean Türünde Metod */
            Sql.GetCommand("INSERT INTO Number (Value) VALUES ('10')");


            // DATATABLE
            /* Veritablosu Çekebileceğiniz DataTable Türünde Metod */
            Sql.GetDataTable("SELECT * FROM Number");
            // Örn 
            // gridview1.datasource = Sql.GetDataTable("SELECT * FROM Number");

            // DATAROW 
            Sql.GetDataRow("SELECT * FROM Number");
            // Örn
            //DataRow dr = Sql.GetDataRow("SELECT * FROM Number WHERE Id=1");
            //string d = dr["Value"].ToString();


            // DATACELL
            /* Verdiğimiz Şarta Bağlı Olarak Tablomuzun İstediğimiz Satırına Bağlı Olan Hücreyi String Türünde Geri Döndrürür */
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
            /* Sorgumuza Bağlı Olarak Tablomuzu JSON Türünde Bize Geri Döndürür */
            Sql.GetDataJson("SELECT * FROM Number");

            //DATA XML
            /* Sorgumuza Bağlı Olarak Tablomuzu XML Türünde Bize Geri Döndürür */
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

            // Dilerseniz Yukarıdaki Gibide SqlConnection ve SqlCommand Neslerinin Bütün Özelliklerini Kullanabilirsiniz.
