namespace WindowsFormsApplication1
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CBPorta = new System.Windows.Forms.ComboBox();
            this.botConectar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.botAtualizar = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.CBbaudRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxReceber = new System.Windows.Forms.TextBox();
            this.Graph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Graph2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.Graph1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.progressBar1 = new VerticalProgressBar();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.progressBar2 = new VerticalProgressBar();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.progressBar3 = new VerticalProgressBar();
            this.CBTipo = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // CBPorta
            // 
            this.CBPorta.FormattingEnabled = true;
            this.CBPorta.Location = new System.Drawing.Point(51, 6);
            this.CBPorta.Name = "CBPorta";
            this.CBPorta.Size = new System.Drawing.Size(59, 21);
            this.CBPorta.TabIndex = 1;
            // 
            // botConectar
            // 
            this.botConectar.Location = new System.Drawing.Point(11, 59);
            this.botConectar.Name = "botConectar";
            this.botConectar.Size = new System.Drawing.Size(123, 22);
            this.botConectar.TabIndex = 4;
            this.botConectar.Text = "Conectar";
            this.botConectar.UseVisualStyleBackColor = true;
            this.botConectar.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Porta:";
            // 
            // botAtualizar
            // 
            this.botAtualizar.Location = new System.Drawing.Point(116, 6);
            this.botAtualizar.Name = "botAtualizar";
            this.botAtualizar.Size = new System.Drawing.Size(18, 20);
            this.botAtualizar.TabIndex = 2;
            this.botAtualizar.Text = "R";
            this.botAtualizar.UseVisualStyleBackColor = true;
            this.botAtualizar.Click += new System.EventHandler(this.button5_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived_1);
            // 
            // CBbaudRate
            // 
            this.CBbaudRate.FormattingEnabled = true;
            this.CBbaudRate.Items.AddRange(new object[] {
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.CBbaudRate.Location = new System.Drawing.Point(51, 32);
            this.CBbaudRate.Name = "CBbaudRate";
            this.CBbaudRate.Size = new System.Drawing.Size(83, 21);
            this.CBbaudRate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Baud:";
            // 
            // textBoxReceber
            // 
            this.textBoxReceber.Location = new System.Drawing.Point(11, 144);
            this.textBoxReceber.Multiline = true;
            this.textBoxReceber.Name = "textBoxReceber";
            this.textBoxReceber.Size = new System.Drawing.Size(123, 24);
            this.textBoxReceber.TabIndex = 6;
            this.textBoxReceber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Graph
            // 
            chartArea1.Name = "ChartArea1";
            this.Graph.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.Graph.Legends.Add(legend1);
            this.Graph.Location = new System.Drawing.Point(31, 0);
            this.Graph.Name = "Graph";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.Graph.Series.Add(series1);
            this.Graph.Size = new System.Drawing.Size(564, 235);
            this.Graph.TabIndex = 12;
            this.Graph.Text = "chart1";
            // 
            // Graph2
            // 
            chartArea2.Name = "ChartArea1";
            this.Graph2.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.Graph2.Legends.Add(legend2);
            this.Graph2.Location = new System.Drawing.Point(31, 0);
            this.Graph2.Name = "Graph2";
            this.Graph2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Berry;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.Graph2.Series.Add(series2);
            this.Graph2.Size = new System.Drawing.Size(564, 235);
            this.Graph2.TabIndex = 13;
            this.Graph2.Text = "chart2";
            // 
            // Graph1
            // 
            chartArea3.Name = "ChartArea1";
            this.Graph1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.Graph1.Legends.Add(legend3);
            this.Graph1.Location = new System.Drawing.Point(31, 0);
            this.Graph1.Name = "Graph1";
            this.Graph1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SeaGreen;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            this.Graph1.Series.Add(series3);
            this.Graph1.Size = new System.Drawing.Size(564, 235);
            this.Graph1.TabIndex = 14;
            this.Graph1.Text = "chart3";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(144, 6);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(603, 261);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.Graph);
            this.tabPage1.Controls.Add(this.progressBar1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(595, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Luminosidade";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(5, 3);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(22, 232);
            this.progressBar1.TabIndex = 3;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.Graph1);
            this.tabPage2.Controls.Add(this.progressBar2);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(595, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Temperatura";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // progressBar2
            // 
            this.progressBar2.ForeColor = System.Drawing.Color.White;
            this.progressBar2.Location = new System.Drawing.Point(5, 3);
            this.progressBar2.Maximum = 150;
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(22, 232);
            this.progressBar2.TabIndex = 15;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.Graph2);
            this.tabPage3.Controls.Add(this.progressBar3);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(595, 235);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Ruído";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // progressBar3
            // 
            this.progressBar3.ForeColor = System.Drawing.Color.White;
            this.progressBar3.Location = new System.Drawing.Point(5, 3);
            this.progressBar3.Name = "progressBar3";
            this.progressBar3.Size = new System.Drawing.Size(22, 232);
            this.progressBar3.TabIndex = 16;
            // 
            // CBTipo
            // 
            this.CBTipo.FormattingEnabled = true;
            this.CBTipo.Items.AddRange(new object[] {
            "Tempo Real",
            "Dia",
            "Semana"});
            this.CBTipo.Location = new System.Drawing.Point(11, 87);
            this.CBTipo.Name = "CBTipo";
            this.CBTipo.Size = new System.Drawing.Size(123, 21);
            this.CBTipo.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(35, 114);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CBTipo);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBoxReceber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CBbaudRate);
            this.Controls.Add(this.botAtualizar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.botConectar);
            this.Controls.Add(this.CBPorta);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Sensoriamento v0.1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Graph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Graph1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CBPorta;
        private System.Windows.Forms.Button botConectar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button botAtualizar;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.ComboBox CBbaudRate;
        private System.Windows.Forms.Label label2;
        private VerticalProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxReceber;
        private System.Windows.Forms.DataVisualization.Charting.Chart Graph;
        private System.Windows.Forms.DataVisualization.Charting.Chart Graph2;
        private System.Windows.Forms.DataVisualization.Charting.Chart Graph1;
        private VerticalProgressBar progressBar2;
        private VerticalProgressBar progressBar3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ComboBox CBTipo;
        private System.Windows.Forms.Button button1;
    }
}

