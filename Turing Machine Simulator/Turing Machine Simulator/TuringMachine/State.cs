using System;

namespace TuringMachineProject
{
	public class State
	{
		private bool isFinal;
		private string stateID;

		public bool IsFinal {
			get {return this.isFinal;}
		}
		public string StateID {
			get {return this.stateID;}
		}

		public State (string stateID, bool isFinal)
		{
			this.stateID = stateID;
			this.isFinal = isFinal;
		}

	}
}

