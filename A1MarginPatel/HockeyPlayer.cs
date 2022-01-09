using System;
using System.Collections.Generic;
using System.Text;

namespace plyrmgnt
{
    class HckyPlyr : Player
    {
        //assist 
        private int asst;

        public int g_Assit
        {
            get { return asst; }
            set { asst = value; }
        }
        //goals 
        private int _goals;

        public int T_Gols
        {
            get { return _goals; }
            set { _goals = value; }
        }

        public HckyPlyr(int plyr_Id, Player_Typ plyrtyp, string plyr_Nme, string tm_Nme,
            int gmsPlyd, int TAssists, int TGoals) : base(plyr_Id, plyrtyp, plyr_Nme, tm_Nme, gmsPlyd)
        {
            g_Assit = TAssists;
            T_Gols = TGoals;
        }
        //override points method 
        public override int pts()
        {
            return g_Assit + (2 * T_Gols);
        }

        public override string ToString()
        {
            return base.ToString() + $"\t{g_Assit,+15}\t{T_Gols,+19}\t{pts(),+10}";
        }

    }

}
