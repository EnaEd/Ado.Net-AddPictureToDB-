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
//
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Drawing.Imaging;

namespace Ado.net_PictucreData_
{
    public partial class Form2 : Form
    {
        SqlConnection conn = null;
        SqlDataAdapter da = null;
        SqlCommandBuilder cmdBldr = null;
        DataSet ds = null;
        string fileName = "";
        public Form2()
        {
            InitializeComponent();
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Picture files|*gif;*jpg;*png;*bmp";
            ofd.FileName = "";
            if (ofd.ShowDialog() == DialogResult.OK) {
                fileName = ofd.FileName;
                LoadPicture();
            }
        }
        public void LoadPicture() {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString)) {//создание строки подключения
                byte[] bites;//массив для нашего рисунка
                bites = CreateCopy();//заполняем массив
                conn.Open();
                SqlCommand cmd = new SqlCommand("insert into Picture(BooksId,Name,Picture)values(@BooksId,@Name,@Picture)", conn);//команда выбора нашего рисунка
                if (txBxIdPict == null || txBxIdPict.Text.Length == 0)//проверка на ввод данных
                    return;
                int index = -1;
                int.TryParse(txBxIdPict.Text, out index);//переносим наши данные в переменную одновреммно делая проверку на принадлежность к числу
                if (index == 0)//проверка что число не ноль
                    return;
                cmd.Parameters.Add("@BooksId", SqlDbType.Int).Value = index;//заполнение параметров, для корректной работы запроса и защиты от вредоносных запросов
                cmd.Parameters.Add("Name", SqlDbType.NVarChar,255).Value = fileName;
                cmd.Parameters.Add("@Picture", SqlDbType.Image, bites.Length).Value = bites;
                cmd.ExecuteNonQuery();
            }
        }
        private byte[] CreateCopy() {//функция обработки рисунка(вставлять рисунок нужного размера без потери качества, независимо от размера файла пользователя)

            Image img = Image.FromFile(fileName);//рисунок пользователя
            int maxW = 300, maxH = 300;//нужные нам размеры
            double ratioX = maxW / img.Width;//создаем коофициент для нужного размера
            double ratioY = maxH / img.Height;
            double ratio = Math.Min(ratioX, ratioY);//выбираем меньший кооф. для предотвращения потери качества
            int newMaxW = (int)(img.Width * ratio);//задаем размеры
            int newMaxH = (int)(img.Height* ratio);

            Image nImg = new Bitmap(newMaxW, newMaxH);//карта для будущего рисунка
            Graphics g = Graphics.FromImage(nImg);//обработка нового рисунка
            g.DrawImage(img, 0, 0, newMaxW, newMaxH);
            MemoryStream ms = new MemoryStream();
            nImg.Save(ms, ImageFormat.Jpeg);//загрузка и выгрузка файла рисунка
            ms.Flush();
            ms.Seek(0, SeekOrigin.Begin);
            BinaryReader br = new BinaryReader(ms);
            byte[] buf = br.ReadBytes((int)ms.Length);
            return buf;
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString)) {
                da = new SqlDataAdapter("SELECT* FROM Picture", conn);
                cmdBldr = new SqlCommandBuilder(da);
                ds = new DataSet();
                da.Fill(ds, "mybook");
                dataGridView1.DataSource = ds.Tables["mybook"];
                
            }
        }

        private void btnShowOne_Click(object sender, EventArgs e)
        {
            using (conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString)) {
                if (txBxIdPict == null || txBxIdPict.Text == "")
                    return;
                int index = -1;
                int.TryParse(txBxIdPict.Text, out index);
                    if (index == 0)
                    return;
                da = new SqlDataAdapter("SELECT Picture FROM Picture WHERE Id=@Id", conn);
                cmdBldr = new SqlCommandBuilder(da);
                da.SelectCommand.Parameters.Add("@Id", SqlDbType.Int).Value = index;
                ds = new DataSet();
                da.Fill(ds);
                byte[] bytes = (byte[])ds.Tables[0].Rows[0]["Picture"];
                MemoryStream ms = new MemoryStream(bytes);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void txBxIdPict_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 49 || e.KeyChar >= 59) && e.KeyChar != 8)
                e.Handled = true;
        }
    }
}
