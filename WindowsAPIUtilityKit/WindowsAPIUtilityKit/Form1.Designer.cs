namespace WindowsAPIUtilityKit
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
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            label3 = new Label();
            label4 = new Label();
            SuspendLayout();

            button1.Location = new Point(43, 115);
            button1.Name = "button1";
            button1.Size = new Size(307, 29);
            button1.TabIndex = 0;
            button1.Text = "Change Title";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;

            textBox1.Location = new Point(43, 69);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(149, 27);
            textBox1.TabIndex = 1;

            textBox2.Location = new Point(225, 69);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 2;

            label1.AutoSize = true;
            label1.Location = new Point(43, 32);
            label1.Name = "label1";
            label1.Size = new Size(156, 20);
            label1.TabIndex = 3;
            label1.Text = "Window Name to find";

            label2.AutoSize = true;
            label2.Location = new Point(225, 32);
            label2.Name = "label2";
            label2.Size = new Size(72, 20);
            label2.TabIndex = 4;
            label2.Text = "New Title";

            button2.Location = new Point(43, 161);
            button2.Name = "button2";
            button2.Size = new Size(307, 29);
            button2.TabIndex = 5;
            button2.Text = "Close Window";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;

            button3.Location = new Point(43, 285);
            button3.Name = "button3";
            button3.Size = new Size(307, 29);
            button3.TabIndex = 6;
            button3.Text = "Play Windows Sounds";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;

            button4.Location = new Point(43, 242);
            button4.Name = "button4";
            button4.Size = new Size(307, 29);
            button4.TabIndex = 7;
            button4.Text = "Get Window Title Length";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;

            label3.AutoSize = true;
            label3.Location = new Point(43, 209);
            label3.Name = "label3";
            label3.Size = new Size(149, 20);
            label3.TabIndex = 8;
            label3.Text = "Window Title Length:";

            label4.AutoSize = true;
            label4.Location = new Point(198, 209);
            label4.Name = "label4";
            label4.Size = new Size(17, 20);
            label4.TabIndex = 9;
            label4.Text = "0";

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(391, 349);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Main Form";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label label3;
        private Label label4;
    }
}
