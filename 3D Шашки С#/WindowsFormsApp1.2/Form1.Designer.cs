
namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.glControl1 = new OpenTK.GLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьИменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правилаИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reverseDeskButton = new System.Windows.Forms.Button();
            this.whoMove = new System.Windows.Forms.Label();
            this.scoreSecondGamer = new System.Windows.Forms.Label();
            this.scoreFirstGamer = new System.Windows.Forms.Label();
            this.nameSecondGamer = new System.Windows.Forms.Label();
            this.nameFirstGamer = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(825, 653);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glControl1_KeyPress);
            this.glControl1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseClick);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.glControl1_PreviewKeyDown);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1084, 30);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.изменитьИменаToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(57, 26);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // изменитьИменаToolStripMenuItem
            // 
            this.изменитьИменаToolStripMenuItem.Name = "изменитьИменаToolStripMenuItem";
            this.изменитьИменаToolStripMenuItem.Size = new System.Drawing.Size(210, 26);
            this.изменитьИменаToolStripMenuItem.Text = "Изменить имена";
            this.изменитьИменаToolStripMenuItem.Click += new System.EventHandler(this.изменитьИменаToolStripMenuItem_Click);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оПрограммеToolStripMenuItem,
            this.правилаИгрыToolStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.оПрограммеToolStripMenuItem.Text = "О программе";
            this.оПрограммеToolStripMenuItem.Click += new System.EventHandler(this.оПрограммеToolStripMenuItem_Click);
            // 
            // правилаИгрыToolStripMenuItem
            // 
            this.правилаИгрыToolStripMenuItem.Name = "правилаИгрыToolStripMenuItem";
            this.правилаИгрыToolStripMenuItem.Size = new System.Drawing.Size(192, 26);
            this.правилаИгрыToolStripMenuItem.Text = "Правила игры";
            this.правилаИгрыToolStripMenuItem.Click += new System.EventHandler(this.правилаИгрыToolStripMenuItem_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 30);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.glControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.reverseDeskButton);
            this.splitContainer1.Panel2.Controls.Add(this.whoMove);
            this.splitContainer1.Panel2.Controls.Add(this.scoreSecondGamer);
            this.splitContainer1.Panel2.Controls.Add(this.scoreFirstGamer);
            this.splitContainer1.Panel2.Controls.Add(this.nameSecondGamer);
            this.splitContainer1.Panel2.Controls.Add(this.nameFirstGamer);
            this.splitContainer1.Size = new System.Drawing.Size(1084, 653);
            this.splitContainer1.SplitterDistance = 825;
            this.splitContainer1.TabIndex = 2;
            // 
            // reverseDeskButton
            // 
            this.reverseDeskButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.reverseDeskButton.Location = new System.Drawing.Point(27, 395);
            this.reverseDeskButton.Name = "reverseDeskButton";
            this.reverseDeskButton.Size = new System.Drawing.Size(195, 61);
            this.reverseDeskButton.TabIndex = 5;
            this.reverseDeskButton.Text = "Развернуть доску";
            this.reverseDeskButton.UseVisualStyleBackColor = true;
            this.reverseDeskButton.Click += new System.EventHandler(this.reverseDeskButton_Click);
            // 
            // whoMove
            // 
            this.whoMove.AutoSize = true;
            this.whoMove.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.whoMove.Location = new System.Drawing.Point(22, 26);
            this.whoMove.Name = "whoMove";
            this.whoMove.Size = new System.Drawing.Size(203, 25);
            this.whoMove.TabIndex = 4;
            this.whoMove.Text = "Сейчас ходят белые";
            // 
            // scoreSecondGamer
            // 
            this.scoreSecondGamer.AutoSize = true;
            this.scoreSecondGamer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreSecondGamer.Location = new System.Drawing.Point(28, 329);
            this.scoreSecondGamer.Name = "scoreSecondGamer";
            this.scoreSecondGamer.Size = new System.Drawing.Size(34, 25);
            this.scoreSecondGamer.TabIndex = 3;
            this.scoreSecondGamer.Text = "12";
            // 
            // scoreFirstGamer
            // 
            this.scoreFirstGamer.AutoSize = true;
            this.scoreFirstGamer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreFirstGamer.Location = new System.Drawing.Point(25, 185);
            this.scoreFirstGamer.Name = "scoreFirstGamer";
            this.scoreFirstGamer.Size = new System.Drawing.Size(34, 25);
            this.scoreFirstGamer.TabIndex = 2;
            this.scoreFirstGamer.Text = "12";
            // 
            // nameSecondGamer
            // 
            this.nameSecondGamer.AutoSize = true;
            this.nameSecondGamer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameSecondGamer.Location = new System.Drawing.Point(22, 297);
            this.nameSecondGamer.Name = "nameSecondGamer";
            this.nameSecondGamer.Size = new System.Drawing.Size(136, 25);
            this.nameSecondGamer.TabIndex = 1;
            this.nameSecondGamer.Text = "Второй игрок";
            // 
            // nameFirstGamer
            // 
            this.nameFirstGamer.AutoSize = true;
            this.nameFirstGamer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameFirstGamer.Location = new System.Drawing.Point(22, 152);
            this.nameFirstGamer.Name = "nameFirstGamer";
            this.nameFirstGamer.Size = new System.Drawing.Size(139, 25);
            this.nameFirstGamer.TabIndex = 0;
            this.nameFirstGamer.Text = "Первый игрок";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 683);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Шашки";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem правилаИгрыToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label scoreSecondGamer;
        private System.Windows.Forms.Label scoreFirstGamer;
        private System.Windows.Forms.Label nameSecondGamer;
        private System.Windows.Forms.Label nameFirstGamer;
        private System.Windows.Forms.Label whoMove;
        private System.Windows.Forms.Button reverseDeskButton;
        private System.Windows.Forms.ToolStripMenuItem изменитьИменаToolStripMenuItem;
    }
}

