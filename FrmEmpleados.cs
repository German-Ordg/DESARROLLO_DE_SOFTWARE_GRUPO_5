using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace Pantallas_proyecto
{
    public partial class FrmEmpleados : Form
    {

        private bool letra1 = false;
        private bool letra2 = false;
        private bool letra4 = false;
        private bool letra9 = false;
        private bool letra10 = false;
        private bool numero1 = false;
        private bool numero2 = false;
        private bool numero3 = false;
        public int empleadoEdad;
        private string identidad;
        private string numero;



        public FrmEmpleados()
        {
            InitializeComponent();
        }

       //metodo para que no sea permito cerrar la pantalla
        private const int noClose = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | noClose;
                return myCp;
            }
        }

        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd;
        validaciones validacion = new validaciones();

        private void label9_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
        //boton de regresar a la pantalla del menu de los crud
        private void button4_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD cRUD = new FrmMenuCRUD();
            cRUD.Show();
            this.Close();
        }
        //se cargan los datos de los limites de las fechas que se pueden ingresar;se cargan los datos de los empleados
        private void FrmEmpleados_Load(object sender, EventArgs e)
        {
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            dtpFechaNacimiento.MaxDate = DateTime.Now.AddYears(-18);
            dtpFechaIngreso.MaxDate = DateTime.Now.AddMonths(3);
            dtpFechaNacimiento.MinDate = DateTime.Now.AddYears(-90);
            DateTime fecha1 = dtpFechaNacimiento.Value;
            dtpFechaIngreso.MinDate = fecha1.Date.AddYears(18);
            conect.abrir();
            conect.cargarDatosEmpleados(dgvEmpleados);
            conect.CargaDePuestos(cmbPuesto);
            conect.cerrar();
        }

        
        //boton para agregar los datos de los empleados
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            

            letra1 = false; letra2 = false; letra4 = false; numero1 = false; numero2 = false;
            if (validacion.Espacio_Blanco_CB(ErrorProvider1, cmbGenero) )
            {
                if (validacion.Espacio_Blanco_CB(ErrorProvider1, cmbGenero))
                    ErrorProvider1.SetError(cmbGenero, "no se puede dejar en blanco");
            }
            else
            {
                letra4 = true;
            }
            if (validacion.Espacio_Blanco(ErrorProvider1, txtNombre) || validacion.Solo_Letras(ErrorProvider1, txtNombre) || txtNombre.TextLength < 3)
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtNombre))
                    ErrorProvider1.SetError(txtNombre, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider1, txtNombre))
                    ErrorProvider1.SetError(txtNombre, "Solo se permite letras");
                else
                if (txtNombre.TextLength < 3)
                {
                    ErrorProvider1.SetError(txtNombre, "el nombre debe ser mayor a 2 caracteres");
                }
            }
            else
            {
                letra1 = true;
            }

            if (validacion.Espacio_Blanco(ErrorProvider1, txtApellido) || validacion.Solo_Letras(ErrorProvider1, txtApellido) || txtApellido.TextLength < 3)
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtApellido))
                    ErrorProvider1.SetError(txtApellido, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider1, txtApellido))
                    ErrorProvider1.SetError(txtApellido, "Solo se permite letras");
                else
                if (txtApellido.TextLength < 3)
                {
                    ErrorProvider1.SetError(txtApellido, "el apellido debe ser mayor a 2 caracteres");
                }
            }
            else
            {
                letra2 = true;
            }

            if (validacion.Espacio_Blanco(ErrorProvider1, txtIdentidad) || validacion.Solo_Numeros(ErrorProvider1, txtIdentidad) || !Regex.IsMatch(txtIdentidad.Text, "^((010[1-8]|020[1-9]|0210|030[1-9]|031[0-9]|032[0-1]|040[1-9]|041[0-9]|042[0-3]|050[1-9]|051[0-2]|060[1-9]|061[0-6]|070[1-9]|071[0-9]|080[1-9]|081[0-9]|082[0-8]|090[1-6]|100[1-9]|101[0-7]|110[1-4]|120[1-9]|121[0-9]|130[1-9]|131[0-9]|132[0-8]|140[1-9]|141[0-6]|150[1-9]|151[0-9]|152[0-3]|160[1-9]|161[0-9]|162[0-8]|170[1-9]|180[1-9]|181[0-1]))+((19[0-9]{2}|20[0-9]{2})+(([0-9]){5}))$"))
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtIdentidad))
                    ErrorProvider1.SetError(txtIdentidad, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Numeros(ErrorProvider1, txtIdentidad))
                    ErrorProvider1.SetError(txtIdentidad, "Solo se permite numeros");
                else
                 if (!Regex.IsMatch(txtIdentidad.Text, "^((010[1-8]|020[1-9]|0210|030[1-9]|031[0-9]|032[0-1]|040[1-9]|041[0-9]|042[0-3]|050[1-9]|051[0-2]|060[1-9]|061[0-6]|070[1-9]|071[0-9]|080[1-9]|081[0-9]|082[0-8]|090[1-6]|100[1-9]|101[0-7]|110[1-4]|120[1-9]|121[0-9]|130[1-9]|131[0-9]|132[0-8]|140[1-9]|141[0-6]|150[1-9]|151[0-9]|152[0-3]|160[1-9]|161[0-9]|162[0-8]|170[1-9]|180[1-9]|181[0-1]))+((19[0-9]{2}|20[0-9]{2})+(([0-9]){5}))$"))
                {
                    ErrorProvider1.SetError(txtIdentidad, " Escriba un Formato de Identidad Valido");
                }
            }
            else
            {
                if (txtIdentidad.Text.Length != 13)
                {
                    MessageBox.Show("Ingrese 13 digitos en su identidad", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                }
                else
                {
                    numero1 = true;
                }
            }

                if (validacion.Espacio_Blanco(ErrorProvider1, txtNumeroTel) || validacion.Solo_Numeros(ErrorProvider1, txtNumeroTel) || !Regex.IsMatch(txtNumeroTel.Text, "^(3|2|8|9){1}[0-9]{7}$"))
                {
                    if (validacion.Espacio_Blanco(ErrorProvider1, txtNumeroTel))
                        ErrorProvider1.SetError(txtNumeroTel, "No se puede dejar en blanco");
                    else
                    if (validacion.Solo_Numeros(ErrorProvider1, txtNumeroTel))
                        ErrorProvider1.SetError(txtNumeroTel, "Solo se permite numeros");
                    else
                    if (!Regex.IsMatch(txtNumeroTel.Text, "^(3|2|8|9){1}[0-9]{7}$"))
                {
                    ErrorProvider1.SetError(txtNumeroTel, "Formato de Numero de Telefono no valido. Debe Comenzar con uno de los numeros: 3, 2, 8, 9.");
                }
            }
                else
                {

                    if (txtNumeroTel.Text.Length != 8)
                    {
                        MessageBox.Show("Ingrese 8 digitos en el telefono del empleado", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtNumeroTel.Focus();

                    }
                    else
                    {
                        numero2 = true;
                    }
                }

                if (validacion.Espacio_Blanco_CB(ErrorProvider1, cmbPuesto) )
                {
                    ErrorProvider1.SetError(cmbPuesto, "no se puede dejar en blanco");
                }
                else
                {
                    numero3 = true;
                }




                if (numero1 && letra1 && letra2 && numero2 && numero3 && letra4)
                {

                    conect.abrir();
                    bool igual = false;

                    SqlCommand comando = new SqlCommand("select * from Empleados where numero_identidad_empleado = '" + txtIdentidad.Text + "'", conect.conexion);
                    SqlDataReader registro = comando.ExecuteReader();
                    if (registro.Read())
                    {
                        igual = true;
                    }
                    conect.cerrar();
                    bool igual2 = false;
                    conect.abrir();
                    SqlCommand comando2 = new SqlCommand("select * from Empleados where num_telefono  = '" + txtNumeroTel.Text + "'", conect.conexion);
                    SqlDataReader registro2 = comando2.ExecuteReader();
                    if (registro2.Read())
                    {
                        igual2 = true;
                    }
                    conect.cerrar();
                        conect.abrir();
                        string codigoPuesto = "";
                        SqlCommand comando1 = new SqlCommand("Select codigo_puesto from Empleados_Puestos where descripcion_puesto='" + cmbPuesto.Text + "'", conect.conexion);
                        SqlDataReader registro1 = comando1.ExecuteReader();
                        while (registro1.Read())
                        {
                            codigoPuesto = registro1["codigo_puesto"].ToString();
                        }
                        conect.cerrar();

                        if (igual == false && igual2 == false)
                        {

                        

                            try
                            {
                                conect.abrir();
                                string genero="m";
                                if (cmbGenero.Text == "Masculino")
                                    genero = "M";
                                else
                                    genero = "F";
                                    
                                cmd = new SqlCommand("Insert into Empleados(codigo_puesto, nombre_empleado, apellido_empleado, numero_identidad_empleado, fecha_nacimiento, fecha_ingreso, num_telefono, genero) Values(" + codigoPuesto + ",'" + txtNombre.Text + "', '" + txtApellido.Text + "', '" + txtIdentidad.Text + "', '" + dtpFechaNacimiento.Text + "','" + dtpFechaIngreso.Text + "','" + txtNumeroTel.Text + "','" + genero + "')", conect.conexion);
                                cmd.ExecuteNonQuery();
                                MessageBox.Show("Se han ingresado los Datos con Exito ", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                conect.cargarDatosEmpleados(dgvEmpleados);
                                txtNombre.Clear();
                                txtApellido.Clear();
                                txtIdentidad.Clear();
                            
                                txtNumeroTel.Clear();
                                dtpFechaNacimiento.Value = DateTime.Now.AddYears(-19);
                                dtpFechaIngreso.Text = DateTime.Now.ToShortDateString();
                                cmbGenero.SelectedIndex = -1;
                                txtNombre.Focus();
                                conect.cerrar();
                                errorProvider2.Clear();
                                ErrorProvider1.Clear();
                                errorProvider3.Clear();
                        }
                            catch (Exception )
                            {
                                MessageBox.Show("ERROR AL INSERTAR LOS DATOS", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);

                                txtNombre.Focus();
                            }
                        



                        }
                        else
                            MessageBox.Show("Esta ingresando una Identidad o numero de telefono que ya fue registrada", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }

        }
        //texbox para buscar los empleados
        private void txtBuscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            var aux = new MetodoBuscarEmpleado();
            aux.filtrar(dgvEmpleados, this.txtBuscarEmpleado.Text.Trim());
        }
        //boton para modificar los datos de los empleados
        private void btnModificar_Click(object sender, EventArgs e)
        {
            conect.abrir();
            int indice;
            int codigo;
            indice = dgvEmpleados.CurrentRow.Index;

            letra1 = false; letra2 = false; letra4 = false; numero1 = false; numero2 = false; numero3 = false; letra9 = false; letra10 = false;

            if (validacion.Espacio_Blanco_CB(ErrorProvider1, cmbGenero))
            {
                if (validacion.Espacio_Blanco_CB(ErrorProvider1, cmbGenero))
                    ErrorProvider1.SetError(cmbGenero, "no se puede dejar en blanco");
            }
            else
            {
                letra4 = true;
            }
            if (validacion.Espacio_Blanco_CB(ErrorProvider1, cmbPuesto))
            {
                ErrorProvider1.SetError(cmbPuesto, "no se puede dejar en blanco");
            }
            else
            {
                numero3 = true;
            }

            if (validacion.Espacio_Blanco(ErrorProvider1, txtNombre) || validacion.Solo_Letras(ErrorProvider1, txtNombre) || txtNombre.TextLength < 3)
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtNombre))
                    ErrorProvider1.SetError(txtNombre, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider1, txtNombre))
                    ErrorProvider1.SetError(txtNombre, "Solo se permite letras");
                else
                if (txtNombre.TextLength < 3)
                {
                    ErrorProvider1.SetError(txtApellido, "el nombre debe ser mayor a 2 caracteres");
                }
            }
            else
            {
                letra1 = true;
            }

            if (validacion.Espacio_Blanco(ErrorProvider1, txtApellido) || validacion.Solo_Letras(ErrorProvider1, txtApellido) || txtApellido.TextLength < 3)
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtApellido))
                    ErrorProvider1.SetError(txtApellido, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider1, txtApellido))
                    ErrorProvider1.SetError(txtApellido, "Solo se permite letras");
                else
                if (txtApellido.TextLength < 3)
                {
                    ErrorProvider1.SetError(txtApellido, "el apellido debe ser mayor a 2 caracteres");
                }
            }
            else
            {
                letra2 = true;
            }

            if (validacion.Espacio_Blanco(ErrorProvider1, txtIdentidad) || validacion.Solo_Numeros(ErrorProvider1, txtIdentidad) || !Regex.IsMatch(txtIdentidad.Text, "^((010[1-8]|020[1-9]|0210|030[1-9]|031[0-9]|032[0-1]|040[1-9]|041[0-9]|042[0-3]|050[1-9]|051[0-2]|060[1-9]|061[0-6]|070[1-9]|071[0-9]|080[1-9]|081[0-9]|082[0-8]|090[1-6]|100[1-9]|101[0-7]|110[1-4]|120[1-9]|121[0-9]|130[1-9]|131[0-9]|132[0-8]|140[1-9]|141[0-6]|150[1-9]|151[0-9]|152[0-3]|160[1-9]|161[0-9]|162[0-8]|170[1-9]|180[1-9]|181[0-1]))+((19[0-9]{2}|20[0-9]{2})+(([0-9]){5}))$"))
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtIdentidad))
                    ErrorProvider1.SetError(txtIdentidad, "no se puede dejar en blanco");
                else
                if (validacion.Solo_Numeros(ErrorProvider1, txtIdentidad))
                    ErrorProvider1.SetError(txtIdentidad, "Solo se permite numeros");
                else
                if (!Regex.IsMatch(txtIdentidad.Text, "^((010[1-8]|020[1-9]|0210|030[1-9]|031[0-9]|032[0-1]|040[1-9]|041[0-9]|042[0-3]|050[1-9]|051[0-2]|060[1-9]|061[0-6]|070[1-9]|071[0-9]|080[1-9]|081[0-9]|082[0-8]|090[1-6]|100[1-9]|101[0-7]|110[1-4]|120[1-9]|121[0-9]|130[1-9]|131[0-9]|132[0-8]|140[1-9]|141[0-6]|150[1-9]|151[0-9]|152[0-3]|160[1-9]|161[0-9]|162[0-8]|170[1-9]|180[1-9]|181[0-1]))+((19[0-9]{2}|20[0-9]{2})+(([0-9]){5}))$"))
                {
                    ErrorProvider1.SetError(txtIdentidad, " Escriba un Formato de Identidad Valido");
                }
            }
            else
            {
                if (txtIdentidad.Text.Length != 13)
                {
                    MessageBox.Show("Ingrese 13 digitos en su identidad", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNombre.Focus();
                }
                else
                {
                    numero1 = true;
                }


                if (validacion.Espacio_Blanco(ErrorProvider1, txtNumeroTel) || validacion.Solo_Numeros(ErrorProvider1, txtNumeroTel) || !Regex.IsMatch(txtNumeroTel.Text, "^(3|2|8|9){1}[0-9]{7}$"))
                {
                    if (validacion.Espacio_Blanco(ErrorProvider1, txtNumeroTel))
                        ErrorProvider1.SetError(txtNumeroTel, "No se puede dejar en blanco");
                    else
                    if (validacion.Solo_Numeros(ErrorProvider1, txtNumeroTel))
                        ErrorProvider1.SetError(txtNumeroTel, "Solo se permite numeros");

                else
                if(!Regex.IsMatch(txtNumeroTel.Text, "^(3|2|8|9){1}[0-9]{7}$") )
                    {
                        ErrorProvider1.SetError(txtNumeroTel, "Formato de Numero de Telefono no valido. Debe Comenzar con uno de los numeros: 3, 2, 8, 9.");
                    }
                }else

                if (txtNumeroTel.Text.Length != 8)
                {
                    MessageBox.Show("Ingrese 8 digitos en el telefono del empleado", "Falta de datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtNumeroTel.Focus();

                }
                else
                {
                    numero2 = true;
                }

                conect.cerrar();
                conect.abrir();
                SqlCommand comando2 = new SqlCommand("select count(*) from Empleados where  numero_identidad_empleado= '" + txtIdentidad.Text + "'", conect.conexion);
                int consulta2 = Convert.ToInt32(comando2.ExecuteScalar());
                if (consulta2 == 1)
                {
                    if (identidad == txtIdentidad.Text)
                    {
                        letra9 = true;
                    }
                    else
                    {
                        letra9 = false;
                        errorProvider2.SetError(txtIdentidad, "identidad ya Registrado");
                    }
                }
                else
                {

                    letra9 = true;

                }


                conect.cerrar();

                conect.abrir();
                SqlCommand comando3 = new SqlCommand("select count(*) from Empleados where  num_telefono= '" + txtNumeroTel.Text + "'", conect.conexion);
                int consulta3 = Convert.ToInt32(comando3.ExecuteScalar());
                if (consulta3 == 1)
                {
                    if ( numero == txtNumeroTel.Text)
                    {
                        letra10 = true;
                    }
                    else
                    {
                        letra10 = false;
                        errorProvider2.SetError(txtNumeroTel, "Numero ya Registrado");
                    }
                }
                else
                {

                    letra10 = true;

                }


                conect.cerrar();





                conect.abrir();



                if (numero1 && letra1 && letra2 && letra9 && letra10 && numero2 && numero3 && letra4)
                {

                    try
                    {
                        

                        codigo = Convert.ToInt32(dgvEmpleados[0, indice].Value);
                        conect.abrir();
                        string codigoPuesto = "";
                        SqlCommand comando1 = new SqlCommand("Select codigo_puesto from Empleados_Puestos where descripcion_puesto='" + cmbPuesto.Text + "'", conect.conexion);
                        SqlDataReader registro1 = comando1.ExecuteReader();
                        while (registro1.Read())
                        {
                            codigoPuesto = registro1["codigo_puesto"].ToString();
                        }
                        conect.cerrar();
                        conect.abrir();
                        cmd = new SqlCommand("update Empleados set codigo_puesto = " + codigoPuesto+ ", nombre_empleado ='" + txtNombre.Text + "', apellido_empleado = '" + txtApellido.Text + "', numero_identidad_empleado= '" + txtIdentidad.Text + "', fecha_nacimiento = '" + dtpFechaNacimiento.Text + "', fecha_ingreso= '" + dtpFechaIngreso.Text + "', num_telefono = '" + txtNumeroTel.Text + "',Genero='" + cmbGenero.Text + "'  where codigo_empelado = " + codigo, conect.conexion);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("El registro fue actualizado exitosamente");
                        conect.cargarDatosEmpleados(dgvEmpleados);
                        conect.cerrar();
                        txtNombre.Clear();
                        txtApellido.Clear();
                        txtIdentidad.Clear();
                        
                        txtNumeroTel.Clear();
                        dtpFechaNacimiento.Value = DateTime.Now.AddYears(-19);
                        dtpFechaIngreso.Text = DateTime.Now.ToShortDateString();
                        cmbGenero.SelectedIndex = -1;
                        cmbPuesto.SelectedIndex = -1;
                        txtNombre.Focus();
                        btnAgregar.Enabled = true;
                        btnModificar.Enabled = false;
                        errorProvider2.Clear();
                        ErrorProvider1.Clear();
                        errorProvider3.Clear();
                        identidad = null;
                        numero = null;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("El registro no pudo ser actualizado" + ex);
                    }
                }

            }
            conect.cerrar();
        }
        //metodo para seleccionar los datos del empleado que se desea del data grid view
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int poc;

            poc = dgvEmpleados.CurrentRow.Index;

            string puesto = dgvEmpleados[1, poc].Value.ToString();
            conect.abrir();
            string codigoPuesto = "";
            SqlCommand comando1 = new SqlCommand("Select descripcion_puesto from Empleados_Puestos where codigo_puesto='" + puesto + "'", conect.conexion);
            SqlDataReader registro1 = comando1.ExecuteReader();
            while (registro1.Read())
            {
                codigoPuesto = registro1["descripcion_puesto"].ToString();
            }
            conect.cerrar();

            cmbPuesto.Text = codigoPuesto;
            txtNombre.Text = dgvEmpleados[2, poc].Value.ToString();
            txtApellido.Text = dgvEmpleados[3, poc].Value.ToString();
            txtIdentidad.Text = dgvEmpleados[4, poc].Value.ToString();
            identidad= dgvEmpleados[4, poc].Value.ToString();
            dtpFechaNacimiento.Text = dgvEmpleados[5, poc].Value.ToString();
            dtpFechaIngreso.Text = dgvEmpleados[6, poc].Value.ToString();
            txtNumeroTel.Text = dgvEmpleados[7, poc].Value.ToString();
            numero = dgvEmpleados[7, poc].Value.ToString();
            cmbGenero.Text = dgvEmpleados[8, poc].Value.ToString();
            btnAgregar.Enabled = false;
            btnModificar.Enabled = true ;
            errorProvider2.Clear();
            ErrorProvider1.Clear();
            errorProvider3.Clear();

        }
        //se carga la fecha y hora actual
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            
        }
        //hace que no se pueda contratar empleados menos de 18 años
        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {
            DateTime fecha1 = dtpFechaNacimiento.Value;
            dtpFechaIngreso.MinDate = fecha1.Date.AddYears(18);
        }

        private void txtNumeroTel_TextChanged(object sender, EventArgs e)
        {

        }
        //se le bloquea que los espacios en blanco del numero de telefono
        private void txtNumeroTel_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider2.Clear();
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                errorProvider2.SetError(txtNumeroTel, "No se permiten espacios en blanco");
                e.Handled = true;
            }
        }
        //se le bloquea que los espacios en blanco del numero de identidad
        private void txtIdentidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            errorProvider3.Clear();
            if (Char.IsWhiteSpace(e.KeyChar))
            {
                errorProvider3.SetError(txtIdentidad, "No se permiten espacios en blanco");
                e.Handled = true;
            }
        }
        //se limpia los datos en pantalla
        private void button1_Click_1(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtIdentidad.Clear();
            txtApellido.Clear();
            txtNumeroTel.Clear();
            cmbGenero.SelectedIndex = -1;
            cmbPuesto.SelectedIndex = -1;
            btnAgregar.Enabled = true;
            btnModificar.Enabled = false;
            errorProvider2.Clear();
            ErrorProvider1.Clear();
            errorProvider3.Clear();
            identidad = null;
            numero = null;


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dgvEmpleados_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

