using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class FormMain : Form
    {
        public double[] operacoes = new double[3];
        int i = 0;
        bool isDisplayCheio = false;
        
        public FormMain()
        {
            InitializeComponent();
        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void NumeroImprime(char num)
        {
            {
                if (isDisplayCheio)
                {
                    historico.Text = "";
                    displayCalc.Text = "";
                }
                isDisplayCheio = false;
                displayCalc.Text += num.ToString();
            }
        }

        private void OperacoesImprime(int numOp, char operacao)
        {
            if (displayCalc.Text.Length == 0) return;
            if(i == 2)
            {
                FazerOp();
                return;
            }
            operacoes[i] = Convert.ToDouble(displayCalc.Text);
            displayCalc.Text += operacao.ToString();
            historico.Text = displayCalc.Text;
            displayCalc.Text = "";
            i++;
            operacoes[i] = numOp;
            i++;

        }


        private void button9_Click(object sender, EventArgs e) => NumeroImprime('6');
        

        private void button16_Click(object sender, EventArgs e) => OperacoesImprime(4, '/');
        

        private void btn0_Click(object sender, EventArgs e) => NumeroImprime('0');
        

        private void btn1_Click(object sender, EventArgs e)=> NumeroImprime('1');
        

        private void btn2_Click(object sender, EventArgs e) => NumeroImprime('2');
        

        private void btn3_Click(object sender, EventArgs e) => NumeroImprime('3');


        private void btn4_Click(object sender, EventArgs e) => NumeroImprime('4');
        

        private void btn5_Click(object sender, EventArgs e) => NumeroImprime('5');

        private void btn9_Click(object sender, EventArgs e)=> NumeroImprime('9');

        private void btn7_Click(object sender, EventArgs e)=> NumeroImprime('7');

        private void btn8_Click(object sender, EventArgs e)=>NumeroImprime('8');

        private void btnMais_Click(object sender, EventArgs e)=> OperacoesImprime(1, '+');
        

        private void btnMenos_Click(object sender, EventArgs e)
        {
            if (displayCalc.Text.Length == 0)
            {
                displayCalc.Text += '-'.ToString();
                return;
            }
            if (displayCalc.Text.Length == 1 && displayCalc.Text[0]=='-')
            {
                return;
            }
            OperacoesImprime(2, '-');
        }

        private void btnMulti_Click(object sender, EventArgs e) =>OperacoesImprime(3, '*');

        private void btnBackspace_Click(object sender, EventArgs e)
        {
            FazerOp();
        }

        private void FazerOp()
        {
            if (isDisplayCheio)
            {
                historico.Text = "";
                displayCalc.Text = "";
                isDisplayCheio = false;
                operacoes = new double[3];
                i = 0;
                return;
            }
            char[] converteParaChar = displayCalc.Text.ToCharArray();

            displayCalc.Text = "";
            for (int i = 0; i < converteParaChar.Length - 1; i++)
            {
                displayCalc.Text += converteParaChar[i];
            }
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            try
            {
                operacoes[i] = Convert.ToDouble(displayCalc.Text);
            }
            catch
            {
                MessageBox.Show("Digite mais um numero!!!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (operacoes[1] == 1)
            {
                displayCalc.Text = (operacoes[0] + operacoes[2]).ToString();
                historico.Text = $"{operacoes[0]} + {operacoes[2]}=";
            }
            if (operacoes[1] == 2)
            {
                displayCalc.Text = (operacoes[0] - operacoes[2]).ToString();
                historico.Text = $"{operacoes[0]} - {operacoes[2]}=";
            }
            if (operacoes[1] == 3)
            {
                displayCalc.Text = (operacoes[0] * operacoes[2]).ToString();
                historico.Text = $"{operacoes[0]} * {operacoes[2]}=";
            }
            if (operacoes[1] == 4)
            {
                if (operacoes[2] == 0)
                {
                    displayCalc.Text = "Error";
                    historico.Text = $"{operacoes[0]} / {operacoes[2]}=";
                }
                else
                {
                displayCalc.Text = (operacoes[0] / operacoes[2]).ToString();
                historico.Text = $"{operacoes[0]} / {operacoes[2]}=";
                }
            }
            isDisplayCheio = true;
            operacoes = new double[3];
            i = 0;
            
        }

        private void btnVirgula_Click(object sender, EventArgs e) => displayCalc.Text += ','.ToString();


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnC_Click(object sender, EventArgs e)
        {
            historico.Text = "";
            displayCalc.Text = "";
            isDisplayCheio = false;
            operacoes = new double[3];
            i = 0;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }
    }
}
