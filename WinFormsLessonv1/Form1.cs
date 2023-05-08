using System;
using System.IO;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsLessonv1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ClearTable();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            ClearTable();
        }
        private void button2_Click(object sender, System.EventArgs e)
        {
            AddElemTable();
        }
        private void button3_Click(object sender, System.EventArgs e)
        {
            dataGridView1.Rows.Remove(dataGridView1.SelectedRows[0]);
            AddElemTable();
        }
        private void button4_Click(object sender, System.EventArgs e)
        {
            textBox1.Text = Minimum(dataGridView1.SelectedCells[^1].ColumnIndex).ToString();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Text = Maximum(dataGridView1.SelectedCells[^1].ColumnIndex).ToString();
        }

        private void ClearTable()
        {
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add("Column1", "District");
            dataGridView1.Columns.Add("Column2", "Invest");
            dataGridView1.Columns.Add("Column3", "Housing");
            dataGridView1.Columns.Add("Column4", "Build");
            dataGridView1.Columns.Add("Column5", "Equipment");
            dataGridView1.Columns.Add("Column6", "Other");

            strings.Clear();
        }
        private void AddElemTable()
        {
            File.Delete("table.txt");
            strings.Add("District\t| Invest\t | Housing\t | Build\t | Equipment\t | Other\t");

            for (int row = 0; row < dataGridView1.RowCount - 1; row++)
            {
                data.dist = dataGridView1[0, row].Value.ToString();
                data.inve = dataGridView1[1, row].Value.ToString();
                data.hous = dataGridView1[2, row].Value.ToString();
                data.buil = dataGridView1[3, row].Value.ToString();
                data.equi = dataGridView1[4, row].Value.ToString();
                data.othe = dataGridView1[5, row].Value.ToString();

                strings.Add(data.dist + "\t | " + data.inve + "\t | "
                    + data.hous + "\t | " + data.buil + "\t | " + data.equi + "\t | " + data.othe);

                datas.Add(data);
            }

            strings.Add("");
            strings.Add("Invest: " + " Max " + Maximum(1) + " Min " + Minimum(1));
            strings.Add("Housing: " + " Max " + Maximum(2) + " Min " + Minimum(2));
            strings.Add("Build: " + " Max " + Maximum(3) + " Min " + Minimum(3));
            strings.Add("Equipment: " + " Max " + Maximum(4) + " Min " + Minimum(4));
            strings.Add("Other: " + " Max " + Maximum(5) + " Min " + Minimum(5));

            File.AppendAllLines("table.txt", strings);
        }
        private double Maximum(int ind)
        {
            double maxValue = Convert.ToDouble(dataGridView1[ind, 0].Value);

            for (int elem = 1; elem < dataGridView1.RowCount - 1; elem++)
            {
                if (maxValue < Convert.ToDouble(dataGridView1[ind, elem].Value))
                {
                    maxValue = Convert.ToDouble(dataGridView1[ind, elem].Value);
                }
            }

            return maxValue;
        }
        private double Minimum(int ind)
        {
            double minValue = Convert.ToDouble(dataGridView1[ind, 0].Value);

            for (int elem = 1; elem < dataGridView1.RowCount - 1; elem++)
            {
                if (minValue > Convert.ToDouble(dataGridView1[ind, elem].Value))
                {
                    minValue = Convert.ToDouble(dataGridView1[ind, elem].Value);
                }
            }

            return minValue;
        }

        Data data = new Data();
        List<Data> datas = new List<Data>();
        List<string> strings = new List<string>();
    }
}
