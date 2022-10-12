using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace Modelo
{
    public class Estudiante
    {
        ConexionBD conectar;
        private DataTable drop_sangre()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("select id_tipos_sangre as id, sangre from tipos_sangre;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        private DataTable grid_estudiantes()
        {
            DataTable tabla = new DataTable();
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("select e.id_estudiante as id,e.carne,e.nombres,e.apellidos,e.direccion,e.telefono, e.correo_electronico, t.sangre, e.fecha_nacimiento from estudiantes as e inner join tipos_sangre as t on e.id_tipo_sangre = t.id_tipos_sangre;");
            MySqlDataAdapter query = new MySqlDataAdapter(consulta, conectar.conectar);
            query.Fill(tabla);
            conectar.CerrarConexion();
            return tabla;
        }

        public void drop_sangre(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("---Elegir tipo de sangre---");
            drop.Items[0].Value = "0";
            drop.DataSource = drop_sangre();
            drop.DataTextField = "sangre";
            drop.DataValueField = "id";
            drop.DataBind();
        }

        public void grid_estudiantes(GridView grid)
        {
            grid.DataSource = grid_estudiantes();
            grid.DataBind();
        }

        public int agregar(string carne, string nombres, string apellidos, string direccion, string telefono, string correo, string fecha, int id_tipo_sangre)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("insert into estudiantes(carne,nombres,apellidos,direccion,telefono,correo_electronico,fecha_nacimiento,id_tipo_sangre) values('{0}','{1}','{2}','{3}',{4},'{5}','{6}',{7});", carne, nombres, apellidos, direccion, telefono, correo, fecha, id_tipo_sangre);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }

        public int modificar(int id, string carne, string nombres, string apellidos, string direccion, string telefono, string correo, string fecha, int id_tipo_sangre)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("update estudiantes set carne = '{0}',nombres = '{1}',apellidos = '{2}',direccion='{3}',telefono={4},correo_electronico='{5}', fecha_nacimiento='{7}',id_tipo_sangre={6} where id_estudiante = {8};", carne, nombres, apellidos, direccion, telefono, correo, fecha, id_tipo_sangre, id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }


        public int eliminar(int id)
        {
            int no = 0;
            conectar = new ConexionBD();
            conectar.AbrirConexion();
            string consulta = string.Format("delete from estudiantes where id_estudiante = {0};", id);
            MySqlCommand query = new MySqlCommand(consulta, conectar.conectar);
            query.Connection = conectar.conectar;
            no = query.ExecuteNonQuery();
            conectar.CerrarConexion();
            return no;
        }
    }
}
