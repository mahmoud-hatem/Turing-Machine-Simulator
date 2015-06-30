using System;
using System.Collections.Generic;

namespace TuringMachineProject
{
	public class TransitionSearcher
	{
		private Dictionary<KeyValuePair<State,char>, Transition> transitionTable; 
		private Dictionary<string, State> stateTable;	// not used
		private State currentState;
        private State startState;

		public State CurrentState {
			get {return this.currentState;}
			set {this.currentState = value;}
		}
        public State StartState {
            get { return this.startState;}
        }

		public TransitionSearcher()
		{
			this.transitionTable = new Dictionary<KeyValuePair<State, char>, Transition> ();
			this.stateTable = new Dictionary<string, State> ();
		}

		public void addTransition(Transition transition) 
		{
			KeyValuePair<State, char> key = new KeyValuePair<State, char> (transition.From, transition.Read);
			if (this.transitionTable.ContainsKey (key) == true)
				throw new Exception ("It's a nondeterministic turing machine");

			this.transitionTable.Add (key, transition);
		}
		public Transition getTransition(char read)
		{
			KeyValuePair<State, char> key = new KeyValuePair<State, char> (this.currentState, read);

			if (!this.transitionTable.ContainsKey (key)) {
				return null;
			}

			Transition transition = this.transitionTable[key];

			return transition;
		}
		public void addState(State state) 
		{
            if (this.startState == null)
                this.startState = this.currentState = state;
			this.stateTable.Add (state.StateID, state);
		}
        public void reset()
        {
            this.currentState = this.startState;
        }
	}
}

