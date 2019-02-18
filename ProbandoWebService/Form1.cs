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
using System.IO;
using System.Net.Http;

namespace ProbandoWebService
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

           

            /* System.Net.WebRequest request = System.Net.WebRequest.Create("https://web-service-to-csharp-hansmerz.c9users.io/test.php?url=123");
             request.Method = "POST";
             string postData = "url";            
             byte[] data = Encoding.UTF8.GetBytes(postData);
             request.ContentLength = data.Length;
             request.ContentType = "application/x-www-form-urlencoded";
             Stream dataStream = request.GetRequestStream();
             dataStream.Write(data, 0, data.Length);
             dataStream.Close();

             WebResponse response = request.GetResponse();
             Console.WriteLine(((HttpWebResponse)response).StatusDescription);
             dataStream = response.GetResponseStream();
             StreamReader reader = new StreamReader(dataStream);

             string responseFromServer = reader.ReadToEnd();
             Console.WriteLine(responseFromServer);

             reader.Close();
             dataStream.Close();
             response.Close();*/


            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String url = "https://web-service-to-csharp-hansmerz.c9users.io/test.php?url=PEOPLE";
            var json = new WebClient().DownloadString(url);
            dynamic m = JsonConvert.DeserializeObject(json);

            foreach (var j in m)
            {
                dataGridView1.Rows.Add(j.Nombres, j.Apellidos, j.docPersona, j.Correo);
                //MessageBox.Show("Nombres: "+j.Nombres+" Apellidos: "+ j.Apellidos + " Documento: "+ j.docPersona + " Correo: "+ j.Correo);                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String data = "https://web-service-to-csharp-hansmerz.c9users.io/test.php?url=SUCUR";
            var json2 = new WebClient().DownloadString(data);
            dynamic me = JsonConvert.DeserializeObject(json2);

            foreach (var j in me)
            {
                //dataGridView1.Rows.Add(j.Nombres, j.Apellidos, j.docPersona, j.Correo);
                MessageBox.Show("Nombre: " + j.Nombre + " Dirección: " + j.Direccion);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ASCIIEncoding encoding = new ASCIIEncoding();

            string postData = "test=123";
            byte[] data = encoding.GetBytes(postData);

            System.Net.WebRequest request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create("https://web-service-to-csharp-hansmerz.c9users.io/test.php");
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;

            Stream steam = request.GetRequestStream();
            steam.Write(data, 0, data.Length);
            steam.Close();

            WebResponse response = request.GetResponse();
            steam = response.GetResponseStream();            

            using (StreamReader sr = new StreamReader(steam))
            {
                while (sr.Peek() >= 0)
                {
                    MessageBox.Show("Alv "+ sr.ReadLine());                    
                }
            }
            /*foreach (var j in me)
            {
                //dataGridView1.Rows.Add(j.Nombres, j.Apellidos, j.docPersona, j.Correo);
                MessageBox.Show("idDetalle: " + j.idDetalle + " Cantidad: " + j.Cantidad);
            }*/
        }

        /*private static string ConcatParams(Dictionary parameters)
        {
            bool FirstParam = true;
            StringBuilder Parametros = null;

            if (parameters != null)
            {
                Parametros = new StringBuilder();
                foreach (KeyValuePair param in parameters)
                {
                    Parametros.Append(FirstParam ? "" : "&");
                    Parametros.Append(param.Key + "=" + System.Web.HttpUtility.UrlEncode(param.Value));
                    FirstParam = false;
                }
            }            
        }*/

        /*
           //Concatenamos los parametros, OJO: antes del primero debe estar el caracter "?"
                //string parametrosConcatenados = ConcatParams(parameters);
                string urlConParametros = "https://web-service-to-csharp-hansmerz.c9users.io/test.php" + " ?" + "URL=1";

                System.Net.WebRequest wr = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(urlConParametros);
                wr.Method = "GET";

                wr.ContentType = "application/x-www-form-urlencoded";

                System.IO.Stream newStream;
                // Obtiene la respuesta
                System.Net.WebResponse response = wr.GetResponse();
                // Stream con el contenido recibido del servidor
                newStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(newStream);
                // Leemos el contenido
                string responseFromServer = reader.ReadToEnd();
                MessageBox.Show(responseFromServer);
                // Cerramos los streams
                reader.Close();
                newStream.Close();
                response.Close();  
         */
    }
}
