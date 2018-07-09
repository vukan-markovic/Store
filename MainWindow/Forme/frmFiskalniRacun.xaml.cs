using System.Windows;
using System.Data;
using System.Data.SqlClient;
using System;

namespace Trafika.Forme
{
    public partial class frmFiskalniRacun : Window
    {
        public SqlConnection konekcija = Konekcija.KreirajKonekciju();

        public frmFiskalniRacun()
        {
            InitializeComponent();
            DatumIzdavanja.Focus();

            try
            {
                konekcija.Open();

                //cbxProdavac

                string vratiProdavce = "select ProdavacID, Username as Prodavac from tblProdavac";
                DataTable dataTableProdavci = new DataTable();
                SqlDataAdapter dataAdapterProdavci = new SqlDataAdapter(vratiProdavce, konekcija);

                dataAdapterProdavci.Fill(dataTableProdavci);
                cbxProdavac.ItemsSource = dataTableProdavci.DefaultView;

                //cbxKupac

                string vratiKupce = "select KupacID, BrojMobilnogTelefona from tblKupac";
                DataTable dataTableKupci = new DataTable();
                SqlDataAdapter dataAdapterKupci = new SqlDataAdapter(vratiKupce, konekcija);

                dataAdapterKupci.Fill(dataTableKupci);
                cbxKupac.ItemsSource = dataTableKupci.DefaultView;

                //cbxProizvod

                string vratiProizvode = "select ProizvodID, Naziv + ' ' + ltrim(str(Cena)) + ' din.' as Proizvod from tblProizvod";
                DataTable dataTableProizvodi = new DataTable();
                SqlDataAdapter dataAdapterProizvodi = new SqlDataAdapter(vratiProizvode, konekcija);

                dataAdapterProizvodi.Fill(dataTableProizvodi);
                cbxProizvod.ItemsSource = dataTableProizvodi.DefaultView;
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
                    string update = @"update tblFiskalniRacun Set DatumIzdavanja = '" + DatumIzdavanja.SelectedDate + "', VremeIzdavanja = '" + txtVremeIzdavanja.Text
                        + "', MestoIzdavanja =  '" + txtMestoIzdavanja.Text + "', Iznos = " + (double.Parse(txtCena.Text) * int.Parse(txtKolicina.Text)).ToString() +
                        ", Kolicina = " + txtKolicina.Text + ", ProdavacID= " + cbxProdavac.SelectedValue + ", ProizvodID = " + cbxProizvod.SelectedValue +
                        ", KupacID = " + cbxKupac.SelectedValue + " Where FiskalniRacunID = " + red["ID"];

                    SqlCommand cmd = new SqlCommand(update, konekcija);
                    cmd.ExecuteNonQuery();
                    MainWindow.pomocniRed = null;
                    this.Close();
                }
                else
                {
                    string insert = @"insert into tblFiskalniRacun(DatumIzdavanja, VremeIzdavanja, MestoIzdavanja, Iznos, Kolicina, ProdavacID, ProizvodID, KupacID)
                                      values('" + DatumIzdavanja.SelectedDate + "', '" + txtVremeIzdavanja.Text + "', '" + txtMestoIzdavanja.Text + "', " +
                                      (int.Parse(txtCena.Text) * int.Parse(txtKolicina.Text)).ToString() + ", " + txtKolicina.Text + ", " + cbxProdavac.SelectedValue +
                                      ", " + cbxProizvod.SelectedValue + ", " + cbxKupac.SelectedValue + ");";

                    SqlCommand cmd = new SqlCommand(insert, konekcija);
                    cmd.ExecuteNonQuery();
                    this.Close();
                }
            }
            catch (Exception)
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