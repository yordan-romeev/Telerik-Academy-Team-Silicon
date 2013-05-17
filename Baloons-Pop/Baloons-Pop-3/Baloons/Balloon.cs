using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    public class Balloon
    {
        private int value;

        public int Value
        {
            get
            {
                return this.value;
            }

            set
            {
                if (value <= 0 || 5 <= value)
                {
                    throw new ArgumentOutOfRangeException("Balloon's value must be in the [1,4] range.");
                }

                this.value = value;
            }
        }

        public Balloon(int value)
        {
            this.Value = value;
        }

        public void Pop()
        {
            this.value = 0;
        }
    }
}
