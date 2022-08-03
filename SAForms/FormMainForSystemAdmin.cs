using AdvertisingAgency.SAForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdvertisingAgency
{
    public partial class FormMainForSystemAdmin : Form
    {
        private SqlConnection sqlConnection = null;
        int idUser;
        DateTime dtIn;

        public FormMainForSystemAdmin(int idUser, DateTime dtIn)
        {
            InitializeComponent();
            this.idUser = idUser;
            this.dtIn = dtIn;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // внести выход
            //sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            //sqlConnection.Open();
            //DateTime dtOut = DateTime.Now;
            //string insertHystory = "update History set exit_time = @et" +
            //    " where entry_time = @from;";
            //SqlCommand cmd = new SqlCommand(insertHystory, sqlConnection);
            //cmd.Parameters.AddWithValue("@et", dtOut);
            //cmd.Parameters.AddWithValue("@from", dtIn);

            //try
            //{
            //    cmd.ExecuteNonQuery();
            //    //MessageBox.Show("Данные успешно обновлены");
            //}
            //catch
            //{
            //    MessageBox.Show("Ошибка. Данные не обновлены");
            //    sqlConnection.Close();
            //    return;
            //}            
            //sqlConnection.Close();
            Application.OpenForms["FormMainForSystemAdmin"].Close();
            Application.OpenForms[1].Show();
        }

        private void FormMainForSystemAdmin_Load(object sender, EventArgs e)
{
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            try
            {
                sqlConnection.Open();
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 17: MessageBox.Show("Неверное имя сервера"); break;
                    case 4060: MessageBox.Show("Неверное имя БД"); break;
                    case 18456: MessageBox.Show("Неверное имя пользователя или пароль"); break;
                }
                MessageBox.Show(ex.Message + "Уровень ошибки " + ex.Class);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения " + ex.Message);
                Application.Exit();
            }

            SqlCommand newCommand = new SqlCommand(
                    "SELECT name_firm, logo, format_logo FROM dbo.Firm where id_firm = 1;",
                    sqlConnection);
            SqlDataReader newReader;
            newReader = newCommand.ExecuteReader();

            List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
            List<string> iScreen_format = new List<string>();

            byte[] iTrimByte = null;
            string iTrimText = null;

            if (newReader.Read())
            {
                labelFirmName.Text = "Рекламное агентство " + newReader["name_firm"].ToString();
                iTrimByte = (byte[])newReader["logo"];
                iScreen.Add(iTrimByte);
                iTrimText = newReader["format_logo"].ToString().TrimStart().TrimEnd(); // читаем строки с форматом изображения
                iScreen_format.Add(iTrimText);
                // конвертируем бинарные данные в изображение
                byte[] imageData = iScreen[0]; // возвращает массив байт из БД. Так как у нас SQL вернёт одну запись и в ней хранится нужное нам изображение, то из листа берём единственное значение с индексом '0'
                MemoryStream ms = new MemoryStream(imageData);
                Image newImage = Image.FromStream(ms);
                pictureBoxLogo.Image = newImage;
            }

            newReader.Close();
            SqlCommand newCommand1 = new SqlCommand(
                     "SELECT photo, format_photo FROM Users where id_user = " + idUser.ToString() + ";",
                     sqlConnection);
            SqlDataReader newReader1;
            newReader1 = newCommand1.ExecuteReader();

            List<byte[]> iScreen1 = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
            List<string> iScreen_format1 = new List<string>();

            byte[] iTrimByte1 = null;
            string iTrimText1 = null;

            if (newReader1.Read())
            {
                iTrimByte1 = (byte[])newReader1["photo"];
                iScreen1.Add(iTrimByte1);
                iTrimText1 = newReader1["format_photo"].ToString().TrimStart().TrimEnd();
                iScreen_format1.Add(iTrimText1);
                byte[] imageData1 = iScreen1[0];
                MemoryStream ms1 = new MemoryStream(imageData1);
                Image newImage1 = Image.FromStream(ms1);
                pictureBoxSA.Image = newImage1;
            }
            else pictureBoxSA.Image = AdvertisingAgency.Properties.Resources.no_image;

            sqlConnection.Close();
        }

        private void buttonHystory_Click(object sender, EventArgs e)
        {
            FormHystory formHystory = new FormHystory();
            this.Hide();
            formHystory.ShowDialog();
            this.Show();
        }

        private void buttonAccount_Click(object sender, EventArgs e)
        {
            FormAccounts formHystory = new FormAccounts();
            this.Hide();
            formHystory.ShowDialog();
            this.Show();
        }

        private void buttonMessages_Click(object sender, EventArgs e)
        {
            FormMessages formHystory = new FormMessages();
            this.Hide();
            formHystory.ShowDialog();
            this.Show();
        }
    }
}
