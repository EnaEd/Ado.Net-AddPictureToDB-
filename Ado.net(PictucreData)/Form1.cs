using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//для работы с БД
using System.Data;
using System.Data.SqlClient;
//Для работы с конфиг файлом
using System.Configuration;//дополнительно подключаем ссылку

namespace Ado.net_PictucreData_
{
    public partial class Form1 : Form
    {
        SqlConnection conn = null;//класс для подключения
        SqlDataAdapter da = null;//для работы с командами
        DataSet ds = null;//для работы с данными и отображения их в таблицу
        SqlCommandBuilder cmdBild = null;//для авто создания комманд(update,insert,delete)
        DataTable table = null;//таблица для локальных данных
        

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);//Определяем сотроку подключения из конфиг файла
        }

        private void btnFill_Click(object sender, EventArgs e)
        {
            da = new SqlDataAdapter(TxtBxQuery.Text, conn);
            cmdBild = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "myBook");
            dataGridView1.DataSource = ds.Tables["myBook"];
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            da.Update(ds,"myBook");
        }

        private void btnAddFoto_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.Show();
        }
    }
}
