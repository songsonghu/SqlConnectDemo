using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlConnectDemo
{
    class Program
    {
        static void Main1(string[] args)
        {
            //sql建立连接
            string connectionString = "Data Source=SONG-PC;Initial Catalog=school;Persist Security Info=True;User ID=sa; Password=123456";
            SqlConnection conn = new SqlConnection(connectionString);
            try
            {
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("连接成功！");
                    Console.WriteLine("当前字符串为：" + conn.ConnectionString);
                    Console.WriteLine();
                }

                //TODO:发送Command命令
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;

                //查询数据记录
                cmd.CommandText = "select * from student";
                cmd.CommandType = CommandType.Text;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Console.WriteLine(reader[0] + "-" + reader[1] + "-" + reader[2] + "-" + reader[3] + "-" + reader[4]);
                }
                reader.Close();     //要记得每次调用SqlDataReader读取数据后，都要Close();
                Console.WriteLine();  //换行

                //删除数据记录
                cmd.CommandText = "delete from student where sname = '张三'";
                int i = cmd.ExecuteNonQuery();
                if (1 == i)
                {
                    Console.WriteLine("删除张三成功！" + i);
                }
                else
                {
                    Console.WriteLine("该用户记录不存在，无法删除！");
                }

                cmd.CommandText = "select * from student";
                SqlDataReader reader2 = cmd.ExecuteReader();
                while (reader2.Read())
                {
                    Console.WriteLine(reader2[0] + "-" + reader2[1] + "-" + reader2[2] + "-" + reader2[3] + "-" + reader2[4]);
                }
                reader2.Close();
                Console.WriteLine();

                //新增数据记录
                cmd.CommandText = "insert into student values(1004, '李四', 30, '男', '湖北武汉市')";
                cmd.ExecuteNonQuery();
                Console.WriteLine("新增李四成功！");

                cmd.CommandText = "select * from student";
                SqlDataReader reader3 = cmd.ExecuteReader();
                while (reader3.Read())
                {
                    Console.WriteLine(reader3[0] + "-" + reader3[1] + "-" + reader3[2] + "-" + reader3[3] + "-" + reader3[4]);
                }
                reader3.Close();
                Console.WriteLine();

                //TODO:更新数据记录
                cmd.CommandText = "update student set splace = '湖北襄阳市' where sname = '李四'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "select * from student";
                SqlDataReader reader4 = cmd.ExecuteReader();
                while (reader4.Read())
                {
                    Console.WriteLine(reader4[0] + "-" + reader4[1] + "-" + reader4[2] + "-" + reader4[3] + "-" + reader4[4]);
                }
                reader4.Close();

                Console.ReadLine();

            }
            catch (SqlException sqlEx)
            {
                if (conn.State != ConnectionState.Open)
                {
                    Console.WriteLine("连接失败！");
                    Console.WriteLine("错误信息是：{0}" + sqlEx.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("错误信息是：{0}" + ex.Message);
            }
            finally
            {
                //关闭连接
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                    Console.WriteLine("已经关闭连接。");
                }

            }

        }
    }
}
