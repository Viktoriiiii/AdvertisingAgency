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

namespace AdvertisingAgency.SAForms
{
    public partial class FormHystory : Form
    {
        private SqlConnection sqlConnection = null;

        public FormHystory()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FormHystory"].Close();
            Application.OpenForms["FormMainForSystemAdmin"].Show();
        }

        private void FormHystory_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            SqlDataReader newReader;
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
            //MessageBox.Show("Связь с сервером установлена");

            SqlCommand newCommand = new SqlCommand(
                    "SELECT name_firm, logo, format_logo FROM dbo.Firm where id_firm = 1;",
                    sqlConnection);
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
            string selectHystory = "select act.str_acc_type, u.name_user, u.surname, u.patronymic, " +
                                    "u.mail, h.entry_time, h.exit_time, h.success from Acc_type act, Users u, History h" +
                                    " where act.id_acc_type = u.id_acc_type and u.id_user = h.id_user";
            inputDataridView(selectHystory);
            sqlConnection.Close();
        }

        private void comboBoxSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBoxSort.SelectedIndex == 1) // успешные
            {
                string con = "select act.str_acc_type, u.name_user, u.surname, u.patronymic, " +
                                    "u.mail, h.entry_time, h.exit_time, h.success from Acc_type act, Users u, History h" +
                                    " where act.id_acc_type = u.id_acc_type and u.id_user = h.id_user" +
                                    " and h.success = 1";
                inputDataridView(con);

            }
            else if (comboBoxSort.SelectedIndex == 2) // неуспешные
            {
                string con = "select act.str_acc_type, u.name_user, u.surname, u.patronymic, " +
                                    "u.mail, h.entry_time, h.exit_time, h.success from Acc_type act, Users u, History h" +
                                    " where act.id_acc_type = u.id_acc_type and u.id_user = h.id_user" +
                                    " and h.success = 0";
                inputDataridView(con);
            }
            else // все
            {
                string con = "select act.str_acc_type, u.name_user, u.surname, u.patronymic, " +
                    "u.mail, h.entry_time, h.exit_time, h.success from Acc_type act, Users u, History h" +
                    " where act.id_acc_type = u.id_acc_type and u.id_user = h.id_user"; 
                inputDataridView(con);
            }
        }

        private void inputDataridView(string con)
        {            
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            sqlConnection.Open();
            SqlCommand selH = new SqlCommand(con, sqlConnection);
            DataTable dataTable = new DataTable("table");
            SqlDataAdapter Adapter = new SqlDataAdapter(selH);
            Adapter.Fill(dataTable);
            dataGridViewHystory.DataSource = null;
            dataGridViewHystory.Rows.Clear();
            dataGridViewHystory.DataSource = dataTable;
            sqlConnection.Close();
        }

        private void buttonPoisk_Click(object sender, EventArgs e)
        {
            if (textBoxPoisk.Text == null)
            {
                MessageBox.Show("Поле поиска не заполнено. Введите mail");
                textBoxPoisk.Focus();
                return;
            }
            string com = "select act.str_acc_type, u.name_user, u.surname, u.patronymic, " +
                                    "u.mail, h.entry_time, h.exit_time, h.success from Acc_type act, Users u, History h" +
                                    " where act.id_acc_type = u.id_acc_type and u.id_user = h.id_user" +
                                    " and u.mail = '" + textBoxPoisk.Text + "';";
            inputDataridView(com);
        }

        private void textBoxPoisk_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar)) return; // разрешить цифры
            if (char.IsWhiteSpace(e.KeyChar)) e.Handled = true; // отменить пробел
            if (e.KeyChar == 8) return; // разрешить backspase
            if (e.KeyChar == '@' || e.KeyChar == '.') return; // разрешить собаку
            if ((e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z')) return; // разрешить латиницу
            e.Handled = true; // остальное запретить
        }
    }
}
