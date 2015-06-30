using System;

namespace TuringMachineProject
{
	public class Transition
	{
		private State from;
		private State to;
		private char read;
		private char write;
		private TapeMoves movement;

		public State From {
			get {return this.from;}
		}
		public State To {
			get {return this.to;}
		}
		public char Read {
			get {return this.read;}
		}
		public char Write {
			get {return this.write;}
		}
		public TapeMoves Movement {
			get {return this.movement;}
		}

		public Transition (State from, State to, char read, char write, TapeMoves movement)
		{
			this.from = from;
			this.to = to;
			this.read = read;
			this.write = write;
			this.movement = movement;
		}
	}
}

