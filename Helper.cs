using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using DevComponents.DotNetBar;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace QLHS
{
    class Helper
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Error { get; set; }


        // Hàm khởi tạo sẽ khởi tạo đối tượng để ghi vào file
        public Helper()
        {
            // khởi tạo đối tượng reader ghi dữ liệu vào file ConnectString.con
            StreamReader reader = new StreamReader(Application.StartupPath+@"\Cauhinh.conf");
            this.Server = reader.ReadLine().Split(':')[1];
            this.Database = reader.ReadLine().Split(':')[1];
            this.Username = reader.ReadLine().Split(':')[1];
            this.Password = reader.ReadLine().Split(':')[1];
            reader.Close();
        }

        // Hàm lấy chuỗi kết nối
        public SqlConnection getConnect()
        {
            if (this.Username != "")
                return new SqlConnection("Data Source=" + this.Server + ";Initial Catalog=" + this.Database + ";User Id=" + this.Username + ";Password=" + this.Password + ";");
            else
                return new SqlConnection("Data Source=" + this.Server + ";Initial Catalog=" + this.Database + ";Integrated Security=True");
        }

        // Hàm ghi thông tin vào file
        public static void GhiFile(string server, string data, string uid, string pass)
        {
            StreamWriter writer = new StreamWriter(Application.StartupPath+@"\Cauhinh.conf");
            writer.WriteLine("Server:" + server);
            writer.WriteLine("Database:" + data);
            writer.WriteLine("User:" + uid);
            writer.WriteLine("Password:" + pass);
            writer.Close();
        }

        //Hàm lấy dữ liệu trả về bảng
        public DataTable getData(string strSQL, SqlConnection con)
        {
            //gán câu SQL cho đối tượng command
            SqlCommand cmd = new SqlCommand(strSQL, con);

            //Dùng DataAdapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            try
            {
                da.Fill(ds);
                dt = ds.Tables[0];
            }
            catch { }
            finally
            {
                if (con != null) con.Close();
                if (da != null) da.Dispose();
            }
            return dt;
        }
        
       
        // Hàm AutoUpdate dữ liệu
        public void AutoUpdate(string sql, SqlConnection con, DataGridViewX nameDgv)
        {
            //gán câu SQL cho đối tượng command
            SqlCommand cmd = new SqlCommand(sql, con);
            //Dùng DataAdapter
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable dt = (DataTable)nameDgv.DataSource;
            SqlCommandBuilder cb = new SqlCommandBuilder(da);
            da.Update(dt);
        }

        // Hàm update
        public bool UpdateData(string strSQL, SqlConnection con)
        {
            if (con.State == ConnectionState.Closed) con.Open();
            SqlCommand sqlUpdate = new SqlCommand(strSQL, con);
            int kq = 0;
            try
            {
                kq = sqlUpdate.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            if(con!=null) con.Close(); // ngắt kết nối
            if (kq <= 0) return false;
            return true;
        }

       // Hàm insert
        public bool InsertData(string strSQL, SqlConnection con)
        {
            if (con.State == ConnectionState.Closed)
                if (!Connect(con)) return false;
            SqlCommand sqlInsert = new SqlCommand(strSQL, con);
            int kq = 0;
            try
            {
                kq = sqlInsert.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            con.Close(); // ngắt kết nối
            if (kq <= 0) return false;
            return true;
        }
      // Hàm kết nối
        private bool Connect(SqlConnection con)
        {
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }

      
    }
}
