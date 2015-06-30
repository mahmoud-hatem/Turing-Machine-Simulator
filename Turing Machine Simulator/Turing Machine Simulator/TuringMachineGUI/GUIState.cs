using System;
using System.Drawing;

namespace TuringMachineProject
{
	public class GUIState
	{
		private State state;
		private Point position;

		public Point Position
		{
			get {return this.position;}
		}

		public GUIState (string stateID, bool isFinal, Point position)
		{
			this.state = new State (stateID, isFinal);
			this.position = position;
		}
		public GUIState (State state, Point position)
		{
			this.state = state;
			this.position = position;
		}

		
		public State getState()
		{
			return this.state;
		}
	}
}

