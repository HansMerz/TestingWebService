using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using Newtonsoft.Json;

namespace ProbandoWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            String url = "https://web-service-to-csharp-hansmerz.c9users.io/test.php";
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);
            var result = JsonConvert.DeserializeObject<DataTable>(json);            
            
            foreach (var j in m)
            {
                dataGridView1.Rows.Add(j.Nombres, j.Apellidos, j.docPersona, j.Correo);
                //MessageBox.Show("Nombres: "+j.Nombres+" Apellidos: "+ j.Apellidos + " Documento: "+ j.docPersona + " Correo: "+ j.Correo);                
            }            
        }
    }
}
