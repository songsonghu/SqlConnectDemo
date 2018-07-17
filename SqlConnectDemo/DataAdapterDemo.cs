using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlConnectDemo
{
    class DataAdapterDemo
    {
        static void Main()
        {
            //sql建立连接
            string connectionString = "Data Source=SONG-PC;Initial Catalog=school;Persist Security Info=True;User ID=sa; Password=123456";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                if(conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("连接成功！");
                }

                //SqlCommand cmd = new SqlCommand();
                //cmd.Connection = conn;
                //cmd.CommandText = "select * from student";
                //cmd.CommandType = CommandType.Text;

                //SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                ////或者adapter.SelectCommand = cmd;

                SqlDataAdapter adapter = new SqlDataAdapter("select * from student", conn);

                //创建DataSet和DataTable
                DataSet ds = new DataSet();
                DataTable dt = new DataTable("student");
                ds.Tables.Add(dt);

                //填充DataTable表格对象
                adapter.Fill(ds, "student");
                //显示DataTable对象中的记录
                ShowRecords(dt);
            }
            catch(Exception ex)
            {
                Console.WriteLine("错误信息：" + ex.Message);
            }
            finally
            { 
                if(conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine("已关闭连接");
                }
            }
            Console.ReadLine();
        }

        static void ShowRecords(DataTable dt)
        {
            //显示表格字段名
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                Console.Write(dt.Columns[i].ColumnName.ToString() + "    ");
            }
            Console.WriteLine();

            //显示数据记录
            for (int i = 0; i <= dt.Rows.Count - 1; i++)
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++)
                {
                    Console.Write(dt.Rows[i][j].ToString() + "  ");
                }
                Console.WriteLine();
            }

        }
    }
}
