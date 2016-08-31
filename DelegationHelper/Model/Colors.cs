﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegationHelper.Model
{
    public class Colors
    {
        public byte R { set; get; }
        public byte G { set; get; }
        public byte B { set; get; }

        public Colors(byte r, byte g, byte b)
        {
            this.R = r;
            this.B = b;
            this.G = g;
        }


    }
}
