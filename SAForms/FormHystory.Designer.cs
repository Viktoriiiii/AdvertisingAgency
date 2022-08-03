namespace AdvertisingAgency.SAForms
{
    partial class FormHystory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHystory));
            this.tableLayoutPanelMain = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.labelFirmName = new System.Windows.Forms.Label();
            this.labelWelcome = new System.Windows.Forms.Label();
            this.tableLayoutPanelAuthoUpr = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridViewHystory = new System.Windows.Forms.DataGridView();
            this.buttonBack = new System.Windows.Forms.Button();
            this.tableLayoutPanelPoisk = new System.Windows.Forms.TableLayoutPanel();
            this.buttonPoisk = new System.Windows.Forms.Button();
            this.textBoxPoisk = new System.Windows.Forms.TextBox();
            this.comboBoxSort = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.tableLayoutPanelAuthoUpr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHystory)).BeginInit();
            this.tableLayoutPanelPoisk.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanelMain
            // 
            this.tableLayoutPanelMain.ColumnCount = 3;
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.71774F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85.28226F));
            this.tableLayoutPanelMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 138F));
            this.tableLayoutPanelMain.Controls.Add(this.pictureBoxLogo, 0, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelFirmName, 2, 0);
            this.tableLayoutPanelMain.Controls.Add(this.labelWelcome, 1, 0);
            this.tableLayoutPanelMain.Controls.Add(this.tableLayoutPanelAuthoUpr, 1, 1);
            this.tableLayoutPanelMain.Controls.Add(this.comboBoxSort, 2, 1);
            this.tableLayoutPanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelMain.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelMain.Name = "tableLayoutPanelMain";
            this.tableLayoutPanelMain.RowCount = 2;
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.85127F));
            this.tableLayoutPanelMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 84.14873F));
            this.tableLayoutPanelMain.Size = new System.Drawing.Size(634, 511);
            this.tableLayoutPanelMain.TabIndex = 12;
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxLogo.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.Image")));
            this.pictureBoxLogo.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(66, 74);
            this.pictureBoxLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLogo.TabIndex = 5;
            this.pictureBoxLogo.TabStop = false;
            // 
            // labelFirmName
            // 
            this.labelFirmName.AutoSize = true;
            this.labelFirmName.Font = new System.Drawing.Font("Sitka Display", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFirmName.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelFirmName.Location = new System.Drawing.Point(520, 2);
            this.labelFirmName.Margin = new System.Windows.Forms.Padding(25, 2, 2, 2);
            this.labelFirmName.MaximumSize = new System.Drawing.Size(410, 0);
            this.labelFirmName.Name = "labelFirmName";
            this.labelFirmName.Size = new System.Drawing.Size(79, 40);
            this.labelFirmName.TabIndex = 4;
            this.labelFirmName.Text = "Рекламное агентство ";
            // 
            // labelWelcome
            // 
            this.labelWelcome.AutoSize = true;
            this.labelWelcome.Font = new System.Drawing.Font("Sitka Display", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelWelcome.ForeColor = System.Drawing.Color.DarkCyan;
            this.labelWelcome.Location = new System.Drawing.Point(192, 10);
            this.labelWelcome.Margin = new System.Windows.Forms.Padding(120, 10, 10, 10);
            this.labelWelcome.MaximumSize = new System.Drawing.Size(410, 0);
            this.labelWelcome.Name = "labelWelcome";
            this.labelWelcome.Padding = new System.Windows.Forms.Padding(10);
            this.labelWelcome.Size = new System.Drawing.Size(230, 59);
            this.labelWelcome.TabIndex = 10;
            this.labelWelcome.Text = "История входов";
            // 
            // tableLayoutPanelAuthoUpr
            // 
            this.tableLayoutPanelAuthoUpr.ColumnCount = 1;
            this.tableLayoutPanelAuthoUpr.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelAuthoUpr.Controls.Add(this.dataGridViewHystory, 0, 0);
            this.tableLayoutPanelAuthoUpr.Controls.Add(this.buttonBack, 0, 2);
            this.tableLayoutPanelAuthoUpr.Controls.Add(this.tableLayoutPanelPoisk, 0, 1);
            this.tableLayoutPanelAuthoUpr.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelAuthoUpr.Location = new System.Drawing.Point(92, 100);
            this.tableLayoutPanelAuthoUpr.Margin = new System.Windows.Forms.Padding(20);
            this.tableLayoutPanelAuthoUpr.Name = "tableLayoutPanelAuthoUpr";
            this.tableLayoutPanelAuthoUpr.RowCount = 3;
            this.tableLayoutPanelAuthoUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87.93651F));
            this.tableLayoutPanelAuthoUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.06349F));
            this.tableLayoutPanelAuthoUpr.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62F));
            this.tableLayoutPanelAuthoUpr.Size = new System.Drawing.Size(383, 378);
            this.tableLayoutPanelAuthoUpr.TabIndex = 9;
            // 
            // dataGridViewHystory
            // 
            this.dataGridViewHystory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewHystory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewHystory.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewHystory.Name = "dataGridViewHystory";
            this.dataGridViewHystory.ReadOnly = true;
            this.dataGridViewHystory.Size = new System.Drawing.Size(377, 271);
            this.dataGridViewHystory.TabIndex = 4;
            // 
            // buttonBack
            // 
            this.buttonBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonBack.Location = new System.Drawing.Point(110, 325);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(110, 10, 110, 10);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Padding = new System.Windows.Forms.Padding(5);
            this.buttonBack.Size = new System.Drawing.Size(163, 43);
            this.buttonBack.TabIndex = 3;
            this.buttonBack.Text = "Вернуться на главную";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // tableLayoutPanelPoisk
            // 
            this.tableLayoutPanelPoisk.ColumnCount = 2;
            this.tableLayoutPanelPoisk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPoisk.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 143F));
            this.tableLayoutPanelPoisk.Controls.Add(this.buttonPoisk, 1, 0);
            this.tableLayoutPanelPoisk.Controls.Add(this.textBoxPoisk, 0, 0);
            this.tableLayoutPanelPoisk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelPoisk.Location = new System.Drawing.Point(3, 280);
            this.tableLayoutPanelPoisk.Name = "tableLayoutPanelPoisk";
            this.tableLayoutPanelPoisk.RowCount = 1;
            this.tableLayoutPanelPoisk.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanelPoisk.Size = new System.Drawing.Size(377, 32);
            this.tableLayoutPanelPoisk.TabIndex = 5;
            // 
            // buttonPoisk
            // 
            this.buttonPoisk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonPoisk.Location = new System.Drawing.Point(237, 3);
            this.buttonPoisk.Name = "buttonPoisk";
            this.buttonPoisk.Size = new System.Drawing.Size(137, 26);
            this.buttonPoisk.TabIndex = 0;
            this.buttonPoisk.Text = "Искать по mail";
            this.buttonPoisk.UseVisualStyleBackColor = true;
            this.buttonPoisk.Click += new System.EventHandler(this.buttonPoisk_Click);
            // 
            // textBoxPoisk
            // 
            this.textBoxPoisk.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxPoisk.Location = new System.Drawing.Point(3, 5);
            this.textBoxPoisk.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.textBoxPoisk.Name = "textBoxPoisk";
            this.textBoxPoisk.Size = new System.Drawing.Size(228, 20);
            this.textBoxPoisk.TabIndex = 1;
            this.textBoxPoisk.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPoisk_KeyPress);
            // 
            // comboBoxSort
            // 
            this.comboBoxSort.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBoxSort.FormattingEnabled = true;
            this.comboBoxSort.Items.AddRange(new object[] {
            "Все",
            "Успешные",
            "Неуспешные"});
            this.comboBoxSort.Location = new System.Drawing.Point(498, 110);
            this.comboBoxSort.Margin = new System.Windows.Forms.Padding(3, 30, 3, 3);
            this.comboBoxSort.Name = "comboBoxSort";
            this.comboBoxSort.Size = new System.Drawing.Size(133, 21);
            this.comboBoxSort.TabIndex = 11;
            this.comboBoxSort.Text = "Все";
            this.comboBoxSort.SelectedIndexChanged += new System.EventHandler(this.comboBoxSort_SelectedIndexChanged);
            // 
            // FormHystory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 511);
            this.Controls.Add(this.tableLayoutPanelMain);
            this.MinimumSize = new System.Drawing.Size(650, 550);
            this.Name = "FormHystory";
            this.Text = "История входов";
            this.Load += new System.EventHandler(this.FormHystory_Load);
            this.tableLayoutPanelMain.ResumeLayout(false);
            this.tableLayoutPanelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.tableLayoutPanelAuthoUpr.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewHystory)).EndInit();
            this.tableLayoutPanelPoisk.ResumeLayout(false);
            this.tableLayoutPanelPoisk.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelMain;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelFirmName;
        private System.Windows.Forms.Label labelWelcome;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelAuthoUpr;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.DataGridView dataGridViewHystory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelPoisk;
        private System.Windows.Forms.Button buttonPoisk;
        private System.Windows.Forms.TextBox textBoxPoisk;
        private System.Windows.Forms.ComboBox comboBoxSort;
    }
}