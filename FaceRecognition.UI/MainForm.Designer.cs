﻿namespace FaceRecognition.UI
{
    partial class MainForm
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
			this.button1 = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage0 = new System.Windows.Forms.TabPage();
			this.button6 = new System.Windows.Forms.Button();
			this.textBox5 = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox7 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.label18 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.radioButton2 = new System.Windows.Forms.RadioButton();
			this.radioButton1 = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.label23 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.button5 = new System.Windows.Forms.Button();
			this.label12 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.comboBox2 = new System.Windows.Forms.ComboBox();
			this.richTextBox2 = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.textBox4 = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label22 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
			this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
			this.panel1 = new System.Windows.Forms.Panel();
			this.button7 = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabPage0.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.flowLayoutPanel1.SuspendLayout();
			this.flowLayoutPanel2.SuspendLayout();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(29, 381);
			this.button1.Margin = new System.Windows.Forms.Padding(1);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(320, 35);
			this.button1.TabIndex = 0;
			this.button1.Text = "Recognize";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
			this.pictureBox1.InitialImage = null;
			this.pictureBox1.Location = new System.Drawing.Point(29, 125);
			this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(320, 245);
			this.pictureBox1.TabIndex = 2;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tabControl1.Controls.Add(this.tabPage0);
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Location = new System.Drawing.Point(12, 50);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(910, 500);
			this.tabControl1.TabIndex = 4;
			// 
			// tabPage0
			// 
			this.tabPage0.Controls.Add(this.button6);
			this.tabPage0.Controls.Add(this.textBox5);
			this.tabPage0.Controls.Add(this.label9);
			this.tabPage0.Controls.Add(this.textBox7);
			this.tabPage0.Controls.Add(this.label11);
			this.tabPage0.Location = new System.Drawing.Point(4, 22);
			this.tabPage0.Name = "tabPage0";
			this.tabPage0.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage0.Size = new System.Drawing.Size(902, 474);
			this.tabPage0.TabIndex = 2;
			this.tabPage0.Text = "Login";
			this.tabPage0.UseVisualStyleBackColor = true;
			// 
			// button6
			// 
			this.button6.Location = new System.Drawing.Point(533, 246);
			this.button6.Name = "button6";
			this.button6.Size = new System.Drawing.Size(100, 23);
			this.button6.TabIndex = 10;
			this.button6.Text = "Start Session";
			this.button6.UseVisualStyleBackColor = true;
			this.button6.Click += new System.EventHandler(this.Button6_Click);
			// 
			// textBox5
			// 
			this.textBox5.Location = new System.Drawing.Point(312, 171);
			this.textBox5.Name = "textBox5";
			this.textBox5.Size = new System.Drawing.Size(321, 20);
			this.textBox5.TabIndex = 5;
			this.textBox5.TextChanged += new System.EventHandler(this.TextBox5_TextChanged);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(243, 174);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(63, 13);
			this.label9.TabIndex = 7;
			this.label9.Text = "User Name:";
			// 
			// textBox7
			// 
			this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.textBox7.Location = new System.Drawing.Point(312, 210);
			this.textBox7.Name = "textBox7";
			this.textBox7.Size = new System.Drawing.Size(321, 20);
			this.textBox7.TabIndex = 9;
			this.textBox7.TextChanged += new System.EventHandler(this.TextBox7_TextChanged);
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(267, 213);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(39, 13);
			this.label11.TabIndex = 8;
			this.label11.Text = "Group:";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.button7);
			this.tabPage1.Controls.Add(this.label18);
			this.tabPage1.Controls.Add(this.label17);
			this.tabPage1.Controls.Add(this.button4);
			this.tabPage1.Controls.Add(this.button3);
			this.tabPage1.Controls.Add(this.richTextBox1);
			this.tabPage1.Controls.Add(this.button2);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.textBox3);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.comboBox1);
			this.tabPage1.Controls.Add(this.radioButton2);
			this.tabPage1.Controls.Add(this.radioButton1);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.textBox2);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(902, 474);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Training";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label18.AutoSize = true;
			this.label18.Location = new System.Drawing.Point(836, 20);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(49, 13);
			this.label18.TabIndex = 16;
			this.label18.Text = "00:00:00";
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(760, 20);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(82, 13);
			this.label17.TabIndex = 15;
			this.label17.Text = "Elaspsed Time: ";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(274, 240);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(60, 20);
			this.button4.TabIndex = 14;
			this.button4.Text = "Browse...";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4_Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(274, 177);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(60, 20);
			this.button3.TabIndex = 13;
			this.button3.Text = "Browse...";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox1.Location = new System.Drawing.Point(359, 34);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ReadOnly = true;
			this.richTextBox1.Size = new System.Drawing.Size(526, 424);
			this.richTextBox1.TabIndex = 12;
			this.richTextBox1.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(35, 281);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(299, 35);
			this.button2.TabIndex = 11;
			this.button2.Text = "Train";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(356, 20);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 10;
			this.label5.Text = "Output:";
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(35, 240);
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(233, 20);
			this.textBox3.TabIndex = 9;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(32, 224);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(99, 13);
			this.label4.TabIndex = 8;
			this.label4.Text = "Model Output Path:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(32, 161);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(95, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Data Source Path:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(32, 79);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(97, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Data Source Type:";
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Location = new System.Drawing.Point(35, 34);
			this.comboBox1.Margin = new System.Windows.Forms.Padding(1);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(299, 21);
			this.comboBox1.TabIndex = 5;
			// 
			// radioButton2
			// 
			this.radioButton2.AutoSize = true;
			this.radioButton2.Location = new System.Drawing.Point(35, 118);
			this.radioButton2.Name = "radioButton2";
			this.radioButton2.Size = new System.Drawing.Size(82, 17);
			this.radioButton2.TabIndex = 3;
			this.radioButton2.TabStop = true;
			this.radioButton2.Text = "image folder";
			this.radioButton2.UseVisualStyleBackColor = true;
			this.radioButton2.CheckedChanged += new System.EventHandler(this.RadioButton2_CheckedChanged);
			// 
			// radioButton1
			// 
			this.radioButton1.AutoSize = true;
			this.radioButton1.Location = new System.Drawing.Point(35, 95);
			this.radioButton1.Name = "radioButton1";
			this.radioButton1.Size = new System.Drawing.Size(45, 17);
			this.radioButton1.TabIndex = 2;
			this.radioButton1.TabStop = true;
			this.radioButton1.Text = ".csv";
			this.radioButton1.UseVisualStyleBackColor = true;
			this.radioButton1.CheckedChanged += new System.EventHandler(this.RadioButton1_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(32, 20);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(111, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Neural Network Type:";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(35, 177);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(233, 20);
			this.textBox2.TabIndex = 0;
			this.textBox2.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.label23);
			this.tabPage2.Controls.Add(this.label19);
			this.tabPage2.Controls.Add(this.label20);
			this.tabPage2.Controls.Add(this.button5);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.comboBox2);
			this.tabPage2.Controls.Add(this.richTextBox2);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.button1);
			this.tabPage2.Controls.Add(this.textBox4);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.pictureBox1);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(902, 474);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Recognition";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// label23
			// 
			this.label23.AutoSize = true;
			this.label23.Cursor = System.Windows.Forms.Cursors.Hand;
			this.label23.Location = new System.Drawing.Point(161, 242);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(51, 13);
			this.label23.TabIndex = 30;
			this.label23.Text = "Browse...";
			this.label23.Click += new System.EventHandler(this.Label23_Click);
			// 
			// label19
			// 
			this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(834, 15);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(49, 13);
			this.label19.TabIndex = 29;
			this.label19.Text = "00:00:00";
			// 
			// label20
			// 
			this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(759, 15);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(82, 13);
			this.label20.TabIndex = 28;
			this.label20.Text = "Elaspsed Time: ";
			// 
			// button5
			// 
			this.button5.Location = new System.Drawing.Point(289, 29);
			this.button5.Name = "button5";
			this.button5.Size = new System.Drawing.Size(60, 20);
			this.button5.TabIndex = 27;
			this.button5.Text = "Browse...";
			this.button5.UseVisualStyleBackColor = true;
			this.button5.Click += new System.EventHandler(this.Button5_Click);
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(28, 111);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(39, 13);
			this.label12.TabIndex = 26;
			this.label12.Text = "Image:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(28, 59);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(89, 13);
			this.label8.TabIndex = 25;
			this.label8.Text = "Emotions Subset:";
			// 
			// comboBox2
			// 
			this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox2.FormattingEnabled = true;
			this.comboBox2.Location = new System.Drawing.Point(29, 75);
			this.comboBox2.Name = "comboBox2";
			this.comboBox2.Size = new System.Drawing.Size(320, 21);
			this.comboBox2.TabIndex = 24;
			// 
			// richTextBox2
			// 
			this.richTextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.richTextBox2.Location = new System.Drawing.Point(376, 29);
			this.richTextBox2.Name = "richTextBox2";
			this.richTextBox2.ReadOnly = true;
			this.richTextBox2.Size = new System.Drawing.Size(509, 432);
			this.richTextBox2.TabIndex = 23;
			this.richTextBox2.Text = "";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(373, 15);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 13);
			this.label6.TabIndex = 21;
			this.label6.Text = "Output:";
			// 
			// textBox4
			// 
			this.textBox4.Location = new System.Drawing.Point(29, 29);
			this.textBox4.Name = "textBox4";
			this.textBox4.Size = new System.Drawing.Size(254, 20);
			this.textBox4.TabIndex = 20;
			this.textBox4.TextChanged += new System.EventHandler(this.TextBox4_TextChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(26, 13);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(103, 13);
			this.label7.TabIndex = 19;
			this.label7.Text = "Trained Model Path:";
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(3, 6);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(68, 13);
			this.label13.TabIndex = 10;
			this.label13.Text = "Python Path:";
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(3, 27);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(116, 13);
			this.label14.TabIndex = 11;
			this.label14.Text = "EmoPy Examples Path:";
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(784, 0);
			this.label15.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(42, 13);
			this.label15.TabIndex = 11;
			this.label15.Text = "Group: ";
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(791, 0);
			this.label16.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(35, 13);
			this.label16.TabIndex = 12;
			this.label16.Text = "User: ";
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Location = new System.Drawing.Point(826, 0);
			this.label22.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.label22.MaximumSize = new System.Drawing.Size(505, 0);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(77, 13);
			this.label22.TabIndex = 16;
			this.label22.Text = "[Not Specified]";
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Location = new System.Drawing.Point(826, 0);
			this.label21.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
			this.label21.MaximumSize = new System.Drawing.Size(505, 0);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(77, 13);
			this.label21.TabIndex = 15;
			this.label21.Text = "[Not Specified]";
			// 
			// flowLayoutPanel1
			// 
			this.flowLayoutPanel1.Controls.Add(this.label22);
			this.flowLayoutPanel1.Controls.Add(this.label16);
			this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 9);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new System.Drawing.Size(906, 20);
			this.flowLayoutPanel1.TabIndex = 31;
			this.flowLayoutPanel1.Visible = false;
			// 
			// flowLayoutPanel2
			// 
			this.flowLayoutPanel2.Controls.Add(this.label21);
			this.flowLayoutPanel2.Controls.Add(this.label15);
			this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
			this.flowLayoutPanel2.Location = new System.Drawing.Point(12, 32);
			this.flowLayoutPanel2.Name = "flowLayoutPanel2";
			this.flowLayoutPanel2.Size = new System.Drawing.Size(906, 20);
			this.flowLayoutPanel2.TabIndex = 32;
			this.flowLayoutPanel2.Visible = false;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.label13);
			this.panel1.Controls.Add(this.label14);
			this.panel1.Location = new System.Drawing.Point(12, 556);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(906, 49);
			this.panel1.TabIndex = 33;
			// 
			// button7
			// 
			this.button7.Enabled = false;
			this.button7.Location = new System.Drawing.Point(35, 329);
			this.button7.Margin = new System.Windows.Forms.Padding(1);
			this.button7.Name = "button7";
			this.button7.Size = new System.Drawing.Size(299, 35);
			this.button7.TabIndex = 32;
			this.button7.Text = "Cancel";
			this.button7.UseVisualStyleBackColor = true;
			this.button7.Click += new System.EventHandler(this.Button7_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(934, 611);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.flowLayoutPanel2);
			this.Controls.Add(this.flowLayoutPanel1);
			this.Controls.Add(this.tabControl1);
			this.Location = new System.Drawing.Point(50, 50);
			this.Margin = new System.Windows.Forms.Padding(1);
			this.MinimumSize = new System.Drawing.Size(837, 614);
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Emotion Recognition";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabPage0.ResumeLayout(false);
			this.tabPage0.PerformLayout();
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			this.flowLayoutPanel1.ResumeLayout(false);
			this.flowLayoutPanel1.PerformLayout();
			this.flowLayoutPanel2.ResumeLayout(false);
			this.flowLayoutPanel2.PerformLayout();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox textBox4;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox textBox5;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox textBox7;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.RichTextBox richTextBox2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox comboBox2;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.TabPage tabPage0;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
		private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button button7;
	}
}

