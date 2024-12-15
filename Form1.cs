using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PracticalTask
{
    public partial class Form1 : Form
    {
        LinearCongruentialGenerator lcg = new LinearCongruentialGenerator();

        public Form1()
        {
            InitializeComponent();
        }
        public Form1(ref LinearCongruentialGenerator lcg)
        {
            InitializeComponent();
            this.lcg = lcg;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lcg.Multiplier = int.Parse(textBox1.Text);
            lcg.Seed = int.Parse(textBox2.Text);
            lcg.Increment = int.Parse(textBox3.Text);
            lcg.Modulus = int.Parse(textBox4.Text);
            lcg.N = int.Parse(textBox5.Text);

            List<int> _out = lcg.LCG();
            DataTable table = new DataTable();

            table.Columns.Add("Index", typeof(int));
            table.Columns.Add("Random Numbers", typeof(int));

            int i = 0;
            foreach (var simCase in _out)
    {

                table.Rows.Add(i++, simCase);

            }
            dataGridView1.DefaultCellStyle.NullValue = "0";
            dataGridView1.DataSource = table;

            int cycleLength = lcg.CalculateLenOfCycle();
            textBox6.Text = cycleLength.ToString();
        }

    }
}
