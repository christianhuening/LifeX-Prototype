﻿﻿using System;
 using System.Threading;
 using Orleans;
using Orleans.Runtime;

namespace LifeX.Client
{
    public static class DefaultClient
    {
        
        
        public static ClientConfiguration DefaultConfiguration()
        {
            return ClientConfiguration.LocalhostSilo();
        }
        
        public static IClusterClient Initialize(ClientConfiguration config, int initializeAttemptsBeforeFailing=5)
        {
            var attempt = 0;
            IClusterClient client = null;
            while (attempt < initializeAttemptsBeforeFailing)
            {
                try
                {
                    var builder = new ClientBuilder().ConfigureAppConfiguration();

                    builder.ConfigureApplicationParts(parts => parts.AddFromApplicationBaseDirectory());
                            
                    client = builder.Build();
                    client.Connect().Wait();
                    
                    break;

                }
                catch (Exception ex) when (ex is AggregateException || ex is SiloUnavailableException)
                {
                    attempt++;
                    Console.WriteLine($"Attempt {attempt} of {initializeAttemptsBeforeFailing} failed to initialize the Orleans client.");
                    if (attempt > initializeAttemptsBeforeFailing)
                    {
                        throw;
                    }
                    Thread.Sleep(TimeSpan.FromSeconds(2));
                }

                attempt++;
            }
            return client;
        }
    }
}