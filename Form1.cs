using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dual
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            cargarTabla(null);
        }

        private void txtCelular_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            bool bandera = false;

            Alumnos _alumnos = new Alumnos();
            
            _alumnos.Matrícula = txtMatrícula.Text;
            _alumnos.NombreCompleto =txtNombreCompleto.Text;
            _alumnos.Semestre  = cmbSemestre.Text;
            _alumnos.Modalidad = cmbModalidad.Text;
            _alumnos.Celular = txtCelular.Text;
            _alumnos.Correo = txtCorreo.Text;

            CtrlAlumnos _ctrl = new CtrlAlumnos();

            if(txtId.Text != "")
            {
                _alumnos.IdAlumno = int.Parse(txtId.Text);
                bandera =_ctrl.actualizar(_alumnos);
                limpiar();
                cargarTabla(null);
            }
            else
            {
                if (string.IsNullOrEmpty(_alumnos.Matrícula) || string.IsNullOrEmpty(_alumnos.NombreCompleto) || string.IsNullOrEmpty(_alumnos.Semestre) || string.IsNullOrEmpty(_alumnos.Modalidad) || string.IsNullOrEmpty(_alumnos.Celular) || string.IsNullOrEmpty(_alumnos.Correo))
                {
                    MessageBox.Show("Llenar todos los campos", "Aviso", MessageBoxButtons.OK);
                }
                else
                {
                    _ctrl.insertar(_alumnos);
                    MessageBox.Show("Registro Guardado", "Aviso", MessageBoxButtons.OK);
                    limpiar();
                    cargarTabla(null);
                }
                
            }

            if (bandera)
            {
                MessageBox.Show("Registro Actualizado");
            }

        }
        private void limpiar()
        {
            txtId.Text = "";
            txtMatrícula.Text = "";
            txtNombreCompleto.Text = "";
            cmbSemestre.Text="";
            cmbModalidad.Text="";
            txtCelular.Text="";
            txtCorreo.Text="";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string dato = txtBuscar.Text;
            
            cargarTabla(dato);
        }

        private void cargarTabla(string dato)
        {
            List<Alumnos> lista = new List<Alumnos>();
            CtrlAlumnos _ctrlAlumnos = new CtrlAlumnos();
            dataGridView1.DataSource = _ctrlAlumnos.consulta(dato);

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtId.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtMatrícula.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtNombreCompleto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            cmbSemestre.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            cmbModalidad.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCelular.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCorreo.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            bool bandera = false;
           
            DialogResult resultado = MessageBox.Show("¿Seguro que desea eliminar el registro?","Salir",MessageBoxButtons.YesNoCancel);
            if (resultado == DialogResult.Yes)
            {
                int IdALumno = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                CtrlAlumnos ctrl = new CtrlAlumnos();
                bandera = ctrl.eliminar(IdALumno);

                if (bandera)
                {
                    cargarTabla(null);
                    MessageBox.Show("Registro Eliminado");
                }
            }
        }
    }
}
