using RedSocial.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RedSocial.Win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var LibroBL = new LibroBL();
            var listadeLibros = LibroBL.ObtenerLibros();

            listadeProductosBindingSource.DataSource = listadeLibros;
        }
    }
}
