using System;

namespace PolarPandaAPI
{
    public class Game
    {
        public int id { get; set; }

        public string gameName { get; set; }

        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public bool isActive { get; set; }
    }
}
