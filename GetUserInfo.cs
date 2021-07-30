using System;

namespace PolarPandaWebAPI
{
    public class GetUserInfo
    {
        public int twitchID {get; set;}
        public string displayName { get; set;}
        public string avatarURL { get; set; }
        public int gold { get; set; }
    }
}
