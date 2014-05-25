using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FrbaCommerce.Common;

/* ////////////// ABM_Rol //////////////// 
 * 
 * 1)Inicializar
 * - SQL. Cargar tabla Roles de la BD en el Datagrid. (OK!)
 * - Registros del Datagrid deben ser seleccionables. (OK!)
 * 
 * 2)Nuevo
 * - Abrir Form.EditorDeRoles (sin cerrar AMB_Rol).
 * - SQL. Cargar todos los NOMBRES de las funcionalidades en una lista y cargarlos luego en Funcionalidades_Checkboxlist.
 * - El Checkbox 'Habilitado' en 'TRUE/YES', NO SE PUEDE MODIFICAR.
 * - Completar Nombre, seleccionar funcionalidades. a)Cancel: 
 *                                                  - resetear campos, cerrar ventana, liberar listas(?).
 *                                                  b)Guardar: 
 *                                                  - Agregar funcionalidades a una lista de NuevasFuncionalidades.
 *                                                  - SQL. Insertar nuevo rol con Nombre y Habilitado a ROLES. Insertar NuevasFuncionalidades a FUNCIONALIDAD_X_ROL.
 *                                                  - Resetear campos, cerrar ventana, liberar listas(?), mssg--> "Exito".
 *                                                  - Actualizar Form.ABM_Roles Datagrid.
 * 
 * 3)Modificar
 * - Seleccionar un Rol ( registro del Datagrid ).
 * - Abrir Form.EditorDeRoles (sin cerrar AMB_Rol).
 * - En Nombre figurara el registro seleccionado.Nombre, puede ser modificado.
 * - SQL. Cargar todos los NOMBRES de las funcionalidades del Rol seleccionado.ID_Rol en una lista y cargarlos luego en Funcionalidades_Checkboxlist CHECKEADAS.
 * - SQL. Cargar todos los NOMBRES de TODAS las funcionalidades en una lista y cargarlos luego en Funcionalidades_Checkboxlist SIN CHECKEAR. (Puede ser misma query)
 * - El Checkbox 'Habilitado' puede ser pasado de FALSE-->TRUE, UNICAMENTE, NO esta permitido de TRUE-->False (solo en Eliminar).
 * - Cambiar Nombre si se desea, sacar/agregar funcionalidades, pasar de INHABILITADO-->HABILITADO si asi se deseara. a)Cancel:
 *                                                                                                                    - resetear campos, cerrar ventana, liberar listas(?).
 *                                                                                                                    b)Guardar:
 *                                                                                                                    - Agregar funcionalidades a una lista de NuevasFuncionalidades.
 *                                                                                                                    - SQL. Modificar el rol con nuevo Nombre (o sin tocar), estado de Habilitado a ROLES. Modificar NuevasFuncionalidades a FUNCIONALIDAD_X_ROL.
 *                                                                                                                    - Resetear campos, cerrar ventana, liberar listas(?), mssg--> "Exito".
 *                                                                                                                    - Actualizar Form.ABM_Roles Datagrid.
 * 4)Eliminar
 * - Seleccionar un Rol ( registro del Datagrid ).
 * - YES NO QUESTION: "Estas seguro que desea eliminar 'seleccionado.Nombre' ??".
 * - IF YES:
 * - SQL. Modificar 'Habilitado' a FALSE/NO del rol seleccionado.ID_Rol.
 * - SQL. Eliminar de ROLES_x_USUARIO a TODOS los usuario dicho Rol.
 * - MSSG--> "Rol eliminado con exito".
 * - Actualizar Form.ABM_Roles Datagrid.
 * - IF NO:
 * - Do nothing.
 * 
 * 5)Volver/Close window
 * - debera volver al Form anterior, "Gestion de admin", donde figuran todas las ABM (?).
 * - SQL. Desconectar Datagrid de la base de datos.
 * - this.hide  show.GestionDeAdmin.form
 */






namespace FrbaCommerce.ABM_Rol
{
    public partial class AbmRolForm : Form
    {
        public AbmRolForm()
        {
            InitializeComponent();
            cargarTodosLosRoles();
        }

 
        private void cargarTodosLosRoles()
        {
            //SqlDataReader lector = BDSQL.ObtenerDataReader("SELECT * FROM MERCADONEGRO.Roles", "DT", null);
            //lector.Read();
            
            SqlDataAdapter dataadapter = new SqlDataAdapter("SELECT * FROM MERCADONEGRO.Roles", BDSQL.iniciarConexion());
            DataTable table = new DataTable();
            dataadapter.Fill(table);
            Roles_Datagrid.DataSource = table;

            
            BDSQL.cerrarConexion();

        }

        private void Nuevo_Button_Click(object sender, EventArgs e)
        {
            EditorDeRoles editForm = new EditorDeRoles("nuevo");
           
            editForm.ShowDialog();
        }
    }
}
