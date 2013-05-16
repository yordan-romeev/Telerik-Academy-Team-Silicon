﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonsPops
{
    class Balloon
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
                this.value = value;
            }
        }

        public Balloon(int value)
        {
            this.Value = value;
        }
    }
}