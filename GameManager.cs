using System;
using System.Linq;
using System.Collections.Generic;
using PolarPandaWebAPI;

namespace PolarPandaAPI
{
    public class GameManager
    {
        public int status {get; set; }

        public Game currentGame { get; set; }

        public List<Player> players { get; set; }

       
    }
}
