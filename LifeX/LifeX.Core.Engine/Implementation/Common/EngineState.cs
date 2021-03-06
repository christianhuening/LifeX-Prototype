﻿// // /*******************************************************
// //  * Copyright (C) Christian Hüning - All Rights Reserved
// //  * Unauthorized copying of this file, via any medium is strictly prohibited
// //  * Proprietary and confidential
// //  * This file is part of the MARS LIFE project, which is part of the MARS System
// //  * More information under: http://www.mars-group.org
// //  * Written by Christian Hüning <christianhuening@gmail.com>, 02.02.2018
// //  *******************************************************/

using System.Collections.Generic;
using LifeX.API.Agent;

namespace LifeX.Core.Engine.Implementation.Common
{
    public abstract class EngineState
    {
        public HashSet<IAgent> Agents { get; set; }
        public int TicksToSimulate { get; set; }
    }
}