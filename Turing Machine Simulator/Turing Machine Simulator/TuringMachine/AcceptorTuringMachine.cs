using System;
using System.Collections.Generic;

namespace TuringMachineProject
{
	public class AcceptorTuringMachine
	{
		private TransitionSearcher transitionSearcher;
		private Tape tape;
		private List<string> steps;

		public List<string> Steps
		{
			get {return this.steps;}
		}
		public AcceptorTuringMachine ()
		{
			this.transitionSearcher = new TransitionSearcher ();
		}

		public void setTuringMachine(List<State> states, List<Transition> transitions)
		{
            if (states.Count == 0 || transitions.Count == 0)
                throw new Exception("No states or transitions");

			foreach (State state in states)
				this.transitionSearcher.addState (state);
			foreach (Transition transition in transitions)
				this.transitionSearcher.addTransition (transition);
		}
		public bool simulate(string input)
		{
			this.steps = new List<string> ();
            bool firstStep = true;

			this.tape = new Tape (input);
			State currentState = null;
			Transition transition = null;

			do {
				currentState = this.transitionSearcher.CurrentState;
				transition = this.transitionSearcher.getTransition (this.tape.Current);

                if (firstStep)
                {
                    this.steps.Add(string.Format("{0} {1} {2}", currentState.StateID, this.tape, this.tape.currentPosition()));
                    firstStep = false;
                }

				if (transition != null) {
					this.tape.write (transition.Write);
					switch (transition.Movement) {
					case TapeMoves.Left:
						this.tape.left ();
						break;
					case TapeMoves.Right:
						this.tape.right ();
						break;
                        case TapeMoves.Stable:
                        break;
					default:
						throw new Exception (transition.Movement + " not supported yet !!");
					}
					this.transitionSearcher.CurrentState = transition.To;

					this.steps.Add (string.Format ("{0} {1} {2} {3} {4}\n", currentState.StateID, transition.To.StateID, transition.Read, this.tape, this.tape.currentPosition()));
				}
			} while(transition != null);

            this.transitionSearcher.reset();

			if (currentState.IsFinal)
				return true;

			return false;
		}
	}
}

