using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mesaj
{
    public partial class Form1 : Form
    {
       
        private void button_Click(object sender, EventArgs e)
        {
            string mesaj = Convert.ToString(textBox1.Text);
            int mAdet = Convert.ToInt16(textBox2.Text);
            for(int i=1; i<=mAdet; i++)
            {
                MessageBox.Show(+i +"-" + mesaj);
            }
        }
    }
}
