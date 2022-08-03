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
using System.Configuration;
using System.IO;

namespace AdvertisingAgency
{
    public partial class FormAuthorization : Form
    {
        private SqlConnection sqlConnection = null;
        int attempt = 3;
        bool o = false;
        bool t = true;
        bool b = false; // доступ
        int sec = 60;
        int sec2 = 120;
        Timer MyTimer;
        private string text = String.Empty;


        public FormAuthorization()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            Application.OpenForms["FormAuthorization"].Close();
            Application.OpenForms[0].Show();
        }

        private void FormAuthorization_Load(object sender, EventArgs e)
        {
            textBoxLogin.Text = "sysadm@mail.ru";
            textBoxPass.Text = "Abcd12";

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

            pictureBoxKapcha.Image = this.CreateKapcha(pictureBoxKapcha.Width, pictureBoxKapcha.Height);
        }

        private void buttonIn_Click(object sender, EventArgs e)
        {
            sec = 15;
            sec2 = 30;
            if (textBoxLogin.Text == "" || textBoxPass.Text == "") // пустота полей
            {
                MessageBox.Show("Поле логина или пароля не заполнено");
                return;
            }

            string loginInput = textBoxLogin.Text;
            string passInput = textBoxPass.Text;
            // string loginReally = null;
            string passReally = null;
            int accType = 0;
            int idUser = 0;

            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            sqlConnection.Open();
            SqlDataReader reader;

            string comSelect = "SELECT id_user, id_acc_type, pass FROM Users where mail = '" + loginInput.ToString() + "';";
            //MessageBox.Show(com);
            SqlCommand command = new SqlCommand(comSelect, sqlConnection);
            try
            {
                reader = command.ExecuteReader();
                if (reader.Read())
                {
                    passReally = reader["pass"].ToString();
                    accType = (int)reader["id_acc_type"];
                    idUser = (int)reader["id_user"];
                }
                if (passReally == null)
                {
                    MessageBox.Show("Неверный логин");
                    o = true;
                    t = false;
                    attempt--;
                    //return;
                }
            }
            catch
            {
                MessageBox.Show("Неверный логин");
                if (!o)
                {
                    attempt--;
                    o = false;
                    t = false;
                }
               // return;
            }
            
            sqlConnection.Close();
            DateTime dtIn = DateTime.Now;
            if (passInput == passReally && t && textBoxKapcha.Text == this.text) 
            {
               // MessageBox.Show("Верно!");
                switch (accType)
                {
                    case 1:
                        pictureBoxKapcha.Image = this.CreateKapcha(pictureBoxKapcha.Width, pictureBoxKapcha.Height);
                        textBoxKapcha.Clear();
                        textBoxLogin.Clear();
                        textBoxPass.Clear();
                        attempt = 3;
                        b = true;
                       // InputInHystory(idUser, dtIn, b); // внести в историю входа
                        FormMainForSystemAdmin formFSA = new FormMainForSystemAdmin(idUser, dtIn);
                        this.Hide();
                        formFSA.ShowDialog();
                        this.Show();
                        break;
                    case 2:
                        pictureBoxKapcha.Image = this.CreateKapcha(pictureBoxKapcha.Width, pictureBoxKapcha.Height);
                        textBoxKapcha.Clear();
                        textBoxLogin.Clear();
                        textBoxPass.Clear();
                        attempt = 3;
                        FormMainForEmployee formFE = new FormMainForEmployee();
                        this.Hide();
                        formFE.ShowDialog();
                        this.Show();
                        break;
                    case 3:
                        pictureBoxKapcha.Image = this.CreateKapcha(pictureBoxKapcha.Width, pictureBoxKapcha.Height);
                        textBoxKapcha.Clear();
                        textBoxLogin.Clear();
                        textBoxPass.Clear();
                        attempt = 3;
                        FormMainForManager formFM = new FormMainForManager();
                        this.Hide();
                        formFM.ShowDialog();
                        this.Show();
                        break;                        
                    case 4:
                        pictureBoxKapcha.Image = this.CreateKapcha(pictureBoxKapcha.Width, pictureBoxKapcha.Height);
                        textBoxKapcha.Clear();
                        textBoxLogin.Clear();
                        textBoxPass.Clear();
                        attempt = 3;
                        FormMainForBooker formFB = new FormMainForBooker();
                        this.Hide();
                        formFB.ShowDialog();
                        this.Show();
                        break;
                }               
            }            
            else if (!t)
            {
                b = false;
                InputInHystory(idUser, dtIn, b);
                // MessageBox.Show("Неверный логин, попробуйте еще раз.");
                //attempt--;
                // return;
            }
            else if (textBoxKapcha.Text != this.text)
            {
                MessageBox.Show("Неверная капча");
                b = false;
                InputInHystory(idUser, dtIn, b);
                attempt--;
            }
            else
            {
                MessageBox.Show("Неверный пароль");
                b = false;
                InputInHystory(idUser, dtIn, b);
                attempt--;
            }            

            if (attempt == 0)
            {
                MessageBox.Show("Количество попыток входа закончилось, приложение будет выключено.");
                Environment.Exit(0);
            }
            if (attempt == 1)
            {
               MessageBox.Show("Система заблокирована на 2 минуты");
                Form.ActiveForm.Enabled = false;
                MyTimer = new Timer();
                MyTimer.Interval = 1000; 
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();

            }
            if (attempt == 2)
            {
                MessageBox.Show("Система заблокирована на 1 минуту");
                Form.ActiveForm.Enabled = false;
                MyTimer = new Timer();
                MyTimer.Interval = 1000; 
                MyTimer.Tick += new EventHandler(MyTimer_Tick);
                MyTimer.Start();                 
            }
        }

        // внести данные о входе в историю, время входа
        private void InputInHystory(int idUser, DateTime dtIn, bool b)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
            sqlConnection.Open();

           // внести вход
            string insertHystory = "insert into History (id_user, entry_time, success) values(@id, @et, @s);";
           // MessageBox.Show(insertHystory);
            SqlCommand cmd = new SqlCommand(insertHystory, sqlConnection);
            cmd.Parameters.AddWithValue("@id", idUser); // ID пользователя
            cmd.Parameters.AddWithValue("@et", dtIn); 
            cmd.Parameters.AddWithValue("@s", b);
            try
            {
                if (cmd.ExecuteNonQuery().ToString() == "1") MessageBox.Show("Данные успешно обновлены");
            }
            catch
            {
                MessageBox.Show("Че-то не то");
                sqlConnection.Close();
                return;
            }
            sqlConnection.Close();
        }

        private void MyTimer_Tick(object sender, EventArgs e)
        {
            if (attempt == 1) sec2--;
            if (attempt == 2) sec--;
            if (sec == 0 || sec2 == 0)
            {
                MyTimer.Stop();
                MessageBox.Show("Время вышло");
                Form.ActiveForm.Enabled = true;
            }
        }

        private Bitmap CreateKapcha(int Width, int Height)
        {
            Random random = new Random();

            Bitmap bmp = new Bitmap(Width, Height);

            // позиция текста
            int Xpos = 10;
            int Ypos = 10;

            // добавить различные цвета для текста
            Brush[] brushes =
            {
                Brushes.Black,
                Brushes.Blue,
                Brushes.Green,
                Brushes.Red,
                Brushes.Yellow,
                Brushes.Pink,
                Brushes.Magenta,
                Brushes.RosyBrown,
                Brushes.DarkGreen,
                Brushes.DarkBlue,
                Brushes.Gray,
                Brushes.Tomato
            };

            // добавить различные цвета для линий
            Pen[] pens =
            {
                Pens.Black,
                Pens.Red,
                Pens.Green,
                Pens.Blue,
                Pens.White,
                Pens.Gray,
                Pens.Yellow,
                Pens.Pink,
                Pens.Magenta
            };

            // сделать случайный стиль
            FontStyle[] style =
            {
                FontStyle.Bold,
                FontStyle.Italic,
                FontStyle.Underline,
                FontStyle.Strikeout,
                FontStyle.Regular
            };

            // добавить различные углы поворота текста
            Int16[] rotate = { 1, -1, 2, -2, 3, -3, 4, -4, 5, -5, 6, -6 };

            // указать, где рисовать
            Graphics graphics = Graphics.FromImage((Image)bmp);

            // фон картинки белый
            graphics.Clear(Color.White);

            // сделать случайный угол поворота текста
            graphics.RotateTransform(random.Next(rotate.Length));

            // сгенерировать текст
            text = String.Empty;
            string alf = "1234567890QWERTYUIOPASDFGHJKLZXCVBNM";
            for (int i = 0; i < 5; ++i)
                text += alf[random.Next(alf.Length)];

            graphics.DrawString(text, new Font("Arial", 20, style[random.Next(style.Length)]),
                brushes[random.Next(brushes.Length)], new PointF(Xpos, Ypos));

            // добавить помехи
            // линии из углов
            graphics.DrawLine(pens[random.Next(pens.Length)], new Point(0, 0), new Point(Width - 1, Height - 1));

            // белые точки
            for (int i = 0; i < Width; ++i)
                for (int j = 0; j < Height; ++j)
                    if (random.Next() % 20 == 0)
                        bmp.SetPixel(i, j, Color.Gray);

            return bmp;
        }

        private void buttonOtherPict_Click(object sender, EventArgs e)
        {
            pictureBoxKapcha.Image = this.CreateKapcha(pictureBoxKapcha.Width, pictureBoxKapcha.Height);
            textBoxKapcha.Text = text;
        }
    }
}
