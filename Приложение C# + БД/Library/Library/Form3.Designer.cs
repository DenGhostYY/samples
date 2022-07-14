
namespace Library
{
    partial class Form3
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.buttonDeleteGenre = new System.Windows.Forms.Button();
            this.buttonUpdateGenre = new System.Windows.Forms.Button();
            this.buttonAddGenre = new System.Windows.Forms.Button();
            this.dataGridViewGenre = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonDeleteAuthor = new System.Windows.Forms.Button();
            this.buttonUpdateAuthor = new System.Windows.Forms.Button();
            this.buttonAddAuthor = new System.Windows.Forms.Button();
            this.dataGridViewAuthor = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.buttonDeleteBook = new System.Windows.Forms.Button();
            this.buttonUpdateBook = new System.Windows.Forms.Button();
            this.buttonAddBook = new System.Windows.Forms.Button();
            this.dataGridViewBook = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.buttonDeleteExemp = new System.Windows.Forms.Button();
            this.buttonUpdateExemp = new System.Windows.Forms.Button();
            this.buttonAddExemp = new System.Windows.Forms.Button();
            this.dataGridViewExemp = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.buttonDeleteReader = new System.Windows.Forms.Button();
            this.buttonUpdateReader = new System.Windows.Forms.Button();
            this.buttonAddReader = new System.Windows.Forms.Button();
            this.dataGridViewReader = new System.Windows.Forms.DataGridView();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.buttonUpdateIssue = new System.Windows.Forms.Button();
            this.buttonAddIssue = new System.Windows.Forms.Button();
            this.dataGridViewIssue = new System.Windows.Forms.DataGridView();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewDebIssue = new System.Windows.Forms.DataGridView();
            this.dataGridViewDebtor = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenre)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuthor)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExemp)).BeginInit();
            this.tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReader)).BeginInit();
            this.tabPage6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssue)).BeginInit();
            this.tabPage7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebIssue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebtor)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Controls.Add(this.tabPage7);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(840, 516);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.buttonDeleteGenre);
            this.tabPage1.Controls.Add(this.buttonUpdateGenre);
            this.tabPage1.Controls.Add(this.buttonAddGenre);
            this.tabPage1.Controls.Add(this.dataGridViewGenre);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(832, 478);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Жанры";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteGenre
            // 
            this.buttonDeleteGenre.Location = new System.Drawing.Point(656, 344);
            this.buttonDeleteGenre.Name = "buttonDeleteGenre";
            this.buttonDeleteGenre.Size = new System.Drawing.Size(143, 41);
            this.buttonDeleteGenre.TabIndex = 3;
            this.buttonDeleteGenre.Text = "Удалить";
            this.buttonDeleteGenre.UseVisualStyleBackColor = true;
            this.buttonDeleteGenre.Click += new System.EventHandler(this.buttonDeleteGenre_Click);
            // 
            // buttonUpdateGenre
            // 
            this.buttonUpdateGenre.Location = new System.Drawing.Point(327, 344);
            this.buttonUpdateGenre.Name = "buttonUpdateGenre";
            this.buttonUpdateGenre.Size = new System.Drawing.Size(143, 41);
            this.buttonUpdateGenre.TabIndex = 2;
            this.buttonUpdateGenre.Text = "Изменить";
            this.buttonUpdateGenre.UseVisualStyleBackColor = true;
            this.buttonUpdateGenre.Click += new System.EventHandler(this.buttonUpdateGenre_Click);
            // 
            // buttonAddGenre
            // 
            this.buttonAddGenre.Location = new System.Drawing.Point(23, 344);
            this.buttonAddGenre.Name = "buttonAddGenre";
            this.buttonAddGenre.Size = new System.Drawing.Size(143, 41);
            this.buttonAddGenre.TabIndex = 1;
            this.buttonAddGenre.Text = "Добавить";
            this.buttonAddGenre.UseVisualStyleBackColor = true;
            this.buttonAddGenre.Click += new System.EventHandler(this.buttonAddGenre_Click);
            // 
            // dataGridViewGenre
            // 
            this.dataGridViewGenre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewGenre.Location = new System.Drawing.Point(23, 22);
            this.dataGridViewGenre.Name = "dataGridViewGenre";
            this.dataGridViewGenre.RowHeadersWidth = 51;
            this.dataGridViewGenre.RowTemplate.Height = 24;
            this.dataGridViewGenre.Size = new System.Drawing.Size(776, 296);
            this.dataGridViewGenre.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonDeleteAuthor);
            this.tabPage2.Controls.Add(this.buttonUpdateAuthor);
            this.tabPage2.Controls.Add(this.buttonAddAuthor);
            this.tabPage2.Controls.Add(this.dataGridViewAuthor);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(832, 478);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Авторы";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteAuthor
            // 
            this.buttonDeleteAuthor.Location = new System.Drawing.Point(677, 335);
            this.buttonDeleteAuthor.Name = "buttonDeleteAuthor";
            this.buttonDeleteAuthor.Size = new System.Drawing.Size(127, 53);
            this.buttonDeleteAuthor.TabIndex = 3;
            this.buttonDeleteAuthor.Text = "Удалить";
            this.buttonDeleteAuthor.UseVisualStyleBackColor = true;
            this.buttonDeleteAuthor.Click += new System.EventHandler(this.buttonDeleteAuthor_Click);
            // 
            // buttonUpdateAuthor
            // 
            this.buttonUpdateAuthor.Location = new System.Drawing.Point(342, 335);
            this.buttonUpdateAuthor.Name = "buttonUpdateAuthor";
            this.buttonUpdateAuthor.Size = new System.Drawing.Size(127, 53);
            this.buttonUpdateAuthor.TabIndex = 2;
            this.buttonUpdateAuthor.Text = "Изменить";
            this.buttonUpdateAuthor.UseVisualStyleBackColor = true;
            this.buttonUpdateAuthor.Click += new System.EventHandler(this.buttonUpdateAuthor_Click);
            // 
            // buttonAddAuthor
            // 
            this.buttonAddAuthor.Location = new System.Drawing.Point(29, 335);
            this.buttonAddAuthor.Name = "buttonAddAuthor";
            this.buttonAddAuthor.Size = new System.Drawing.Size(127, 53);
            this.buttonAddAuthor.TabIndex = 1;
            this.buttonAddAuthor.Text = "Добавить";
            this.buttonAddAuthor.UseVisualStyleBackColor = true;
            this.buttonAddAuthor.Click += new System.EventHandler(this.buttonAddAuthor_Click);
            // 
            // dataGridViewAuthor
            // 
            this.dataGridViewAuthor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAuthor.Location = new System.Drawing.Point(29, 30);
            this.dataGridViewAuthor.Name = "dataGridViewAuthor";
            this.dataGridViewAuthor.RowHeadersWidth = 51;
            this.dataGridViewAuthor.RowTemplate.Height = 24;
            this.dataGridViewAuthor.Size = new System.Drawing.Size(775, 284);
            this.dataGridViewAuthor.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.buttonDeleteBook);
            this.tabPage3.Controls.Add(this.buttonUpdateBook);
            this.tabPage3.Controls.Add(this.buttonAddBook);
            this.tabPage3.Controls.Add(this.dataGridViewBook);
            this.tabPage3.Location = new System.Drawing.Point(4, 34);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(832, 478);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Книги";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteBook
            // 
            this.buttonDeleteBook.Location = new System.Drawing.Point(652, 343);
            this.buttonDeleteBook.Name = "buttonDeleteBook";
            this.buttonDeleteBook.Size = new System.Drawing.Size(141, 45);
            this.buttonDeleteBook.TabIndex = 3;
            this.buttonDeleteBook.Text = "Удалить";
            this.buttonDeleteBook.UseVisualStyleBackColor = true;
            this.buttonDeleteBook.Click += new System.EventHandler(this.buttonDeleteBook_Click);
            // 
            // buttonUpdateBook
            // 
            this.buttonUpdateBook.Location = new System.Drawing.Point(333, 343);
            this.buttonUpdateBook.Name = "buttonUpdateBook";
            this.buttonUpdateBook.Size = new System.Drawing.Size(141, 45);
            this.buttonUpdateBook.TabIndex = 2;
            this.buttonUpdateBook.Text = "Изменить";
            this.buttonUpdateBook.UseVisualStyleBackColor = true;
            this.buttonUpdateBook.Click += new System.EventHandler(this.buttonUpdateBook_Click);
            // 
            // buttonAddBook
            // 
            this.buttonAddBook.Location = new System.Drawing.Point(20, 343);
            this.buttonAddBook.Name = "buttonAddBook";
            this.buttonAddBook.Size = new System.Drawing.Size(141, 45);
            this.buttonAddBook.TabIndex = 1;
            this.buttonAddBook.Text = "Добавить";
            this.buttonAddBook.UseVisualStyleBackColor = true;
            this.buttonAddBook.Click += new System.EventHandler(this.buttonAddBook_Click);
            // 
            // dataGridViewBook
            // 
            this.dataGridViewBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBook.Location = new System.Drawing.Point(8, 20);
            this.dataGridViewBook.Name = "dataGridViewBook";
            this.dataGridViewBook.RowHeadersWidth = 51;
            this.dataGridViewBook.RowTemplate.Height = 24;
            this.dataGridViewBook.Size = new System.Drawing.Size(785, 275);
            this.dataGridViewBook.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.buttonDeleteExemp);
            this.tabPage4.Controls.Add(this.buttonUpdateExemp);
            this.tabPage4.Controls.Add(this.buttonAddExemp);
            this.tabPage4.Controls.Add(this.dataGridViewExemp);
            this.tabPage4.Location = new System.Drawing.Point(4, 34);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(832, 478);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Экземпляры";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteExemp
            // 
            this.buttonDeleteExemp.Location = new System.Drawing.Point(687, 335);
            this.buttonDeleteExemp.Name = "buttonDeleteExemp";
            this.buttonDeleteExemp.Size = new System.Drawing.Size(123, 48);
            this.buttonDeleteExemp.TabIndex = 3;
            this.buttonDeleteExemp.Text = "Удалить";
            this.buttonDeleteExemp.UseVisualStyleBackColor = true;
            this.buttonDeleteExemp.Click += new System.EventHandler(this.buttonDeleteExemp_Click);
            // 
            // buttonUpdateExemp
            // 
            this.buttonUpdateExemp.Location = new System.Drawing.Point(336, 335);
            this.buttonUpdateExemp.Name = "buttonUpdateExemp";
            this.buttonUpdateExemp.Size = new System.Drawing.Size(123, 48);
            this.buttonUpdateExemp.TabIndex = 2;
            this.buttonUpdateExemp.Text = "Изменить";
            this.buttonUpdateExemp.UseVisualStyleBackColor = true;
            this.buttonUpdateExemp.Click += new System.EventHandler(this.buttonUpdateExemp_Click);
            // 
            // buttonAddExemp
            // 
            this.buttonAddExemp.Location = new System.Drawing.Point(19, 335);
            this.buttonAddExemp.Name = "buttonAddExemp";
            this.buttonAddExemp.Size = new System.Drawing.Size(123, 48);
            this.buttonAddExemp.TabIndex = 1;
            this.buttonAddExemp.Text = "Добавить";
            this.buttonAddExemp.UseVisualStyleBackColor = true;
            this.buttonAddExemp.Click += new System.EventHandler(this.buttonAddExemp_Click);
            // 
            // dataGridViewExemp
            // 
            this.dataGridViewExemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExemp.Location = new System.Drawing.Point(19, 15);
            this.dataGridViewExemp.Name = "dataGridViewExemp";
            this.dataGridViewExemp.RowHeadersWidth = 51;
            this.dataGridViewExemp.RowTemplate.Height = 24;
            this.dataGridViewExemp.Size = new System.Drawing.Size(791, 298);
            this.dataGridViewExemp.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.buttonDeleteReader);
            this.tabPage5.Controls.Add(this.buttonUpdateReader);
            this.tabPage5.Controls.Add(this.buttonAddReader);
            this.tabPage5.Controls.Add(this.dataGridViewReader);
            this.tabPage5.Location = new System.Drawing.Point(4, 34);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(832, 478);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Читатели";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteReader
            // 
            this.buttonDeleteReader.Location = new System.Drawing.Point(667, 334);
            this.buttonDeleteReader.Name = "buttonDeleteReader";
            this.buttonDeleteReader.Size = new System.Drawing.Size(148, 49);
            this.buttonDeleteReader.TabIndex = 3;
            this.buttonDeleteReader.Text = "Удалить";
            this.buttonDeleteReader.UseVisualStyleBackColor = true;
            this.buttonDeleteReader.Click += new System.EventHandler(this.buttonDeleteReader_Click);
            // 
            // buttonUpdateReader
            // 
            this.buttonUpdateReader.Location = new System.Drawing.Point(337, 334);
            this.buttonUpdateReader.Name = "buttonUpdateReader";
            this.buttonUpdateReader.Size = new System.Drawing.Size(148, 49);
            this.buttonUpdateReader.TabIndex = 2;
            this.buttonUpdateReader.Text = "Изменить";
            this.buttonUpdateReader.UseVisualStyleBackColor = true;
            this.buttonUpdateReader.Click += new System.EventHandler(this.buttonUpdateReader_Click);
            // 
            // buttonAddReader
            // 
            this.buttonAddReader.Location = new System.Drawing.Point(8, 334);
            this.buttonAddReader.Name = "buttonAddReader";
            this.buttonAddReader.Size = new System.Drawing.Size(148, 49);
            this.buttonAddReader.TabIndex = 1;
            this.buttonAddReader.Text = "Добавить";
            this.buttonAddReader.UseVisualStyleBackColor = true;
            this.buttonAddReader.Click += new System.EventHandler(this.buttonAddReader_Click);
            // 
            // dataGridViewReader
            // 
            this.dataGridViewReader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReader.Location = new System.Drawing.Point(8, 20);
            this.dataGridViewReader.Name = "dataGridViewReader";
            this.dataGridViewReader.RowHeadersWidth = 51;
            this.dataGridViewReader.RowTemplate.Height = 24;
            this.dataGridViewReader.Size = new System.Drawing.Size(807, 289);
            this.dataGridViewReader.TabIndex = 0;
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.buttonUpdateIssue);
            this.tabPage6.Controls.Add(this.buttonAddIssue);
            this.tabPage6.Controls.Add(this.dataGridViewIssue);
            this.tabPage6.Location = new System.Drawing.Point(4, 34);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(832, 478);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Выдачи";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // buttonUpdateIssue
            // 
            this.buttonUpdateIssue.Location = new System.Drawing.Point(595, 415);
            this.buttonUpdateIssue.Name = "buttonUpdateIssue";
            this.buttonUpdateIssue.Size = new System.Drawing.Size(228, 50);
            this.buttonUpdateIssue.TabIndex = 2;
            this.buttonUpdateIssue.Text = "Принять книгу";
            this.buttonUpdateIssue.UseVisualStyleBackColor = true;
            this.buttonUpdateIssue.Click += new System.EventHandler(this.buttonUpdateIssue_Click);
            // 
            // buttonAddIssue
            // 
            this.buttonAddIssue.Location = new System.Drawing.Point(8, 415);
            this.buttonAddIssue.Name = "buttonAddIssue";
            this.buttonAddIssue.Size = new System.Drawing.Size(189, 50);
            this.buttonAddIssue.TabIndex = 1;
            this.buttonAddIssue.Text = "Выдать книгу";
            this.buttonAddIssue.UseVisualStyleBackColor = true;
            this.buttonAddIssue.Click += new System.EventHandler(this.buttonAddIssue_Click);
            // 
            // dataGridViewIssue
            // 
            this.dataGridViewIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewIssue.Location = new System.Drawing.Point(7, 97);
            this.dataGridViewIssue.Name = "dataGridViewIssue";
            this.dataGridViewIssue.RowHeadersWidth = 51;
            this.dataGridViewIssue.RowTemplate.Height = 24;
            this.dataGridViewIssue.Size = new System.Drawing.Size(816, 303);
            this.dataGridViewIssue.TabIndex = 0;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.label3);
            this.tabPage7.Controls.Add(this.label2);
            this.tabPage7.Controls.Add(this.dataGridViewDebIssue);
            this.tabPage7.Controls.Add(this.dataGridViewDebtor);
            this.tabPage7.Controls.Add(this.textBox1);
            this.tabPage7.Controls.Add(this.label1);
            this.tabPage7.Location = new System.Drawing.Point(4, 34);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(832, 478);
            this.tabPage7.TabIndex = 6;
            this.tabPage7.Text = "Должники";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 268);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 25);
            this.label3.TabIndex = 5;
            this.label3.Text = "Долги";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "Должники";
            // 
            // dataGridViewDebIssue
            // 
            this.dataGridViewDebIssue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDebIssue.Location = new System.Drawing.Point(140, 268);
            this.dataGridViewDebIssue.Name = "dataGridViewDebIssue";
            this.dataGridViewDebIssue.RowHeadersWidth = 51;
            this.dataGridViewDebIssue.RowTemplate.Height = 24;
            this.dataGridViewDebIssue.Size = new System.Drawing.Size(629, 180);
            this.dataGridViewDebIssue.TabIndex = 3;
            // 
            // dataGridViewDebtor
            // 
            this.dataGridViewDebtor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDebtor.Location = new System.Drawing.Point(140, 73);
            this.dataGridViewDebtor.Name = "dataGridViewDebtor";
            this.dataGridViewDebtor.RowHeadersWidth = 51;
            this.dataGridViewDebtor.RowTemplate.Height = 24;
            this.dataGridViewDebtor.Size = new System.Drawing.Size(483, 170);
            this.dataGridViewDebtor.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(86, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 30);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "20";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Срок";
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 528);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form3";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Библиотекарь";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form3_FormClosed);
            this.Load += new System.EventHandler(this.Form3_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewGenre)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAuthor)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).EndInit();
            this.tabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExemp)).EndInit();
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReader)).EndInit();
            this.tabPage6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewIssue)).EndInit();
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebIssue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDebtor)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button buttonDeleteGenre;
        private System.Windows.Forms.Button buttonUpdateGenre;
        private System.Windows.Forms.Button buttonAddGenre;
        private System.Windows.Forms.DataGridView dataGridViewGenre;
        private System.Windows.Forms.DataGridView dataGridViewAuthor;
        private System.Windows.Forms.Button buttonDeleteAuthor;
        private System.Windows.Forms.Button buttonUpdateAuthor;
        private System.Windows.Forms.Button buttonAddAuthor;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonDeleteBook;
        private System.Windows.Forms.Button buttonUpdateBook;
        private System.Windows.Forms.Button buttonAddBook;
        private System.Windows.Forms.DataGridView dataGridViewBook;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button buttonDeleteExemp;
        private System.Windows.Forms.Button buttonUpdateExemp;
        private System.Windows.Forms.Button buttonAddExemp;
        private System.Windows.Forms.DataGridView dataGridViewExemp;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.Button buttonDeleteReader;
        private System.Windows.Forms.Button buttonUpdateReader;
        private System.Windows.Forms.Button buttonAddReader;
        private System.Windows.Forms.DataGridView dataGridViewReader;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Button buttonUpdateIssue;
        private System.Windows.Forms.Button buttonAddIssue;
        private System.Windows.Forms.DataGridView dataGridViewIssue;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.DataGridView dataGridViewDebIssue;
        private System.Windows.Forms.DataGridView dataGridViewDebtor;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}