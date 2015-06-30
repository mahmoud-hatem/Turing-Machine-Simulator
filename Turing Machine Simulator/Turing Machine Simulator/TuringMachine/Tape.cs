using System;
using System.Collections.Generic;

namespace TuringMachineProject
{
	public class Tape
	{
		private Stack<char> leftStack;
		private Stack<char> rightStack;
		private const char BLANK = '#';
        private const int NUM_BLANK = 10;
		private char current;

		public char Current 
		{
			get {return this.current;}
		}

		public Tape () : this(BLANK.ToString())
		{
		}
		public Tape(string initialString)
		{
			this.leftStack = new Stack<char> ();
			this.rightStack = new Stack<char> ();

            for (int i = 0; i < NUM_BLANK; ++i)
            {
                this.leftStack.Push(BLANK);
                this.rightStack.Push(BLANK);
            }

			for (int i = initialString.Length - 1; i >= 0; --i) {
				this.rightStack.Push(initialString[i]);
			}

			this.current = this.rightStack.Pop ();
		}

		public void left()
		{
			this.rightStack.Push (this.current);
			if (this.leftStack.Count == 0) {
				this.current = BLANK;
				this.leftStack.Push (BLANK);
			} else {
				this.current = this.leftStack.Pop ();
			}
		}

		public void right()
		{
			this.leftStack.Push (this.current);
			if (this.rightStack.Count == 0) {
				this.current = BLANK;
				this.rightStack.Push (BLANK);
			} else {
				this.current = this.rightStack.Pop ();
			}
		}

		public void write(char newChar)
		{
			this.current = newChar;
		}

		public override string ToString ()
		{
			char[] tmp;

			tmp = this.leftStack.ToArray ();
			Array.Reverse (tmp);
			string left = new string (tmp);

			//no need to reverse
			string right = new string (this.rightStack.ToArray());


			return string.Format ("{0}", left + this.current + right);
		}

        public int currentPosition()
        {
            return leftStack.Count;
        }
	}
}

