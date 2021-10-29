using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;

namespace Pantallas_proyecto
{

    public partial class validaciones
    {




        //valida espacios en blanco
        public bool Espacio_Blanco(ErrorProvider ubicacionError, TextBox txt)
        {
            bool espacioBlanco = true;

            foreach (char caracter in txt.Text)
            {
                if (!Char.IsWhiteSpace(caracter))
                {
                    espacioBlanco = false;
                    ubicacionError.SetError(txt, "");
                    break;
                }
                else
                {
                    espacioBlanco = true;
                }
            }
            return espacioBlanco;
        }
        //valida espacios en blanco en un combobox
        public bool Espacio_Blanco_CB(ErrorProvider ubicacionError, ComboBox txt)
        {
            bool espacioBlanco = true;

            foreach (char caracter in txt.Text)
            {
                if (!Char.IsWhiteSpace(caracter))
                {
                    espacioBlanco = false;
                    ubicacionError.SetError(txt, "");
                    break;
                }
                else
                {
                    espacioBlanco = true;
                }
            }
            return espacioBlanco;
        }
        //valida solo letras con espacios en blacons
        public bool Solo_Letras(ErrorProvider ubicacionError, TextBox txt)
        {
            bool soloLetras = true;
            foreach (char caracter in txt.Text)
            {
                if (Char.IsLetter(caracter))
                {
                    soloLetras = false;
                    ubicacionError.SetError(txt, "");
                }
                else if (char.IsWhiteSpace(caracter))
                {
                    soloLetras = false;
                    ubicacionError.SetError(txt, "");
                }
                else
                {
                    soloLetras = true;
                    break;
                }
            }
            return soloLetras;
        }
        //valida solo letras con espacios en blancos en un combo box
        public bool Solo_Letras_CB(ErrorProvider ubicacionError, ComboBox txt)
        {
            bool soloLetras = true;
            foreach (char caracter in txt.Text)
            {
                if (Char.IsLetter(caracter))
                {
                    soloLetras = false;
                    ubicacionError.SetError(txt, "");
                }
                else if (char.IsWhiteSpace(caracter))
                {
                    soloLetras = false;
                    ubicacionError.SetError(txt, "");
                }
                else
                {
                    soloLetras = true;
                    break;
                }
            }
            return soloLetras;
        }

        //valida solo numeros
        public bool Solo_Numeros(ErrorProvider ubicacionError, TextBox txt)
        {
            bool soloNumeros = true;
            foreach (char caracter in txt.Text)
            {
                if (Char.IsDigit(caracter))
                {
                    soloNumeros = false;
                    ubicacionError.SetError(txt, "");
                }
                else
                {
                    soloNumeros = true;
                    break;
                }
            }
            return soloNumeros;
        }

        //valida solo numeros en un combobox
        public bool Solo_Numeros_CB(ErrorProvider ubicacionError, ComboBox txt)
        {
            bool soloNumeros = true;
            foreach (char caracter in txt.Text)
            {
                if (Char.IsDigit(caracter))
                {
                    soloNumeros = false;
                    ubicacionError.SetError(txt, "");
                }
                else
                {
                    soloNumeros = true;
                    break;
                }
            }
            return soloNumeros;
        }

        //valida numero con signos de puntuacion
        public bool Solo_Numeros1(ErrorProvider ubicacionError, TextBox txt)
        {
            bool soloNumeros = true;
            foreach (char caracter in txt.Text)
            {
                if (Char.IsDigit(caracter))
                {
                    soloNumeros = false;
                    ubicacionError.SetError(txt, "");
                }
                else if (char.IsPunctuation(caracter))
                {
                    soloNumeros = false;
                    ubicacionError.SetError(txt, "");
                }
                else
                {
                    soloNumeros = true;
                    break;
                }
            }
            return soloNumeros;
        }
        //valida numero con signos de puntuacion en un combobox
        public bool Solo_Numeros1_CB(ErrorProvider ubicacionError, ComboBox txt)
        {
            bool soloNumeros = true;
            foreach (char caracter in txt.Text)
            {
                if (Char.IsDigit(caracter))
                {
                    soloNumeros = false;
                    ubicacionError.SetError(txt, "");
                }
                else if (char.IsPunctuation(caracter))
                {
                    soloNumeros = false;
                    ubicacionError.SetError(txt, "");
                }
                else
                {
                    soloNumeros = true;
                    break;
                }
            }
            return soloNumeros;
        }




    }
}
