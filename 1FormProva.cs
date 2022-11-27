using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExercicisRepasRecu_M03UF2
{
    public partial class _1FormProva : Form
    {
        public _1FormProva()
        {
            InitializeComponent();
            //txSortida.Enabled = false;
            txC.Visible = true;
            txF.Visible = true;

            txPC.Visible = false;
            txPF.Visible = false;
            lbPC.Visible = false;
            lbPF.Visible = false;
            btPintar.Visible = false;
            button2.Visible = false;
            btEx2.Visible = false;
            btEx22.Visible = false;
            btEx4.Visible = false;
            label3.Visible = false;
            gbIllaTresor.Visible = false;
            btIlla.Visible = true;
        }


        String[,] taula;
        private void btStart_Click(object sender, EventArgs e)
        {
            btIlla.Visible = false;
            String c = txC.Text;
            String f = txF.Text;
            int columna = 0;
            int fila = 0; ;
            try
            {
                columna = int.Parse(c);
                fila = int.Parse(f);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            taula = new string[fila, columna];

            for (int i = 0; i < taula.GetLength(0); i++)
            {
                for (int j = 0; j < taula.GetLength(1); j++)
                {
                    taula[i, j] = "[#]";
                }
            }
            Imprimir();
            btStart.Visible = false;
            txF.Visible = false;
            txC.Visible = false;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = true;

            txPC.Visible = true;
            txPF.Visible = true;
            lbPC.Visible = true;
            lbPF.Visible = true;
            btPintar.Visible = true;
            button2.Visible = true;
            btEx2.Visible = true;
            btEx22.Visible = true;
            btEx4.Visible = true;
        }
        private void Imprimir()
        {
            for (int i = 0; i < taula.GetLength(0); i++)
            {
                for (int j = 0; j < taula.GetLength(1); j++)
                {
                    txSortida.Text = txSortida.Text + taula[i, j];
                }
                txSortida.Text = txSortida.Text + Environment.NewLine;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            btStart.Visible = true;
            txC.Visible = true;
            txF.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            txC.Text = "";
            txF.Text = "";
            txSortida.Text = "";
            txPC.Text = "";
            txPF.Text = "";

            txPC.Visible = false;
            txPF.Visible = false;
            lbPC.Visible = false;
            lbPF.Visible = false;
            btPintar.Visible = false;
            button2.Visible = false;
            btEx2.Visible = false;
            btEx22.Visible = false;
            btEx4.Visible = false;
            gbIllaTresor.Visible = false;
            btIlla.Visible = true;
        }

        private void btPintar_Click(object sender, EventArgs e)
        {
            txSortida.Text = "";
            int pf = int.Parse(txPF.Text);
            int pc = int.Parse(txPC.Text);
            for (int i = 0; i < taula.GetLength(0); i++)
            {
                for (int j = 0; j < taula.GetLength(1); j++)
                {
                    taula[i, j] = "[#]";
                    taula[i, pc - 1] = "[⨷]";
                    taula[pf - 1, j] = "[⨷]";
                }
            }
            Imprimir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txSortida.Text = "";
            int i = 0;
            int w = 0;
            int v = taula.GetLength(0) - 1;
            for (int x = 0; x < taula.GetLength(0); x++)
            {
                for (int y = 0; y < taula.GetLength(1); y++)
                {
                    taula[x, y] = "[#]";
                    taula[i, i] = "[⨷]";
                    taula[0, y] = "[⨷]";
                    taula[x, 0] = "[⨷]";
                }
                i++;
            }
            for (int x = taula.GetLength(0) - 1; x >= 0; x--)
            {
                for (int y = 0; y < taula.GetLength(1); y++)
                {
                    taula[v, w] = "[⨷]";
                    taula[taula.GetLength(0) - 1, y] = "[⨷]";
                    taula[x, taula.GetLength(1) - 1] = "[⨷]";
                }
                w++;
                v--;
            }

            Imprimir();
        }

        //DRETA DIAGONAL ABAIX
        private void btEx2_Click(object sender, EventArgs e)
        {
            //      \
            txSortida.Text = "";
            int i = 0;
            for (int x = 0; x < taula.GetLength(0); x++)
            {
                for (int y = 0; y < taula.GetLength(1); y++)
                {
                    taula[x, y] = "[#]";
                    taula[i, i] = "[⨷]";
                }
                i++;
            }
            for (int x = 0; x < taula.GetLength(0); x++)
            {
                for (int y = 0; y < taula.GetLength(1); y++)
                {
                    if (taula[x, y] == "[#]")
                    {
                        taula[x, y] = "[⨷]";
                    }
                    else if (taula[x, y] == "[⨷]")
                    {
                        break;
                    }
                }
            }
            Imprimir();
        }

        //ESQUERRA DIAGONAL ABAIX
        private void btEx22_Click(object sender, EventArgs e)
        {
            // /
            txSortida.Text = "";
            int v = taula.GetLength(0) - 1;
            int w = 0;
            for (int x = taula.GetLength(0) - 1; x >= 0; x--)
            {
                for (int y = 0; y < taula.GetLength(1); y++)
                {
                    taula[x, y] = "[#]";
                    taula[v, w] = "[⨷]";
                    taula[v, w] = "[⨷]"; ;
                    //taula[taula.GetLength(0) - 1, w] = "[⨷]";
                    //taula[v, taula.GetLength(1)-1] = "[⨷]";
                }
                w++;
                v--;
            }
            for (int x = taula.GetLength(0) - 1; x >= 0; x--)
            {
                for (int y = taula.GetLength(1) - 1; y >= 0; y--)
                {
                    if (taula[x, y] == "[#]")
                    {
                        taula[x, y] = "[⨷]";
                    }
                    else if (taula[x, y] == "[⨷]")
                    {
                        break;
                    }
                }
            }
            Imprimir();
        }

        private void btEx4_Click(object sender, EventArgs e)
        {
            txSortida.Text = "";

        }

        private void btIlla_Click(object sender, EventArgs e)
        {
            gbIllaTresor.Visible = true;
            btIniciar.Enabled = true;
            txMida.Enabled = true;
            label4.Enabled = true;
            label7.Enabled = false;
            label8.Enabled = false;
            txFila.Enabled = false;
            txColumna.Enabled = false;
            btCavar.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            btStart.Visible = true;
            txC.Visible = true;
            txF.Visible = true;
            label1.Visible = true;
            label2.Visible = true;
            txC.Text = "";
            txF.Text = "";
            txSortida.Text = "";
            txPC.Text = "";
            txPF.Text = "";

            txPC.Visible = false;
            txPF.Visible = false;
            lbPC.Visible = false;
            lbPF.Visible = false;
            btPintar.Visible = false;
            button2.Visible = false;
            btEx2.Visible = false;
            btEx22.Visible = false;
            btEx4.Visible = false;
            gbIllaTresor.Visible = false;
            txMida.Text = "";
            txIlla.Text = "";
            txFila.Text = "";
            txColumna.Text = "";

            label7.Enabled = false;
            label8.Enabled = false;
            txFila.Enabled = false;
            txColumna.Enabled = false;
            btCavar.Enabled = false;
        }
        //██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
        //██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
        //██████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████████
        private void ImprimirIlla()
        {
            for (int x = 0; x < illa.GetLength(0); x++)
            {
                for (int y = 0; y < illa.GetLength(1); y++)
                {
                    txIlla.Text += illa[x, y];
                }
                txIlla.Text += Environment.NewLine;
            }
        }

        string[,] illa;
        Random r = new Random();
        int mida = 0;

        int cavarX;
        int cavarY;
        bool correcte = false;
        int tresorX = 0;
        int tresorY = 0;
        private void btIniciar_Click(object sender, EventArgs e)
        {
            txIlla.Text = "";
            txFila.Text = "";
            txColumna.Text = "";
            try
            {
                mida = int.Parse(txMida.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (txMida.Text == "")
            {
                MessageBox.Show("Introdueix una altra mida");
                return;
            }
            illa = new string[mida, mida];
            for (int x = 0; x < illa.GetLength(0); x++)
            {
                for (int y = 0; y < illa.GetLength(1); y++)
                {
                    illa[x, y] = "[⚽]";
                }
            }
            tresorX = r.Next(0, illa.GetLength(0));
            tresorY = r.Next(0, illa.GetLength(1));
            ImprimirIlla();
            btIniciar.Enabled = false;
            txMida.Enabled = false;
            label4.Enabled = false;
            label7.Enabled = true;
            label8.Enabled = true;
            txFila.Enabled = true;
            txColumna.Enabled = true;
            btCavar.Enabled = true;

        }

        private void btCavar_Click(object sender, EventArgs e)
        {
            try
            {
                cavarX = int.Parse(txFila.Text) - 1;
                cavarY = int.Parse(txColumna.Text) - 1;
            }
            catch (Exception ex)
            {
                correcte = false;
                MessageBox.Show(ex.Message);
            }
            if (txFila.Text != "" && txColumna.Text != "")
            {
                if (cavarX >= 0 && cavarY >= 0 && cavarX < illa.GetLength(0) && cavarY < illa.GetLength(1))
                {
                    correcte = true;
                }
            }

            if (correcte == true)
            {
                txIlla.Text = "";
                if (cavarX == tresorX && cavarY == tresorY)
                {
                    illa[cavarX, cavarY] = "[☆]";
                    ImprimirIlla();
                    MessageBox.Show("Has trobat el tresor !!");
                    btIniciar.Enabled = true;
                    txMida.Enabled = true;
                    label4.Enabled = true;

                    label7.Enabled = false;
                    label8.Enabled = false;
                    txFila.Enabled = false;
                    txColumna.Enabled = false;
                    btCavar.Enabled = false;
                }
                else
                {
                    illa[cavarX, cavarY] = "[☀]";
                    ImprimirIlla();
                }
                correcte = false;
            }

        }
    }
}
