using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        double sayi1 = 0;
        string secilenIslem = "";
        bool yeniGiris = true;

        public Form1()
        {
            InitializeComponent();
            if (textBox1 != null)
            {
                textBox1.Text = "0";
            }
        }

        // Rakam butonları için (0, 1, 2, 3, 4, 5, 6, 7, 8, 9)
        public void Sayi_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (textBox1.Text == "0" || yeniGiris)
            {
                textBox1.Text = btn.Text;
                yeniGiris = false;
            }
            else
            {
                textBox1.Text += btn.Text;
            }
        }

        // Virgül (,) butonu
        public void btnVirgul_Click(object sender, EventArgs e)
        {
            if (yeniGiris)
            {
                textBox1.Text = "0,";
                yeniGiris = false;
            }
            else if (!textBox1.Text.Contains(","))
            {
                textBox1.Text += ",";
            }
        }

        // İşlem butonları (+, -, *, /)
        public void Islem_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (double.TryParse(textBox1.Text, out double val))
            {
                sayi1 = val;
                secilenIslem = btn.Text;
                yeniGiris = true;
            }
        }

        // Eşittir (=) butonu
        public void btnEsittir_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox1.Text, out double sayi2)) return;
            double sonuc = 0;

            switch (secilenIslem)
            {
                case "+":
                    sonuc = sayi1 + sayi2;
                    break;
                case "-":
                    sonuc = sayi1 - sayi2;
                    break;
                case "*":
                    sonuc = sayi1 * sayi2;
                    break;
                case "/":
                    if (sayi2 != 0)
                    {
                        sonuc = sayi1 / sayi2;
                    }
                    else
                    {
                        MessageBox.Show("Sıfıra bölünemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    break;
                default:
                    return;
            }

            textBox1.Text = sonuc.ToString();
            yeniGiris = true;
        }

        // Yüzde (%) butonu
        public void btnYuzde_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double deger))
            {
                textBox1.Text = (deger / 100).ToString();
                yeniGiris = true;
            }
        }

        // Temizle (C) butonu
        public void btnC_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            sayi1 = 0;
            secilenIslem = "";
            yeniGiris = true;
        }

        // Geri Silme (<-) butonu
        public void btnSil_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 1)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
            else
            {
                textBox1.Text = "0";
                yeniGiris = true;
            }
        }
    }
}