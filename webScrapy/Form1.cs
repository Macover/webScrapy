using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webScrapy
{
    public partial class Form1 : Form
    {
        private List<string> titulos;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Enabled = false;
            this.txtB_input.Enabled = true;
            this.btnBuscar.Enabled = true;

            int numeroPaginas = 10;
            
            titulos = new List<string>();            

            for (int i = 0; i < numeroPaginas; i++)
            {
                string url = "https://www.bbc.com/mundo/topics/cyx5krnw38vt?page";
                url += "="+(i+1);
                HtmlWeb dWEb = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = dWEb.Load(url);
                int contador = 1;
                foreach (var Nodo in doc.DocumentNode.CssSelect(".bbc-uk8dsi"))
                {
                    titulos.Add(Nodo.InnerHtml);
                    this.listBox1.Items.Add(contador + ".- " + Nodo.InnerHtml);
                    contador++;
                }                
            }
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {            
            string valorABuscar = this.txtB_input.Text;
            this.listBox1.Items.Clear();
            foreach (var titulo in titulos)
            {
                if (titulo.Contains(valorABuscar))
                {                    
                    this.listBox1.Items.Add(titulo);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bbc.com/mundo/topics/cyx5krnw38vt?page=1");
        }
    }
}
