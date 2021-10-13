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

namespace Pantallas_proyecto
{
    public partial class FrmMetodosdePago : Form
    {
        public FrmMetodosdePago()
        {
            InitializeComponent();
        }

        ClsConexionBD conect = new ClsConexionBD();
        SqlCommand cmd;
        validaciones validacion = new validaciones();
        private bool letra = false;
        private bool letra2 = false;

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

        private void button4_Click(object sender, EventArgs e)
        {
            FrmMenuCRUD cRUD = new FrmMenuCRUD();
            cRUD.Show();
            this.Close();
        }

        private void FrmMetodosdePago_Load(object sender, EventArgs e)
        {
            conect.abrir();
            conect.cargarMetodosPago(dgvMetodosPago);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            letra2 = false;

            if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion) || validacion.Solo_Letras(ErrorProvider, txtDescripcion))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion))
                    ErrorProvider.SetError(txtDescripcion, "No se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider, txtDescripcion))
                    ErrorProvider.SetError(txtDescripcion, "No se permiten números");
            }
            else
            {
                letra2 = true;
            }

            if (letra2)
            {

                bool igual = false;
                conect.abrir();
                SqlCommand comando1 = new SqlCommand("select * from Metodo_pago where descripcion_pago = '" + txtDescripcion.Text + "'", conect.conexion);
                SqlDataReader registro = comando1.ExecuteReader();
                if (registro.Read())
                {
                    igual = true;
                }
                conect.cerrar();
                if (igual == false)
                {
                    try
                    {
                        conect.abrir();
                        cmd = new SqlCommand("INSERT INTO Metodo_Pago (descripcion_pago) VALUES ('" + txtDescripcion.Text + "')", conect.conexion);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Los Datos han sido insertados con Exitos", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        conect.cargarMetodosPago(dgvMetodosPago);
                        conect.cerrar();
                        txtDescripcion.Clear();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al ingresar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtDescripcion.Clear();
                    }
                }
                else
                    MessageBox.Show("Esta ingresando un Metodo de pago que ya fue registrado", "Aviso", MessageBoxButtons.OK);
            }
        }

        int poc;
        string codigo;

        int codigo1;

        private void button3_Click(object sender, EventArgs e)
        {
            letra2 = false;

            if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion) || validacion.Solo_Letras(ErrorProvider, txtDescripcion))
            {
                if (validacion.Espacio_Blanco(ErrorProvider, txtDescripcion))
                    ErrorProvider.SetError(txtDescripcion, "No se puede dejar en blanco");
                else
                if (validacion.Solo_Letras(ErrorProvider, txtDescripcion))
                    ErrorProvider.SetError(txtDescripcion, "No se permiten números");
            }
            else
            {
                letra2 = true;
            }
            poc = dgvMetodosPago.CurrentRow.Index;

            if (letra2)
            {
                bool igual = false;
                conect.abrir();
                SqlCommand comando1 = new SqlCommand("select * from Metodo_pago where descripcion_pago = '" + txtDescripcion.Text + "'", conect.conexion);
                SqlDataReader registro = comando1.ExecuteReader();
                if (registro.Read())
                {
                    igual = true;
                }
                conect.cerrar();
                if (igual == false)
                {
                    try
                    {
                        if (txtDescripcion.Text == "")
                        {
                            MessageBox.Show("Seleccione la descripción del método de Pago que desea modificar haciendo clic sobre la descripción que desea cambiar o modificar. Recuerde que Tampoco es permitido dejar sin descripción algún método de pago.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            codigo1 = Convert.ToInt32(dgvMetodosPago[0, poc].Value);
                            dgvMetodosPago[1, poc].Value = txtDescripcion.Text;
                            conect.abrir();
                            cmd = new SqlCommand("UPDATE Metodo_Pago SET descripcion_pago = '" + txtDescripcion.Text + "' WHERE codigo_pago = " + codigo1, conect.conexion);
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("El Registro fue actualizado exitosamente.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            conect.cargarMetodosPago(dgvMetodosPago);
                            codigo1 = 0;
                            txtDescripcion.Clear();
                            conect.cerrar();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("No se pudo modificar los datos" + ex, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                    MessageBox.Show("Esta ingresando un Metodo de pago que ya fue registrado", "Aviso", MessageBoxButtons.OK);
            }
        }

        private void dgvMetodosPago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = dgvMetodosPago.CurrentRow.Index;
            codigo = dgvMetodosPago[0, poc].Value.ToString();
            txtDescripcion.Text = dgvMetodosPago[1, poc].Value.ToString();
        }

        private void FrmMetodosdePago_Click(object sender, EventArgs e)
        {
            txtDescripcion.Clear();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToShortTimeString();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void dgvMetodosPago_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = dgvMetodosPago.CurrentRow.Index;
            codigo = dgvMetodosPago[0, poc].Value.ToString();
            txtDescripcion.Text = dgvMetodosPago[1, poc].Value.ToString();
        }

        private void dgvMetodosPago_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            poc = dgvMetodosPago.CurrentRow.Index;
            codigo = dgvMetodosPago[0, poc].Value.ToString();
            txtDescripcion.Text = dgvMetodosPago[1, poc].Value.ToString();
        }
    }
}
