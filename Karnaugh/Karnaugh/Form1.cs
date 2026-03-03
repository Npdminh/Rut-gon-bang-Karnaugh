using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karnaugh
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void cboVariables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboMethod_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtMinterm_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            try
            {
                int n = int.Parse(cboVariables.Text.Split(' ')[0]);

                var minterms = txtMinterm.Text
                    .Split(',')
                    .Select(x => int.Parse(x.Trim()))
                    .ToList();

                GenerateTruthTable(n, minterms);

                if (cboMethod.Text == "Karnaugh")
                    txtResult.Text = KarnaughSolve(minterms, n);
                else
                    txtResult.Text = QuineMcCluskey(minterms, n);
            }
            catch
            {
                MessageBox.Show("Nhập sai định dạng!");
            }
        }

        private void dgvTruthTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }
        private void GenerateTruthTable(int n, List<int> minterms)
        {
            dgvTruthTable.Columns.Clear();
            dgvTruthTable.Rows.Clear();

            for (int i = 0; i < n; i++)
            {
                dgvTruthTable.Columns.Add("Var" + i, ((char)('A' + i)).ToString());
            }

            dgvTruthTable.Columns.Add("F", "F");

            int rows = (int)Math.Pow(2, n);

            for (int i = 0; i < rows; i++)
            {
                string binary = Convert.ToString(i, 2).PadLeft(n, '0');

                List<object> row = new List<object>();

                foreach (char bit in binary)
                    row.Add(bit.ToString());

                row.Add(minterms.Contains(i) ? "1" : "0");

                dgvTruthTable.Rows.Add(row.ToArray());
                dgvTruthTable.Width = 100 + n * 80;
            }
        }
        private string MintermToExpression(int m, int n)
        {
            string binary = Convert.ToString(m, 2).PadLeft(n, '0');
            string result = "";

            for (int i = 0; i < n; i++)
            {
                char varName = (char)('A' + i);

                if (binary[i] == '1')
                    result += varName;
                else
                    result += varName + "'";
            }

            return result;
        }
        private string KarnaughSolve(List<int> minterms, int n)
        {
            if (minterms.Count == 0)
                return "F = 0";

            if (minterms.Count == Math.Pow(2, n))
                return "F = 1";

            List<string> terms = new List<string>();

            foreach (var m in minterms)
                terms.Add(MintermToExpression(m, n));

            return "F = " + string.Join(" + ", terms);
        }
        private string CompareBinary(string a, string b)
        {
            int diff = 0;
            string result = "";

            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] == b[i])
                    result += a[i];
                else
                {
                    diff++;
                    result += "-";
                }
            }

            return diff == 1 ? result : null;
        }
        private string QuineMcCluskey(List<int> minterms, int n)
        {
            var binaries = minterms
                .Select(m => Convert.ToString(m, 2).PadLeft(n, '0'))
                .ToList();

            List<string> primeImplicants = new List<string>();
            HashSet<string> used = new HashSet<string>();

            
            for (int i = 0; i < binaries.Count; i++)
            {
                for (int j = i + 1; j < binaries.Count; j++)
                {
                    var combined = CompareBinary(binaries[i], binaries[j]);
                    if (combined != null)
                    {
                        primeImplicants.Add(combined);
                        used.Add(binaries[i]);
                        used.Add(binaries[j]);
                    }
                }
            }

            
            foreach (var b in binaries)
            {
                if (!used.Contains(b))
                    primeImplicants.Add(b);
            }

            primeImplicants = primeImplicants.Distinct().ToList();

            
            List<string> resultTerms = new List<string>();

            foreach (var pattern in primeImplicants)
            {
                string term = "";

                for (int i = 0; i < n; i++)
                {
                    char varName = (char)('A' + i);

                    if (pattern[i] == '1')
                        term += varName;
                    else if (pattern[i] == '0')
                        term += varName + "'";
                    
                }

                if (term != "")
                    resultTerms.Add(term);
            }

            return "F = " + string.Join(" + ", resultTerms);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvTruthTable_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtResult_TextChanged_1(object sender, EventArgs e)
        {

        }

    }
}
