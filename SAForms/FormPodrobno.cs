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
    public partial class FormPodrobno : Form
    {
        private SqlConnection sqlConnection = null;
        int mode, id = 0;
        string mail, pass, name, surname, patronymic, phone, dolg;
        bool dostup;
        bool flag = false; // изменения данных
        OpenFileDialog ofd = new OpenFileDialog();

        public FormPodrobno(int mode)
        {
            InitializeComponent();
            this.mode = mode;
        }       

        public FormPodrobno(int mode, int id)
        {
            InitializeComponent();
            this.mode = mode;
            this.id = id;
        }

        private void buttonChoosePhoto_Click(object sender, EventArgs e)
        {
            string iFile, iImageExtension;
            using (ofd)
            {
                ofd.Filter = "*.jpg|*.jpg;|*.png|*.png";
                if (this.ofd.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxPhoto.Load(this.ofd.FileName);
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
                        string commandText = "update Users set photo = @screen, format_photo = @screen_format" +
                            " where id_user = " + id.ToString() + ";"; // запрос на вставку
                        SqlCommand command = new SqlCommand(commandText, sqlConnection);
                        command.Parameters.AddWithValue("@screen", (object)imageData); // записываем само изображение
                        command.Parameters.AddWithValue("@screen_format", iImageExtension); // записываем расширение изображения
                        sqlConnection.Open();
                        command.ExecuteNonQuery();
                        sqlConnection.Close();
                    }
                }
            }
        }

        private void buttonDeletePhoto_Click(object sender, EventArgs e)
        {
            this.pictureBoxPhoto.Image = Properties.Resources.no_image;
            string commandText = "UPDATE Users SET photo = null, format_photo = null " +
                                                     "WHERE id_user = " + id.ToString() + ";";
            SqlCommand command = new SqlCommand(commandText, sqlConnection);
            MessageBox.Show("Данные успешно обновлены");
            sqlConnection.Open();
            command.ExecuteNonQuery();
            sqlConnection.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // записать данные из текстбоксов в бд если что-то поменялось
            checkFlag();
            checkEmpty();
            int idAcc = getIdAcc();
            if (flag)
            {
                if (id != 0)
                {
                    sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                    sqlConnection.Open();
                    string com = "update Users set id_acc_type = @id, mail = @m, pass = @p, " +
                        "name_user = @nu, surname = @s, patronymic = @pk, " +
                        "phone = @phn, availabilty_in_system = @as " +
                        "where id_user = " + id.ToString() + ";";
                    SqlCommand update = new SqlCommand(com, sqlConnection);
                    update.Parameters.AddWithValue("@id", idAcc.ToString());
                    update.Parameters.AddWithValue("@m", textBoxMail.Text.ToString());
                    update.Parameters.AddWithValue("@p", textBoxPass.Text.ToString());
                    update.Parameters.AddWithValue("@nu", textBoxName.Text.ToString());
                    update.Parameters.AddWithValue("@s", textBoxSureName.Text.ToString());
                    update.Parameters.AddWithValue("@pk", textBoxPatronymic.Text.ToString());
                    update.Parameters.AddWithValue("@phn", maskedTextBoxPhone.Text.ToString());
                    update.Parameters.AddWithValue("@as", checkBoxDostup.Checked.ToString());
                    if (update.ExecuteNonQuery().ToString() == "1") MessageBox.Show("Данные успешно обновлены");
                    sqlConnection.Close();  
                }
                else
                {
                    // insert запрос
                    SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                    sqlConnection.Open();
                    string com = "insert into Users (id_acc_type, mail, pass, name_user, surname, patronymic, " +
                                "phone, availabilty_in_system) " +
                                "VALUES(@id, @m, @p, @nu, @s, @pk, @phn, @as);";

                    SqlCommand command = new SqlCommand(com, sqlConnection);
                    command.Parameters.AddWithValue("@id", idAcc.ToString());
                    command.Parameters.AddWithValue("@m", textBoxMail.Text.ToString());
                    command.Parameters.AddWithValue("@p", textBoxPass.Text.ToString());
                    command.Parameters.AddWithValue("@nu", textBoxName.Text.ToString());
                    command.Parameters.AddWithValue("@s", textBoxSureName.Text.ToString());
                    command.Parameters.AddWithValue("@pk", textBoxPatronymic.Text.ToString());
                    command.Parameters.AddWithValue("@phn", maskedTextBoxPhone.Text.ToString());
                    command.Parameters.AddWithValue("@as", checkBoxDostup.Checked.ToString());

                    try
                    {
                        if (command.ExecuteNonQuery().ToString() == "1") MessageBox.Show("Данные успешно обновлены");
                    }
                    catch
                    {
                        MessageBox.Show("Данные не обновились.");
                        return;
                    }
                    sqlConnection.Close();
                }
                mail = textBoxMail.Text;
                pass = textBoxPass.Text;
                name = textBoxName.Text;
                surname = textBoxSureName.Text;
                patronymic = textBoxPatronymic.Text;
                phone = maskedTextBoxPhone.Text;
                dolg = comboBoxDolg.Text;
                dostup = checkBoxDostup.Checked;
            }
        }    

        private int getIdAcc()
        {
            int idAcc = 0;
            string txt = comboBoxDolg.Text;
            switch (txt)
            {
                case "Системный администатор":
                    idAcc = 1;
                    break;
                case "Сотрудник": idAcc = 2;
                    break;
                case "Менеджер": idAcc = 3;
                    break;
                case "Бухгалтер": idAcc = 4;
                    break;
            }
            return idAcc;
        }

        private void checkEmpty()
        {
            if (textBoxMail.Text == "") // пустота полей
            {
                MessageBox.Show("Поле почты не заполнено.");
                textBoxMail.Focus();
                return;
            }
            if (textBoxPass.Text == "") // пустота полей
            {
                MessageBox.Show("Поле пароля не заполнено");
                textBoxPass.Focus();
                return;
            }
            if (textBoxName.Text == "") // минимальная длина 
            {
                MessageBox.Show("Поле имени не заполнено");
                textBoxName.Focus();
                return;
            }
            if (textBoxSureName.Text == "")
            {
                MessageBox.Show("Поле фамилии не заполнено");
                textBoxSureName.Focus();
                return;
            }
            if (textBoxPatronymic.Text == "")
            {
                MessageBox.Show("Поле отчетства не заполнено");
                textBoxPatronymic.Focus();
                return;
            }
            if (maskedTextBoxPhone.Text == "" )
            {
                MessageBox.Show("Поле телефона не заполнено");
                maskedTextBoxPhone.Focus();
                return;
            }
            if (comboBoxDolg.Text == "Поле должности не заполнено")
            {
                MessageBox.Show("");
                comboBoxDolg.Focus();
                return;
            }
        }

        private void checkFlag()
        {
            if (mail != textBoxMail.Text || pass != textBoxPass.Text ||
                name != textBoxName.Text || surname != textBoxSureName.Text ||
                patronymic != textBoxPatronymic.Text || phone != maskedTextBoxPhone.Text ||
                dolg != comboBoxDolg.Text || dostup != checkBoxDostup.Checked)
                flag = true;
            else flag = false;
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            checkFlag();

            if (flag)
            {
                DialogResult dialogResult = MessageBox.Show("Выйти без сохранения изменений?", "Сообщение", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.OpenForms["FormPodrobno"].Close();
                    Application.OpenForms["FormAccounts"].Show();
                }
                else if (dialogResult == DialogResult.No)
                {
                    return;
                }
                else return;
            }
            else
            {
                Application.OpenForms["FormPodrobno"].Close();
                Application.OpenForms["FormAccounts"].Show();
            }
        }

        private void FormPodrobno_Load(object sender, EventArgs e)
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
           // MessageBox.Show("Связь с сервером установлена");

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

            switch (mode)
            {
                case 1:				//Подробно - все заблокировано
                    buttonSave.Visible = false;
                    buttonChoosePhoto.Visible = false;
                    buttonDeletePhoto.Visible = false;
                    textBoxMail.Enabled = false;
                    textBoxPass.Enabled = false;
                    textBoxName.Enabled = false;
                    textBoxPatronymic.Enabled = false;
                    textBoxSureName.Enabled = false;
                    maskedTextBoxPhone.Enabled = false;
                    comboBoxDolg.Enabled = false;
                    checkBoxDostup.Enabled = false;
                    break;
                case 2:             //Редактирование - разблокировано, доступ заблокировано
                    buttonSave.Visible = true;
                    buttonChoosePhoto.Visible = true;
                    buttonDeletePhoto.Visible = true;
                    textBoxMail.Enabled = true;
                    textBoxPass.Enabled = true;
                    textBoxName.Enabled = true;
                    textBoxPatronymic.Enabled = true;
                    textBoxSureName.Enabled = true;
                    maskedTextBoxPhone.Enabled = true;
                    comboBoxDolg.Enabled = true;
                    checkBoxDostup.Enabled = false;
                    break;
                case 3: // Доступ - разблокировано, остальное заблокировано
                    buttonSave.Visible = true;
                    buttonChoosePhoto.Visible = false;
                    buttonDeletePhoto.Visible = false;
                    textBoxMail.Enabled = false;
                    textBoxPass.Enabled = false;
                    textBoxName.Enabled = false;
                    textBoxPatronymic.Enabled = false;
                    textBoxSureName.Enabled = false;
                    maskedTextBoxPhone.Enabled = false;
                    comboBoxDolg.Enabled = false;
                    checkBoxDostup.Enabled = true;
                    break;
                case 4: // создать новый
                    buttonSave.Visible = true;
                    buttonChoosePhoto.Visible = true;
                    buttonDeletePhoto.Visible = true;
                    textBoxMail.Enabled = true;
                    textBoxPass.Enabled = true;
                    textBoxName.Enabled = true;
                    textBoxPatronymic.Enabled = true;
                    textBoxSureName.Enabled = true;
                    maskedTextBoxPhone.Enabled = true;
                    comboBoxDolg.Enabled = true;
                    checkBoxDostup.Enabled = true;
                    string[] items = { "Системный администратор", "Сотрудник", "Менеджер", "Бухгалтер" };
                    comboBoxDolg.Items.AddRange(items);
                    tableLayoutPanelPhoto.Visible = false;
                    break;
            }
            getInfo();
        }

        // получить из бд данные о пользователе по id
        // записать их в переменные
        // вывести переменные в поля
        private void getInfo()
        {
            if (id != 0)
            {
                sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                sqlConnection.Open();

                string com = "select ac.str_acc_type, u.name_user, " +
                            "u.surname, u.patronymic, u.mail, u.pass, " +
                            "u.phone, u.photo, u.format_photo, " +
                            "u.availabilty_in_system " +
                            "from Users u, Acc_type ac " +
                            "where u.id_acc_type = ac.id_acc_type " +
                            "and u.id_user = " + id.ToString() + ";";
                SqlDataAdapter adapter = new SqlDataAdapter(com, sqlConnection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dolg = dt.Rows[0][0].ToString();
                comboBoxDolg.Text = dolg;

                name = dt.Rows[0][1].ToString();
                textBoxName.Text = name;

                surname = dt.Rows[0][2].ToString();
                textBoxSureName.Text = surname;

                patronymic = dt.Rows[0][3].ToString();
                textBoxPatronymic.Text = patronymic;

                mail = dt.Rows[0][4].ToString();
                textBoxMail.Text = mail;

                pass = dt.Rows[0][5].ToString();
                textBoxPass.Text = pass;

                phone = dt.Rows[0][6].ToString();
                maskedTextBoxPhone.Text = phone;

                dostup = Convert.ToBoolean(dt.Rows[0][9].ToString());
                checkBoxDostup.Checked = dostup;

                SqlCommand newCommand = new SqlCommand(
                     "SELECT photo, format_photo FROM Users where id_user = " + id.ToString() + ";",
                     sqlConnection);
                SqlDataReader newReader;
                newReader = newCommand.ExecuteReader();

                List<byte[]> iScreen = new List<byte[]>(); // сделав запрос к БД мы получим множество строк в ответе, поэтому мы их сможем загнать в массив/List
                List<string> iScreen_format = new List<string>();

                byte[] iTrimByte = null;
                string iTrimText = null;

                try
                {
                    if (newReader.Read())
                    {
                        iTrimByte = (byte[])newReader["photo"];
                        iScreen.Add(iTrimByte);
                        iTrimText = newReader["format_photo"].ToString().TrimStart().TrimEnd();
                        iScreen_format.Add(iTrimText);
                        byte[] imageData = iScreen[0];
                        MemoryStream ms = new MemoryStream(imageData);
                        Image newImage = Image.FromStream(ms);
                        pictureBoxPhoto.Image = newImage;
                    }
                }
                catch
                {
                    pictureBoxPhoto.Image = AdvertisingAgency.Properties.Resources.no_image;
                }            
                
                sqlConnection.Close();
            }
        }
    }
}
