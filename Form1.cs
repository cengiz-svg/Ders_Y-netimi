using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ders_yönetimi
{
    public partial class Form1 : Form
    {
        string connectionString = "server=localhost;user=root;database=ders_yonetimi;port=3306;password=23456789";
        MySqlConnection conn;

        public Form1()
        {
            InitializeComponent();
            conn = new MySqlConnection(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnListele.Text = "Listele";
            btnEkle.Text = "Ekle";
            btnGuncelle.Text = "Güncelle";
            btnSil.Text = "Sil";

            btnListele.Click += BtnListele_Click;
            btnEkle.Click += BtnEkle_Click;
            btnGuncelle.Click += BtnGuncelle_Click;
            btnSil.Click += BtnSil_Click;
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            try
            {
                conn.Open();
                string sql = "SELECT ogrenci_id, ogrenci_ad, ogrenci_soyad, ogrenci_email FROM ogrenci";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    listBox1.Items.Add($"{dr["ogrenci_id"]} - {dr["ogrenci_ad"]} {dr["ogrenci_soyad"]} ({dr["ogrenci_email"]})");
                }

                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        
        private void BtnEkle_Click(object sender, EventArgs e)
        {
            string ad = textBoxAd.Text.Trim();
            string soyad = textBoxSoyad.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            if (ad == "" || soyad == "" || email == "")
            {
                MessageBox.Show("Lütfen Ad, Soyad ve Email alanlarını doldurun!");
                return;
            }

            try
            {
                conn.Open();
                string sql = "INSERT INTO ogrenci (ogrenci_id, ogrenci_ad, ogrenci_soyad, ogrenci_email, bolum_id, danisman_id) " +
                             "VALUES (@id, @ad, @soyad, @email, 1, 1001)";

                Random rnd = new Random();
                int yeniID = rnd.Next(3000, 9999);

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", yeniID);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@email", email);

                cmd.ExecuteNonQuery();
                MessageBox.Show("Öğrenci eklendi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxID.Text.Trim(), out int id))
            {
                MessageBox.Show("Geçerli bir ID girin!");
                return;
            }

            string ad = textBoxAd.Text.Trim();
            string soyad = textBoxSoyad.Text.Trim();
            string email = textBoxEmail.Text.Trim();

            try
            {
                conn.Open();
                string sql = "UPDATE ogrenci SET ogrenci_ad=@ad, ogrenci_soyad=@soyad, ogrenci_email=@email WHERE ogrenci_id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@ad", ad);
                cmd.Parameters.AddWithValue("@soyad", soyad);
                cmd.Parameters.AddWithValue("@email", email);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Öğrenci güncellendi!");
                else
                    MessageBox.Show("Bu ID bulunamadı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBoxID.Text.Trim(), out int id))
            {
                MessageBox.Show("Geçerli bir ID girin!");
                return;
            }

            try
            {
                conn.Open();
                string sql = "DELETE FROM ogrenci WHERE ogrenci_id=@id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id", id);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                    MessageBox.Show("Öğrenci silindi!");
                else
                    MessageBox.Show("Bu ID bulunamadı!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
