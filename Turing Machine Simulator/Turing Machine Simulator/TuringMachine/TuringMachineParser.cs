using System;
using System.IO;
using System.Collections.Generic;

namespace TuringMachineProject
{
	public class TuringMachineParser
	{
		private Dictionary<string, State> states;
		private List<Transition> transitions;
		private StreamReader reader;

		public List<State> States
		{
			get {return new List<State>(this.states.Values);}
		}
		public List<Transition> Transitions
		{
			get {return this.transitions;}
		}

		public TuringMachineParser(string filePath)
		{
			this.states = new Dictionary<string, State> ();
			this.transitions = new List<Transition> ();
			this.reader = new StreamReader (filePath); 
		}

		public void parse()
		{
			bool isStates = false;
			while (!this.reader.EndOfStream) {
				string line = reader.ReadLine ();

				if (line == "states") {
					isStates = true;
					continue;
				} 
				else if (line == "transitions") {
					isStates = false;
					continue;
				} 

				if (isStates) {
					string[] tokens = line.Split (new char[]{' '});
					State state = new State (tokens [0], tokens [1] == "1");
					this.states.Add (state.StateID, state);
				} 
				else {
					string[] tokens = line.Split (new char[]{' '});
					TapeMoves move = TapeMoves.Down;
					switch (tokens [4][0]) {
					case 'l':
						move = TapeMoves.Left;
						break;
					case 'r':
						move = TapeMoves.Right;
						break;
					case 'u':
						move = TapeMoves.Up;
						break;
					case 'd':
						move = TapeMoves.Down;
						break;
                        case 's':
                        move = TapeMoves.Stable;
                        break;
					}

					Transition transition = new Transition (this.states [tokens [0]], this.states [tokens [1]], 
					                                        tokens [2] [0], tokens [3] [0], move);
					this.transitions.Add (transition);
				}

			}
		}
	}
}

