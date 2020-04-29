using L07.db.daos;
using L07.db.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace L07
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            List<Highscore> lista = HighscoresDAO.findAll();

            foreach(Highscore hs in lista)
            {
                listBox1.Items.Add(hs);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Highscore hs = new Highscore();

            hs.Gamer = textBox1.Text;
            hs.Hscore = int.Parse(textBox2.Text);

            HighscoresDAO.insert(hs);

            textBox1.Text = "";
            textBox2.Text = "";

            button1_Click(this, null);
        }
    }
}
