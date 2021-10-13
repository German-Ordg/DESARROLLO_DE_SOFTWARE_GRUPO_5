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

        ClsConexionBD connect = new ClsConexionBD();
        validaciones validacion = new validaciones();
        int Record_Id;
        private bool letra = false;
        private bool letra2 = false;

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

        public void Limpiar()
        {
            txtCodigo.Clear();
            txtPosicion.Clear();
            txtPosicion.Select();
        }

        private void frmPuestosTrabajo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void DgvPuesto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Record_Id = Convert.ToInt32(DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCodigo.Text = (DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtPosicion.Text = (DgvPuesto.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD cRUD = new FrmMenuCRUD();
            cRUD.Show();
            this.Close();
        }

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
                        string query = "Update Empleados_Puestos set descripcion_puesto= '" + txtPosicion.Text + "' where codigo_puesto='" + Record_Id + "'";
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            tslFecha.Text = DateTime.Now.ToLongDateString();
            tslHora.Text = DateTime.Now.ToLongTimeString();
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void DgvPuesto_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Record_Id = Convert.ToInt32(DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCodigo.Text = (DgvPuesto.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtPosicion.Text = (DgvPuesto.Rows[e.RowIndex].Cells[1].Value.ToString());
        }
    }
}
