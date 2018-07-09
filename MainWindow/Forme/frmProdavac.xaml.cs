using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Trafika.Forme
{
    public partial class frmProdavac : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmProdavac()
        {
            InitializeComponent();
            txtUserName.Focus();
        }
    
        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.izmena)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocniRed;

                    string update = @"update tblProdavac Set Username = '" + txtUserName.Text + "', Password = '" + txtPassword.Text + "' Where ProdavacID = " + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                    this.Close();
                }
                else
                {
                    string insert = @"insert into tblProdavac(Username, Password)
                                      values('" + txtUserName.Text + "', '" + txtPassword.Text + "');";

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