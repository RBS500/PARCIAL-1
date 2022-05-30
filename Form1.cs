using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace PARCIAL_1
{
    public partial class Form1 : Form
    {
        List<Inscripcion> inscripciones = new List<Inscripcion>();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {


            FileStream stream = new FileStream("alunmos2.txt", FileMode.Open, FileAccess.Read);
           
            StreamReader reader = new StreamReader(stream);

            while (reader.Peek() > -1)

            {
                
                comboAlumno.Items.Add(reader.ReadLine());

            }

            reader.Close();
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void Guardar(string fileName)
        {
            DateTime hoy = DateTime.Now;

            FileStream stream = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream);
            foreach (var inscripcion in inscripciones)
            {
                writer.WriteLine(inscripcion.alumno);
                writer.WriteLine(inscripcion.grado);
                writer.WriteLine(hoy);
            }
            writer.Close(); 
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Guardar ("inscripciones.txt");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Inscripcion inscripcion = new Inscripcion();
            inscripcion.alumno = comboAlumno.Text;
            inscripcion.grado = comboGrados.Text;
            inscripciones.Add(inscripcion);

            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.Refresh();
            dataGridView2.DataSource = inscripciones;
            dataGridView2.Refresh();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            inscripciones.ToString();
            dataGridView2.DataSource = null;
            dataGridView2.Refresh(); 

            dataGridView2.DataSource = inscripciones;
            dataGridView2.Refresh();

        }
    }
}
