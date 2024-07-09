using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BookApplication
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            // Get the values from the text boxes
            string name = textBox1.Text;
            string email = textBox2.Text;
            string phone = textBox3.Text;

            // Validate the input
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone))
            {
                MessageBox.Show("Please fill in all the fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Save the contact information
            // You can add the contact to a list, database, or any other storage mechanism here
            MessageBox.Show($"Contact saved:\nName: {name}\nEmail: {email}\nPhone: {phone}", "Contact Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear the text boxes
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }
    }
}
