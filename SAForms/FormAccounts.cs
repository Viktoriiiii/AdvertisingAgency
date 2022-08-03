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
    public partial class FormAccounts : Form
    {
        private SqlConnection sqlConnection = null;
        int mode = 0;

        public FormAccounts()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FormAccounts"].Close();
            Application.OpenForms["FormMainForSystemAdmin"].Show();
        }

        private void FormAccounts_Load(object sender, EventArgs e)
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
            MessageBox.Show("Связь с сервером установлена");

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
            sqlConnection.Close();

            string com = "select u.id_user, ac.str_acc_type, u.surname, u.name_user, " +
                "u.patronymic,  u.mail, u.pass, u.phone, u.availabilty_in_system " +
                "from Users u, Acc_type ac " +
                "where u.id_acc_type = ac.id_acc_type;";
            fillUsers(com);

            string com1 = "select COUNT(id_user) as 'Количество сис админов'" +
                            " from Users" +
                            " where id_acc_type = 1";
            int u = fillLblCount(com1);
            labelCountSysAdmin.Text = "Количество системных администраторов: " + u.ToString();

            string com2 = "select COUNT(id_user) as 'Количество сотрудников'" +
                " from Users" +
                " where id_acc_type = 2";
            u = fillLblCount(com2);
            labelSotrudnik.Text = "Количество сотрудников: " + u.ToString();

            string com3 = "select COUNT(id_user) as 'Количество менежеров'" +
                " from Users" +
                " where id_acc_type = 3";
            u = fillLblCount(com3);
            labelManager.Text = "Количество менеджеров: " + u.ToString();

            string com4 = "select COUNT(id_user) as 'Количество бухгалтеров'" +
                " from Users" +
                " where id_acc_type = 4";
            u = fillLblCount(com4);
            labelBuhgalter.Text = "Количество бухгалтеров: " + u.ToString();
        }

        private int fillLblCount(string com)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            sqlConnection.Open();
            SqlCommand sqlCommandGetCommonAmount = new SqlCommand(com, sqlConnection);
            DataTable table = new DataTable("table");
            SqlDataAdapter DataAdapter = new SqlDataAdapter(sqlCommandGetCommonAmount);
            DataAdapter.Fill(table);
            int countSoldTickets = (int)table.Rows[0][0];
            sqlConnection.Close();
            return countSoldTickets;
        }

        private void fillUsers(string com)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            sqlConnection.Open();

            DataTable dt = new DataTable("table");
            SqlDataAdapter adapter = new SqlDataAdapter(com, sqlConnection);
            adapter.Fill(dt);
            
            for (int j = 0; j < dt.Rows.Count; j++)
            {
                dt.Rows[j][2] = dt.Rows[j][2].ToString() + " " + 
                      dt.Rows[j][3] + " " + dt.Rows[j][4];
            }

            dt.Columns.Remove(dt.Columns[3]);
            dt.Columns.Remove(dt.Columns[3]);
            dt.Columns[0].ColumnName = "ID";
            dt.Columns[1].ColumnName = "Должность";
            dt.Columns[2].ColumnName = "ФИО";
            dt.Columns[3].ColumnName = "Почта";
            dt.Columns[4].ColumnName = "Пароль";
            dt.Columns[5].ColumnName = "Телефон";
            dt.Columns[6].ColumnName = "Доступ";

            dataGridViewAccount.DataSource = dt;
            sqlConnection.Close();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (textBoxSearh.Text == "")
            {
                MessageBox.Show("Поле поиска не заполнено.");
                return;
            }
            string txt = textBoxSearh.Text;
            string com = "select u.id_user, ac.str_acc_type, u.surname, u.name_user, " +
                "u.patronymic,  u.mail, u.pass, u.phone, u.availabilty_in_system " +
                "from Users u, Acc_type ac " +
                "where u.id_acc_type = ac.id_acc_type " +
                "and u.surname like '" + txt + "';";
            fillUsers(com);
        }

        private void comboBoxDostup_SelectedIndexChanged(object sender, EventArgs e)
        {
            int b;
            string com;
            if (comboBoxDostup.SelectedIndex == 1)
                b = 1;
            else if (comboBoxDostup.SelectedIndex == 2) b = 0;
            else b = 2;

            if (b != 2)            
                com = "select u.id_user, ac.str_acc_type, u.surname, u.name_user, " +
                        "u.patronymic,  u.mail, u.pass, u.phone, u.availabilty_in_system " +
                         "from Users u, Acc_type ac " +
                         "where u.id_acc_type = ac.id_acc_type " +
                         "and u.availabilty_in_system = " + b.ToString() + ";";
            
            else 
            com = "select u.id_user, ac.str_acc_type, u.surname, u.name_user, " +
                "u.patronymic,  u.mail, u.pass, u.phone, u.availabilty_in_system " +
                "from Users u, Acc_type ac " +
                "where u.id_acc_type = ac.id_acc_type ";
            fillUsers(com);
        }

        private void buttonMore_Click(object sender, EventArgs e)
        {
            // вычислить id сотрудника
            int id = (int)this.dataGridViewAccount.CurrentRow.Cells[0].Value;
            mode = 1;
            FormPodrobno fmore = new FormPodrobno(mode, id);
            this.Hide();
            fmore.ShowDialog();
            this.Show();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            // вычислить id сотрудника
            int id = (int)this.dataGridViewAccount.CurrentRow.Cells[0].Value;
            mode = 2;
            FormPodrobno fmore = new FormPodrobno(mode, id);
            this.Hide();
            fmore.ShowDialog();
            this.Show();
        }

        private void buttonDostup_Click(object sender, EventArgs e)
        {
            // вычислить id сотрудника
            int id = (int)this.dataGridViewAccount.CurrentRow.Cells[0].Value;
            mode = 3;
            FormPodrobno fmore = new FormPodrobno(mode, id);
            this.Hide();
            fmore.ShowDialog();
            this.Show();
        }

        private void buttonNewAccount_Click(object sender, EventArgs e)
        {
            mode = 4;
            FormPodrobno fmore = new FormPodrobno(mode);
            this.Hide();
            fmore.ShowDialog();
            this.Show();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            int b;
            string comm;
            if (comboBoxDostup.SelectedIndex == 1)
                b = 1;
            else if (comboBoxDostup.SelectedIndex == 2) b = 0;
            else b = 2;

            if (b != 2)
                comm = "select u.id_user, ac.str_acc_type, u.surname, u.name_user, " +
                        "u.patronymic,  u.mail, u.pass, u.phone, u.availabilty_in_system " +
                         "from Users u, Acc_type ac " +
                         "where u.id_acc_type = ac.id_acc_type " +
                         "and u.availabilty_in_system = " + b.ToString() + ";";

            else
                comm = "select u.id_user, ac.str_acc_type, u.surname, u.name_user, " +
                    "u.patronymic,  u.mail, u.pass, u.phone, u.availabilty_in_system " +
                    "from Users u, Acc_type ac " +
                    "where u.id_acc_type = ac.id_acc_type ";
            fillUsers(comm);

            string com = "select u.id_user, ac.str_acc_type, u.surname, u.name_user, " +
                "u.patronymic,  u.mail, u.pass, u.phone, u.availabilty_in_system " +
                "from Users u, Acc_type ac " +
                "where u.id_acc_type = ac.id_acc_type;";
            fillUsers(com);

            string com1 = "select COUNT(id_user) as 'Количество сис админов'" +
                            " from Users" +
                            " where id_acc_type = 1";
            int u = fillLblCount(com1);
            labelCountSysAdmin.Text = "Количество системных администраторов: " + u.ToString();

            string com2 = "select COUNT(id_user) as 'Количество сотрудников'" +
                " from Users" +
                " where id_acc_type = 2";
            u = fillLblCount(com2);
            labelSotrudnik.Text = "Количество сотрудников: " + u.ToString();

            string com3 = "select COUNT(id_user) as 'Количество менежеров'" +
                " from Users" +
                " where id_acc_type = 3";
            u = fillLblCount(com3);
            labelManager.Text = "Количество менеджеров: " + u.ToString();

            string com4 = "select COUNT(id_user) as 'Количество бухгалтеров'" +
                " from Users" +
                " where id_acc_type = 4";
            u = fillLblCount(com4);
            labelBuhgalter.Text = "Количество бухгалтеров: " + u.ToString();
        }
    }
}
