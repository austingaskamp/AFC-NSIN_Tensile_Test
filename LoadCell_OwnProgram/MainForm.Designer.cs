namespace LoadCell_OwnProgram
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.StartButton = new System.Windows.Forms.Button();
            this.StopButton = new System.Windows.Forms.Button();
            this.ResultsLab = new System.Windows.Forms.Label();
            this.ForceLabel = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown3 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown4 = new System.Windows.Forms.NumericUpDown();
            this.StressOutput = new System.Windows.Forms.Label();
            this.StressLabel = new System.Windows.Forms.Label();
            this.numericUpDown5 = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.InitializeButton = new System.Windows.Forms.Button();
            this.TimeOutput = new System.Windows.Forms.Label();
            this.TimeLabel = new System.Windows.Forms.Label();
            this.DispLabel = new System.Windows.Forms.Label();
            this.DispOutput = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Temp1Label = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Temp2Label = new System.Windows.Forms.Label();
            this.Temp3Label = new System.Windows.Forms.Label();
            this.Temp4Label = new System.Windows.Forms.Label();
            this.ForceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.StressChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDown6 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StressChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.BackColor = System.Drawing.Color.Lime;
            this.StartButton.Enabled = false;
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.StartButton.Location = new System.Drawing.Point(623, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(243, 77);
            this.StartButton.TabIndex = 0;
            this.StartButton.Text = "Start";
            this.StartButton.UseVisualStyleBackColor = false;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // StopButton
            // 
            this.StopButton.BackColor = System.Drawing.Color.Red;
            this.StopButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.StopButton.Location = new System.Drawing.Point(923, 12);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(243, 77);
            this.StopButton.TabIndex = 1;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = false;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // ResultsLab
            // 
            this.ResultsLab.AutoSize = true;
            this.ResultsLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.6F);
            this.ResultsLab.Location = new System.Drawing.Point(299, 345);
            this.ResultsLab.Name = "ResultsLab";
            this.ResultsLab.Size = new System.Drawing.Size(160, 39);
            this.ResultsLab.TabIndex = 2;
            this.ResultsLab.Text = "Force [N]";
            // 
            // ForceLabel
            // 
            this.ForceLabel.AutoSize = true;
            this.ForceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.6F);
            this.ForceLabel.Location = new System.Drawing.Point(299, 402);
            this.ForceLabel.Name = "ForceLabel";
            this.ForceLabel.Size = new System.Drawing.Size(62, 39);
            this.ForceLabel.TabIndex = 3;
            this.ForceLabel.Text = "[N]";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DecimalPlaces = 2;
            this.numericUpDown1.Location = new System.Drawing.Point(50, 136);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.DecimalPlaces = 2;
            this.numericUpDown2.Location = new System.Drawing.Point(50, 199);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown2.TabIndex = 5;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // numericUpDown3
            // 
            this.numericUpDown3.DecimalPlaces = 2;
            this.numericUpDown3.Location = new System.Drawing.Point(50, 264);
            this.numericUpDown3.Name = "numericUpDown3";
            this.numericUpDown3.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown3.TabIndex = 6;
            this.numericUpDown3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown3.ValueChanged += new System.EventHandler(this.numericUpDown3_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Gauge Length [mm]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Gauge Thickness [mm]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(31, 171);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Gauge Width [mm]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 300);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Strain Rate [1/s]";
            // 
            // numericUpDown4
            // 
            this.numericUpDown4.DecimalPlaces = 3;
            this.numericUpDown4.Location = new System.Drawing.Point(50, 328);
            this.numericUpDown4.Name = "numericUpDown4";
            this.numericUpDown4.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown4.TabIndex = 11;
            this.numericUpDown4.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDown4.ValueChanged += new System.EventHandler(this.numericUpDown4_ValueChanged);
            // 
            // StressOutput
            // 
            this.StressOutput.AutoSize = true;
            this.StressOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.StressOutput.Location = new System.Drawing.Point(299, 459);
            this.StressOutput.Name = "StressOutput";
            this.StressOutput.Size = new System.Drawing.Size(217, 39);
            this.StressOutput.TabIndex = 12;
            this.StressOutput.Text = "Stress [MPa]";
            // 
            // StressLabel
            // 
            this.StressLabel.AutoSize = true;
            this.StressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.StressLabel.Location = new System.Drawing.Point(299, 516);
            this.StressLabel.Name = "StressLabel";
            this.StressLabel.Size = new System.Drawing.Size(108, 39);
            this.StressLabel.TabIndex = 13;
            this.StressLabel.Text = "[MPa]";
            // 
            // numericUpDown5
            // 
            this.numericUpDown5.DecimalPlaces = 2;
            this.numericUpDown5.Location = new System.Drawing.Point(50, 390);
            this.numericUpDown5.Name = "numericUpDown5";
            this.numericUpDown5.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown5.TabIndex = 14;
            this.numericUpDown5.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown5.ValueChanged += new System.EventHandler(this.numericUpDown5_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(31, 360);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Acquisition Rate [Hz]";
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.CheckFileExists = true;
            this.saveFileDialog1.FileName = "data.csv";
            this.saveFileDialog1.Title = "Enter File Name Here";
            this.saveFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.saveFileDialog1_FileOk);
            // 
            // InitializeButton
            // 
            this.InitializeButton.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.InitializeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F);
            this.InitializeButton.Location = new System.Drawing.Point(358, 14);
            this.InitializeButton.Name = "InitializeButton";
            this.InitializeButton.Size = new System.Drawing.Size(205, 77);
            this.InitializeButton.TabIndex = 16;
            this.InitializeButton.Text = "Initialize";
            this.InitializeButton.UseVisualStyleBackColor = false;
            this.InitializeButton.Click += new System.EventHandler(this.InitializeButton_Click);
            // 
            // TimeOutput
            // 
            this.TimeOutput.AutoSize = true;
            this.TimeOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.TimeOutput.Location = new System.Drawing.Point(299, 108);
            this.TimeOutput.Name = "TimeOutput";
            this.TimeOutput.Size = new System.Drawing.Size(142, 39);
            this.TimeOutput.TabIndex = 17;
            this.TimeOutput.Text = "Time [s]";
            // 
            // TimeLabel
            // 
            this.TimeLabel.AutoSize = true;
            this.TimeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.TimeLabel.Location = new System.Drawing.Point(299, 165);
            this.TimeLabel.Name = "TimeLabel";
            this.TimeLabel.Size = new System.Drawing.Size(55, 39);
            this.TimeLabel.TabIndex = 18;
            this.TimeLabel.Text = "[s]";
            // 
            // DispLabel
            // 
            this.DispLabel.AutoSize = true;
            this.DispLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.DispLabel.Location = new System.Drawing.Point(299, 288);
            this.DispLabel.Name = "DispLabel";
            this.DispLabel.Size = new System.Drawing.Size(86, 39);
            this.DispLabel.TabIndex = 19;
            this.DispLabel.Text = "[um]";
            // 
            // DispOutput
            // 
            this.DispOutput.AutoSize = true;
            this.DispOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.DispOutput.Location = new System.Drawing.Point(299, 231);
            this.DispOutput.Name = "DispOutput";
            this.DispOutput.Size = new System.Drawing.Size(307, 39);
            this.DispOutput.TabIndex = 20;
            this.DispOutput.Text = "Displacement [um]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.label1.Location = new System.Drawing.Point(898, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 39);
            this.label1.TabIndex = 21;
            this.label1.Text = "Temp1 [C]";
            // 
            // Temp1Label
            // 
            this.Temp1Label.AutoSize = true;
            this.Temp1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.Temp1Label.Location = new System.Drawing.Point(898, 165);
            this.Temp1Label.Name = "Temp1Label";
            this.Temp1Label.Size = new System.Drawing.Size(86, 39);
            this.Temp1Label.TabIndex = 22;
            this.Temp1Label.Text = "[um]";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.label7.Location = new System.Drawing.Point(898, 231);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(179, 39);
            this.label7.TabIndex = 23;
            this.label7.Text = "Temp2 [C]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.label8.Location = new System.Drawing.Point(898, 345);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(179, 39);
            this.label8.TabIndex = 24;
            this.label8.Text = "Temp3 [C]";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.label9.Location = new System.Drawing.Point(898, 459);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 39);
            this.label9.TabIndex = 25;
            this.label9.Text = "Temp4 [C]";
            // 
            // Temp2Label
            // 
            this.Temp2Label.AutoSize = true;
            this.Temp2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.Temp2Label.Location = new System.Drawing.Point(898, 288);
            this.Temp2Label.Name = "Temp2Label";
            this.Temp2Label.Size = new System.Drawing.Size(86, 39);
            this.Temp2Label.TabIndex = 26;
            this.Temp2Label.Text = "[um]";
            // 
            // Temp3Label
            // 
            this.Temp3Label.AutoSize = true;
            this.Temp3Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.Temp3Label.Location = new System.Drawing.Point(898, 402);
            this.Temp3Label.Name = "Temp3Label";
            this.Temp3Label.Size = new System.Drawing.Size(86, 39);
            this.Temp3Label.TabIndex = 27;
            this.Temp3Label.Text = "[um]";
            // 
            // Temp4Label
            // 
            this.Temp4Label.AutoSize = true;
            this.Temp4Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.64286F);
            this.Temp4Label.Location = new System.Drawing.Point(898, 516);
            this.Temp4Label.Name = "Temp4Label";
            this.Temp4Label.Size = new System.Drawing.Size(86, 39);
            this.Temp4Label.TabIndex = 28;
            this.Temp4Label.Text = "[um]";
            // 
            // ForceChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ForceChart.ChartAreas.Add(chartArea1);
            this.ForceChart.Location = new System.Drawing.Point(2, 588);
            this.ForceChart.Name = "ForceChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Force vs Displacement";
            this.ForceChart.Series.Add(series1);
            this.ForceChart.Size = new System.Drawing.Size(864, 366);
            this.ForceChart.TabIndex = 29;
            this.ForceChart.Text = "sldfhjoisjf";
            // 
            // StressChart
            // 
            chartArea2.Name = "ChartArea1";
            this.StressChart.ChartAreas.Add(chartArea2);
            this.StressChart.Location = new System.Drawing.Point(872, 588);
            this.StressChart.Name = "StressChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Stress vs Displacement";
            this.StressChart.Series.Add(series2);
            this.StressChart.Size = new System.Drawing.Size(860, 366);
            this.StressChart.TabIndex = 30;
            this.StressChart.Text = "sldfhjoisjf";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Desktop;
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(1738, -24);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(5, 1038);
            this.label10.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Desktop;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label11.Location = new System.Drawing.Point(-196, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(2000, 5);
            this.label11.TabIndex = 32;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Desktop;
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label12.Location = new System.Drawing.Point(-25, 957);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(2000, 5);
            this.label12.TabIndex = 33;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Desktop;
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label13.Location = new System.Drawing.Point(-51, 92);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(2000, 5);
            this.label13.TabIndex = 34;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Desktop;
            this.label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label14.Location = new System.Drawing.Point(-25, 580);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(2000, 5);
            this.label14.TabIndex = 35;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Desktop;
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(738, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(5, 493);
            this.label15.TabIndex = 36;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Desktop;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(1170, 92);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(5, 493);
            this.label16.TabIndex = 37;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Desktop;
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(252, 92);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(5, 493);
            this.label17.TabIndex = 38;
            // 
            // numericUpDown6
            // 
            this.numericUpDown6.DecimalPlaces = 2;
            this.numericUpDown6.Location = new System.Drawing.Point(50, 450);
            this.numericUpDown6.Name = "numericUpDown6";
            this.numericUpDown6.Size = new System.Drawing.Size(120, 22);
            this.numericUpDown6.TabIndex = 39;
            this.numericUpDown6.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.numericUpDown6.ValueChanged += new System.EventHandler(this.numericUpDown6_ValueChanged);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(31, 422);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 16);
            this.label18.TabIndex = 40;
            this.label18.Text = "Max Strain";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(141, 482);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 41;
            this.label19.Text = "Actuator";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 482);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(95, 16);
            this.label20.TabIndex = 42;
            this.label20.Text = "Thermocouple";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(17, 510);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 22);
            this.textBox1.TabIndex = 43;
            this.textBox1.Text = "COM9";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(146, 510);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 22);
            this.textBox2.TabIndex = 44;
            this.textBox2.Text = "COM10";
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1193, 142);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(528, 270);
            this.pictureBox1.TabIndex = 45;
            this.pictureBox1.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1924, 966);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.numericUpDown6);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.StressChart);
            this.Controls.Add(this.ForceChart);
            this.Controls.Add(this.Temp4Label);
            this.Controls.Add(this.Temp3Label);
            this.Controls.Add(this.Temp2Label);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Temp1Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DispOutput);
            this.Controls.Add(this.DispLabel);
            this.Controls.Add(this.TimeLabel);
            this.Controls.Add(this.TimeOutput);
            this.Controls.Add(this.InitializeButton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown5);
            this.Controls.Add(this.StressLabel);
            this.Controls.Add(this.StressOutput);
            this.Controls.Add(this.numericUpDown4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown3);
            this.Controls.Add(this.numericUpDown2);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.ForceLabel);
            this.Controls.Add(this.ResultsLab);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.StartButton);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ForceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StressChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label ResultsLab;
        private System.Windows.Forms.Label ForceLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown4;
        private System.Windows.Forms.Label StressOutput;
        private System.Windows.Forms.Label StressLabel;
        private System.Windows.Forms.NumericUpDown numericUpDown5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button InitializeButton;
        private System.Windows.Forms.Label TimeOutput;
        private System.Windows.Forms.Label TimeLabel;
        private System.Windows.Forms.Label DispLabel;
        private System.Windows.Forms.Label DispOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Temp1Label;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Temp2Label;
        private System.Windows.Forms.Label Temp3Label;
        private System.Windows.Forms.Label Temp4Label;
        private System.Windows.Forms.DataVisualization.Charting.Chart ForceChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart StressChart;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.NumericUpDown numericUpDown6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}