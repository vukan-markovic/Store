using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Trafika.Forme
{
    public partial class frmVrstaProizvoda : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmVrstaProizvoda()
        {
            InitializeComponent();
            txtNazivVrsteProizvoda.Focus();
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.izmena)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocniRed;
                    string upit = @"update tblVrstaProizvoda Set NazivVrsteProizvoda = '" + txtNazivVrsteProizvoda.Text + "' Where VrstaProizvodaID = " + red["ID"];
                    SqlCommand cmd = new SqlCommand(upit, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                    this.Close();
                }
                else
                {
                    string insert = @"insert into tblVrstaProizvoda(NazivVrsteProizvoda)
                                      values('" + txtNazivVrsteProizvoda.Text + "');";

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