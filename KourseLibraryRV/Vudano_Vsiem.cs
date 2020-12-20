﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LiveCharts;
using LiveCharts.Wpf;

namespace KourseLibraryRV
{
    public partial class Vudano_Vsiem : Form
    {
       // private object vudachaValues;

        //SqlConnection sqlConnection = null;
        //SqlDataReader reader = null;

        public Vudano_Vsiem()
        {
            InitializeComponent();
        }

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");
            await sqlConnection.OpenAsync();

            string query = "SELECT v.ReadCardNum,(SELECT COUNT(ReadCardNum) FROM Vudachia WHERE v.ReadCardNum=ReadCardNum) AS HowManyBooks FROM Vudachia v GROUP BY ReadCardNum";

            SqlCommand command = new SqlCommand(query, sqlConnection);
            SqlDataReader reader = command.ExecuteReader();

            List<string[]> data = new List<string[]>();


            while (reader.Read())
            {
                  data.Add(new string[2]);  
                  data[data.Count - 1][0] = reader[0].ToString();
                  data[data.Count - 1][1] = reader[1].ToString();
            }
            foreach (string[] s in data)
                dataGridView1.Rows.Add(s);

            reader.Close();
            sqlConnection.Close();          
        }

        private void AllDiagramm_Load(object sender, EventArgs e)
        {
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
    }
}
