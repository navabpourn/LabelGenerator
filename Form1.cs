using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LableCreator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PN_ComboBox.Text = "P01";
            SE_ComboBox.Text = "Soil Column Experiment";
            Subsample_ComboBox.Text = "";
            FE_ComboBox.Text = "FP01";
            dateTimePicker1.Value = DateTime.Now;            
        }


        private void CE_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            CE_Label.Enabled = true;
            CE_TextBox.Enabled = true;
            FE_Label.Enabled = false;
            FE_ComboBox.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void UC_CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (UC_CheckBox.Checked)
            {
                UC_Label.Enabled = true;
                UC_TextBox.Enabled = true;
            }
            if (!UC_CheckBox.Checked)
            {
                UC_Label.Enabled = false;
                UC_TextBox.Enabled = false;
            }
        }

        private void FE_RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            FE_Label.Enabled = true;
            FE_ComboBox.Enabled = true;
            CE_Label.Enabled = false;
            CE_TextBox.Enabled = false;
        }

        private void Generator_Button_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(SerialNumber_TextBox.Text))
            {
                MessageBox.Show("Serial number is mandatory.");
            }
            else if (String.IsNullOrEmpty(Depth_TextBox.Text))
            {
                MessageBox.Show("Depth is mandatory.");
            }
            else if (UC_CheckBox.Checked && String.IsNullOrEmpty(UC_TextBox.Text))
            {
                MessageBox.Show("Undisturbed Soil Column needs a number.");                
            }
            else
            {
                string soilEx = "";
                switch (SE_ComboBox.Text)
                {
                    case "Soil Column Experiment":
                        soilEx = "SCE";
                        break;
                    case "Soil Plot Experiment":
                        soilEx = "SPE";
                        break;
                    default:
                        break;
                }

                //Prepare date
                int d = dateTimePicker1.Value.Day;
                string ds = d.ToString();
                if (d < 10) { ds = "0" + ds; }
                int m = dateTimePicker1.Value.Month;
                string ms = m.ToString();
                if (m < 10) { ms = "0" + ms; }
                int y = dateTimePicker1.Value.Year;
                string myDate = y.ToString() + ms + ds;

                //Column number or field plot number
                string exp = "";
                if (CE_RadioButton.Checked)
                {
                    exp = CE_TextBox.Text;
                }
                else if (FE_RadioButton.Checked)
                {
                    exp = FE_ComboBox.Text;
                }

                string label = "";
                label += PN_ComboBox.Text + "_" + soilEx +
                        SerialNumber_TextBox.Text + "_" + myDate + "_" +
                        exp + "_D" + Depth_TextBox.Text;

                //Prepare UC number and add
                if (UC_CheckBox.Checked)
                {
                    string uc = UC_TextBox.Text;
                    label = label + "_UC" + uc;
                }

                Result_TextBox.Text = label;

            }
        }
    }
}
