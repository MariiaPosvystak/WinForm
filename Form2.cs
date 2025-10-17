using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TreeView;

namespace FormElements
{
    public partial class Form2 : Form
    {
        TreeView tree;
        Label lbl, text, text1, text2, text3;
        PictureBox pic, picture, pic1, pic2, pic3;
        CheckBox c_btn1, c_btn2, c_btn3, c_btn4;
        RadioButton r_btn1, r_btn2;
        TabControl tabC;
        TabPage tabP1, tabP2, tabP3;
        ListBox lb;
        TextBox tb;
        bool t = true;
        public Form2()
        {
            this.Height = 600;
            this.Width = 800;
            this.Text = "Vorm elementidega";
            tree = new TreeView();
            tree.Dock = DockStyle.Left;
            tree.Width = 145;
            tree.AfterSelect += Tree_AfterSelect;
            TreeNode tn = new TreeNode("Elemendid");
            tn.Nodes.Add(new TreeNode("PictureBox"));
            tn.Nodes.Add(new TreeNode("Checkbox"));
            tn.Nodes.Add(new TreeNode("RadioButton"));
            tn.Nodes.Add(new TreeNode("MessageBox"));
            tn.Nodes.Add(new TreeNode("TabControl"));
            tn.Nodes.Add(new TreeNode("ListBox"));
            tn.Nodes.Add(new TreeNode("MainMenu"));

            lbl = new Label();
            lbl.Text = "Tere päevast!";
            lbl.Font = new Font("Georgia", 24);
            lbl.Size = new Size(400, 30);
            lbl.Location = new Point(150, 0);

            picture = new PictureBox();
            picture.Size = new Size(100, 100);
            picture.Location = new Point(150, 100);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = Image.FromFile(@"..\..\Images\stich.png");
            picture.MouseWheel += Picture;

            pic = new PictureBox();
            pic.Image = Image.FromFile(@"..\..\Images\b.png");
            pic.Size = new Size(1000, 1000);
            pic.Location = new Point(140, 400);

            text = new Label();
            text.Text = $"Ivano-Frankivskist pärit, kuulsa kirjaniku Juri Igorovitš Andruhovitši tütar. " +
                $"Armastan raamatuid ja kirjandust – vähe, enne kui mu ema Nina Mikolaivna raamatukogus töötas." +
                $" Seejärel algas õpingud loodusteaduste lütseumis ja Ukraina Meditsiiniakadeemias." +
                $"Tema kirjanduslik karjäär algas 2002. aastal romaaniga „Miili suvi“. " +
                $"Kuni 2007. aastani ilmus veel kolm raamatut: „Vanad inimesed“, " +
                $"„Oma meeste naised“, „Somga“. „Somga“ uuenduslikkus on tähelepanuväärne; " +
                $"enne seda illustreeris autor oma romaani enam kui 70 aastat omaenda pisikestega. " +
                $"Pärast seda vajas ta sel saatuslikul ajal pausi. Kõik toimuv, emaks olemine, sealhulgas " +
                $"kõik muu, osutus ilmutuseks. Romaan „Felix Austria” ilmus 2014. aasta kevadel. " +
                $"Autori arvates pole see täielikult ajalooline, vaid pigem dekoratsioon, kuigi mul oli " +
                $"võimalus palju uurida ja õppida minevikust palju saladusi parfüümide ja naisterõivaste " +
                $"kohta XX loos. Ajakirjad, raamatud, muud asjad. Romaanis armastame tänapäeva " +
                $"Ivano-Frankivskit ja Andruhovitš kirjutas selle raamatu Poolas Gaude Polonia stipendiumi " +
                $"toel. Raamat ei olnud mitte ainult Ukrainas praegune bestseller, vaid näitas märke ka " +
                $"kaugel oma piiridest. Sophia ei suuda luua maagilist elementi, mida paljude inimeste " +
                $"ellu sisendada, sest see on kuum, mis võib seejärel põhjustada ohtlikke häireid. " +
                $"Tal on tahe neist aaretest vabaneda, mis tähendab „ja arendada neid kõigi rõõmuks ja " +
                $"hüvanguks, kes soovivad”.Järgneme romaanile „Amadoka”, mille kallal autor töötas kuus " +
                $"korda. Müstiline järv, mis kunagi asus Ukraina Podill'i ja Volina vahel ning seejärel " +
                $"sõja ajal, stalinlike repressioonide ja holokausti ajal nagu tuhanded ja miljonid inimesed " +
                $"unustusse vajus. Looduspildid põimunud elu ja ajaloo kujutistega. Lisaks kirjutamisele " +
                $"tegeleb proua Sofia tõlkimisega inglise ja poola keelest (Manuela Gretkovskaja romaan " +
                $"„Eurooplane“ (2006).";
            text.Font = new Font("Tahoma", 12);
            text.Size = new Size(700, 400);
            text.Location = new Point(150, 400);

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }
        int click = 0;
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "PictureBox")
            {
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "Checkbox")
            {
                c_btn1 = new CheckBox();
                c_btn1.Text = "Näita pilt";
                c_btn1.Size = new Size(c_btn1.Text.Length * 20, 20);
                c_btn1.Location = new Point(700, 100);
                c_btn1.CheckedChanged += CheckBox;
                c_btn2 = new CheckBox();
                c_btn2.Text = "Näita info";
                c_btn2.Size = new Size(c_btn2.Text.Length * 20, 20);
                c_btn2.Location = new Point(700, 120);
                c_btn2.CheckedChanged += CheckBox_1;
                c_btn3 = new CheckBox();
                c_btn3.Text = "Pilt";
                c_btn3.Size = new Size(c_btn2.Text.Length * 20, 20);
                c_btn3.Location = new Point(700, 160);
                c_btn3.CheckedChanged += CheckBox_2;
                c_btn4 = new CheckBox();
                c_btn4.Text = "Tere!";
                c_btn4.Size = new Size(c_btn2.Text.Length * 20, 20);
                c_btn4.Location = new Point(700, 140);
                c_btn4.CheckedChanged += CheckBox_3;
                this.Controls.Add(c_btn1);
                this.Controls.Add(c_btn2);
                this.Controls.Add(c_btn3);
                this.Controls.Add(c_btn4);
            }
            else if (e.Node.Text == "RadioButton")
            {
                r_btn1 = new RadioButton();
                r_btn1.Text = "Punane tekst";
                r_btn1.Location = new Point(400, 100);
                r_btn2 = new RadioButton();
                r_btn2.Text = "Roheline tekst";
                r_btn2.Location = new Point(400, 120);
                this.Controls.Add(r_btn1);
                this.Controls.Add(r_btn2);
                r_btn1.CheckedChanged += new EventHandler(Radio);
                r_btn2.CheckedChanged += new EventHandler(Radio);
            }
            else if (e.Node.Text == "MessageBox")
            {
                MessageBox.Show("MessageBox", "Kõige lihtsam aken");
                var answer = MessageBox.Show("Tahad InputBoxi näha?", "Aken koos nupudega", MessageBoxButtons.YesNo);
                if (answer == DialogResult.Yes)
                {
                    string text = Interaction.InputBox("Sisesta siia oma nimi", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad nimi saada Tekskastisse?", "Nimi salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = "Sinu nimi on: " + text;
                        Controls.Add(lbl);
                    }
                    else
                    {
                        lbl.Text = "Siis mina lisan oma nimi!";
                        Controls.Add(lbl);
                    }
                }
                else
                {
                    MessageBox.Show("Veel MessageBox", "Kõige lihtsam aken");
                }
            }
            else if (e.Node.Text == "TabControl")
            {
                tabC = new TabControl();
                tabC.Location = new Point(450, 200);
                tabC.Size = new Size(300, 200);
                tabP1 = new TabPage("Esimene pilt");
                pic1 = new PictureBox();
                pic1.SizeMode = PictureBoxSizeMode.StretchImage;
                pic1.Image = Image.FromFile(@"..\..\Images\naine.png");
                pic1.Size = new Size(200, 150);
                pic1.Location = new Point(0, 40);
                text1 = new Label();
                text1.Text = "Esimene pilt";
                tabP1.Controls.Add(pic1);
                tabP1.Controls.Add(text1);

                tabP2 = new TabPage("Teine pilt");
                pic2 = new PictureBox();
                pic2.SizeMode = PictureBoxSizeMode.StretchImage;
                pic2.Image = Image.FromFile(@"..\..\Images\kass.png");
                pic2.Size = new Size(200, 150);
                pic2.Location = new Point(0, 40);
                text2 = new Label();
                text2.Text = "Teine pilt";
                tabP2.Controls.Add(pic2);
                tabP2.Controls.Add(text2);

                tabP3 = new TabPage("Kolmmas pilt");
                pic3 = new PictureBox();
                pic3.SizeMode = PictureBoxSizeMode.StretchImage;
                pic3.Image = Image.FromFile(@"..\..\Images\puu.png");
                pic3.Size = new Size(200, 150);
                pic3.Location = new Point(0, 40);
                text3 = new Label();
                text3.Text = "Kolmas pilt";
                tabP3.Controls.Add(pic3);
                tabP3.Controls.Add(text3);
                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
                this.Controls.Add(tabC);

            }
            else if (e.Node.Text == "ListBox")
            {
                lb = new ListBox();
                lb.Items.Add("Must");
                lb.Items.Add("Valge");
                lb.Items.Add("Punane");
                lb.Items.Add("Sinine");
                lb.Items.Add("Roheline");
                lb.Location = new Point(250, 100);
                lb.SelectedIndexChanged += new EventHandler(ListBox);
                this.Controls.Add(lb);
            }
            else if (e.Node.Text == "MainMenu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuFile = new MenuItem("File");
                menuFile.MenuItems.Add("Exit", new EventHandler(menuFile_Exit_Select));
                menuFile.MenuItems.Add("Label", new EventHandler(Label));
                menu.MenuItems.Add(menuFile);
                this.Menu = menu;
            }
            else if (e.Node.Text == "Tekst")
            {
                tb = new TextBox();
                tb.GotFocus += Tb_GotFocus;
                tb.LostFocus += Tb_LostFocus;
                //tree.Nodes.Add(tn);
                this.Controls.Add(tree);
            }
        }

        private void Tb_GotFocus(object sender, EventArgs e)
        {
            if (tb.ForeColor == Color.Gray)
            {
                tb.Text = "";
                tb.ForeColor = Color.Black;
            }
        }
        private void Tb_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tb.Text))
            {
                tb.ForeColor = Color.Gray;
                tb.Text = "Sisesta tekst siia...";
            }
        }
        //Ulesanned
        int wheel = 0;
        private void Picture(object sender, EventArgs e)
        {
            string[] images = { "kass.png", "naine.png", "puu.png" };
            string fail = images[wheel];
            picture.Image = Image.FromFile(@"..\..\Images\" + fail);
            wheel++;
            if (wheel == 3) { wheel = 0; }
        }
        private void CheckBox(object sender, EventArgs e)
        {
            if (t)
            {
                this.Controls.Add(pic);
                this.Size = new Size(850, 830);
                c_btn1.Text = "Peida pilt";
                t = false;
            }
            else
            {
                this.Controls.Remove(pic);
                this.Size = new Size(800, 600);
                c_btn1.Text = "Näita pilt";
                t = true;
            }
        }
        private void CheckBox_1(object sender, EventArgs e)
        {
            if (t)
            {
                this.Controls.Add(text);
                this.Size = new Size(880, 830);
                c_btn2.Text = "Peida info";
                t = false;
            }
            else
            {
                this.Controls.Remove(text);
                this.Size = new Size(800, 600);
                c_btn2.Text = "Näita info";
                t = true;
            }
        }
        private void CheckBox_2(object sender, EventArgs e)
        {
            if (t)
            {
                c_btn3.Image = Image.FromFile(@"..\..\Images\puu.png");
                c_btn3.Size = new Size(200, 200);
                this.Size = new Size(820, 600);
                t = false;
            }
            else
            {
                c_btn3.Text = "Pilt";
                c_btn3.Image = null;
                c_btn3.Size = new Size(100, 30);
                t = true;
            }
        }
        private void CheckBox_3(object sender, EventArgs e)
        {
            if (t)
            {
                c_btn4.Text = "Nägemist!";
                t = false;
            }
            else
            {
                c_btn4.Text = "Tere!";
                t = true;
            }
        }
        private void Radio(object sender, EventArgs e)
        {
            if (r_btn1.Checked)
            {
                tree.ForeColor = Color.Red;
                tree.ForeColor = Color.Red;
            }
            else if (r_btn2.Checked)
            {
                tree.ForeColor = Color.Green;
                tree.ForeColor = Color.Green;
            }
        }
        private void ListBox(object sender, EventArgs e)
        {
            switch (lb.SelectedItem.ToString())
            {
                case ("Must"): 
                    tree.BackColor = Color.SlateGray; 
                    tree.ForeColor = Color.White;
                    BackColor = Color.Black;
                    break;
                case ("Valge"): 
                    tree.BackColor = Color.WhiteSmoke;
                    tree.ForeColor = Color.Gray;
                    BackColor = Color.White;
                    break;
                case ("Punane"): 
                    tree.BackColor = Color.Red;
                    tree.ForeColor = Color.Maroon;
                    BackColor = Color.DarkRed;
                    break;
                case ("Sinine"): 
                    tree.BackColor = Color.Aqua;
                    tree.ForeColor = Color.Blue;
                    BackColor = Color.CornflowerBlue;
                    break;
                case ("Roheline"): 
                    tree.BackColor = Color.MediumSeaGreen;
                    tree.ForeColor = Color.Lime;
                    BackColor = Color.LightGreen;
                    break;
            }
        }
        private void menuFile_Exit_Select(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Label(object sender, EventArgs e)
        {
            this.Controls.Add(lbl);
        }
    }
}
