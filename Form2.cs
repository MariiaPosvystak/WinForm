using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Media;
using System.Text;
using System.Windows.Forms;

namespace FormElements
{
    public partial class Form2 : Form
    {
        TreeView tree;
        Button btn;
        Label lbl;
        PictureBox pic;
        PictureBox picture;
        CheckBox c_btn1, c_btn2;
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

            picture = new PictureBox();
            picture.Size = new Size(100, 100);
            picture.Location = new Point(150, 60);
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
            picture.Image = Image.FromFile(@"..\..\Images\stich.png");
            picture.MouseWheel += Picture;

            tree.Nodes.Add(tn);
            this.Controls.Add(tree);
        }
        int click = 0;

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            lbl.BackColor = Color.Transparent;
            Form1 Form = new Form1();
            Form.Show();
            this.Hide();
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            lbl.BackColor = Color.FromArgb(200, 10, 20);
        }
        private void Tree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Text == "PictureBox")
            {
                this.Controls.Add(picture);
            }
            else if (e.Node.Text == "Checkbox")
            {
                c_btn1 = new CheckBox();
                c_btn1.Text = "Vali mind";
                c_btn1.Size = new Size(c_btn1.Text.Length * 2, 2);
                c_btn1.Location = new Point(310, 420);
                c_btn1.CheckedChanged += CheckBox;
                c_btn2 = new CheckBox();
                c_btn2.Size = new Size(100, 100);
                c_btn2.Image = Image.FromFile(@"..\..\Images\about.png");
                c_btn2.Location = new Point(310, 450);
                this.Controls.Add(c_btn1);
                this.Controls.Add(c_btn2);
            }
            else if (e.Node.Text == "RadioButton")
            {
                r_btn1 = new RadioButton();
                r_btn1.Text = "Must teema";
                r_btn1.Location = new Point(200, 420);
                r_btn2 = new RadioButton();
                r_btn2.Text = "Valge teema";
                r_btn2.Location = new Point(200, 440);
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
                    string text = Interaction.InputBox("Sisesta siia mingi tekst", "InputBox", "Mingi tekst");
                    if (MessageBox.Show("Kas tahad tekst saada Tekskastisse?", "Teksti salvestamine", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        lbl.Text = text;
                        Controls.Add(lbl);
                    }
                    else
                    {
                        lbl.Text = "Siis mina lisan oma teksti!";
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
                tabC.Location = new Point(450, 50);
                tabC.Size = new Size(300, 200);
                tabP1 = new TabPage("Esimene pilt");
                picture.Image = Image.FromFile(@"..\..\Images\naine.png");
                tabP1.Controls.Add(picture);
                tabP2 = new TabPage("Teine pilt");
                picture.Image = Image.FromFile(@"..\..\Images\kass.png");
                tabP2.Controls.Add(picture);
                //Teeme ise!
                tabP3 = new TabPage("Kolmas pilt");
                picture.Image = Image.FromFile(@"..\..\Images\stich.png");
                tabP3.Controls.Add(picture);
                tabC.Controls.Add(tabP1);
                tabC.Controls.Add(tabP2);
                tabC.Controls.Add(tabP3);
            }
            else if (e.Node.Text == "ListBox")
            {
                lb = new ListBox();
                lb.Items.Add("Must");
                lb.Items.Add("Valge");
                lb.Items.Add("Punane");
                lb.Items.Add("Sinine");
                lb.Items.Add("Roheline");
                lb.Location = new Point(150, 120);
                lb.SelectedIndexChanged += new EventHandler(ListBox);
                this.Controls.Add(lb);
            }
            else if (e.Node.Text == "MainMenu")
            {
                MainMenu menu = new MainMenu();
                MenuItem menuFile = new MenuItem("File");
                menuFile.MenuItems.Add("Exit", new EventHandler(menuFile_Exit_Select));
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
                this.Size = new Size(1000, 1000);
                pic.BorderStyle = BorderStyle.Fixed3D;
                c_btn1.Text = "Teeme väiksem";
                c_btn1.Font = new Font("Arial", 36, FontStyle.Bold);
                t = false;
            }
            else
            {
                this.Size = new Size(700, 500);
                c_btn1.Text = "Suurendame";
                c_btn1.Font = new Font("Arial", 36, FontStyle.Regular);
                t = true;
            }
        }
        private void Radio(object sender, EventArgs e)
        {
            if (r_btn1.Checked)
            {
                this.BackColor = Color.Black;
                r_btn2.ForeColor = Color.White;
                r_btn1.ForeColor = Color.White;
            }
            else if (r_btn2.Checked)
            {
                this.BackColor = Color.White;
                r_btn2.ForeColor = Color.Black;
                r_btn1.ForeColor = Color.Black;
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
    }
}
