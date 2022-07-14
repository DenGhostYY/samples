
namespace Library
{
    partial class ChangeIssueForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxNumberTicket = new System.Windows.Forms.TextBox();
            this.dataGridViewReader = new System.Windows.Forms.DataGridView();
            this.dataGridViewBook = new System.Windows.Forms.DataGridView();
            this.dataGridViewExemp = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxTerm = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dateTimePickerIssue = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerReturn = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExemp)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер билета";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(651, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Экземпляры";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 303);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Книги";
            // 
            // textBoxNumberTicket
            // 
            this.textBoxNumberTicket.Location = new System.Drawing.Point(27, 37);
            this.textBoxNumberTicket.Name = "textBoxNumberTicket";
            this.textBoxNumberTicket.Size = new System.Drawing.Size(153, 30);
            this.textBoxNumberTicket.TabIndex = 1;
            this.textBoxNumberTicket.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridViewReader
            // 
            this.dataGridViewReader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReader.Location = new System.Drawing.Point(27, 82);
            this.dataGridViewReader.Name = "dataGridViewReader";
            this.dataGridViewReader.RowHeadersWidth = 51;
            this.dataGridViewReader.RowTemplate.Height = 24;
            this.dataGridViewReader.Size = new System.Drawing.Size(581, 181);
            this.dataGridViewReader.TabIndex = 10;
            // 
            // dataGridViewBook
            // 
            this.dataGridViewBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBook.Location = new System.Drawing.Point(27, 331);
            this.dataGridViewBook.Name = "dataGridViewBook";
            this.dataGridViewBook.RowHeadersWidth = 51;
            this.dataGridViewBook.RowTemplate.Height = 24;
            this.dataGridViewBook.Size = new System.Drawing.Size(581, 205);
            this.dataGridViewBook.TabIndex = 11;
            // 
            // dataGridViewExemp
            // 
            this.dataGridViewExemp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExemp.Location = new System.Drawing.Point(656, 82);
            this.dataGridViewExemp.Name = "dataGridViewExemp";
            this.dataGridViewExemp.RowHeadersWidth = 51;
            this.dataGridViewExemp.RowTemplate.Height = 24;
            this.dataGridViewExemp.Size = new System.Drawing.Size(207, 153);
            this.dataGridViewExemp.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 307);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 13;
            this.label1.Text = "Дата выдачи";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(658, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "Дата возврата";
            // 
            // textBoxTerm
            // 
            this.textBoxTerm.Location = new System.Drawing.Point(663, 510);
            this.textBoxTerm.Name = "textBoxTerm";
            this.textBoxTerm.Size = new System.Drawing.Size(98, 30);
            this.textBoxTerm.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(658, 482);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 25);
            this.label6.TabIndex = 18;
            this.label6.Text = "Срок";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(722, 572);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 57);
            this.button1.TabIndex = 19;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(28, 572);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(141, 57);
            this.button2.TabIndex = 20;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // dateTimePickerIssue
            // 
            this.dateTimePickerIssue.Location = new System.Drawing.Point(663, 335);
            this.dateTimePickerIssue.Name = "dateTimePickerIssue";
            this.dateTimePickerIssue.Size = new System.Drawing.Size(200, 30);
            this.dateTimePickerIssue.TabIndex = 21;
            // 
            // dateTimePickerReturn
            // 
            this.dateTimePickerReturn.Location = new System.Drawing.Point(663, 425);
            this.dateTimePickerReturn.Name = "dateTimePickerReturn";
            this.dateTimePickerReturn.Size = new System.Drawing.Size(200, 30);
            this.dateTimePickerReturn.TabIndex = 22;
            // 
            // ChangeIssueForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 651);
            this.Controls.Add(this.dateTimePickerReturn);
            this.Controls.Add(this.dateTimePickerIssue);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxTerm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewExemp);
            this.Controls.Add(this.dataGridViewBook);
            this.Controls.Add(this.dataGridViewReader);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumberTicket);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "ChangeIssueForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выдача экземпляра";
            this.Load += new System.EventHandler(this.ChangeIssueForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExemp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxNumberTicket;
        private System.Windows.Forms.DataGridView dataGridViewReader;
        private System.Windows.Forms.DataGridView dataGridViewBook;
        private System.Windows.Forms.DataGridView dataGridViewExemp;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxTerm;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dateTimePickerIssue;
        private System.Windows.Forms.DateTimePicker dateTimePickerReturn;
    }
}