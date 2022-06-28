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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int numeroPaginas = 10;
            
            List<string> titulos = new List<string>();

            for (int i = 0; i < numeroPaginas; i++)
            {
                string url = "https://www.bbc.com/mundo/topics/cyx5krnw38vt?page";
                url += "="+(i+1);
                HtmlWeb dWEb = new HtmlWeb();
                HtmlAgilityPack.HtmlDocument doc = dWEb.Load(url);

                //HtmlNode Body = doc.DocumentNode.CssSelect("body").First();
                //string bodyHtml = Body.InnerHtml;

                foreach (var Nodo in doc.DocumentNode.CssSelect(".bbc-uk8dsi"))
                {
                    titulos.Add(Nodo.InnerHtml);
                }
            }

        }
    }
}
