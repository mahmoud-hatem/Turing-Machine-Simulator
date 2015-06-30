using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using TuringMachineProject;
using TuringMachineBuilder;

namespace Turing_Machine_Simulator
{
    public partial class Simulator : Form
    {

        AcceptorTuringMachine turingMachine;
        TuringMachineVisualizer turingMachineVisualizer;
        bool accept;
        bool inputEntered;
        bool modelLoaded;
        bool working;

        public Simulator()
        {
            InitializeComponent();
            this.accept = false;
            this.modelLoaded = false;
            this.inputEntered = false;
            this.working = false;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!this.modelLoaded)
            {
                MessageBox.Show("Load a model first");
                return;
            }

            this.clearResult();

            string input = this.inputTextBox.Text;
            this.accept = this.turingMachine.simulate(input);

            this.turingMachineVisualizer.setSteps(this.turingMachine.Steps);
            this.turingMachineVisualizer.drawTuringMachine();
            this.inputEntered = true;
        }

        private void loadModelBtn_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result != DialogResult.OK)
            {
                return;
            }

            TuringMachineParser parser = new TuringMachineParser(this.openFileDialog1.FileName);
            parser.parse();

            TuringMachineGUIParser parserGUI = new TuringMachineGUIParser(this.openFileDialog1.FileName);
            parserGUI.parse();

            this.turingMachine = new AcceptorTuringMachine();
            this.turingMachineVisualizer = new TuringMachineVisualizer(this.Convex.CreateGraphics());

            try
            {
                this.turingMachine.setTuringMachine(parser.States, parser.Transitions);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            this.turingMachineVisualizer.setStateTable(parserGUI.StateGUITable);
            this.turingMachineVisualizer.setEdgeTable(parserGUI.EdgeGUITable);
            this.modelLoaded = true;
            this.inputEntered = false;

            this.speedTrackBar.Value = this.speedTrackBar.Maximum - this.turingMachineVisualizer.SleepAmount;
        }

        private void stepBtn_Click(object sender, EventArgs e)
        {
            if (this.isBusy())
            {
                MessageBox.Show("Busy!!");
                return;
            }
            if (!this.inputEntered)
            {
                MessageBox.Show("Enter an input first");
                return;
            }

            if (this.turingMachineVisualizer.isLastStep() == true)
            {
                this.printResult();
                return;
            }

            Thread thread = new Thread(new ThreadStart(this.step));
            thread.Start();
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            if (this.isBusy())
            {
                MessageBox.Show("Busy!!");
                return;
            }
            if (!this.inputEntered)
            {
                MessageBox.Show("Enter an input first");
                return;
            }

            Thread thread = new Thread(new ThreadStart(this.run));
            thread.Start();
        }

        private void resultBtn_Click(object sender, EventArgs e)
        {
            if (this.isBusy())
            {
                MessageBox.Show("Busy!!");
                return;
            }
            if (!this.inputEntered)
            {
                MessageBox.Show("Enter an input first");
                return;
            }

            Thread thread = new Thread(new ThreadStart(this.lastStep));
            thread.Start();
        }

        private void step()
        {
            this.changeWorkingState();
            this.turingMachineVisualizer.drawStep();
            this.changeWorkingState();
        }
        private void run()
        {
            this.changeWorkingState();
            while (!this.turingMachineVisualizer.isLastStep())
            {
                this.turingMachineVisualizer.drawStep();
            }
            this.printResult();
            this.changeWorkingState();
        }
        private void lastStep()
        {
            this.changeWorkingState();
            this.turingMachineVisualizer.drawLastStep();
            this.printResult();
            this.changeWorkingState();
        }
        private void printResult()
        {
            Graphics g = this.resultPanel.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.LightGreen);
            string result = "ACCEPT";
            Font font = new Font(new Font("Comic Sans MS", 30), FontStyle.Bold);
            Rectangle rect = new Rectangle(new Point(0, 0), new Size((int)g.VisibleClipBounds.Width, (int)g.VisibleClipBounds.Height));
            if (!this.accept)
            {
                result = "REJECT";
                brush.Color = Color.Red;
            }
            g.FillRectangle(brush, rect);
            g.DrawString(result, font, new SolidBrush(Color.White), new Point(0, 0));
            g.Dispose();
        }
        private void clearResult()
        {
            Graphics g = this.resultPanel.CreateGraphics();
            g.Clear(Color.DarkGray);
        }

        private void changeWorkingState()
        {
            this.working = !this.working;
        }
        private bool isBusy()
        {
            return this.working;
        }

        private void speedTrackBar_Scroll(object sender, EventArgs e)
        {
            this.turingMachineVisualizer.SleepAmount = this.speedTrackBar.Maximum - this.speedTrackBar.Value;
        }

        private void nightVisionCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void Convex_Paint(object sender, PaintEventArgs e)
        {
            if (this.turingMachineVisualizer != null && !this.isBusy())
                this.turingMachineVisualizer.reDraw();
        }

        private void nightVisionCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.isBusy())
            {
                MessageBox.Show("Busy!!");
                if (this.nightVisionCheckBox.CheckState == CheckState.Checked)
                    this.nightVisionCheckBox.CheckState = CheckState.Unchecked;
                else
                    this.nightVisionCheckBox.CheckState = CheckState.Checked;
                return;
            }
            Color dayColor = Color.White;
            Color nightColor = Color.Black;

            Color currentColor;
            if (this.nightVisionCheckBox.Checked)
                currentColor = nightColor;
            else
                currentColor = dayColor;

            if (this.turingMachineVisualizer != null)
                this.turingMachineVisualizer.CLEAR_COLOR = currentColor;
            this.Convex.BackColor = currentColor;

            this.Convex.Refresh();
        }

        private void generateModelBtn_Click(object sender, EventArgs e)
        {
            Builder builder = new Builder();
            builder.Show();
        }
    }
}
