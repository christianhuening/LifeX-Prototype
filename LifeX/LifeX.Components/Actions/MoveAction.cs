﻿using LifeX.API.Action;
using LifeX.API.Agent;
using LifeX.API.Environment;

namespace LifeX.Components.Actions
{
    public class MoveAction : IAction
    {
        public MoveAction(IVector newPosition)
        {
            Position = newPosition;
        }

        public IVector Position { get; set; }
        public IAgent Source { get; set; }
    }


}