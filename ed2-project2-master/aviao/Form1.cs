using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aviao
{
    public partial class Form1 : Form
    {
        //dia, fila, poltrona [31, 4, 25]
        private ComboBox dia;
        private Button confirmaDia;
        private Button[,] assentos;
        private Button reservar;
        private Assento[, ,] total;

        public void iniciarComponentes()
        {
            assentos = new Button[4, 25];
            total = new Assento[31, 4, 25];
            dia = new ComboBox();
            confirmaDia = new Button();
            reservar = new Button();
            //total = new object[dia, j, i];

            dia.Parent = this;
            dia.Top = 100;
            dia.Left = 25;
            for (int k = 0; k < 31; ++k)
            {
                dia.Items.Add((k + 1).ToString());
            }

            confirmaDia.Parent = this;
            confirmaDia.Top = 100;
            confirmaDia.Left = 150;
            confirmaDia.Text = "OK";
            confirmaDia.Click += new EventHandler(confirmouDia);

            reservar.Parent = this;
            reservar.Top = 100;
            reservar.Left = 400;
            reservar.Text = "RESERVAR";
            reservar.Click += new EventHandler(reservou);

            for (int d = 0; d < 31; ++d)
            {
                for (int j = 0; j < 4; ++j)
                {
                    for (int i = 0; i < 25; ++i)
                    {
                        total[d, j, i] = new Assento();
                    }
                }
            }

            assentos = new Button[4, 25];

            Top = 150;
            for (int j = 0; j < 4; ++j)
            {
                for (int i = 0; i < 25; ++i)
                {
                    //L - Livre, X - Marcado, R - Reservado
                    assentos[j,i] = new Button();
                    assentos[j,i].Parent = this;
                    assentos[j,i].Left = 25 * i;
                    assentos[j,i].Top = Top;
                    assentos[j,i].Text = "L";
                    assentos[j, i].Width = 25;
                    assentos[j, i].Height = 25;                    
                    assentos[j,i].Click += new EventHandler(marcouAssento);
                }
                Top += 25;
            }
            
        }

        public void marcouAssento(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            clickedButton.Text = "X";
            clickedButton.Enabled = false;
          
            //assentos[4,25].Visible = true;
        }
        public void confirmouDia(object sender, EventArgs e)
        {

            for(int i = 0 ; i < 25 ; i++)
            {
                for(int j = 0; j < 4; j++)
                {  
                    if(total[int.Parse(dia.Text), j, i].Ocupado == true)
                    {
                        assentos[j, i].Text = "R";
                        assentos[j, i].Enabled = false;
                        // total[int.Parse(dia.Text), j, i].Ocupado = true;
                    }
                    else
                    {
                        assentos[j, i].Text = "L";
                        assentos[j, i].Enabled = true;
                    }
                }
            }              
        }
        public void reservou(object sender, EventArgs e)
        {
            for (int i = 0; i < 25; i++)
                for (int j = 0; j < 4; j++)
                    if (assentos[j,i].Text=="X")
                    {
                        assentos[j, i].Text = "R";
                        assentos[j, i].Enabled = false;
                        total[int.Parse(dia.Text), j, i].Ocupado = true;
                    }
                    else if (assentos[j,i].Text!="R") 
                        assentos[j, i].Text = "L";
        }

        public Form1()
        {
            InitializeComponent();
            iniciarComponentes();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Olá :3 Você achou um easteregg :p","Mensagem");
        }
    }
}
