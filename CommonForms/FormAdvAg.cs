using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;

namespace AdvertisingAgency
{
    public partial class FormAdvAg : Form
    {
        public FormAdvAg()
        {
            InitializeComponent();
        }
        OpenFileDialog ofd = new OpenFileDialog();
        PictureBox pic = new PictureBox();
        private SqlConnection sqlConnection = null;
        TextBox txt;
        string descriptionAboutFirm;
        int flag = 0;
        DataGridView dataGridView;
        ListView listEx;

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /*
        private void buttonChangeName_Click(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            sqlConnection.Open();

            SqlCommand update = new SqlCommand(
                    "Update dbo.Firm set name_firm = @Name where id_firm = 1;",
                    sqlConnection);
            update.Parameters.AddWithValue("@Name", textBoxLogo.Text.ToString());
            update.ExecuteNonQuery();
            if (update.ExecuteNonQuery().ToString() == "1") MessageBox.Show("Данные успешно обновлены");

            SqlCommand newCommand = new SqlCommand(
                    "SELECT name_firm FROM dbo.Firm where id_firm = 1;",
                    sqlConnection);
            SqlDataReader newReader;
            newReader = newCommand.ExecuteReader();

            if (newReader.Read())
            {
                labelFirmName.Text = "Рекламное агентство " + newReader["name_firm"].ToString();
            }

            sqlConnection.Close();
        }
        */
        private void FormAdvAg_Load(object sender, EventArgs e)
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
                    "SELECT name_firm, logo, format_logo, descriptions FROM dbo.Firm where id_firm = 1;",
                    sqlConnection);
            newReader = newCommand.ExecuteReader();

            List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
            List<string> iScreen_format = new List<string>();

            byte[] iTrimByte = null;
            string iTrimText = null;

            if (newReader.Read())
            {
                labelFirmName.Text = "Рекламное агентство " + newReader["name_firm"].ToString();
                descriptionAboutFirm = newReader["descriptions"].ToString();
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
        }

        private void buttonAboutFirm_Click(object sender, EventArgs e)
        {
            if (flag == 0 || flag == 2 || flag == 3)
            {
                txt = new TextBox();
                txt.ReadOnly = true;
                txt.Multiline = true;
                txt.ScrollBars = ScrollBars.Both;
                txt.Dock = DockStyle.Fill;
                txt.Text = descriptionAboutFirm;
                tableLayoutPanelMainPage.Controls.Remove(labelWelcome);
                tableLayoutPanelMainPage.Controls.Remove(dataGridView);
                tableLayoutPanelMainPage.Controls.Remove(listEx);
                tableLayoutPanelMainPage.Controls.Add(txt, 1, 1);
                flag = 1;
            }
            else return;

        }

        private void buttonEmployees_Click(object sender, EventArgs e)
        {
            if (flag == 0 || flag == 1 || flag == 3)
            {
                tableLayoutPanelMainPage.Controls.Remove(labelWelcome);
                tableLayoutPanelMainPage.Controls.Remove(txt);
                tableLayoutPanelMainPage.Controls.Remove(listEx);

                List<Users> lbUsers = new List<Users>();

                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                SqlDataReader reader;
                sqlConnection.Open();
                SqlCommand readUsers = new SqlCommand("select * from Users", sqlConnection);
                reader = readUsers.ExecuteReader();
                //mail, pass, name_user, surname, patronymic, phone, availibility_in_system" +
                //"from dbo.Users where  ");
                int count = 0;
                ListView lstUsers = new ListView();
                while (reader.Read())
                {
                    lbUsers.Add(new Users
                    {
                        name = reader["name_user"].ToString(),
                        surname = reader["surname"].ToString(),
                        patronymic = reader["patronymic"].ToString(),
                        email = reader["mail"].ToString(),
                        password = reader["pass"].ToString(),
                        phone = reader["phone"].ToString(),
                        accType = (int)reader["id_acc_type"],
                        availabilityInSystem = (bool)reader["availabilty_in_system"]
                    });
                    count++;
                }
                int index = 0;
                dataGridView = new DataGridView();
                dataGridView.Columns.Add("newColumnNameNumber", "№");
                dataGridView.Columns.Add("newColumnNameSurname", "Фамилия");
                dataGridView.Columns.Add("newColumnNameName", "Имя");
                dataGridView.Columns.Add("newColumnNamePatronymic", "Отчество");
                dataGridView.Columns.Add("newColumnNameDolg", "Должность");
                dataGridView.Columns.Add("newColumnNameMail", "Почта");
                dataGridView.Columns.Add("newColumnNamePass", "Пароль");
                dataGridView.Columns.Add("newColumnNamePhone", "Телефон");

                SqlCommand getDolg = new SqlCommand("select * from dbo.Acc_type", sqlConnection);
                reader.Close();
                reader = getDolg.ExecuteReader();
                List<AccType> accTypes = new List<AccType>();
                while (reader.Read())
                {
                    accTypes.Add(new AccType
                    {
                        idAccType = (int)reader["id_acc_type"],
                        strAccType = reader["str_acc_type"].ToString()
                    });
                }

                foreach (var item in lbUsers) //По всем элементам списка
                {
                    foreach (var accType in accTypes)
                    {
                        if (item.accType == accType.idAccType)
                            item.accTypeString = accType.strAccType;
                    }

                    dataGridView.Rows.Add();
                    dataGridView.Rows[index].Cells[0].Value = index + 1;
                    dataGridView.Rows[index].Cells[1].Value = item.surname;
                    dataGridView.Rows[index].Cells[2].Value = item.name;
                    dataGridView.Rows[index].Cells[3].Value = item.patronymic;
                    dataGridView.Rows[index].Cells[4].Value = item.accTypeString;
                    dataGridView.Rows[index].Cells[5].Value = item.email;
                    dataGridView.Rows[index].Cells[6].Value = item.password;
                    dataGridView.Rows[index].Cells[7].Value = item.phone;
                    index++;
                }

                tableLayoutPanelMainPage.Controls.Add(dataGridView);
                dataGridView.Dock = DockStyle.Fill;
                dataGridView.AllowUserToAddRows = false;
                dataGridView.ReadOnly = true;
                dataGridView.RowHeadersVisible = false;
                dataGridView.Columns[0].Width = 30;
                sqlConnection.Close();
                flag = 2;
            }
            else return;
        }

        private void buttonWorkExamples_Click(object sender, EventArgs e)
        {
            if (flag == 0 || flag == 1 || flag == 2)
            {
                tableLayoutPanelMainPage.Controls.Remove(labelWelcome);
                tableLayoutPanelMainPage.Controls.Remove(txt);
                tableLayoutPanelMainPage.Controls.Remove(dataGridView);

                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                sqlConnection.Open();
                SqlCommand getWorkEx = new SqlCommand("select * from WorkExamples", sqlConnection);
                SqlDataReader getWorkReader = getWorkEx.ExecuteReader();

                List<WorkExamples> lstWorks = new List<WorkExamples>();
                while (getWorkReader.Read())
                {
                    List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
                    List<string> iScreen_format = new List<string>();

                    byte[] iTrimByte = null;
                    string iTrimText = null;

                    WorkExamples wE = new WorkExamples();
                    wE.textDescr = getWorkReader["text_descr"].ToString();
                    iTrimByte = (byte[])getWorkReader["pict"];
                    iTrimText = getWorkReader["format_pict"].ToString().TrimStart().TrimEnd();
                    iScreen.Add(iTrimByte);
                    iScreen_format.Add(iTrimText);
                    byte[] imageData = iScreen[0]; // возвращает массив байт из БД. Так как у нас SQL вернёт одну запись и в ней хранится нужное нам изображение, то из листа берём единственное значение с индексом '0'
                    MemoryStream ms = new MemoryStream(imageData);
                    Image newImage = Image.FromStream(ms);
                    wE.pb.Image = newImage;
                    lstWorks.Add(wE);
                }
                sqlConnection.Close();

                listEx = new ListView();
                listEx.Items.Clear();        //Сначала список надо очистить
                listEx.LabelWrap = true;    //Разрешить перенос на новую строку
                listEx.Scrollable = true;    //Обеспечитьналичиеполоспрокрутки
                listEx.View = View.LargeIcon;    //Видкомпонента – большиекартинки

                ImageList il = new ImageList();       //Динамический элемент – массив изображений
                il.ImageSize = new Size(100, 100);   //Размеры всех изображений одинаковы
                listEx.LargeImageList = il;  //Связать два списка между собой
                il.Images.Clear();

                int i = 1;
                foreach (WorkExamples wE in lstWorks)
                {
                    ListViewItem lvi = new ListViewItem();       //Элемент списка
                    lvi.Text = wE.textDescr;
                    Bitmap bitmap;
                    if (wE.pb.Image != null)
                    {
                        bitmap = new Bitmap(wE.pb.Image);
                    }
                    else
                    {
                        bitmap = Properties.Resources.no_image;
                    }
                    il.Images.Add(bitmap);
                    lvi.ImageIndex = (i - 1);
                    listEx.Items.Add(lvi);
                    i++;
                }

                tableLayoutPanelMainPage.Controls.Add(listEx);
                listEx.Dock = DockStyle.Fill;
                flag = 3;
            }
            else return;
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {            
            FormAuthorization formAu = new FormAuthorization();
            this.Hide();
            formAu.ShowDialog();
            this.Show();
        }
    }
}
            //string iFile, iImageExtension;
            //using (ofd)
            //{
            //    ofd.Filter = "*.jpg|*.jpg;|*.png|*.png";
            //    if (this.ofd.ShowDialog() == DialogResult.OK)
            //    {
            //        pictureBoxLogo.Load(this.ofd.FileName);
            //        iFile = ofd.SafeFileName;
            //        byte[] imageData = null;
            //        FileInfo fInfo = new FileInfo(ofd.SafeFileName);
            //        long numBytes = fInfo.Length;
            //        FileStream fStream = new FileStream(ofd.SafeFileName, FileMode.Open, FileAccess.Read);
            //        BinaryReader br = new BinaryReader(fStream);
            //        imageData = br.ReadBytes((int)numBytes);
            //        // получение расширения файла изображения не забыв удалить точку перед расширением
            //        iImageExtension = (Path.GetExtension(ofd.SafeFileName)).Replace(".", "").ToLower();
            //        // запись изображения в БД
            //        using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString)) // строка подключения к БД
            //        {
            //            string commandText = "insert into WorkExamples (id_work_ex, text_descr, pict, format_pict)" +
            //                " values(@id, @txt, @pi, @fpi);"; // запрос на вставку
            //            SqlCommand command = new SqlCommand(commandText, sqlConnection);
            //            command.Parameters.AddWithValue("@id", 2);
            //            command.Parameters.AddWithValue("@txt", "Реклама для тетрадей");
            //            command.Parameters.AddWithValue("@pi", (object)imageData); // записываем само изображение
            //            command.Parameters.AddWithValue("@fpi", iImageExtension); // записываем расширение изображения
            //            sqlConnection.Open();
            //            command.ExecuteNonQuery();
            //            sqlConnection.Close();
            //        }
            //    }
         //   }
        /*
private void buttonChangeLogo_Click(object sender, EventArgs e)
{
string iFile, iImageExtension;
using (ofd)
{
ofd.Filter = "*.jpg|*.jpg;|*.png|*.png";
if (this.ofd.ShowDialog() == DialogResult.OK)
{
pictureBoxLogo.Load(this.ofd.FileName);
iFile = ofd.SafeFileName;
byte[] imageData = null;
FileInfo fInfo = new FileInfo(ofd.SafeFileName);
long numBytes = fInfo.Length;
FileStream fStream = new FileStream(ofd.SafeFileName, FileMode.Open, FileAccess.Read);
BinaryReader br = new BinaryReader(fStream);
imageData = br.ReadBytes((int)numBytes);
// получение расширения файла изображения не забыв удалить точку перед расширением
iImageExtension = (Path.GetExtension(ofd.SafeFileName)).Replace(".", "").ToLower();
// запись изображения в БД
using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString)) // строка подключения к БД
{
string commandText = "update Firm set logo = @screen, format_logo = @screen_format where id_firm = 1;"; // запрос на вставку
SqlCommand command = new SqlCommand(commandText, sqlConnection);
command.Parameters.AddWithValue("@screen", (object)imageData); // записываем само изображение
command.Parameters.AddWithValue("@screen_format", iImageExtension); // записываем расширение изображения
sqlConnection.Open();
command.ExecuteNonQuery();
sqlConnection.Close();
}
}
}
}*/
    
