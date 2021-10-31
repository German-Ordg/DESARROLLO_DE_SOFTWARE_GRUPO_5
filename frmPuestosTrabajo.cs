using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Pantallas_proyecto
{
    public partial class frmPuestosTrabajo : Form
    {

        public frmPuestosTrabajo()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }
        //Funcion que evita que se pueda cerrar la pantalla.
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        //Creacion de variables de la funcion conexion y validacion.
        ClsConexionBD connect = new ClsConexionBD();
        validaciones validacion = new validaciones();
        int recordId;
        private bool letra = false;
        private bool letra2 = false;


        //Funcion para mostrar la tabla codigo_puesto en el Datagriewview "DgvPuesto".
        public void MostrarDatos()
        {
            try
            {
                string consulta = "SELECT codigo_puesto as Código, descripcion_puesto as Puesto FROM Empleados_Puestos";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connect.conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                DgvPuesto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvPuesto.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Funcion para limpiar del codigo de los 3 textbox en la pantalla.
        public void Limpiar()
        {
            txtCodigo.Clear();
            txtPosicion.Clear();
            txtPosicion.Select();
        }

        //Llamado a la funcion "MostrarDatos()".
        private void frmPuestosTrabajo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        //Funcion para llenar los texbox: Codigo y Posicion. Dando doble click en la fila del DataGridView.
        private void DgvPuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            recordId = Convert.ToInt32(DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCodigo.Text = (DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtPosicion.Text = (DgvPuesto.Rows[e.RowIndex].Cells[1].Value.ToString());
        }


        //Boton para regresar al formulario anterior.
        private void button5_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD cRUD = new FrmMenuCRUD();
            cRUD.Show();
            this.Close();
        }

        //Boton para insertar.
        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            ErrorProvider1.Clear();
            letra2 = false;
            letra = false;

            if (validacion.Espacio_Blanco(ErrorProvider, txtPosicion) || validacion.Solo_Letras(ErrorProvider, txtPosicion))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtPosicion))
                    ErrorProvider.SetError(txtPosicion, "No se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider, txtPosicion))
                    ErrorProvider.SetError(txtPosicion, "No se permiten números");
                Limpiar();

            }
            else
            {
                letra2 = true;
            }

            if (letra2)
            {
                bool igual = false;
                connect.abrir();
                SqlCommand comando1 = new SqlCommand("select * from Empleados_Puestos where descripcion_puesto = '" + txtPosicion.Text + "'", connect.conexion);
                SqlDataReader registro = comando1.ExecuteReader();
                if (registro.Read())
                {
                    igual = true;
                }
                connect.cerrar();


                if (igual == false)
                {
                    try
                    {
                        string query = "INSERT INTO Empleados_Puestos (descripcion_puesto) VALUES (@puesto)";
                        connect.abrir();
                        SqlCommand comando = new SqlCommand(query, connect.conexion);
                        comando.Parameters.AddWithValue("@puesto", txtPosicion.Text);
                        comando.ExecuteNonQuery();
                        connect.abrir();
                        MessageBox.Show("Nuevo Puesto Insertado");
                        Limpiar();
                        MostrarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Esta ingresando un Puesto que ya fue registrado", "Aviso", MessageBoxButtons.OK);

            }
        }

        //Boton para modificar.
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            ErrorProvider.Clear();
            letra2 = false;
            letra = false;

            if (validacion.Espacio_Blanco(ErrorProvider1, txtPosicion) || validacion.Solo_Letras(ErrorProvider1, txtPosicion))
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtPosicion))
                    ErrorProvider1.SetError(txtPosicion, "No se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider1, txtPosicion))
                    ErrorProvider1.SetError(txtPosicion, "No se permiten números");
                Limpiar();
            }
            else
            {
                letra2 = true;
            }
            if (validacion.Espacio_Blanco(ErrorProvider1, txtCodigo))
            {
                if (validacion.Espacio_Blanco(ErrorProvider1, txtCodigo))
                    ErrorProvider1.SetError(txtCodigo, "Debe seleccionar el registro que desea cambiar");
            }
            else
            {
                letra = true;
            }

            if (letra2 && letra)
            {
                bool igual = false;
                connect.abrir();
                SqlCommand comando1 = new SqlCommand("select * from Empleados_Puestos where descripcion_puesto = '" + txtPosicion.Text + "'", connect.conexion);
                SqlDataReader registro = comando1.ExecuteReader();
                if (registro.Read())
                {
                    igual = true;
                }
                connect.cerrar();


                if (igual == false)
                {
                    try
                    {
                        string query = "Update Empleados_Puestos set descripcion_puesto= '" + txtPosicion.Text + "' where codigo_puesto='" + recordId + "'";
                        connect.abrir();
                        SqlCommand comando = new SqlCommand(query, connect.conexion);
                        comando.ExecuteNonQuery();
                        connect.cerrar();
                        MessageBox.Show("Se Modificó Correctamente");
                        Limpiar();
                        MostrarDatos();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                else
                    MessageBox.Show("Esta ingresando un Puesto que ya fue registrado", "Aviso", MessageBoxButtons.OK);
            }
        }

        //Funcion para mostrar la hora y la fecha debajo de la pantalla.
        private void timer1_Tick(object sender, EventArgs e)
        {
            tslFecha.Text = DateTime.Now.ToLongDateString();
            tslHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        //Funcion para llenar los campos de texto, dando click en una fila del DataGridView.
        private void DgvPuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            recordId = Convert.ToInt32(DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCodigo.Text = (DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtPosicion.Text = (DgvPuesto.Rows[e.RowIndex].Cells[1].Value.ToString());
        }
    }
}
