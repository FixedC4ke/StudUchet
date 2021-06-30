
namespace Megalaba3
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
            this.components = new System.ComponentModel.Container();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.аккаунтToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adduserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addGroupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDiscToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.teacherActMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addActivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeActivityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.acceptDoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studActMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.studTakeActToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studDropActToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studReqMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.studReqSendToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.teacherReqMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.acceptReqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.declineReqToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.teacherActMenu.SuspendLayout();
            this.studActMenu.SuspendLayout();
            this.studReqMenu.SuspendLayout();
            this.teacherReqMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 27);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(204, 398);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(222, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(566, 398);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.аккаунтToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // аккаунтToolStripMenuItem
            // 
            this.аккаунтToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.adduserToolStripMenuItem,
            this.addGroupToolStripMenuItem,
            this.addDiscToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.аккаунтToolStripMenuItem.Name = "аккаунтToolStripMenuItem";
            this.аккаунтToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.аккаунтToolStripMenuItem.Text = "Аккаунт";
            // 
            // adduserToolStripMenuItem
            // 
            this.adduserToolStripMenuItem.Name = "adduserToolStripMenuItem";
            this.adduserToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.adduserToolStripMenuItem.Text = "Добавить пользователя";
            this.adduserToolStripMenuItem.Click += new System.EventHandler(this.adduserToolStripMenuItem_Click);
            // 
            // addGroupToolStripMenuItem
            // 
            this.addGroupToolStripMenuItem.Name = "addGroupToolStripMenuItem";
            this.addGroupToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.addGroupToolStripMenuItem.Text = "Добавить группу";
            this.addGroupToolStripMenuItem.Click += new System.EventHandler(this.addGroupToolStripMenuItem_Click);
            // 
            // addDiscToolStripMenuItem
            // 
            this.addDiscToolStripMenuItem.Name = "addDiscToolStripMenuItem";
            this.addDiscToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.addDiscToolStripMenuItem.Text = "Добавить предмет";
            this.addDiscToolStripMenuItem.Click += new System.EventHandler(this.addDiscToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.exitToolStripMenuItem.Text = "Выход";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // teacherActMenu
            // 
            this.teacherActMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addActivityToolStripMenuItem,
            this.removeActivityToolStripMenuItem,
            this.acceptDoneToolStripMenuItem});
            this.teacherActMenu.Name = "teacherActMenu";
            this.teacherActMenu.Size = new System.Drawing.Size(179, 70);
            // 
            // addActivityToolStripMenuItem
            // 
            this.addActivityToolStripMenuItem.Name = "addActivityToolStripMenuItem";
            this.addActivityToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.addActivityToolStripMenuItem.Text = "Добавить задание";
            this.addActivityToolStripMenuItem.Click += new System.EventHandler(this.addActivityToolStripMenuItem_Click);
            // 
            // removeActivityToolStripMenuItem
            // 
            this.removeActivityToolStripMenuItem.Name = "removeActivityToolStripMenuItem";
            this.removeActivityToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.removeActivityToolStripMenuItem.Text = "Удалить задание";
            this.removeActivityToolStripMenuItem.Click += new System.EventHandler(this.removeActivityToolStripMenuItem_Click);
            // 
            // acceptDoneToolStripMenuItem
            // 
            this.acceptDoneToolStripMenuItem.Name = "acceptDoneToolStripMenuItem";
            this.acceptDoneToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
            this.acceptDoneToolStripMenuItem.Text = "Подтвердить сдачу";
            this.acceptDoneToolStripMenuItem.Click += new System.EventHandler(this.acceptDoneToolStripMenuItem_Click);
            // 
            // studActMenu
            // 
            this.studActMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studTakeActToolStripMenuItem,
            this.studDropActToolStripMenuItem});
            this.studActMenu.Name = "studActMenu";
            this.studActMenu.Size = new System.Drawing.Size(187, 48);
            // 
            // studTakeActToolStripMenuItem
            // 
            this.studTakeActToolStripMenuItem.Name = "studTakeActToolStripMenuItem";
            this.studTakeActToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.studTakeActToolStripMenuItem.Text = "Взять задание";
            this.studTakeActToolStripMenuItem.Click += new System.EventHandler(this.studTakeActToolStripMenuItem_Click);
            // 
            // studDropActToolStripMenuItem
            // 
            this.studDropActToolStripMenuItem.Name = "studDropActToolStripMenuItem";
            this.studDropActToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.studDropActToolStripMenuItem.Text = "Освободить задание";
            this.studDropActToolStripMenuItem.Click += new System.EventHandler(this.studDropActToolStripMenuItem_Click);
            // 
            // studReqMenu
            // 
            this.studReqMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studReqSendToolStripMenuItem});
            this.studReqMenu.Name = "studReqMenu";
            this.studReqMenu.Size = new System.Drawing.Size(300, 26);
            // 
            // studReqSendToolStripMenuItem
            // 
            this.studReqSendToolStripMenuItem.Name = "studReqSendToolStripMenuItem";
            this.studReqSendToolStripMenuItem.Size = new System.Drawing.Size(299, 22);
            this.studReqSendToolStripMenuItem.Text = "Создать запрос на выполненное задание";
            this.studReqSendToolStripMenuItem.Click += new System.EventHandler(this.studReqSendToolStripMenuItem_Click);
            // 
            // teacherReqMenu
            // 
            this.teacherReqMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acceptReqToolStripMenuItem,
            this.declineReqToolStripMenuItem});
            this.teacherReqMenu.Name = "teacherReqMenu";
            this.teacherReqMenu.Size = new System.Drawing.Size(134, 48);
            // 
            // acceptReqToolStripMenuItem
            // 
            this.acceptReqToolStripMenuItem.Name = "acceptReqToolStripMenuItem";
            this.acceptReqToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.acceptReqToolStripMenuItem.Text = "Принять";
            this.acceptReqToolStripMenuItem.Click += new System.EventHandler(this.acceptReqToolStripMenuItem_Click);
            // 
            // declineReqToolStripMenuItem
            // 
            this.declineReqToolStripMenuItem.Name = "declineReqToolStripMenuItem";
            this.declineReqToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.declineReqToolStripMenuItem.Text = "Отклонить";
            this.declineReqToolStripMenuItem.Click += new System.EventHandler(this.declineReqToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Мегалаба3, ИБ186";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.teacherActMenu.ResumeLayout(false);
            this.studActMenu.ResumeLayout(false);
            this.studReqMenu.ResumeLayout(false);
            this.teacherReqMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem аккаунтToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adduserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ContextMenuStrip teacherActMenu;
        private System.Windows.Forms.ToolStripMenuItem addActivityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeActivityToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip studActMenu;
        private System.Windows.Forms.ToolStripMenuItem studTakeActToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem acceptDoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studDropActToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip studReqMenu;
        private System.Windows.Forms.ToolStripMenuItem studReqSendToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip teacherReqMenu;
        private System.Windows.Forms.ToolStripMenuItem acceptReqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem declineReqToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addGroupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDiscToolStripMenuItem;
    }
}

