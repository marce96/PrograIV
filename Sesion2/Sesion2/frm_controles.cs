using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Sesion2
{
    public partial class frm_controles : Form
    {
        //formula total: Precio * (1 + Interes)
        //formula cuota: Total / plazo
        int contadorseg = 0;
        int contadormin = 0;
        public frm_controles()
        {
            InitializeComponent();

        }

        private void b_calcular_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_precio.Text))
            {
                MessageBox.Show("Por favor digite el precio","Validadción de Datos",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txt_precio.Focus();
                return;//Sirve para hacer una pausa en el programa
            }
            if (string.IsNullOrEmpty(txt_interes.Text))
            {
                    MessageBox.Show("Por favor digite el interes", "Validadción de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_precio.Focus();
                    return;//Sirve para hacer una pausa en el programa
            }
            if (rb_6meses.Checked == false && rb_12meses.Checked == false && rb_24meses.Checked==false)
            {
                MessageBox.Show("Por favor seleccione el plazo a pagar", "Validadción de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;//Sirve para hacer una pausa en el programa
            }
            decimal precio = Convert.ToDecimal(txt_precio.Text);
            decimal interes = Convert.ToDecimal(txt_interes.Text);
            decimal plazo = 0;
            //Calcula el plazo
            if (rb_6meses.Checked)
            {
                plazo = 6;
            }
            else if(rb_12meses.Checked)
            {
                plazo=12;
            }else{
                plazo=24;
            }
            //Calcula la Cuota
            decimal total = precio * (1 + interes);
            decimal couta = total / plazo;

            txt_cuota.Text = couta.ToString("c2");
            txt_total.Text = total.ToString("c2");

        }

        private void b_limpiar_Click(object sender, EventArgs e)
        {
            txt_precio.Clear();
            txt_interes.Clear();
            txt_total.Clear();
            txt_cuota.Clear();

            rb_6meses.Checked = false;
            rb_12meses.Checked = false;
            rb_24meses.Checked = false;

            txt_precio.Focus();
        }

        private void b_ver_seleccionados_Click(object sender, EventArgs e)
        {
            string seleccionados = string.Empty;

            if (chk_verde.CheckState == CheckState.Checked)
            {
                seleccionados = " Verde ";
            }
            if (chk_azul.CheckState == CheckState.Checked)
            {
                seleccionados += " Azul ";
            }
            if (chk_rojo.CheckState == CheckState.Checked)
            {
                seleccionados += " Rojo ";
            }
            txt_colores.Text = seleccionados;
        }

        private void b_cambiar_color_Click(object sender, EventArgs e)
        {
            if (rb_verde.Checked) 
            {
                lb_color.ForeColor=Color.Green;
            }
            else if (rb_azul.Checked)
            {
                lb_color.ForeColor = Color.Blue;
            }
            else if (rb_rojo.Checked)
            {
                lb_color.ForeColor = Color.Red;
            }
            else
            {
                lb_color.ForeColor = Color.Yellow;
            }
        }

        private void b_arrancar_Click(object sender, EventArgs e)
        {
            T_Cronometro.Start();
        }

        private void T_Cronometro_Tick(object sender, EventArgs e)
        {
            int contador = Convert.ToInt32(txt_milisegundos.Text);
            contador++;
            txt_milisegundos.Text = contador.ToString();
            if (contador == 59)
            {
                contadorseg++;
                txt_milisegundos.Text = "0";
            }

            txt_segundos.Text = contadorseg.ToString();
            if (contadorseg == 59)
            {

                contadormin++;
                txt_segundos.Text = "0";
                contadorseg = 0;
            }
        }

        private void b_ver_pb_Click(object sender, EventArgs e)
        {
            int valor = Convert.ToInt32(txt_valor_pb.Text);

            pb_ejemplo.Minimum = 0;
            pb_ejemplo.Maximum = valor;

            for (int i = 0; i <=valor; i++)
            {
                pb_ejemplo.Value = i;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            pb_ejemplo.Minimum = 0;

            int valor = pb_ejemplo.Maximum - 1;

            for (int i = valor-1; i >= 0; i--)
            {
                pb_ejemplo.Value = i;
            }
            pb_ejemplo.Maximum = 0;
        }

        private void rb_Cubica_CheckedChanged(object sender, EventArgs e)
        {
            txt_Result1.Text = Math.Sqrt(Convert.ToInt32(txt_Number1.Text)).ToString();
            txt_Result2.Text = Math.Sqrt(Convert.ToInt32(txt_Number2.Text)).ToString();
            txt_Result3.Text = Math.Sqrt(Convert.ToInt32(txt_Number3.Text)).ToString();
            txt_Result4.Text = Math.Sqrt(Convert.ToInt32(txt_Number4.Text)).ToString();
            txt_Result5.Text = Math.Sqrt(Convert.ToInt32(txt_Number5.Text)).ToString();
        }

        private void rb_Cuarta_CheckedChanged(object sender, EventArgs e)
        {
            double potencia = 1.0 / 3.0;
            txt_Result1.Text = Math.Pow(Convert.ToDouble(txt_Number1.Text),potencia).ToString();
            txt_Result2.Text = Math.Pow(Convert.ToDouble(txt_Number2.Text), potencia).ToString();
            txt_Result3.Text = Math.Pow(Convert.ToDouble(txt_Number3.Text), potencia).ToString();
            txt_Result4.Text = Math.Pow(Convert.ToDouble(txt_Number4.Text), potencia).ToString();
            txt_Result5.Text = Math.Pow(Convert.ToDouble(txt_Number5.Text), potencia).ToString();
        }

        private void rb__Cuadrada_CheckedChanged(object sender, EventArgs e)
        {
            double potencia = 1.0 / 4.0;
            txt_Result1.Text = Math.Pow(Convert.ToDouble(txt_Number1.Text), potencia).ToString();
            txt_Result2.Text = Math.Pow(Convert.ToDouble(txt_Number2.Text), potencia).ToString();
            txt_Result3.Text = Math.Pow(Convert.ToDouble(txt_Number3.Text), potencia).ToString();
            txt_Result4.Text = Math.Pow(Convert.ToDouble(txt_Number4.Text), potencia).ToString();
            txt_Result5.Text = Math.Pow(Convert.ToDouble(txt_Number5.Text), potencia).ToString();
        }

    }
}