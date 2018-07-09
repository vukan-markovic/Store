using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using Trafika.Forme;

namespace Trafika
{
    public partial class MainWindow : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju(); // otvara se konekcija
        public static bool izmena; // promenljiva koja ukazuje da li je u pitanju operacija dodavanja ili izmene
        public static object pomocniRed; // objekat kojim pamtimo selektovani red

        // Metoda koja popunjava pocetni dataGrid

        private void PocetniDataGrid(DataGrid grid)
        {
            try
            {
                string upit = @"select ProizvodID as ID, Cena, Sifra as Šifra, Naziv, NazivProizvodjaca as 'Naziv proizvođača', 
                                NazivVrsteProizvoda as 'Vrsta proizvoda', NazivFirme as 'Dobavljač' from tblProizvod 
                                inner join tblProizvodjac on tblProizvod.ProizvodjacID = tblProizvodjac.ProizvodjacID 
                                inner join tblVrstaProizvoda on tblProizvod.VrstaProizvodaID = tblVrstaProizvoda.VrstaProizvodaID
                                inner join tblDobavljac on tblProizvod.DobavljacID = tblDobavljac.DobavljacID";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dataTable = new DataTable("Proizvod");
                dataAdapter.Fill(dataTable);
                grid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            PocetniDataGrid(dataGridCentralni);            
        }

        private void btnProizvodi_Click(object sender, RoutedEventArgs e)
        {
            btnDodajProizvod.Visibility = Visibility.Visible;

            btnDodajProdavca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnDodajFiskalniRacun.Visibility = Visibility.Collapsed;
            btnDodajProizvodjaca.Visibility = Visibility.Collapsed;


            btnIzmeniProizvod.Visibility = Visibility.Visible;

            btnIzmeniProdavca.Visibility = Visibility.Collapsed;
            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnIzmeniFiskalniRacun.Visibility = Visibility.Collapsed;
            btnIzmeniProizvodjaca.Visibility = Visibility.Collapsed;


            btnObrisiProizvod.Visibility = Visibility.Visible;

            btnObrisiProdavca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnObrisiFiskalniRacun.Visibility = Visibility.Collapsed;
            btnObrisiProizvodjaca.Visibility = Visibility.Collapsed;

            PocetniDataGrid(dataGridCentralni);
        }

        private void btnVrsteProizvoda_Click(object sender, RoutedEventArgs e)
        {
            btnDodajVrstuProizvoda.Visibility = Visibility.Visible;

            btnDodajProdavca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajFiskalniRacun.Visibility = Visibility.Collapsed;
            btnDodajProizvodjaca.Visibility = Visibility.Collapsed;


            btnIzmeniVrstuProizvoda.Visibility = Visibility.Visible;

            btnIzmeniProdavca.Visibility = Visibility.Collapsed;
            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniFiskalniRacun.Visibility = Visibility.Collapsed;
            btnIzmeniProizvodjaca.Visibility = Visibility.Collapsed;


            btnObrisiVrstuProizvoda.Visibility = Visibility.Visible;

            btnObrisiProdavca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiFiskalniRacun.Visibility = Visibility.Collapsed;
            btnObrisiProizvodjaca.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select VrstaProizvodaID as ID, NazivVrsteProizvoda as 'Naziv vrste proizvoda' from tblVrstaProizvoda";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dataTable = new DataTable("VrstaProizvoda");
                dataAdapter.Fill(dataTable);
                dataGridCentralni.ItemsSource = dataTable.DefaultView;
            }
            catch(Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnProizvodjaci_Click(object sender, RoutedEventArgs e)
        {
            btnDodajProizvodjaca.Visibility = Visibility.Visible;

            btnDodajProdavca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnDodajFiskalniRacun.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;


            btnIzmeniProizvodjaca.Visibility = Visibility.Visible;

            btnIzmeniProdavca.Visibility = Visibility.Collapsed;
            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnIzmeniFiskalniRacun.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;


            btnObrisiProizvodjaca.Visibility = Visibility.Visible;

            btnObrisiProdavca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnObrisiFiskalniRacun.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select ProizvodjacID as ID, NazivProizvodjaca as 'Naziv proizvođača' from tblProizvodjac";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dataTable = new DataTable("Proizvodjac");
                dataAdapter.Fill(dataTable);
                dataGridCentralni.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnDobavljaci_Click(object sender, RoutedEventArgs e)
        {
            btnDodajDobavljaca.Visibility = Visibility.Visible;

            btnDodajProdavca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnDodajFiskalniRacun.Visibility = Visibility.Collapsed;
            btnDodajProizvodjaca.Visibility = Visibility.Collapsed;


            btnIzmeniDobavljaca.Visibility = Visibility.Visible;

            btnIzmeniProdavca.Visibility = Visibility.Collapsed;
            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnIzmeniFiskalniRacun.Visibility = Visibility.Collapsed;
            btnIzmeniProizvodjaca.Visibility = Visibility.Collapsed;


            btnObrisiDobavljaca.Visibility = Visibility.Visible;

            btnObrisiProdavca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnObrisiFiskalniRacun.Visibility = Visibility.Collapsed;
            btnObrisiProizvodjaca.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select DobavljacID as ID, NazivFirme as 'Naziv firme' from tblDobavljac";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dataTable = new DataTable("Dobavljac");
                dataAdapter.Fill(dataTable);
                dataGridCentralni.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnKupci_Click(object sender, RoutedEventArgs e)
        {
            btnDodajKupca.Visibility = Visibility.Visible;

            btnDodajProdavca.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnDodajFiskalniRacun.Visibility = Visibility.Collapsed;
            btnDodajProizvodjaca.Visibility = Visibility.Collapsed;


            btnIzmeniKupca.Visibility = Visibility.Visible;

            btnIzmeniProdavca.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnIzmeniFiskalniRacun.Visibility = Visibility.Collapsed;
            btnIzmeniProizvodjaca.Visibility = Visibility.Collapsed;


            btnObrisiKupca.Visibility = Visibility.Visible;

            btnObrisiProdavca.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnObrisiFiskalniRacun.Visibility = Visibility.Collapsed;
            btnObrisiProizvodjaca.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select KupacID as ID, BrojMobilnogTelefona as 'Broj mobilnog telefona' from tblKupac";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dataTable = new DataTable("Kupac");
                dataAdapter.Fill(dataTable);
                dataGridCentralni.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnProdavci_Click(object sender, RoutedEventArgs e)
        {
            btnDodajProdavca.Visibility = Visibility.Visible;

            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnDodajFiskalniRacun.Visibility = Visibility.Collapsed;
            btnDodajProizvodjaca.Visibility = Visibility.Collapsed;


            btnIzmeniProdavca.Visibility = Visibility.Visible;

            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnIzmeniFiskalniRacun.Visibility = Visibility.Collapsed;
            btnIzmeniProizvodjaca.Visibility = Visibility.Collapsed;


            btnObrisiProdavca.Visibility = Visibility.Visible;

            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnObrisiFiskalniRacun.Visibility = Visibility.Collapsed;
            btnObrisiProizvodjaca.Visibility = Visibility.Collapsed;

            try
            {
                konekcija.Open();

                string upit = @"select ProdavacID as ID, Username, Password from tblProdavac";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dataTable = new DataTable("Prodavac");
                dataAdapter.Fill(dataTable);
                dataGridCentralni.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        private void btnFiskalniRacuni_Click(object sender, RoutedEventArgs e)
        {
            btnDodajFiskalniRacun.Visibility = Visibility.Visible;

            btnDodajProdavca.Visibility = Visibility.Collapsed;
            btnDodajKupca.Visibility = Visibility.Collapsed;
            btnDodajDobavljaca.Visibility = Visibility.Collapsed;
            btnDodajVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnDodajProizvod.Visibility = Visibility.Collapsed;
            btnDodajProizvodjaca.Visibility = Visibility.Collapsed;


            btnIzmeniFiskalniRacun.Visibility = Visibility.Visible;

            btnIzmeniProdavca.Visibility = Visibility.Collapsed;
            btnIzmeniKupca.Visibility = Visibility.Collapsed;
            btnIzmeniDobavljaca.Visibility = Visibility.Collapsed;
            btnIzmeniVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnIzmeniProizvod.Visibility = Visibility.Collapsed;
            btnIzmeniProizvodjaca.Visibility = Visibility.Collapsed;


            btnObrisiFiskalniRacun.Visibility = Visibility.Visible;

            btnObrisiProdavca.Visibility = Visibility.Collapsed;
            btnObrisiKupca.Visibility = Visibility.Collapsed;
            btnObrisiDobavljaca.Visibility = Visibility.Collapsed;
            btnObrisiVrstuProizvoda.Visibility = Visibility.Collapsed;
            btnObrisiProizvod.Visibility = Visibility.Collapsed;
            btnObrisiProizvodjaca.Visibility = Visibility.Collapsed;


            try
            {
                konekcija.Open();

                string upit = @"select FiskalniRacunID as ID, DatumIzdavanja as 'Datum izdavanja', VremeIzdavanja as 'Vreme izdavanja',
                                MestoIzdavanja as 'Mesto izdavanja', Iznos, Kolicina as Količina, UserName as Prodavac,
                                BrojMobilnogTelefona as Kupac, Naziv as Proizvod from tblFiskalniRacun
                                inner join tblProdavac on tblFiskalniRacun.ProdavacID = tblProdavac.ProdavacID
                                inner join tblKupac on tblFiskalniRacun.KupacID = tblKupac.KupacID
                                inner join tblProizvod on tblFiskalniRacun.ProizvodID = tblProizvod.ProizvodID";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(upit, konekcija);
                DataTable dataTable = new DataTable("FiskalniRacun");
                dataAdapter.Fill(dataTable);
                dataGridCentralni.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception exception)
            {
                System.Diagnostics.Debug.WriteLine(exception.Message.ToString());
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
        }

        // Akcija dodaj

        private void btnDodajProizvod_Click(object sender, RoutedEventArgs e)
        {
            frmProizvod prozor = new frmProizvod();
            prozor.ShowDialog();
            PocetniDataGrid(dataGridCentralni); // refresh centralnog dataGrida
        }

        private void btnDodajVrstuProizvoda_Click(object sender, RoutedEventArgs e)
        {
            frmVrstaProizvoda prozor = new frmVrstaProizvoda();
            prozor.ShowDialog();
            btnVrsteProizvoda_Click(sender, e); // refresh
        }

        private void btnDodajProizvodjaca_Click(object sender, RoutedEventArgs e)
        {
            frmProizvodjac prozor = new frmProizvodjac();
            prozor.ShowDialog();
            btnProizvodjaci_Click(sender, e);
        }

        private void btnDodajDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            frmDobavljac prozor = new frmDobavljac();
            prozor.ShowDialog();
            btnDobavljaci_Click(sender, e);
        }

        private void btnDodajKupca_Click(object sender, RoutedEventArgs e)
        {
            frmKupac prozor = new frmKupac();
            prozor.ShowDialog();
            btnKupci_Click(sender, e);
        }

        private void btnDodajProdavca_Click(object sender, RoutedEventArgs e)
        {
            frmProdavac prozor = new frmProdavac();
            prozor.ShowDialog();
            btnProdavci_Click(sender, e);
        }

        private void btnDodajFiskalniRacun_Click(object sender, RoutedEventArgs e)
        {
            frmFiskalniRacun prozor = new frmFiskalniRacun();
            prozor.ShowDialog();
            btnFiskalniRacuni_Click(sender, e);
        }

        private void btnIzmeniProizvod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmena = true;

                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocniRed = selektovaniRed;
                string upit = "select * from tblProizvod where ProizvodID = " + selektovaniRed["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                frmProizvod prozor = new frmProizvod();

                while (citac.Read())
                {
                    prozor.txtCena.Text = citac["Cena"].ToString();
                    prozor.txtSifra.Text = citac["Sifra"].ToString();
                    prozor.txtNaziv.Text = citac["Naziv"].ToString();
                    prozor.cbxProizvodjac.SelectedValue = citac["ProizvodjacID"].ToString();
                    prozor.cbxVrstaProizvoda.SelectedValue = citac["VrstaProizvodaID"].ToString();
                    prozor.cbxDobavljac.SelectedValue = citac["DobavljacID"].ToString();
                }

                prozor.ShowDialog();
            }
            catch(ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            PocetniDataGrid(dataGridCentralni);
            izmena = false; // pri izmeni je true ali kada se izmeni postavlja se na false
        }

        private void btnIzmeniVrstuProizvoda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmena = true;

                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocniRed = selektovaniRed;
                string upit = "select * from tblVrstaProizvoda where VrstaProizvodaID = " + selektovaniRed["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                frmVrstaProizvoda prozor = new frmVrstaProizvoda();

                while (citac.Read())
                    prozor.txtNazivVrsteProizvoda.Text = citac["NazivVrsteProizvoda"].ToString();

                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnVrsteProizvoda_Click(sender, e);
            izmena = false;

        }

        private void btnIzmeniProizvodjaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmena = true;

                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocniRed = selektovaniRed;
                string upit = "select * from tblProizvodjac where ProizvodjacID = " + selektovaniRed["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                frmProizvodjac prozor = new frmProizvodjac();

                while (citac.Read())
                    prozor.txtNazivProizvodjaca.Text = citac["NazivProizvodjaca"].ToString();

                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnProizvodjaci_Click(sender, e);
            izmena = false;
        }

        private void btnIzmeniDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmena = true;

                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocniRed = selektovaniRed;
                string upit = "select * from tblDobavljac where DobavljacID = " + selektovaniRed["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                frmDobavljac prozor = new frmDobavljac();

                while (citac.Read())
                    prozor.txtNazivFirme.Text = citac["NazivFirme"].ToString();

                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnDobavljaci_Click(sender, e);
            izmena = false;
        }

        private void btnIzmeniKupca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmena = true;

                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocniRed = selektovaniRed;
                string upit = "select * from tblKupac where KupacID = " + selektovaniRed["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                frmKupac prozor = new frmKupac();

                while (citac.Read())
                    prozor.txtBrojMobilnogTelefona.Text = citac["BrojMobilnogTelefona"].ToString();

                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnKupci_Click(sender, e);
            izmena = false;
        }

        private void btnIzmeniProdavca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmena = true;

                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocniRed = selektovaniRed;
                string upit = "select * from tblProdavac where ProdavacID = " + selektovaniRed["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                frmProdavac prozor = new frmProdavac();

                while (citac.Read())
                {
                    prozor.txtUserName.Text = citac["Username"].ToString();
                    prozor.txtPassword.Text = citac["Password"].ToString();

                }

                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnProdavci_Click(sender, e);
            izmena = false;
        }

        private void btnIzmeniFiskalniRacun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                izmena = true;

                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                pomocniRed = selektovaniRed;
                string upit = "select * from tblFiskalniRacun where FiskalniRacunID = " + selektovaniRed["ID"];
                SqlCommand komanda = new SqlCommand(upit, konekcija);
                SqlDataReader citac = komanda.ExecuteReader();

                frmFiskalniRacun prozor = new frmFiskalniRacun();

                while (citac.Read())
                {
                    prozor.DatumIzdavanja.Text = citac["DatumIzdavanja"].ToString();
                    prozor.txtVremeIzdavanja.Text = citac["VremeIzdavanja"].ToString();
                    prozor.txtMestoIzdavanja.Text = citac["MestoIzdavanja"].ToString();
                    prozor.txtKolicina.Text = citac["Kolicina"].ToString();
                    prozor.txtCena.Text = citac["Iznos"].ToString();
                    prozor.cbxProdavac.SelectedValue = citac["ProdavacID"].ToString();
                    prozor.cbxProizvod.SelectedValue = citac["ProizvodID"].ToString();
                    prozor.cbxKupac.SelectedValue = citac["KupacID"].ToString();
                }
                prozor.ShowDialog();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red.", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnFiskalniRacuni_Click(sender, e);
            izmena = false;
        }

        private void btnObrisiProizvod_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView) dataGridCentralni.SelectedItems[0];
                string upit = @"Delete from tblProizvod Where ProizvodID = " + selektovaniRed["ID"];

                MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da želite da izbrišete selektovani red?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (poruka == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch(SqlException)
            {
                MessageBox.Show("Podaci koje želite da izbrišete su povezani sa podacima u drugim tabelama.","Upozorenje!",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            PocetniDataGrid(dataGridCentralni);
        }

        private void btnObrisiVrstuProizvoda_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = @"Delete from tblVrstaProizvoda Where VrstaProizvodaID = " + selektovaniRed["ID"];
               
                MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da želite da izbrišete selektovani red?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (poruka == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("Podaci koje želite da izbrišete su povezani sa podacima u drugim tabelama.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnVrsteProizvoda_Click(sender, e);
        }

        private void btnObrisiProizvodjaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = @"Delete from tblProizvodjac Where ProizvodjacID = " + selektovaniRed["ID"];

                MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da želite da izbrišete selektovani red?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (poruka == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("Podaci koje želite da izbrišete su povezani sa podacima u drugim tabelama.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnProizvodjaci_Click(sender, e);
        }

        private void btnObrisiDobavljaca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = @"Delete from tblDobavljac Where DobavljacID = " + selektovaniRed["ID"];
                
                MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da želite da izbrišete selektovani red?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (poruka == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("Podaci koje želite da izbrišete su povezani sa podacima u drugim tabelama.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }
            btnDobavljaci_Click(sender, e);
        }

        private void btnObrisiKupca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = @"Delete from tblKupac Where KupacID = " + selektovaniRed["ID"];

                MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da želite da izbrišete selektovani red?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (poruka == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("Podaci koje želite da izbrišete su povezani sa podacima u drugim tabelama.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnKupci_Click(sender, e);
        }

        private void btnObrisiProdavca_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = @"Delete from tblProdavac Where ProdavacID = " + selektovaniRed["ID"];

                MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da želite da izbrišete selektovani red?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (poruka == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("Podaci koje želite da izbrišete su povezani sa podacima u drugim tabelama.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnProdavci_Click(sender, e);
        }

        private void btnObrisiFiskalniRacun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                konekcija.Open();

                DataRowView selektovaniRed = (DataRowView)dataGridCentralni.SelectedItems[0];
                string upit = @"Delete from tblFiskalniRacun Where FiskalniRacunID = " + selektovaniRed["ID"];

                MessageBoxResult poruka = MessageBox.Show("Da li ste sigurni da želite da izbrišete selektovani red?", "Upozorenje!", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (poruka == MessageBoxResult.Yes)
                {
                    SqlCommand komanda = new SqlCommand(upit, konekcija);
                    komanda.ExecuteNonQuery();
                }
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Niste selektovali odgovarajući red!", "Obaveštenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (SqlException)
            {
                MessageBox.Show("Podaci koje želite da izbrišete su povezani sa podacima u drugim tabelama.", "Upozorenje!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            finally
            {
                if (konekcija != null)
                    konekcija.Close();
            }

            btnFiskalniRacuni_Click(sender, e);
        }
    }
}