using Newtonsoft.Json;
using System.Collections.Generic;

namespace Stockfighter.HttpModels
{
    public class LevelResponse
    {
        public bool Ok { get; set; }
        public string Account { get; set; }
        public int InstanceId { get; set; }
        public Instruction Instructions { get; set; }
        public string[] Tickers { get; set; }
        public string[] Venues { get; set; }

        public class Instruction
        {
            public string Instructions { get; set; }
        }
    }
}