using System;
using System.Collections.Generic;
using System.Text;

namespace plyrmgnt
{
    class BsktBallPlyr : Player
    {   //feild goal
        private int f_Gols;

        public int FieldGoals
        {
            get { return f_Gols; }
            set { f_Gols = value; }
        }
        //three points 
        private int _tPntrs;

        public int ThreePointers
        {
            get { return _tPntrs; }
            set { _tPntrs = value; }
        }
        public BsktBallPlyr(int plyr_Id, Player_Typ plyrtyp, string plyr_Nme, string tm_Nme,
          int gmsPlyd, int fldGoals, int TPointers) : base(plyr_Id, plyrtyp, plyr_Nme, tm_Nme, gmsPlyd)
        {
            FieldGoals = fldGoals;
            ThreePointers = TPointers;
        }
        //override point method 
        public override int pts()
        {
            return ((FieldGoals - ThreePointers) + (2 * ThreePointers));
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{FieldGoals,+15}\t{ThreePointers,+19}\t{pts(),+10}";
        }
    }
}
