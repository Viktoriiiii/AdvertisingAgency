namespace AdvertisingAgency
{
    partial class FormAdvAg
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAdvAg));
            this.buttonAboutFirm = new System.Windows.Forms.Button();
            this.buttonEmployees = new System.Windows.Forms.Button();
            this.buttonIn = new System.Windows.Forms.Button();
            this.buttonExit = new System.Windows.Forms.Button();
            this.labelFirmName = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanelMainPage = new System.Windows.Forms.TableLayoutPanel();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.tableLayoutPanelMainUpr = new System.Windows.Forms.TableLayoutPanel();
            this.buttonWorkExamples = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.tableLayoutPanelMainPage.SuspendLayout();
            this.tableLayoutPanelMainUpr.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonAboutFirm
            // 
            this.buttonAboutFirm.Location = new System.Drawing.Point(10, 10);
            this.buttonAboutFirm.Margin = new System.Windows.Forms.Padding(10);
            this.buttonAboutFirm.Name = "buttonAboutFirm";
            this.buttonAboutFirm.Padding = new System.Windows.Forms.Padding(10);
            this.buttonAboutFirm.Size = new System.Drawing.Size(147, 44);
            this.buttonAboutFirm.TabIndex = 0;
            this.buttonAboutFirm.Text = "О фирме";
            this.buttonAboutFirm.UseVisualStyleBackColor = true;
            this.buttonAboutFirm.Click += new System.EventHandler(this.buttonAboutFirm_Click);
            // 
            // buttonEmployees
            // 
            this.buttonEmployees.Location = new System.Drawing.Point(10, 74);
            this.buttonEmployees.Margin = new System.Windows.Forms.Padding(10);
            this.buttonEmployees.Name = "buttonEmployees";
            this.buttonEmployees.Padding = new System.Windows.Forms.Padding(10);
            this.buttonEmployees.Size = new System.Drawing.Size(147, 44);
            this.buttonEmployees.TabIndex = 1;
            this.buttonEmployees.Text = "Сотрудники";
            this.buttonEmployees.UseVisualStyleBackColor = true;
            this.buttonEmployees.Click += new System.EventHandler(this.buttonEmployees_Click);
            // 
            // buttonIn
            // 
            this.buttonIn.Location = new System.Drawing.Point(10, 207);
            this.buttonIn.Margin = new System.Windows.Forms.Padding(10);
            this.buttonIn.Name = "buttonIn";
            this.buttonIn.Padding = new System.Windows.Forms.Padding(10);
            this.buttonIn.Size = new System.Drawing.Size(147, 44);
            this.buttonIn.TabIndex = 2;
            this.buttonIn.Text = "Войти";
            this.buttonIn.UseVisualStyleBackColor = true;
            this.buttonIn.Click += new System.EventHandler(this.buttonIn_Click);
            // 
            // buttonExit
            // 
            this.buttonExit.Dock = System.Windows.Forms.DockStyle.Right;
            this.buttonExit.Location = new System.Drawing.Point(481, 455);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(10);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(143, 46);
            this.buttonExit.TabIndex = 3;
            this.buttonExit.Text = "Выйти из програмы";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // labelFirmName
            // 
            this.labelFirmName.AutoSize = true;
            this.labelFirmName.Font = new System.Drawing.Font("Sitka Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirmName.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelFirmName.Location = new System.Drawing.Point(183, 10);
            this.labelFirmName.Margin = new System.Windows.Forms.Padding(10);
            this.labelFirmName.MaximumSize = new System.Drawing.Size(410, 0);
            this.labelFirmName.Name = "labelFirmName";
            this.labelFirmName.Padding = new System.Windows.Forms.Padding(10);
            this.labelFirmName.Size = new System.Drawing.Size(296, 59);
            this.labelFirmName.TabIndex = 4;
            this.labelFirmName.Text = "Рекламное агентство ";
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(132, 133);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            // 
            // tableLayoutPanelMainPage
            // 
            this.tableLayoutPanelMainPage.ColumnCount = 2;
            this.tableLayoutPanelMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.38654F));
            this.tableLayoutPanelMainPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 72.61346F));
            this.tableLayoutPanelMainPage.Controls.Add(this.labelWelcome, 1, 1);
            this.tableLayoutPanelMainPage.Controls.Add(this.pictureBoxLogo, 0, 0);
            this.tableLayoutPanelMainPage.Controls.Add(this.labelFirmName, 1, 0);
            this.tableLayoutPanelMainPage.Controls.Add(this.buttonExit, 1, 2);
            this.tableLayoutPanelMainPage.Controls.Add(this.tableLayoutPanelMainUpr, 0, 1);
            this.tableLayoutPanelMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMainPage.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMainPage.Name = "tableLayoutPanelMainPage";
            this.tableLayoutPanelMainPage.RowCount = 3;
            this.tableLayoutPanelMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.6789F));
            this.tableLayoutPanelMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.3211F));
            this.tableLayoutPanelMainPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tableLayoutPanelMainPage.Size = new System.Drawing.Size(634, 511);
            this.tableLayoutPanelMainPage.TabIndex = 9;
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Sitka Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelWelcome.Location = new System.Drawing.Point(273, 276);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(100, 100, 10, 10);
            this.labelWelcome.MaximumSize = new System.Drawing.Size(410, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Padding = new System.Windows.Forms.Padding(10);
            this.labelWelcome.Size = new System.Drawing.Size(271, 59);
            this.labelWelcome.TabIndex = 10;
            this.labelWelcome.Text = "Добро пожаловать!";
            // 
            // tableLayoutPanelMainUpr
            // 
            this.tableLayoutPanelMainUpr.ColumnCount = 1;
            this.tableLayoutPanelMainUpr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMainUpr.Controls.Add(this.buttonWorkExamples, 0, 2);
            this.tableLayoutPanelMainUpr.Controls.Add(this.buttonAboutFirm, 0, 0);
            this.tableLayoutPanelMainUpr.Controls.Add(this.buttonEmployees, 0, 1);
            this.tableLayoutPanelMainUpr.Controls.Add(this.buttonIn, 0, 3);
            this.tableLayoutPanelMainUpr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMainUpr.Location = new System.Drawing.Point(3, 179);
            this.tableLayoutPanelMainUpr.Name = "tableLayoutPanelMainUpr";
            this.tableLayoutPanelMainUpr.RowCount = 4;
            this.tableLayoutPanelMainUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelMainUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.tableLayoutPanelMainUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanelMainUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 66F));
            this.tableLayoutPanelMainUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelMainUpr.Size = new System.Drawing.Size(167, 263);
            this.tableLayoutPanelMainUpr.TabIndex = 9;
            // 
            // buttonWorkExamples
            // 
            this.buttonWorkExamples.Location = new System.Drawing.Point(10, 138);
            this.buttonWorkExamples.Margin = new System.Windows.Forms.Padding(10);
            this.buttonWorkExamples.Name = "buttonWorkExamples";
            this.buttonWorkExamples.Padding = new System.Windows.Forms.Padding(10);
            this.buttonWorkExamples.Size = new System.Drawing.Size(147, 44);
            this.buttonWorkExamples.TabIndex = 11;
            this.buttonWorkExamples.Text = "Наши работы";
            this.buttonWorkExamples.UseVisualStyleBackColor = true;
            this.buttonWorkExamples.Click += new System.EventHandler(this.buttonWorkExamples_Click);
            // 
            // FormAdvAg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.tableLayoutPanelMainPage);
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "FormAdvAg";
            this.Text = "Рекламное агентство";
            this.Load += new System.EventHandler(this.FormAdvAg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.tableLayoutPanelMainPage.ResumeLayout(false);
            this.tableLayoutPanelMainPage.PerformLayout();
            this.tableLayoutPanelMainUpr.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonAboutFirm;
        private System.Windows.Forms.Button buttonEmployees;
        private System.Windows.Forms.Button buttonIn;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.Label labelFirmName;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainPage;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMainUpr;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.Button buttonWorkExamples;
    }
}

