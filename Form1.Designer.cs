namespace ders_yönetimi
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private ListBox listBox1;
        private TextBox textBoxID, textBoxAd, textBoxSoyad, textBoxEmail;
        private Button btnListele, btnEkle, btnGuncelle, btnSil;

        private void InitializeComponent()
        {
            this.listBox1 = new ListBox();
            this.textBoxID = new TextBox();
            this.textBoxAd = new TextBox();
            this.textBoxSoyad = new TextBox();
            this.textBoxEmail = new TextBox();
            this.btnListele = new Button();
            this.btnEkle = new Button();
            this.btnGuncelle = new Button();
            this.btnSil = new Button();
            this.SuspendLayout();

            this.listBox1.Location = new System.Drawing.Point(20, 200);
            this.listBox1.Size = new System.Drawing.Size(500, 200);

            this.textBoxID.Location = new System.Drawing.Point(20, 20);
            this.textBoxID.PlaceholderText = "ID (Güncelle/Sil)";

            this.textBoxAd.Location = new System.Drawing.Point(150, 20);
            this.textBoxAd.PlaceholderText = "Ad";

            this.textBoxSoyad.Location = new System.Drawing.Point(280, 20);
            this.textBoxSoyad.PlaceholderText = "Soyad";

            this.textBoxEmail.Location = new System.Drawing.Point(410, 20);
            this.textBoxEmail.PlaceholderText = "Email";

            this.btnListele.Location = new System.Drawing.Point(20, 60);
            this.btnListele.Size = new System.Drawing.Size(100, 30);

            this.btnEkle.Location = new System.Drawing.Point(130, 60);
            this.btnEkle.Size = new System.Drawing.Size(100, 30);

            this.btnGuncelle.Location = new System.Drawing.Point(240, 60);
            this.btnGuncelle.Size = new System.Drawing.Size(100, 30);

            this.btnSil.Location = new System.Drawing.Point(350, 60);
            this.btnSil.Size = new System.Drawing.Size(100, 30);

            this.ClientSize = new System.Drawing.Size(550, 450);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.textBoxID);
            this.Controls.Add(this.textBoxAd);
            this.Controls.Add(this.textBoxSoyad);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.btnListele);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnGuncelle);
            this.Controls.Add(this.btnSil);
            this.Name = "Form1";
            this.Text = "Öğrenci CRUD";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
