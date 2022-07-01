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
               
            titulos = new List<string>();

            string url = "https://verne.elpais.com/verne/2014/11/06/articulo/1415256670_000066.html";
            //url += "="+(i+1);
            HtmlWeb dWEb = new HtmlWeb();
            HtmlAgilityPack.HtmlDocument doc = dWEb.Load(url);
            int contador = 1;
            
            string body = doc.DocumentNode.CssSelect(".twitter-tweet").First().InnerHtml;
            
            foreach (var Nodo in doc.DocumentNode.CssSelect(".twitter-tweet"))
            {
                
                titulos.Add(Nodo.InnerText);
                this.listBox1.Items.Add(contador + ".- " + Nodo.InnerText);
                contador++;
            }


        }
         public char[] convertStringToArray(string useString)
         {             
            
            // Creating array of string length 
            char[] ch = new char[useString.Length];

            // Copy character by character into array 
            for (int i = 0; i < useString.Length; i++)
            {
                ch[i] = useString[i];
            }
            return ch;

        }

        public string transformTweet(string etiqueta)
        {
            char[] charArray = convertStringToArray(etiqueta);

            string newText = "";

            for (int i = 0; i < charArray.Length; i++)
            {
                if(charArray[i] == '<')
                {
                    i = i + 2;
                    while (charArray[i] != '<')
                    {
                        newText += charArray[i].ToString();
                    }
                }
            }

            return newText;
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
