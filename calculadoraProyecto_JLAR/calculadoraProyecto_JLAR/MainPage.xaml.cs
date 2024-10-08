using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculadoraProyecto_JLAR
{
    public partial class MainPage : ContentPage
    {
        double num1 = 0;
        double num2 = 0;
        string operacion = "";
        bool nuevoNum = true;


        public MainPage()
        {
            InitializeComponent();
        }

        private void numPresionado(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string  presionar= button.Text;

            if (pantalla.Text == "0" || nuevoNum)
            {
                pantalla.Text = presionar; 
                nuevoNum = false;
            }
            else
            {
                pantalla.Text = pantalla.Text + presionar;
            }
        }

        private void borrarTodo(object sender, EventArgs e)
        {
            num1 = 0;
            num2 = 0;
            operacion = "";
            pantalla.Text = "0";
            nuevoNum=true;
        }

        private void borrarDigito(object sender, EventArgs e)
        {
            if(pantalla.Text.Length > 1)
            {
                pantalla.Text = pantalla.Text.Substring(0,pantalla.Text.Length - 1);
            }
            else
            {
                pantalla.Text = "0";
            }
        }

        private void Operaciones(object sender, EventArgs e)
        {
            Button button = ( Button )sender;
            operacion = button.Text;

            num1 = Convert.ToDouble(pantalla.Text);
            nuevoNum = true;
        }

        private void Resultados(object sender, EventArgs e)
        {
            if (double.TryParse(pantalla.Text, out num2))
            {
                double resultado = 0;

                switch (operacion)
                {
                    case "+":
                        resultado = num1 + num2;
                        break;
                    case "-":
                        resultado = num2 - num1;
                        break;

                    case "X":
                        resultado = num1 * num2;
                        break;
                    case "÷":
                        if (num2 == 0)
                        {
                            pantalla.Text = "Error";
                            return;
                        }
                        resultado = num1 / num2;
                        break;
                    case "%":
                        resultado = num1 / 100;
                        break;
                }
                pantalla.Text = resultado.ToString();
                nuevoNum = true;
            }
        }

        private void Validacion(object sender, EventArgs e)
        {
            if(!pantalla.Text.Contains(","))
            {
                pantalla.Text = pantalla.Text + ",";
            }
        }
    }
}