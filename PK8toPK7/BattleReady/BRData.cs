using System;
namespace PKConverter.BattleReady
{
	public class BRData
	{
        public string name { get; set; }
        public BRBuild[] builds { get; set; }

      
    }

    public class BRBuild
    {
        public string name { get; set; }
        public string recommendation { get; set; }
        public string nature { get; set; }
        public string ability { get; set; }
        public EVs evs { get; set; }
        public string teraType { get; set; }
        public string heldItem { get; set; }
        public string[] moveset { get; set; }
    }

    public class EVs
    {
        public int HP { get; set; }
        public int ATK { get; set; }
        public int DEF { get; set; }
        public int SPE { get; set; }
        public int SPA { get; set; }
        public int SPD { get; set; }

    }
}

