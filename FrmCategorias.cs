//Categorias
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
    public partial class FrmCategorias : Form
    {
        public FrmCategorias()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        bool letra = false;
        bool letra2 = false;
        private const int cpNoCloseButton = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | cpNoCloseButton;
                return myCp;
            }
        }

        ClsConexionBD connect = new ClsConexionBD();
        int Record_Id;

        public void MostrarDatos()
        {
            /*
             Se conecta con la base de datos para extraer los datos de las categorias
            */
            try
            {
                string consulta = "SELECT codigo_categoria as Código, descripcion_categoria as Categoria FROM Categoria_Producto";
                SqlDataAdapter adaptador = new SqlDataAdapter(consulta, connect.conexion);
                DataTable tabla = new DataTable();
                adaptador.Fill(tabla);

                DgvCategoria.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                DgvCategoria.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Limpiar()
        {
            /*
             Limpia la pantalla
            */
            txtCodigo.Clear();
            txtCategoria.Clear();
        }

        private void BtnRegresar_Click(object sender, EventArgs e)
        {
            /*
             Regresa al menu de CRUDs
            */
            FrmMenuCRUD CRUD = new FrmMenuCRUD();
            CRUD.Show();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            /*
             Muestra la hora y fecha del dispositivo
            */
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            /*
             Llama a la función MostrarDatos
            */
            MostrarDatos();
            timer1.Enabled = true;
        }

        validaciones validacion = new validaciones();

        public void validar()
        {
            /*
             Verifica que todos los datos que pide se hayan ingresado correctamente
            */
            if (validacion.Espacio_Blanco(errorProvider1, txtCategoria) || validacion.Solo_Letras(errorProvider1, txtCategoria))
            {

                if (validacion.Espacio_Blanco(errorProvider1, txtCategoria))
                {
                    errorProvider1.SetError(txtCategoria, "No se puede dejar en blanco las categorias");
                }
                else
                {
                    if (validacion.Solo_Letras(errorProvider1, txtCategoria))
                        errorProvider1.SetError(txtCategoria, "Solo es permitido ingresar letras");
                }
            }
        }


        private void DgvCategoria_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Record_Id = Convert.ToInt32(DgvCategoria.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCodigo.Text = (DgvCategoria.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCategoria.Text = (DgvCategoria.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void BtnAgregar_Click(object sender, EventArgs e)
        {
            /*
             Agrega los datos ingresados a categorias
            */
            errorProvider2.Clear();
            try
            {
                if (validacion.Espacio_Blanco(errorProvider1, txtCategoria) || validacion.Solo_Letras(errorProvider1, txtCategoria))
                {

                    if (validacion.Espacio_Blanco(errorProvider1, txtCategoria))
                    {
                        errorProvider1.SetError(txtCategoria, "No se puede dejar en blanco las categorias");
                    }
                    else
                    {
                        if (validacion.Solo_Letras(errorProvider1, txtCategoria))
                            errorProvider1.SetError(txtCategoria, "Solo es permitido ingresar letras");
                    }
                }
                else
                {

                    int cont = 0;
                    bool resp = false;
                    connect.abrir();
                    SqlCommand comando1 = new SqlCommand("select descripcion_categoria from Categoria_Producto", connect.conexion);

                    SqlDataReader reader = comando1.ExecuteReader();

                    List<string> resultado = new List<string>();
                    while (reader.Read())
                    {
                        resultado.Add(Convert.ToString(reader["descripcion_categoria"]));
                        cont++;
                    }

                    string[] arrayCate = resultado.ToArray();


                    connect.cerrar();
                    for (int i = 0; i < cont; i++)
                    {
                        if (arrayCate[i].ToLower() == txtCategoria.Text.ToLower())
                            resp = true;
                    }


                    if (resp == false)
                    {
                        string query = "INSERT INTO Categoria_Producto (descripcion_categoria) VALUES (@categoria)";
                        connect.abrir();
                        SqlCommand comando = new SqlCommand(query, connect.conexion);
                        comando.Parameters.AddWithValue("@categoria", txtCategoria.Text);
                        comando.ExecuteNonQuery();
                        connect.abrir();
                        MessageBox.Show("Nueva Categoria Insertado");
                        Limpiar();
                        MostrarDatos();
                    }
                    else
                        MessageBox.Show("La categoria ya esta registrada, intente otra", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);

            }


        }



        private void BtnModificar_Click(object sender, EventArgs e)
        {
            /*
             Permite modificar datos de categorias 
            */
            errorProvider1.Clear();
            letra = false;
            letra2 = false;
            bool resp = false;

            if (validacion.Espacio_Blanco(errorProvider2, txtCategoria) || validacion.Solo_Letras(errorProvider2, txtCategoria))
            {

                if (validacion.Espacio_Blanco(errorProvider2, txtCategoria))
                {
                    errorProvider2.SetError(txtCategoria, "No se puede dejar en blanco las categorias");
                }
                else
                {
                    if (validacion.Solo_Letras(errorProvider2, txtCategoria))
                        errorProvider2.SetError(txtCategoria, "Solo es permitido ingresar letras");
                }
            }
            else
            {
                letra = true;
            }
            if (validacion.Espacio_Blanco(errorProvider2, txtCodigo))
            {

                if (validacion.Espacio_Blanco(errorProvider2, txtCodigo))
                {
                    errorProvider2.SetError(txtCodigo, "Debe seleccionar el registro que desea cambiar");
                }
            }
            else
            {
                letra2 = true;
                int cont = 0;

                connect.abrir();
                SqlCommand comando1 = new SqlCommand("select descripcion_categoria from Categoria_Producto", connect.conexion);

                SqlDataReader reader = comando1.ExecuteReader();

                List<string> resultado = new List<string>();
                while (reader.Read())
                {
                    resultado.Add(Convert.ToString(reader["descripcion_categoria"]));
                    cont++;
                }

                string[] arrayCate = resultado.ToArray();


                connect.cerrar();
                for (int i = 0; i < cont; i++)
                {
                    if (arrayCate[i].ToLower() == txtCategoria.Text.ToLower())
                        resp = true;
                }
                if (resp == true)
                {
                    errorProvider1.SetError(txtCategoria, "No se puede ingresar la misma categoria");
                }
            }
            if (letra && letra2 && resp == false)
            {
                try
                {
                    string query = "Update Categoria_Producto set descripcion_categoria= '" + txtCategoria.Text + "' where Codigo_Categoria='" + Record_Id + "'";
                    connect.abrir();
                    SqlCommand comando = new SqlCommand(query, connect.conexion);
                    comando.ExecuteNonQuery();
                    connect.abrir();
                    MessageBox.Show("Se Modificó Correctamente");
                    Limpiar();
                    MostrarDatos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void toolStripContainer1_ContentPanel_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            /*
             Muestra la hora y fecha del dispositivo
            */
            toolStripLabel1.Text = DateTime.Now.ToLongDateString();
            toolStripLabel2.Text = DateTime.Now.ToLongTimeString();
        }

        private void DgvCategoria_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Record_Id = Convert.ToInt32(DgvCategoria.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCodigo.Text = (DgvCategoria.Rows[e.RowIndex].Cells[0].Value.ToString());
            txtCategoria.Text = (DgvCategoria.Rows[e.RowIndex].Cells[1].Value.ToString());
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}