using Chat.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_chat.win
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            var cateBL = new CategoriaBL();
            var Lista_categorias = cateBL.MostrarCategorias();
            listaCategoriaBindingSource.DataSource = Lista_categorias;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
