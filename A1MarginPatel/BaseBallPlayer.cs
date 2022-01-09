using System;
using System.Collections.Generic;
using System.Text;

namespace plyrmgnt
{
    class BsBallPlyr : Player
    {   //player run
        private int p_runs;
        public int T_Runs
        {
            get { return p_runs; }
            set { p_runs = value; }
        }

        private int Hm_Runs;
        //for home run
        public int Hom_Runs
        {
            get { return Hm_Runs; }
            set { Hm_Runs = value; }
        }

        public BsBallPlyr(int plyr_Id, Player_Typ plyrtyp, string plyr_Nme, string tm_Nme,
         int gmsPlyd, int Truns, int THomeRuns) : base(plyr_Id, plyrtyp, plyr_Nme, tm_Nme, gmsPlyd)
        {
            T_Runs = Truns;
            Hom_Runs = THomeRuns;
        }

        //overriding point method 
        public override int pts()
        {
            return ((T_Runs - Hom_Runs) + (2 * Hom_Runs));
        }
        public override string ToString()
        {
            return base.ToString() + $"\t{T_Runs,+15}\t{Hom_Runs,+19}\t{pts(),+10}";
        }
    }

}
