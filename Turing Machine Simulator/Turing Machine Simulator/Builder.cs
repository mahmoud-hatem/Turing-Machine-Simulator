using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachineBuilder
{
    public partial class Builder : Form
    {
        private int numberOfStates;
        private bool lockButtonPressed;

        public Builder()
        {
            InitializeComponent();
        }

        private void initializeStates()
        {
            this.statesDataGridView.RowCount = this.numberOfStates;

            for (int i = 0; i < this.numberOfStates; i++)
            {
                string state = "q" + i.ToString();

                this.statesDataGridView.Rows[i].HeaderCell.Value = state;
            }
        }
        private void initializeTransitionDataGridView()
        {
            List<string> stateList = new List<string>();
            List<int> angleList = new List<int>();

            for (int i = 0; i < this.numberOfStates; i++)
            {
                stateList.Add("q" + i.ToString());
            }

            this.fromStateID.DataSource = stateList;
            this.toStateID.DataSource = stateList;

            //this.angle.ReadOnly = true;
        }
        private bool toTheSameState(string first, string second)
        {
            return first == second;
        }
        private void fileBuilder(string states, string transitions)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.DefaultExt = "txt";
                saveDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    StreamWriter sw = new StreamWriter(saveDialog.FileName);

                    sw.WriteLine("states");
                    sw.Write(states);
                    sw.WriteLine("transitions");
                    sw.Write(transitions);
                    sw.Close();
                }
                this.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void generate_Click(object sender, EventArgs e)
        {
            string statesRowData = "";
            string transitionsRowData = "";

            try
            {
                foreach (DataGridViewRow row in this.statesDataGridView.Rows)
                {
                    string isFinal = row.Cells[0].Value.ToString() == "Yes" ? "1" : "0";
                    int xCoordinate = int.Parse(row.Cells[1].Value.ToString());
                    int yCoordinate = int.Parse(row.Cells[2].Value.ToString());

                    statesRowData += string.Format("{0} {1} {2} {3}\n",row.HeaderCell.Value, isFinal,
                        xCoordinate.ToString(), yCoordinate.ToString());
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show("States coordinates should be integers!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                // last row is an empty row
                for (int i = 0; i < this.transitionsDataGridView.Rows.Count - 1; ++i)
                {
                    DataGridViewRow row = this.transitionsDataGridView.Rows[i];

                    string from = row.Cells[0].Value.ToString();
                    string to = row.Cells[1].Value.ToString();
                    string readChar = row.Cells[2].Value.ToString();
                    string writeChar = row.Cells[3].Value.ToString();
                    string movement = row.Cells[4].Value.ToString();
                    double angle = 0.0;

                    if (row.Cells[5].Value != null)
                    {
                        angle = double.Parse(row.Cells[5].Value.ToString());
                    }

                    transitionsRowData += string.Format("{0} {1} {2} {3} {4} {5}\n", from, to, readChar[0], writeChar[0]
                        , movement.ToLower()[0], angle.ToString());
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.fileBuilder(statesRowData, transitionsRowData);
        }
        private void lockBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.lockButtonPressed)
                {
                    this.numberOfStates = Convert.ToInt32(numberOfStatesTextBox.Text.ToString());
                    this.initializeStates();
                    this.initializeTransitionDataGridView();
                    this.lockBtn.Text = "Unlock";
                    lockButtonPressed = true;
                    this.numberOfStatesTextBox.Enabled = false;
                }

                else
                {
                    this.lockBtn.Text = "Lock";
                    lockButtonPressed = false;
                    this.numberOfStatesTextBox.Enabled = true;
                }
            }

            catch (FormatException ex)
            {
                MessageBox.Show("Write the number of states!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Number of states should be a positive number!");
            }
            
        }
        private void transitionsDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int currentRow = e.RowIndex;
            int currentColumn = e.ColumnIndex;

            if (currentRow < 0)
                return;
            if (currentColumn == 0 || currentColumn == 1)
            {
                this.transitionsDataGridView.Rows[currentRow].Cells[5].Value = null;
            }

        }
        private void transitionsDataGridView_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            int currentRow = e.Cell.RowIndex;
            int currentColumn = e.Cell.ColumnIndex;
            
            if (currentColumn == 5)
            {
                if (this.transitionsDataGridView.Rows[currentRow].Cells[0].Value != null &&
                this.transitionsDataGridView.Rows[currentRow].Cells[1].Value != null)
                {
                    string from = this.transitionsDataGridView.Rows[currentRow].Cells[0].Value.ToString();
                    string to = this.transitionsDataGridView.Rows[currentRow].Cells[1].Value.ToString();

                    if (this.toTheSameState(from, to))
                    {
                        this.transitionsDataGridView.Rows[currentRow].Cells[5].ReadOnly = false;
                    }

                    else
                    {
                        this.transitionsDataGridView.Rows[currentRow].Cells[5].ReadOnly = true;
                    }
                }
            }
            
        }
    }
}
