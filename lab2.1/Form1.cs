using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormAppLab21
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void BtnPiramid_Click(object sender, EventArgs e)
        {
            var array = new List<int>();

            var arr2 = CtrlInputStr.Text.Trim();

            foreach(string number in arr2.Split(' '))
            {
                array.Add(Int32.Parse(number));
            }

            var sorting = new SortMethods(array);

            CtrlTimer.Text = sorting.PiramidSort().Milliseconds.ToString();

            var output = sorting.SortedResult;

            var stringBuilder = new StringBuilder();
            foreach (var num in output)
            {
                stringBuilder.Append(num);
                stringBuilder.Append(" ");

            }
            CtrlSortedNumbers.Text = stringBuilder.ToString();
        }

        private void BtnTournir_Click(object sender, EventArgs e)
        {
            var array = new List<int>();

            var arr2 = CtrlInputStr.Text.Trim();

            foreach (string number in arr2.Split(' '))
            {
                array.Add(Int32.Parse(number));
            }

            var sorting = new SortMethods(array);

            CtrlTimer.Text = sorting.TournirSort().Milliseconds.ToString();

            var output = sorting.SortedResult;

            var stringBuilder = new StringBuilder();
            foreach (var num in output) {
                stringBuilder.Append(num);
                stringBuilder.Append(" ");

            }
            CtrlSortedNumbers.Text = stringBuilder.ToString();

        }
    }
}
