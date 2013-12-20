using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SchemesGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Point s = new Point();
            Graphics g = this.CreateGraphics();
            DrawBlocks b = new DrawBlocks(g);
            Block bl = new Block();
            s.X = 100;
            s.Y = 100;
            bl.Start = s;
            bl.Text = "begin";
            bl.Type = BlockType.Terminator;
            //b.DrawTerminator(bl);
            //b.DrawSubprocess(bl);
            b.DrawInput(bl);
        }
    }
}
