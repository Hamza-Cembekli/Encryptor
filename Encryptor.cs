namespace Encryptor
{
    public partial class Encryptor : Form
    {
        public Encryptor()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string yazi = textBox1.Text;
            listBox1.Items.Add(yazi);
            
            char[] karakterler = yazi.ToCharArray();
            
            int uzunluk = karakterler.Length;
          
            string[] kodlar = new string[uzunluk];
            for (int i = 0; i < uzunluk; i++)
            {
                kodlar[i] = ((int)karakterler[i]).ToString();
                listBox1.Items.Add(kodlar[i]);
            }
            
            string siralikodlar = "";
            int j = 0;
            while (j < kodlar.Length)
            {
                string asciikodu = kodlar[j];
        
                int eklenecek = Convert.ToInt16(4 - asciikodu.Length);
       
                for (int i = 0; i < eklenecek; i++)
                {
                    asciikodu = asciikodu.Insert(0, "0");

                }
                siralikodlar += asciikodu;
                listBox1.Items.Add(asciikodu);
                j++;
            }
            listBox1.Items.Add(siralikodlar);
           
            string sifre = "";
            j = 0;
            while (j < siralikodlar.Length / 2)
            {
                sifre += siralikodlar.Substring(j, 1);
               
                sifre += siralikodlar.Substring(siralikodlar.Length - j - 1, 1);
                j++;
            }
            label2.Text = sifre;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sifre = label2.Text;
            string ilkyari = "";
            string sonyari = "";
         
            for (int i = 0; i < sifre.Length; i += 2)
            {
                ilkyari += sifre.Substring(i, 1);
                sonyari = sonyari.Insert(0, sifre.Substring(i + 1, 1));
            }
            string siralikodlar = ilkyari + sonyari;
            string yazi = "";
            int k = 0;
            while (k < siralikodlar.Length)
            {
                int asclikodu = Convert.ToInt16(siralikodlar.Substring(k, 4));
                yazi += (char)asclikodu;
                k += 4;
            }

            sifre2.Text = yazi;
        } 
    }
}