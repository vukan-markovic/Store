using System.Windows;
using System.Data;
using System.Data.SqlClient;

namespace Trafika.Forme
{
    public partial class frmProizvod : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmProizvod()
        {
            InitializeComponent();
            txtCena.Focus();

            try
            {
                konekcija.Open();

                //cbxProizvodjac

                string vratiProizvodjace = "select ProizvodjacID, NazivProizvodjaca from tblProizvodjac";
                DataTable dataTableProizvodjaci = new DataTable();
                SqlDataAdapter dataAdapterProizvodjaci = new SqlDataAdapter(vratiProizvodjace, konekcija);

                dataAdapterProizvodjaci.Fill(dataTableProizvodjaci);
                cbxProizvodjac.ItemsSource = dataTableProizvodjaci.DefaultView;

                //cbxVrstaProizvoda

                string vratiVrsteProizvoda = "select VrstaProizvodaID, NazivVrsteProizvoda from tblVrstaProizvoda";
                DataTable dataTableVrsteProizvoda = new DataTable();
                SqlDataAdapter dataAdapterVrsteProizvoda = new SqlDataAdapter(vratiVrsteProizvoda, konekcija);

                dataAdapterVrsteProizvoda.Fill(dataTableVrsteProizvoda);
                cbxVrstaProizvoda.ItemsSource = dataTableVrsteProizvoda.DefaultView;


                //cbxDobavljac

                string vratiDobavljace = "select DobavljacID, NazivFirme from tblDobavljac";
                DataTable dataTableDobavljaci = new DataTable();
                SqlDataAdapter dataAdapterDobavljaci = new SqlDataAdapter(vratiDobavljace, konekcija);

                dataAdapterDobavljaci.Fill(dataTableDobavljaci);
                cbxDobavljac.ItemsSource = dataTableDobavljaci.DefaultView;
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                if (MainWindow.izmena)
                {
                    DataRowView red = (DataRowView)MainWindow.pomocniRed;
                    string update = @"update tblProizvod Set Cena = " + txtCena.Text + " , Sifra = '" + txtSifra.Text + "' , Naziv = '" + txtNaziv.Text + "', ProizvodjacID = " + cbxProizvodjac.SelectedValue + ", VrstaProizvodaID = " + cbxVrstaProizvoda.SelectedValue + ", DobavljacID = " + cbxDobavljac.SelectedValue + " Where ProizvodID = " + red["ID"];
                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                    this.Close();
                }
                else
                {
                    string insert = @"insert into tblProizvod(Cena, Sifra, Naziv, ProizvodjacID, VrstaProizvodaID, DobavljacID)
                                      values(" + txtCena.Text + ", '" + txtSifra.Text + "', '" + txtNaziv.Text + "', " + cbxProizvodjac.SelectedValue + 
                                      ", " + cbxVrstaProizvoda.SelectedValue + ", " + cbxDobavljac.SelectedValue + ");";

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