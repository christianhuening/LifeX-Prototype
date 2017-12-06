﻿using System.Collections.Generic;
using System.Threading.Tasks;
using LifeX.API;
using LifeX.Runtime;

namespace WolfSheep.Model
{
    public interface IWolf : IAgent
    {
        
    }
    
    public enum WolfPlan
    {
        WalkAround,
        AttackSheep,
    }
    
    public class WolfState : AgentState
    {
        public double Hunger;
        public WolfPlan Plan;
        public ISheep Target;
        // public IWolf Leader;
        public IEnumerable<MoveAction> Sheeps; // can get sheep instances from Action.GetSource<ISheep>()
        public double CurrentHeight;
        public double ReproductionProbability;
        public double GainFromFood;
    }

    public class WolfAgent : AgentBase<WolfState>, IWolf {
        
        public async Task Initialize()
        {
            State.Plan = WolfPlan.WalkAround;
            
            SubscribeAction<MoveAction>()
                .From<ISheep>()
                .Near(Parameter.Optional<double>("WOLF_VIEW_RADIUS", 5.0d))
                .Memory(State.Sheeps, 3, (old, recent) => State.Position.DistanceTo(old.Position) > State.Position.DistanceTo(recent.Position))
                .ForgetIf<OutOfSightAction>() // both action types need to implement IForgettable action
                .ForEach((action) => { // instead of lambda member function is also possible
                    if (State.Hunger > 100)
                    {
                        State.Plan = WolfPlan.AttackSheep;
                    }
                });
                
            await WriteStateAsync();
        }

        public async Task Tick()
        {
            // do something
            if (State.Target != null)
            {
                if (await State.Target.TryKill())
                {
                    State.Hunger -= 100;
                }
            }

            TryAction(new MoveAction(null));
        }
    }

}