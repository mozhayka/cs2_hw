﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Objects;

namespace Calculator
{
    public interface ILBKCalculator
    {
        public LBK FindAllLBK(DateTime day);
    }
}
