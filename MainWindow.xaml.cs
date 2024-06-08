using ExamenFinal;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ExamenFinal1
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT Usuario FROM Usuarios";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbUsuario.Items.Add(reader["Usuario"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void Guardar_Click(object sender, RoutedEventArgs e)
        {
            int carnet;
            if (int.TryParse(txtCarnet.Text, out carnet))
            {
                string nombre = txtNombre.Text;
                string telefono = txtTelefono.Text;
                string grado = txtGrado.Text;
                string usuario = cmbUsuario.SelectedItem?.ToString();

                if (!string.IsNullOrEmpty(nombre) && !string.IsNullOrEmpty(telefono) &&
                    !string.IsNullOrEmpty(grado) && !string.IsNullOrEmpty(usuario))
                {
                    using (SqlConnection connection = ConexionBD.GetConnection())
                    {
                        string query = "INSERT INTO Alumnos (Carnet, Nombre, Telefono, Grado, Usuario) " +
                            "VALUES (@Carnet, @Nombre, @Telefono, @Grado, @Usuario)";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Carnet", carnet);
                        command.Parameters.AddWithValue("@Nombre", nombre);
                        command.Parameters.AddWithValue("@Telefono", telefono);
                        command.Parameters.AddWithValue("@Grado", grado);
                        command.Parameters.AddWithValue("@Usuario", usuario);

                        try
                        {
                            command.ExecuteNonQuery();
                            MessageBox.Show("Alumno guardado correctamente.");
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al guardar alumno: " + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Por favor complete todos los campos.");
                }
            }
            else
            {
                MessageBox.Show("El carnet debe ser un número entero.");
            }
        }
    }
}