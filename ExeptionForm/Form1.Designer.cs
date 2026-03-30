namespace ExeptionForm
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnGenerate = new Button();
            listBox1 = new ListBox();
            SuspendLayout();
            
            btnGenerate.Location = new Point(12, 12);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(250, 40);
            btnGenerate.TabIndex = 0;
            btnGenerate.Text = "Сгенерировать пользователей";
            btnGenerate.UseVisualStyleBackColor = true;
            btnGenerate.Click += btnGenerate_Click;

            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 15;
            listBox1.Location = new Point(12, 70);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(400, 199);
            listBox1.TabIndex = 1;

            ClientSize = new Size(1363, 736);
            Controls.Add(listBox1);
            Controls.Add(btnGenerate);
            Name = "Form1";
            Text = "Faker Users App";
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.ListBox listBox1;
    }
}