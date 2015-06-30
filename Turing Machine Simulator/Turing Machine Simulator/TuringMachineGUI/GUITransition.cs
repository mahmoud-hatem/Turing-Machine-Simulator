using System;
using System.Drawing;

namespace TuringMachineProject
{
	public class GUITransition
	{
		private Transition transition;
		private double angle;
		private bool isSelfLoop;

		public double Angle
		{
			get {return this.angle;}
		}
		public bool IsSelfLoop
		{
			get {return this.isSelfLoop;}
		}

		public GUITransition (Transition transition, double angle, bool isSelf)
		{
			this.transition = transition;
			this.angle = angle;
			this.isSelfLoop = isSelf;
		}

		public Transition getTransition ()
		{
			return this.transition;
		}
	}
}

