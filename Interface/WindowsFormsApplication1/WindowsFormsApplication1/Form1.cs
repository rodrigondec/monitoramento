using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using MySql.Data.MySqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private MySqlConnection bdConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        string RxString;
        int tipo = 0;

        public Form1()
        {
            InitializeComponent();

            Graph.Legends.Clear();
            Graph1.Legends.Clear();
            Graph2.Legends.Clear();

            Graph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            Graph1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            Graph2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;

            Graph.ChartAreas[0].AxisY.Maximum = 100;
            Graph1.ChartAreas[0].AxisY.Maximum = 150;
            Graph2.ChartAreas[0].AxisY.Maximum = 100;

            Graph.ChartAreas[0].AxisX.Minimum = 1;
            Graph.ChartAreas[0].AxisX.Maximum = 9;

            Graph1.ChartAreas[0].AxisX.Minimum = 1;
            Graph1.ChartAreas[0].AxisX.Maximum = 9;

            Graph2.ChartAreas[0].AxisX.Minimum = 1;
            Graph2.ChartAreas[0].AxisX.Maximum = 9;

            Diminuir();
        }

        int valor1, valor2, valor3;

        private void Form1_Load(object sender, EventArgs e)
        {
            atualizaListaCOMs();
            CBbaudRate.SelectedIndex = 0;
            CBTipo.SelectedIndex = 0;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            atualizaListaCOMs();
        }

        private void atualizaListaCOMs()
        {
            int i;
            bool quantDiferente;    //flag para sinalizar que a quantidade de portas mudou

            i = 0;
            quantDiferente = false;

            //se a quantidade de portas mudou
            if (CBPorta.Items.Count == SerialPort.GetPortNames().Length)
            {
                foreach (string s in SerialPort.GetPortNames())
                {
                    if (CBPorta.Items[i++].Equals(s) == false)
                    {
                        quantDiferente = true;
                    }
                }
            }
            else
            {
                quantDiferente = true;
            }

            //Se não foi detectado diferença
            if (quantDiferente == false)
            {
                return;                     //retorna
            }

            //limpa comboBox
            CBPorta.Items.Clear();

            //adiciona todas as COM diponíveis na lista
            foreach (string s in SerialPort.GetPortNames())
            {
                CBPorta.Items.Add(s);
            }
            //seleciona a primeira posição da lista
            CBPorta.SelectedIndex = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == false)
            {
                try
                {
                    serialPort1.PortName = CBPorta.Items[CBPorta.SelectedIndex].ToString();
                    serialPort1.BaudRate = int.Parse(CBbaudRate.Items[CBbaudRate.SelectedIndex].ToString());
                    serialPort1.Open();
                }
                catch
                {
                    return;
                }

                if (serialPort1.IsOpen)
                {
                    botConectar.Text = "Desconectar";
                    CBPorta.Enabled = false;
                    CBbaudRate.Enabled = false;
                    botAtualizar.Enabled = false;
                    //CBTipo.Enabled = false;
                    Aumentar();
                }
            }
            else
            {

                try
                {
                    serialPort1.Close();
                    CBPorta.Enabled = true;
                    CBbaudRate.Enabled = true;
                    //CBTipo.Enabled = true;
                    botConectar.Text = "Conectar";
                    botAtualizar.Enabled = true;
                    LimpaTudo();
                    Diminuir();
                }
                catch
                {
                    return;
                }

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen == true)          //porta está aberta
                serialPort1.Write("Teste");      
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (serialPort1.IsOpen == true)  // se porta aberta
                serialPort1.Close();         //fecha a porta
        }

        private void LimpaTudo()
        {
            Graph.Series[0].Points.Clear();
            Graph1.Series[0].Points.Clear();
            Graph2.Series[0].Points.Clear();
            textBoxReceber.Text = "";
            progressBar1.Value = 0;
            progressBar2.Value = 0;
            progressBar3.Value = 0;
        }

        private void Aumentar()
        {
            if (this.Width != 775 && this.Height != 315)
            {
                this.Width = 775;
                this.Height = 315;
            }
        }

        private void Diminuir()
        {
            if (this.Width != 160 && this.Height != 215)
            {
                this.Width = 160;
                this.Height = 215;
            }
        }

        private void gravarBanco(int sensor1, int sensor2, int sensor3)
        {
            //Define string de conexão
            bdConn = new MySqlConnection("server=localhost;database=sensoriamento;uid=root;pwd=dg79531");

            //Abre conecção
            try
            {
                bdConn.Open();
            }
            catch
            {
                MessageBox.Show("Impossível estabelecer conexão");
            }
            //Verifica se a conexão está aberta
            if (bdConn.State == ConnectionState.Open)
            {
                //Se estiver aberta insere os dados na BD
                MySqlCommand commS = new MySqlCommand("INSERT INTO log (DataHora, Sensor1, Sensor2, Sensor3) VALUES('" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "','" + sensor1 + "','" + sensor2 + "','" + sensor3+ "')", bdConn);
                commS.ExecuteNonQuery();
            }  
        }

        private void AtualizarDia()
        {
            LimpaTudo();
            Graph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            Graph1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
            Graph2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;

            Graph.Series[0].IsValueShownAsLabel = false;
            Graph1.Series[0].IsValueShownAsLabel = false;
            Graph2.Series[0].IsValueShownAsLabel = false;

            Graph.ChartAreas[0].AxisX.Minimum = 1;
            Graph1.ChartAreas[0].AxisX.Minimum = 1;
            Graph2.ChartAreas[0].AxisX.Minimum = 1;

            //Define string de conexão
            bdConn = new MySqlConnection("server=localhost;database=sensoriamento;uid=root;pwd=dg79531");
            mDataSet = new DataSet();

            try
            {
                //abre a conexao
                bdConn.Open();
            }
            catch
            {
                MessageBox.Show("Impossível estabelecer conexão");
            }

            //verificva se a conexão esta aberta
            if (bdConn.State == ConnectionState.Open)
            {
                //cria um adapter usando a instrução SQL para acessar a tabela Clientes
                mAdapter = new MySqlDataAdapter("SELECT TIME(DataHora), Sensor1, Sensor2, Sensor3 FROM log where DataHora LIKE '%" + DateTime.Now.ToString("yyyy-MM-dd") + "%'", bdConn);
                //preenche o dataset via adapter
                mAdapter.Fill(mDataSet, "log");

                int linhas, BDvalor1, BDvalor2, BDvalor3;
                string hr;
                linhas = mDataSet.Tables[0].Rows.Count;

                for (int i = 0; i < linhas; i++)
                {
                    hr = mDataSet.Tables[0].Rows[i]["TIME(DataHora)"].ToString();
                    BDvalor1 = int.Parse(mDataSet.Tables[0].Rows[i]["Sensor1"].ToString());
                    BDvalor2 = int.Parse(mDataSet.Tables[0].Rows[i]["Sensor2"].ToString());
                    BDvalor3 = int.Parse(mDataSet.Tables[0].Rows[i]["Sensor3"].ToString());

                    Graph.Series[0].Points.AddXY(hr, BDvalor1);
                    Graph1.Series[0].Points.AddXY(hr, BDvalor2);
                    Graph2.Series[0].Points.AddXY(hr, BDvalor3);

                    Graph.ChartAreas[0].AxisX.Maximum = linhas;
                    Graph1.ChartAreas[0].AxisX.Maximum = linhas;
                    Graph2.ChartAreas[0].AxisX.Maximum = linhas;
                }

                Aumentar();
            }
        }

        private void AtualizarSemana()
        {
            LimpaTudo();

            Graph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            Graph1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            Graph2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            Graph.Series[0].IsValueShownAsLabel = true;
            Graph1.Series[0].IsValueShownAsLabel = true;
            Graph2.Series[0].IsValueShownAsLabel = true;

            Graph.ChartAreas[0].AxisX.Minimum = 0;
            Graph1.ChartAreas[0].AxisX.Minimum = 0;
            Graph2.ChartAreas[0].AxisX.Minimum = 0;

            Graph.ChartAreas[0].AxisX.Maximum = 8;
            Graph1.ChartAreas[0].AxisX.Maximum = 8;
            Graph2.ChartAreas[0].AxisX.Maximum = 8;

            //Define string de conexão
            bdConn = new MySqlConnection("server=localhost;database=sensoriamento;uid=root;pwd=dg79531");
            mDataSet = new DataSet();

            try
            {
                //abre a conexao
                bdConn.Open();
            }
            catch
            {
                MessageBox.Show("Impossível estabelecer conexão");
            }

            //verificva se a conexão esta aberta
            if (bdConn.State == ConnectionState.Open)
            {
                //cria um adapter usando a instrução SQL para acessar a tabela Clientes
                mAdapter = new MySqlDataAdapter("SELECT DATE(DataHora), AVG(Sensor1), AVG(Sensor2), AVG(Sensor3) FROM log group by DATE(DataHora)", bdConn);
                //preenche o dataset via adapter
                mAdapter.Fill(mDataSet, "log");

                int linhas;
                int BDvalor1, BDvalor2, BDvalor3;
                DateTime data;
                string Sdata;
                linhas = mDataSet.Tables[0].Rows.Count;

                for (int i = 0; i < linhas; i++)
                {
                    data = Convert.ToDateTime(mDataSet.Tables[0].Rows[i]["DATE(DataHora)"].ToString());
                    BDvalor1 = (int)Double.Parse(mDataSet.Tables[0].Rows[i]["AVG(Sensor1)"].ToString());
                    BDvalor2 = (int)Double.Parse(mDataSet.Tables[0].Rows[i]["AVG(Sensor2)"].ToString());
                    BDvalor3 = (int)Double.Parse(mDataSet.Tables[0].Rows[i]["AVG(Sensor3)"].ToString());

                    Sdata = data.ToString("dd-MM-yyyy");

                    Graph.Series[0].Points.AddXY(Sdata, BDvalor1);
                    Graph1.Series[0].Points.AddXY(Sdata, BDvalor2);
                    Graph2.Series[0].Points.AddXY(Sdata, BDvalor3);
                }
            }
        }

        private void AtualizarTempoReal()
        {
            textBoxReceber.Text = "";

            if (valor1 >= 0 && valor1 <= 100)
            {
                progressBar1.Value = valor1;
            }

            if (valor2 >= 0 && valor2 <= 100)
            {
                progressBar2.Value = valor2;
            }

            if (valor3 >= 0 && valor3 <= 100)
            {
                progressBar3.Value = valor3;
            }

            //if (CBTipo.SelectedIndex == 0)
            //{
                atualizaTextBox();
            //}

            if (Graph.Series[0].Points.Count >= 9)
            {
                Graph.Series[0].Points.RemoveAt(0);
                Graph.Update();
            }

            if (Graph1.Series[0].Points.Count >= 9)
            {
                Graph1.Series[0].Points.RemoveAt(0);
                Graph1.Update();
            }


            if (Graph2.Series[0].Points.Count >= 9)
            {
                Graph2.Series[0].Points.RemoveAt(0);
                Graph2.Update();
            }

            string hora = DateTime.Now.ToLongTimeString();

            Graph.Series[0].Points.AddXY(hora, valor1);
            Graph1.Series[0].Points.AddXY(hora, valor2);
            Graph2.Series[0].Points.AddXY(hora, valor3);
        }

        private void trataDadoRecebido(object sender, EventArgs e)
        {
            string pattern = "(:)";

            string[] substrings = System.Text.RegularExpressions.Regex.Split(RxString, pattern);    // Split on hyphens

            if (!(Int32.TryParse(substrings[0], out valor1)))
            {
                valor1 = progressBar1.Value;
            }

            if (!(Int32.TryParse(substrings[2], out valor2)))
            {
                valor2 = progressBar2.Value;
            }

            if (!(Int32.TryParse(substrings[4], out valor3)))
            {
                valor3 = progressBar3.Value;
            }

            gravarBanco(valor1, valor2, valor3);

            switch(tipo)
            {
                case 0:
                    AtualizarTempoReal();
                break;

                case 1:
                    AtualizarDia();
                break;

                case 2:
                    AtualizarSemana();
                break;
            }
        }

        private void serialPort1_DataReceived_1(object sender, SerialDataReceivedEventArgs e)
        {
            RxString = serialPort1.ReadLine();                      //le o dado disponível na serial
            this.Invoke(new EventHandler(trataDadoRecebido));       //chama outra thread para escrever o dado no text box
        }

        private void atualizaTextBox()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    textBoxReceber.Text = valor1.ToString() + "% de Luminosidade \n";
                    break;

                case 1:
                    textBoxReceber.Text = valor2.ToString() + "° Celsius";
                    break;

                case 2:
                    textBoxReceber.Text = valor3.ToString() + "db";
                    break;
            }
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (tipo == 0)
                atualizaTextBox();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (CBTipo.SelectedIndex)
            {
                case 0:
                    {
                        LimpaTudo();

                        if (serialPort1.IsOpen == false)
                        {
                            Diminuir();
                        }

                        Graph.ChartAreas[0].AxisX.Maximum = 9;
                        Graph1.ChartAreas[0].AxisX.Maximum = 9;
                        Graph2.ChartAreas[0].AxisX.Maximum = 9;

                        Graph.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
                        Graph1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;
                        Graph2.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Range;

                        Graph.Series[0].IsValueShownAsLabel = false;
                        Graph1.Series[0].IsValueShownAsLabel = false;
                        Graph2.Series[0].IsValueShownAsLabel = false;

                        Graph.ChartAreas[0].AxisX.Minimum = 1;
                        Graph1.ChartAreas[0].AxisX.Minimum = 1;
                        Graph2.ChartAreas[0].AxisX.Minimum = 1;
                        tipo = 0;
                        break;
                    }

                case 1:
                    {
                        LimpaTudo();
                        AtualizarDia();
                        Aumentar();
                        tipo = 1;
                        break;
                    }

                case 2:
                    {
                        LimpaTudo();
                        AtualizarSemana();
                        Aumentar();
                        tipo = 2;
                        break;
                    }
            }
        }
    }
}


