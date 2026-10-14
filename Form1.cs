using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Kullanıcının listBox2 üzerinde seçim yapma sırasını takip eden liste
        List<object> secimKaydi = new List<object>();

        public Form1()
        {
            InitializeComponent();
        }

        // 1. BUTON: 10 ile 500 arasında 20 rastgele sayı üretir; tekleri küçükten büyüğe, çiftleri büyükten küçüğe sıralar
        private void button1_Click(object sender, EventArgs e)
        {
            // Listeleri ve seçim hafızasını sıfırla
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            secimKaydi.Clear();

            Random rnd = new Random();

            List<int> tekler = new List<int>();
            List<int> ciftler = new List<int>();

            // 10 - 500 aralığında 20 adet rastgele sayı üretimi
            for (int i = 0; i < 20; i++)
            {
                int uretilenSayi = rnd.Next(10, 501);

                if (uretilenSayi % 2 == 0)
                {
                    ciftler.Add(uretilenSayi);
                }
                else
                {
                    tekler.Add(uretilenSayi);
                }
            }

            // Tek sayıları artan sırada sırala ve listBox2'ye aktar
            tekler.Sort();
            foreach (int t in tekler)
            {
                listBox2.Items.Add(t);
            }

            // Çift sayıları azalan sırada sırala ve listBox3'e aktar
            ciftler.Sort();
            ciftler.Reverse();
            foreach (int c in ciftler)
            {
                listBox3.Items.Add(c);
            }
        }

        // 2. BUTON: listBox2'de tıklanma sırasına göre seçilen ögeleri listBox3'e ekler
        private void button2_Click(object sender, EventArgs e)
        {
            // Kaydedilen tıklama sırasına göre aktarım işlemi
            foreach (var oge in secimKaydi)
            {
                listBox3.Items.Add(oge);
            }
        }

        // listBox2'de seçim yapıldıkça veya seçim kaldırıldıkça tıklama sırasını günceller
        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Yeni seçilen öğeleri sırayla listeye dahil et
            foreach (var secim in listBox2.SelectedItems)
            {
                if (!secimKaydi.Contains(secim))
                {
                    secimKaydi.Add(secim);
                }
            }

            // Seçimi iptal edilen öğeleri listeden düşür
            for (int i = secimKaydi.Count - 1; i >= 0; i--)
            {
                if (!listBox2.SelectedItems.Contains(secimKaydi[i]))
                {
                    secimKaydi.RemoveAt(i);
                }
            }
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Tasarım tarafında sorun yaratmaması için bırakıldı
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Ek buton işlevi
        }
    }
}
