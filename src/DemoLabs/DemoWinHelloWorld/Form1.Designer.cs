namespace DemoWinHelloWorld
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button1 = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(103, 63);
            label1.Name = "label1";
            label1.Size = new Size(229, 32);
            label1.TabIndex = 0;
            label1.Text = "Enter FIRST Number";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F);
            label2.Location = new Point(103, 108);
            label2.Name = "label2";
            label2.Size = new Size(250, 32);
            label2.TabIndex = 1;
            label2.Text = "Enter Second Number";
            // 
            // textBox1
            // 
            textBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox1.Font = new Font("Segoe UI", 14F);
            textBox1.Location = new Point(360, 60);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(173, 39);
            textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            textBox2.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox2.Font = new Font("Segoe UI", 14F);
            textBox2.Location = new Point(360, 105);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(173, 39);
            textBox2.TabIndex = 3;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            button1.Font = new Font("Segoe UI", 14F);
            button1.Location = new Point(102, 158);
            button1.Name = "button1";
            button1.Size = new Size(431, 49);
            button1.TabIndex = 4;
            button1.Text = "Click to Add numbers";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.None;
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label3.Location = new Point(127, 219);
            label3.Name = "label3";
            label3.Size = new Size(83, 32);
            label3.TabIndex = 5;
            label3.Text = "label3";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(635, 311);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button1;
        private Label label3;
    }
}
