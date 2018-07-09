using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Trafika.Forme
{
    public partial class frmKupac : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmKupac()
        {
            InitializeComponent();
            txtBrojMobilnogTelefona.Focus();
        }
  

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.izmena)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocniRed;
                    string update = @"update tblKupac Set BrojMobilnogTelefona = '" + txtBrojMobilnogTelefona.Text + "' Where KupacID = " + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                    this.Close();
                }
                else
                {                
                    string insert = @"insert into tblKupac(BrojMobilnogTelefona)
                                      values ('" + txtBrojMobilnogTelefona.Text + "');";

                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (SqlException)
            {
                MessageBox.Show("Unos određenih vrednosti nije validan.", "Greška!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnOtkazi_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}