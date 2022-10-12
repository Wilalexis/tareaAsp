using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tareaAsp
{
    public partial class _Default : Page
    {
        Estudiante estudiante;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                estudiante = new Estudiante();
                estudiante.drop_sangre(drop_sangre);
                estudiante.grid_estudiantes(grid_datos);
            }
        }

        protected void grid_datos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void agregar_Click(object sender, EventArgs e)
        {
            estudiante = new Estudiante();
            if (estudiante.agregar(carne.Text, nombres.Text, apellidos.Text, direccion.Text, telefono.Text, correo.Text, fecha_nan.Text, Convert.ToInt32(drop_sangre.SelectedValue)) > 0)
            {
                mensaje.Text = "Ingreso exitoso";
                estudiante.grid_estudiantes(grid_datos);
            }
        }

        protected void grid_datos_SelectedIndexChanged1(object sender, EventArgs e)
        {
            carne.Text = grid_datos.SelectedRow.Cells[2].Text;
            nombres.Text = grid_datos.SelectedRow.Cells[3].Text;
            apellidos.Text = grid_datos.SelectedRow.Cells[4].Text;
            direccion.Text = grid_datos.SelectedRow.Cells[5].Text;
            telefono.Text = grid_datos.SelectedRow.Cells[6].Text;
            correo.Text = grid_datos.SelectedRow.Cells[7].Text;

            DateTime fecha = Convert.ToDateTime(grid_datos.SelectedRow.Cells[9].Text);
            fecha_nan.Text = fecha.ToString("yyyy-MM-dd");
            int indice = grid_datos.SelectedRow.RowIndex;
            drop_sangre.SelectedValue = grid_datos.DataKeys[indice].Values["id"].ToString();
            modicar.Visible = true;
        }

        protected void grid_datos_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            estudiante = new Estudiante();
            if (estudiante.eliminar(Convert.ToInt32(e.Keys["id"])) > 0)
            {
                mensaje.Text = "Eliminacion exitosa";
                estudiante.grid_estudiantes(grid_datos);
            }
        }

        protected void modicar_Click(object sender, EventArgs e)
        {
            estudiante = new Estudiante();
            if (estudiante.modificar(Convert.ToInt32(grid_datos.SelectedValue), carne.Text, nombres.Text, apellidos.Text, direccion.Text, telefono.Text, correo.Text, fecha_nan.Text, Convert.ToInt32(drop_sangre.SelectedValue)) > 0)
            {
                mensaje.Text = "Modificacion exitoso";
                estudiante.grid_estudiantes(grid_datos);
            }
        }
    }
}