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

namespace KourseLibraryRV
{
    public partial class WydachaKnig : Form
    {
        private SqlConnection sqlConnection = null;
      
        public WydachaKnig()
        {
            InitializeComponent();
        }

        private async void WydachaKnig_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kourseWorkDataSet.Katalog". При необходимости она может быть перемещена или удалена.
            this.katalogTableAdapter.Fill(this.kourseWorkDataSet.Katalog);
            sqlConnection = new SqlConnection(@"Data Source=MAHNITSKIY-PC;Initial Catalog=KourseWork;Integrated Security=True");

            await sqlConnection.OpenAsync();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text))
            {
                SqlCommand command = new SqlCommand(
             $"INSERT INTO Vudachia (ReadCardNum,InvNBook,LibNBook,DateVudachi,Condition,DateBack,ID_vudachi,RealDateBack) VALUES  (@ReadCardNum,@InvNBook,@LibNBook,@DateVudachi,@Condition,@DateBack,@ID_vudachi,Null)" +
             $"UPDATE Book_Fond SET HowMany = HowMany - 1 WHERE LibNBook = @LibNBook ", sqlConnection);

                DateTime date = DateTime.Parse(textBox6.Text);
                DateTime sex = DateTime.Parse(textBox5.Text);

                command.Parameters.AddWithValue("ReadCardNum", textBox4.Text);
                command.Parameters.AddWithValue("InvNBook", textBox3.Text);
                command.Parameters.AddWithValue("LibNBook", textBox2.Text);
                command.Parameters.AddWithValue("DateVudachi", $"{sex.Day}/{sex.Month}/{sex.Year}");
                command.Parameters.AddWithValue("Condition", textBox9.Text);
                command.Parameters.AddWithValue("DateBack", $"{date.Day}/{date.Month}/{date.Year}");
                command.Parameters.AddWithValue("ID_vudachi", textBox1.Text);
                MessageBox.Show(command.ExecuteNonQuery().ToString());
            }
            else
            {
                SqlCommand com = new SqlCommand("$SELECT * FROM Book_Fond WHERE HowMany = '0'", sqlConnection);

                MessageBox.Show("Ну нету книги !!!!!!!");
                Sklad show = new Sklad();
                show.ShowDialog();
            }
           
        }
        private void button3_Click(object sender, EventArgs e)
        {
            WydachaKnigAdmin show = new WydachaKnigAdmin();
            show.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Doljniki show = new Doljniki();
            show.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sklad show = new Sklad();
            show.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TopReaders show = new TopReaders();
            show.ShowDialog();
        }



        private void button6_Click_1(object sender, EventArgs e)
        {
            Vudano_Vsiem show = new Vudano_Vsiem();
            show.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            TopBook show = new TopBook();
            show.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WydachaKnigAdmin show = new WydachaKnigAdmin();
            show.ShowDialog();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
           
                SqlCommand command = new SqlCommand(
                    $"UPDATE Vudachia SET Condition = '@Condition', RealDateBack = '@RealDateBack' WHERE ID_vudachi = '@IDvudachi' AND LibNBook = '@LibNB', ReadCardNum = '@NReader'" +
                    $"UPDATE Book_Fond SET HowMany = HowMany + 1 WHERE LibNBook = '@LibNB'", sqlConnection);

                DateTime a = DateTime.Parse(textBox8.Text);

                command.Parameters.AddWithValue("NReader", textBox12.Text);
                command.Parameters.AddWithValue("IDvudachi", textBox10.Text);
                command.Parameters.AddWithValue("LibNB", textBox11.Text);
                command.Parameters.AddWithValue("Condition", textBox7.Text);
                command.Parameters.AddWithValue("DateBack", $"{a.Day}/{a.Month}/{a.Year}");

                command.ExecuteNonQuery();

            
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Sklad show = new Sklad();
            show.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            WydachaKnigAdmin show = new WydachaKnigAdmin();
            show.ShowDialog();
        }
    }
}
