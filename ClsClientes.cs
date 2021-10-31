using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pantallas_proyecto
{
    class ClsClientes
    {

        private  String nombreCliente;
        private  String apellidoCliente;
        private  String rtn;


        //Metodos Get y Set para encapsular los datos :nombreCliente, apellidoCliente y rtn. En el FormClientes.
        public string NombreCliente { get => nombreCliente; set => nombreCliente = value; }
        public string ApellidoCliente { get => apellidoCliente; set => apellidoCliente = value; }
        public string Rtn { get => rtn; set => rtn = value; }
    }
}
