using System;
using System.IO;
using System.Collections.Generic;
using System.Drawing;

namespace TuringMachineProject
{
	public class TuringMachineGUIParser
	{
		private StreamReader reader;
		private Dictionary<string, GUIState> stateGUITable;
		private Dictionary<KeyValuePair<State, char>, GUITransition> edgeGUITable;

		public Dictionary<string, GUIState> StateGUITable
		{
			get {return this.stateGUITable;}
		}
		public Dictionary<KeyValuePair<State, char>, GUITransition> EdgeGUITable
		{
			get {return this.edgeGUITable;}
		}

		public TuringMachineGUIParser (string filePath)
		{
			this.reader = new StreamReader (filePath);
			this.stateGUITable = new Dictionary<string, GUIState> ();
			this.edgeGUITable = new Dictionary<KeyValuePair<State, char>, GUITransition> ();
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
					Point point = new Point(int.Parse(tokens[2]), int.Parse(tokens[3])); 
					GUIState guiState = new GUIState (state, point);

					this.stateGUITable.Add(guiState.getState().StateID, guiState);
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

					Transition transition = new Transition (this.stateGUITable [tokens [0]].getState(),
					                                        this.stateGUITable [tokens [1]].getState(), 
					                                        tokens [2] [0], tokens [3] [0], move);
					GUITransition guiTransition;
					if (tokens.Length == 6)
						guiTransition = new GUITransition (transition, double.Parse (tokens [5]), transition.From == transition.To);
					else
						guiTransition = new GUITransition (transition, 0, false);
					KeyValuePair<State, char> key = new KeyValuePair<State, char> (guiTransition.getTransition ().From, guiTransition.getTransition ().Read);
					this.edgeGUITable.Add (key, guiTransition);
				}

			}

		}
	}
}

