using System;
using System.Collections.Generic;
using System.Text;

namespace plyrmgnt
{

    public enum Player_Typ
    {
        HckyPlyr, BsBallPlyr, BsktBallPlyr
    }
    public abstract class Player
    {


        //player type
        private Player_Typ plyrTyp;

        public Player_Typ Player_Typ
        {
            get { return plyrTyp; }
            set { plyrTyp = value; }
        }
        //id
        private int plyr_id;

        public int PlyrId
        {
            get { return plyr_id; }
            set { plyr_id = value; }
        }

        //name
        private string plyr_Name;

        public string Plyr_Name
        {
            get { return plyr_Name; }
            set { plyr_Name = value; }
        }
        //team name 
        private string tm_Nme;

        public string TeamName
        {
            get { return tm_Nme; }
            set { tm_Nme = value; }
        }

        private int gms_Plyd;
        //game played 
        public int TGames_Played
        {
            get { return gms_Plyd; }
            set
            {
                gms_Plyd = value;
            }
        }

        //player constructor 
        public Player(int plyr_Id, Player_Typ plyrtyp, string plyr_Nme, string tm_Nme, int gmsPlyd)
        {

            PlyrId = plyr_Id;
            Player_Typ = plyrtyp;
            Plyr_Name = plyr_Nme;
            TeamName = tm_Nme;
            TGames_Played = gmsPlyd;
        }

        //method points
        public abstract int pts();


        public override string ToString()
        {
            return $"{Player_Typ,-23}{PlyrId,+15} {Plyr_Name,-27} {TeamName,-28} {TGames_Played,+19}";
        }


    }
}
