using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SqlConnectDemo
{
    class DataSetDemo
    {
        static void Main2()
        {
            DataSet ds = new DataSet();

            //创建一个表格
            DataTable dt = new DataTable("book");
            dt.Columns.Add(new DataColumn("书名", typeof(string)));
            dt.Columns.Add(new DataColumn("书号", typeof(string)));
            
            DataColumn[] dataCols = new DataColumn[2];
            dataCols[0] = new DataColumn("价格", typeof(string));
            dataCols[1] = new DataColumn("出版社", typeof(string));
            dt.Columns.AddRange(dataCols);

            //将表格添加到DataSet中
            ds.Tables.Add(dt);
            
            //添加记录到表格中
            DataRow dr = dt.NewRow();
            dr["书名"] = "C#编程系列";
            dr["书号"] = "1234-235-60";
            dr["价格"] = "88.50";
            dr["出版社"] = "清华出版社";
            dt.Rows.Add(dr);

            dt.Rows.Add(new object[]{"数据结构", "360-256-30", 22.30, "机械工业出版社"});
            
            //显示数据
            ShowRecords(dt);
            Console.ReadLine();
        }

        static void ShowRecords(DataTable dt)
        { 
            //显示表格字段名
            for (int i = 0; i <= dt.Columns.Count - 1; i++ )
            {
                Console.Write(dt.Columns[i].ColumnName.ToString() + "    ");
            }
            Console.WriteLine();

            //显示数据记录
            for (int i = 0; i <= dt.Rows.Count - 1; i++ )
            {
                for (int j = 0; j <= dt.Columns.Count - 1; j++ )
                {
                    Console.Write(dt.Rows[i][j].ToString() + "  ");
                }
                Console.WriteLine();
            }

        }
    }
}
