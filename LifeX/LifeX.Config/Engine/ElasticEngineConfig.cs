﻿namespace LifeX.Config.Engine
{
    public class ElasticEngineConfig : EngineConfig
    {
        public static ConservativeEngineConfig FromDefault()
        {
            var config = new ConservativeEngineConfig();
            return config;
        }
    }
}