using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;

namespace TuringMachineProject
{
	public class TuringMachineVisualizer
	{
		private Graphics graphics;
		private Dictionary<string, GUIState> stateGUITable;
		private Dictionary<KeyValuePair<State, char>, GUITransition> edgeGUITable;
        private string startState;
		private List<string> steps;
		private int stepIndex;

        //private string[] stepAttribute = new string[] { "from", "to", "read", "tape", "pinter" };
        private string lastTape;
        private int lastPointerIndex;
        private int DUPLICATION_SHIFT = 20;
        private int SLEEP_AMOUNT = 200;
        public int SleepAmount
        {
            get { return SLEEP_AMOUNT; }
            set { SLEEP_AMOUNT = value; }
        }

        #region Drawing Attributes
        
        private const int CIRCLE_RADIUS = 25;
        private const int CIRCLE_RADIUS_SPECIAL = 20;
		private const float WIDTH_HIGHLIGHTED = 5;
		private const float WIDTH_NORMAL = 3;
        private int TAPE_HEIGHT;
        #region Fonts
        private Font FONT_HIGHLIGHTED;
        private Font FONT_NORMAL;
        private Font TAPE_FONT;
        #endregion
        #region Colors
        private Color CIRCLE_COLOR_HIGHLIGHTED = Color.LightGreen;
		private Color CIRCLE_COLOR_NORMAL = Color.Orange;
        private Color CIRCLE_COLOR_SPECIAL = Color.Red;
        private Color CIRCLE_STRING_COLOR = Color.Black;
        private Color LINE_COLOR_HIGHLIGHTED = Color.LightGreen;
		private Color LINE_COLOR_NORMAL = Color.Gray;
        private Color LINE_STRING_COLOR_HIGHLIGHTED = Color.Tomato;
        private Color LINE_STRING_COLOR_NORMAL = Color.DarkCyan;
        private Color TAPE_COLOR = Color.LightBlue;
        private Color TAPE_POINTER_COLOR = Color.Blue;
        private Color TAPE_CHAR_COLOR = Color.DarkGray;
        private Color TAPE_CHAR_POINTER_COLOR = Color.Red;
        public Color CLEAR_COLOR = Color.White;
        #endregion
        #endregion

        public TuringMachineVisualizer(Graphics graphics)
		{
			this.graphics = graphics;
			this.FONT_HIGHLIGHTED = new Font (new Font("Comic Sans MS",10), FontStyle.Bold);
            this.FONT_NORMAL = new Font(new Font("Comic Sans MS", 10), FontStyle.Regular);
            this.TAPE_FONT = new Font(new Font("Comic Sans MS", 15), FontStyle.Bold);
            this.TAPE_HEIGHT = (int)(this.graphics.VisibleClipBounds.Height - this.graphics.MeasureString("#",this.TAPE_FONT).Height);
		}

		public void setStateTable(Dictionary<string, GUIState> stateTable)
		{
			this.stateGUITable = stateTable;
		}
		public void setEdgeTable(Dictionary<KeyValuePair<State, char>, GUITransition> transitions)
		{
			this.edgeGUITable = transitions;
		}
		public void setSteps(List<string> steps)
		{
			this.steps = steps;
			this.stepIndex = 1;
		}

		public void drawStep()
		{
            

            string[] tokens = this.steps[this.stepIndex].Split(new char[] { ' ' });
            string fromState = tokens[0];
            string toState = tokens[1];
            char readChar = tokens[2][0];
            string tape = tokens[3];
            int pointerIndex = int.Parse(tokens[4]);

            //light start, can be deleted but delete this.initialDrawing() too and change implementation of drawLastStep()
            this.initialDrawing();

            this.clearState(fromState, false);
            this.drawState(fromState, true, this.stateGUITable[fromState].getState().IsFinal);

            Thread.Sleep(SLEEP_AMOUNT);

            //light edge and draw tape
            this.clearState(fromState, true);
            this.clearEdge(fromState, readChar, false);
            this.clearEdge(fromState, readChar, true);  // for more accurate erase
            this.clearTape(this.lastTape, this.lastPointerIndex);

            this.drawState(fromState, false, this.stateGUITable[fromState].getState().IsFinal);
            this.drawEdge(fromState, readChar, true);
            
            this.drawTape(tape, pointerIndex);
            Thread.Sleep(SLEEP_AMOUNT);
            
            //light end
            //this.initialDrawing();
            this.clearEdge(fromState, readChar,true);
            this.clearEdge(fromState, readChar, false); // for more accurate erase

            this.clearState(toState, false);

            this.drawState(toState, true, this.stateGUITable[toState].getState().IsFinal);
            this.drawEdge(fromState, readChar, false);

            this.lastTape = tape;
            this.lastPointerIndex = pointerIndex;
			this.stepIndex++;
		}
		public bool isLastStep()
		{
			return this.stepIndex == this.steps.Count;
		}
		public void drawLastStep()
		{
            if (this.steps.Count <= 1)
                return;
            this.stepIndex = this.steps.Count - 1;

            string[] tokens = this.steps[this.stepIndex].Split(new char[] { ' ' });
            string fromState = tokens[0];
            string toState = tokens[1];
            char readChar = tokens[2][0];
            string tape = tokens[3];
            int pointerIndex = int.Parse(tokens[4]);

            this.graphics.Clear(CLEAR_COLOR);
            this.initialDrawing();

            this.drawState(toState, true, this.stateGUITable[toState].getState().IsFinal);
            this.drawTape(tape, pointerIndex);

            this.lastTape = tape;
            this.lastPointerIndex = pointerIndex;
            this.stepIndex++;
		}
        public void drawTuringMachine()
		{
            string[] tokens = this.steps[0].Split(new char[] { ' ' });
            this.startState = tokens[0];
            string initialTape = tokens[1];
            int pointerIndex = int.Parse(tokens[2]);

            this.graphics.Clear(CLEAR_COLOR);
            this.initialDrawing();

            bool isFinal = this.stateGUITable[this.startState].getState().IsFinal;
            this.drawState(this.startState, true, isFinal);
            
            this.drawTape(initialTape, pointerIndex);
            
            this.lastTape = initialTape;
            this.lastPointerIndex = pointerIndex;
		}
        public void reDraw()
        {
            if (this.stepIndex == 1)
                this.drawTuringMachine();
            else if (this.stepIndex > 1)
            {
                this.stepIndex--;

                string[] tokens = this.steps[this.stepIndex].Split(new char[] { ' ' });
                string fromState = tokens[0];
                string toState = tokens[1];
                char readChar = tokens[2][0];
                string tape = tokens[3];
                int pointerIndex = int.Parse(tokens[4]);

                this.initialDrawing();

                this.drawState(toState, true, this.stateGUITable[toState].getState().IsFinal);
                this.drawTape(tape, pointerIndex);

                this.stepIndex++;
            }
        }
        private void initialDrawing()
        {
       //     this.graphics.Clear(Color.White);

            this.drawEnterArrow();

            List<string> IDs = new List<string>(this.stateGUITable.Keys);

            for (int i = 0; i < IDs.Count; ++i)
            {
                bool isFinal = this.stateGUITable[IDs[i]].getState().IsFinal;
                this.drawState(IDs[i], false, isFinal);
            }

            List<KeyValuePair<State, char>> edgeKeys = new List<KeyValuePair<State, char>>(this.edgeGUITable.Keys);

            foreach (KeyValuePair<State, char> edge in edgeKeys)
            {
                this.drawEdge(edge.Key.StateID, edge.Value, false);
            }

        }

		private void drawState(string name, bool highlight, bool final)
		{
			//getState
			GUIState guiState = this.stateGUITable [name];
			//draw
			SolidBrush brush;
			Pen pen;

			if (highlight) {
				pen = new Pen (CIRCLE_COLOR_HIGHLIGHTED, WIDTH_HIGHLIGHTED);
				brush = new SolidBrush (CIRCLE_COLOR_HIGHLIGHTED);
			} else {
                pen = new Pen(CIRCLE_COLOR_NORMAL, WIDTH_NORMAL);
				brush = new SolidBrush (CIRCLE_COLOR_NORMAL);
			}

			//Circle
			Point cornerPoint = new Point (guiState.Position.X - CIRCLE_RADIUS, guiState.Position.Y - CIRCLE_RADIUS);
			Rectangle boundedRect = new Rectangle (cornerPoint, new Size (2 * CIRCLE_RADIUS, 2 * CIRCLE_RADIUS));

			this.graphics.FillEllipse (brush, boundedRect);

            if (final)
            {
                Point corner = new Point(guiState.Position.X - CIRCLE_RADIUS_SPECIAL, guiState.Position.Y - CIRCLE_RADIUS_SPECIAL);
                Rectangle smallBoundRect = new Rectangle(corner, new Size(2 * CIRCLE_RADIUS_SPECIAL, 2 * CIRCLE_RADIUS_SPECIAL));
                Pen innerPen = new Pen(CIRCLE_COLOR_SPECIAL,WIDTH_NORMAL);
                this.graphics.DrawEllipse(innerPen, smallBoundRect);
                innerPen.Dispose();
            }

			//String
            brush.Color = CIRCLE_STRING_COLOR;

            cornerPoint = new Point(guiState.Position.X - CIRCLE_RADIUS / 2, guiState.Position.Y - CIRCLE_RADIUS / 2);
            Font font;
            if (highlight)
                font = FONT_HIGHLIGHTED;
            else
                font = FONT_NORMAL;
            
            this.graphics.DrawString(guiState.getState().StateID, font, brush, cornerPoint);
			//End
			brush.Dispose ();
            pen.Dispose();
			//this.graphics.Dispose ();
		}
        #region Edge Drawing
        private void drawEdge(string fromID, char read, bool highlight)
		{
			KeyValuePair<State, char> key = new KeyValuePair<State, char> (this.stateGUITable [fromID].getState (), read);
			Transition transition = this.edgeGUITable [key].getTransition ();

			//draw
			SolidBrush brush;
			Pen pen;
            Font font;

			if (highlight) {
				pen = new Pen (LINE_COLOR_HIGHLIGHTED, WIDTH_HIGHLIGHTED);
                brush = new SolidBrush(LINE_STRING_COLOR_HIGHLIGHTED);
                font = FONT_HIGHLIGHTED;
			} else {
				pen = new Pen (LINE_COLOR_NORMAL, WIDTH_NORMAL);
                brush = new SolidBrush(LINE_STRING_COLOR_NORMAL);
                font = FONT_NORMAL;
			}
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.ArrowAnchor;

			if (this.edgeGUITable [key].IsSelfLoop) {
                Point stringPoint = new Point();
                List<Point> curvePoint = this.getSelfCurvePointsAndStringPoint(this.stateGUITable[transition.From.StateID].Position,
                                                        this.edgeGUITable[key].Angle, ref stringPoint);

                //Draw Curve
                this.graphics.DrawBeziers(pen, curvePoint.ToArray());
                //Draw String
                this.graphics.DrawString(this.getTransitionString(transition), font, brush, stringPoint);
                

			} else {
                Point startPoint = new Point(this.stateGUITable[transition.From.StateID].Position.X,
                                                 this.stateGUITable[transition.From.StateID].Position.Y);
                Point endPoint = new Point(this.stateGUITable[transition.To.StateID].Position.X,
                                             this.stateGUITable[transition.To.StateID].Position.Y);

                bool isUpOrLEFT = true;
				// example: q0 -> q1 
				if (transition.From.StateID.CompareTo(transition.To.StateID) < 0) {
                    isUpOrLEFT = true;
				}
                else if (transition.From.StateID.CompareTo(transition.To.StateID) < 0){
                    isUpOrLEFT = false;
                }

                Point stringPoint = new Point();
                List<Point> curvePoints = this.getCurvePointsAndStringPoint(startPoint, endPoint, isUpOrLEFT, ref stringPoint);

                //Draw Curve
                this.graphics.DrawCurve(pen, curvePoints.ToArray());
                //Draw String
                if (this.searchForDublication(transition.From, transition.To, transition.Read))
                    stringPoint.Y -= DUPLICATION_SHIFT;
                this.graphics.DrawString(this.getTransitionString(transition), font, brush, stringPoint);
			}
            pen.Dispose();
            brush.Dispose();
		}
        private List<Point> getCurvePointsAndStringPoint(Point start, Point end, bool isUpOrLEFT, ref Point stringPoint)
        {
            int LINE_SHIFT_AMOUNT = 15;
            double ANGLE_SHIFT_AMOUNT = 0.34;   // radius

            double angleBetweenCenters = Math.Atan2((end.Y - start.Y), (end.X - start.X));  // winFrom coordinate   - | -
                                                                                            //                      + | +
            // Swaping between lines
            if (end.X <= start.X)
                LINE_SHIFT_AMOUNT *= -1;

            if (isUpOrLEFT){
                LINE_SHIFT_AMOUNT *= -1;
                ANGLE_SHIFT_AMOUNT *= -1;
            }

            start.X += (int)(CIRCLE_RADIUS * Math.Cos(angleBetweenCenters + ANGLE_SHIFT_AMOUNT));
            start.Y += (int)(CIRCLE_RADIUS * Math.Sin(angleBetweenCenters + ANGLE_SHIFT_AMOUNT));

            end.X += (int)(CIRCLE_RADIUS * Math.Cos(angleBetweenCenters - ANGLE_SHIFT_AMOUNT + Math.PI));
            end.Y += (int)(CIRCLE_RADIUS * Math.Sin(angleBetweenCenters - ANGLE_SHIFT_AMOUNT + Math.PI));

            double deltaX = end.X - start.X;
            double deltaY = end.Y - start.Y;

            int numOfPoints = 4;
            List<Point> curvePoints = new List<Point>();

            for (int i = 0; i < numOfPoints; ++i)
            {
                if (i == 0)
                    curvePoints.Add(start);
                else if (i == numOfPoints - 1)
                    curvePoints.Add(end);
                else
                {
                    double segmentXLength = deltaX / (numOfPoints - 1);
                    double segmentYLength = deltaY / (numOfPoints - 1);

                    int X = (int)(start.X + i * segmentXLength + LINE_SHIFT_AMOUNT);
                    int Y = (int)(start.Y + i * segmentYLength + LINE_SHIFT_AMOUNT);
                    curvePoints.Add(new Point(X, Y));
                }
            }

            int X_SHIFT = 30;
            int Y_SHIFT = 20;
            stringPoint = new Point((int)(start.X + (deltaX / 2) + LINE_SHIFT_AMOUNT - X_SHIFT), (int)(start.Y + (deltaY / 2) + LINE_SHIFT_AMOUNT - Y_SHIFT));
            
            return curvePoints;
        }
        private List<Point> getSelfCurvePointsAndStringPoint(Point center, double angle, ref Point stringPoint)
        {

            angle *= -1;    // convert to winForm coordinates
            angle = (float)((angle / 180) * Math.PI);   // convert to radius

            double ANGLE_SHIFT_AMOUNT = Math.PI/6;   // radius
            float CURVE_HEIGHT = 3;

            Point start = new Point(center.X + (int)(CIRCLE_RADIUS * Math.Cos(angle - ANGLE_SHIFT_AMOUNT)), 
                                    center.Y + (int)(CIRCLE_RADIUS * Math.Sin(angle - ANGLE_SHIFT_AMOUNT)));

            Point end = new Point(center.X + (int)(CIRCLE_RADIUS * Math.Cos(angle + ANGLE_SHIFT_AMOUNT)),
                                    center.Y + (int)(CIRCLE_RADIUS * Math.Sin(angle + ANGLE_SHIFT_AMOUNT)));

            Point middle1 = new Point(center.X + (int)(CURVE_HEIGHT * CIRCLE_RADIUS * Math.Cos(angle - ANGLE_SHIFT_AMOUNT)),
                                    center.Y + (int)(CURVE_HEIGHT * CIRCLE_RADIUS * Math.Sin(angle - ANGLE_SHIFT_AMOUNT)));

            Point middle2 = new Point(center.X + (int)(CURVE_HEIGHT * CIRCLE_RADIUS * Math.Cos(angle + ANGLE_SHIFT_AMOUNT)),
                                    center.Y + (int)(CURVE_HEIGHT * CIRCLE_RADIUS * Math.Sin(angle + ANGLE_SHIFT_AMOUNT)));

            List<Point> curvePoints = new List<Point>();
            curvePoints.Add(start);
            curvePoints.Add(middle1);
            curvePoints.Add(middle2);
            curvePoints.Add(end);

            if (Math.PI >= angle && angle >= -Math.PI / 2)
                CURVE_HEIGHT = 2.4F;

            stringPoint = new Point(center.X + (int)(CURVE_HEIGHT * CIRCLE_RADIUS * Math.Cos(angle)),
                                    center.Y + (int)(CURVE_HEIGHT * CIRCLE_RADIUS * Math.Sin(angle)));

            return curvePoints;
        }
        private string getTransitionString(Transition transition)
        {
            string transString;
            switch (transition.Movement)
            {
                case TapeMoves.Left:
                    transString = string.Format("{0}|{1},{2}", transition.Read, transition.Write, "L");
                    break;
                case TapeMoves.Right:
                    transString = string.Format("{0}|{1},{2}", transition.Read, transition.Write, "R");
                    break;
                case TapeMoves.Stable:
                    transString = string.Format("{0}|{1},{2}", transition.Read, transition.Write, "S");
                    break;
                default:
                    throw new Exception("Not Implemented Yet");
            }

            return transString;
        }
        #endregion
        private bool searchForDublication(State from, State to, char read)
        {
            List<GUITransition> value = new List<GUITransition>(this.edgeGUITable.Values);

            foreach (GUITransition guiT in value)
            {
                Transition t = guiT.getTransition();
                if (t.From == from && t.To == to && t.Read != read)
                    return true;
                else if (t.From == from && t.To == to && t.Read == read)
                    return false;
            }
            return false;
        }
        private void drawTape(string currentTape, int pointerIndex)
		{
            Pen pen = new Pen(TAPE_COLOR, WIDTH_NORMAL);
            SolidBrush brush = new SolidBrush(TAPE_CHAR_COLOR);

            SizeF rectangleSize = graphics.MeasureString("#", TAPE_FONT);

            if (rectangleSize.Width * (pointerIndex + 1) > this.graphics.VisibleClipBounds.Width)
            {
                int diff = (int)(rectangleSize.Width * currentTape.Length - this.graphics.VisibleClipBounds.Width);
                int numOfCharToCut = diff / (int)rectangleSize.Width;

                currentTape = currentTape.Substring(numOfCharToCut);
                pointerIndex -= numOfCharToCut;
            }

            int xPosition = 0;
            Point pointerPoint = new Point();
            for (int i = 0; i < currentTape.Length; ++i)
            {
                Point corner = new Point(xPosition, TAPE_HEIGHT);

                if (i == pointerIndex)
                {
                    pointerPoint = corner;
                    brush.Color = TAPE_CHAR_POINTER_COLOR;
                    graphics.DrawString(currentTape[i].ToString(), TAPE_FONT, brush, corner);
                }
                else
                {
                    brush.Color = TAPE_CHAR_COLOR;
                    graphics.DrawString(currentTape[i].ToString(), TAPE_FONT, brush, corner);
                    graphics.DrawRectangle(pen, new Rectangle(corner, new Size((int)rectangleSize.Width, (int)rectangleSize.Height)));
                }

                xPosition += (int)rectangleSize.Width;
            }

            pen.Width = WIDTH_HIGHLIGHTED;
            pen.Color = TAPE_POINTER_COLOR;
            graphics.DrawRectangle(pen, new Rectangle(pointerPoint, new Size((int)rectangleSize.Width, (int)rectangleSize.Height)));

            brush.Dispose();
            pen.Dispose();
		}
        private void drawEnterArrow()
        {
            Point center = this.stateGUITable[this.startState].Position;

            float angle = (float)Math.PI;
            int arrowLength = 20;

            Point endPoint = new Point((int)(center.X + CIRCLE_RADIUS * Math.Cos(angle)),
                                            (int)(center.Y + CIRCLE_RADIUS * Math.Sin(angle)));
            Point startPoint = new Point(endPoint.X - arrowLength, endPoint.Y);

            Pen pen = new Pen(LINE_COLOR_NORMAL, WIDTH_HIGHLIGHTED);
            pen.StartCap = LineCap.Round;
            pen.EndCap = LineCap.ArrowAnchor;
            
            this.graphics.DrawLine(pen, startPoint, endPoint);
            
            pen.Dispose();
        }

        private void clearEdge(string fromID, char read, bool highlight)
        {
            Color backupLine,backupString;
            if (highlight)
            {
                backupLine = this.LINE_COLOR_HIGHLIGHTED;
                backupString = this.LINE_STRING_COLOR_HIGHLIGHTED;
                this.LINE_COLOR_HIGHLIGHTED = CLEAR_COLOR;
                this.LINE_STRING_COLOR_HIGHLIGHTED = CLEAR_COLOR;
            }
            else
            { 
                backupLine = this.LINE_COLOR_NORMAL;
                backupString = this.LINE_STRING_COLOR_NORMAL;
                this.LINE_COLOR_NORMAL = CLEAR_COLOR;
                this.LINE_STRING_COLOR_NORMAL = CLEAR_COLOR;
            }
            
            this.drawEdge(fromID, read, highlight);

            if (highlight)
            {
                this.LINE_COLOR_HIGHLIGHTED = backupLine;
                this.LINE_STRING_COLOR_HIGHLIGHTED = backupString;
            }
            else
            {
                this.LINE_COLOR_NORMAL = backupLine;
                this.LINE_STRING_COLOR_NORMAL = backupString;
            }
        }
        private void clearState(string name, bool highlight)
        {
            Color backup;
            if (highlight)
            {
                backup = this.CIRCLE_COLOR_HIGHLIGHTED;
                this.CIRCLE_COLOR_HIGHLIGHTED = CLEAR_COLOR;
            }
            else
            {
                backup = this.CIRCLE_COLOR_NORMAL;
                this.CIRCLE_COLOR_NORMAL = CLEAR_COLOR;
            }

            this.drawState(name, highlight, false);

            if (highlight)
            {
                this.CIRCLE_COLOR_HIGHLIGHTED = backup;
            }
            else
            {
                this.CIRCLE_COLOR_NORMAL = backup;
            }
        }
        private void clearTape(string currentTape, int pointerIndex)
        {
            Color backupTapePointer, backupCharPointer;

            backupTapePointer = this.TAPE_POINTER_COLOR;
            backupCharPointer = this.TAPE_CHAR_POINTER_COLOR;
            this.TAPE_POINTER_COLOR = CLEAR_COLOR;
            this.TAPE_CHAR_POINTER_COLOR = CLEAR_COLOR;
            
            this.drawTape(currentTape, pointerIndex);

            this.TAPE_POINTER_COLOR = backupTapePointer;
            this.TAPE_CHAR_POINTER_COLOR = backupCharPointer;
        }

        public Bitmap screenShot()
        {
            return new Bitmap((int)this.graphics.VisibleClipBounds.Width, (int)this.graphics.VisibleClipBounds.Height, this.graphics);
        }
	}
}

