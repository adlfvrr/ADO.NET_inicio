namespace ModalPrueba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Probamos un connection string a nuestra bdd
            string connectionString = "Host=localhost;Port=5432;Database=your_db;Username=your_user;Password=your_password;";

            // Creamos una instancia de NpgsqlConnection
            try
            {
                //Mediante la cláusula using, se asegura que la conexión se cierre de manera automática terminado el bloque de código.
                //Algo parecido es el manejo de archivos, donde se cierra la conexión en el bloque finally de un try-catch
            using var conn = new Npgsql.NpgsqlConnection(connectionString);
            conn.Open();
          
                MessageBox.Show("¡ Conexión realizada con éxito !");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Error en la conexión: {ex.Message}");
            }

            //En este caso, conexión realizada con éxito.

        }
    }
}
