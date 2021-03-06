﻿using System;
using System.Collections.Generic;

namespace LifeX.API.Agent
{
    
    public class AgentConfig<TAgent> where TAgent : IAgent
    {
        public int AgentCount { get; private set; }
        public Func<int, List<TAgent>> InitFunction { get; private set; }
        
        public AgentConfig<TAgent> Count(int amountOfAgents)
        {
            AgentCount = amountOfAgents;
            return this;
        }

        public AgentConfig<TAgent> Init(Func<int, List<TAgent>> func)
        {
            InitFunction = func;
            return this;
        }
    }
}