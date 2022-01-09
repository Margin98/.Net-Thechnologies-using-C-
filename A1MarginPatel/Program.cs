using System;
using System.Collections.Generic;
using System.Linq;

namespace plyrmgnt
{
    class Program
    {

        private static int cnt = 1;
        public static void Main(string[] args)
        {
            Console.Clear();//clear
            Console.ForegroundColor = ConsoleColor.Green;//text color


            //data

            Player plyerhcky1 = new HckyPlyr(cnt++, Player_Typ.HckyPlyr, "Margin Patel", "India", 1, 15, 15);
            players.Add(plyerhcky1);
            Player plyerhcky2 = new HckyPlyr(cnt++, Player_Typ.HckyPlyr, "Virat kohli", "India", 9, 9, 6);
            players.Add(plyerhcky2);
            Player plyerhcky3 = new HckyPlyr(cnt++, Player_Typ.HckyPlyr, "Gursharan singh Tatla ", "India", 9, 12, 12);
            players.Add(plyerhcky3);

            Player plyrbasket1 = new BsktBallPlyr(cnt++, Player_Typ.BsktBallPlyr, "kobe", "Gurdian", 19, 15, 3);
            players.Add(plyrbasket1);
            Player plyrbasket2 = new BsktBallPlyr(cnt++, Player_Typ.BsktBallPlyr, "stephen hawk", "Hunter", 10, 14, 4);
            players.Add(plyrbasket2);
            Player plyrbasket3 = new BsktBallPlyr(cnt++, Player_Typ.BsktBallPlyr, "sehwag", "Ind", 10, 19, 8);
            players.Add(plyrbasket3);

            Player plyrbaseball1 = new BsBallPlyr(cnt++, Player_Typ.BsBallPlyr, "alex subau", "secrate", 11, 2, 3);
            players.Add(plyrbaseball1);
            Player plyrbaseball2 = new BsBallPlyr(cnt++, Player_Typ.BsBallPlyr, "Anderson", "OG", 11, 5, 7);
            players.Add(plyrbaseball2);
            Player plyrbaseball3 = new BsBallPlyr(cnt++, Player_Typ.BsBallPlyr, "rock", "rocking roll", 2, 10, 10);
            players.Add(plyrbaseball3);



            bool Menu_playershw = true;


            do
            {
                Menu_playershw = Mn_Menu();
            } while (Menu_playershw);

        }
        //list
        static List<Player> players = new List<Player>();

        //main menu 
        private static bool Mn_Menu()
        {

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;//text color

            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("\t1 - Add Player info     |\n\t");
            Console.WriteLine("\t2 - Edit Player info    |\n\t");
            Console.WriteLine("\t3 - Delete Player info  |\n\t");
            Console.WriteLine("\t4 - View Players info   |\n\t");
            Console.WriteLine("\t5 - Search Player info  |\n\t");
            Console.WriteLine("\t6 - Exit                |");
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Console.Write("\nEnter your Number: ");

            //if - else if  statement to select particular option 
            int tmpnum = Convert.ToInt32(Console.ReadLine());
            if (tmpnum == 1)
            {
                Console.Clear();
                AddPlyrInfo();//calling ADD player method to add player 
                return false;
            }
            else if (tmpnum == 2){
                Console.Clear();
                EdePlyr_info();
                return false;

            }
            else if (tmpnum == 3)
            {
                Console.Clear();
                DeltPlyr_info();
                return false;
            }

            else if (tmpnum == 4)
            {
                Console.Clear();
                ViwPlyrs();
                return false;
            }

            else if (tmpnum == 5)
            {
                Console.Clear();
                SrchPlyr_info();
                return false;
            }
            else if (tmpnum == 6)
            {
                Console.Clear();
                Console.WriteLine("\n\tBye, Have a great day :)\n\t");
                return false;
            }
            else 
            {
                Console.WriteLine("Invalid number: Please enter right value .\nPress enter any key ");
                Console.ReadKey();
                return true;
            }


        }
        //  for add player information 
        private static Player AddPlyrInfo()
        {
            Console.WriteLine("------------------------------------------------------------\n");
            Console.WriteLine("Add a New Player Information:            |\n");
            Console.WriteLine("1 - Add a Hockey Player Information      |  \n\t");
            Console.WriteLine("2 - Add a BasketBall Player Information  |\n\t");
            Console.WriteLine("3 - Add a BaseBall Player Information    |\n\t");
            Console.WriteLine("4 - a Back to Main Menu                  |");
            Console.WriteLine("------------------------------------------------------------\n");

            Player_Typ plyrtyp = Player_Typ.HckyPlyr;

            bool Menu_playershw = true;
            while (Menu_playershw)
            { Menu_playershw = ForAddMnu(); }

            //switch statement for add player menu for particular sport
            bool ForAddMnu()
            {
                Console.Write("\nEnter your number: ");
                switch (Console.ReadLine())
                {

                    case "1":
                        plyrtyp = Player_Typ.HckyPlyr;
                        AddingPlayer(plyrtyp);
                        return false;
                    case "2":
                        plyrtyp = Player_Typ.BsktBallPlyr;
                        AddingPlayer(plyrtyp);
                        return false;
                    case "3":
                        plyrtyp = Player_Typ.BsBallPlyr;     
                        AddingPlayer(plyrtyp);
                        return false;
                    case "4":
                        Console.Clear();
                        Mn_Menu();
                        return false;
                    default:
                        Console.WriteLine("\n Invalid number, Please try again.");
                        return true;
                }

            }
            //will adding player info
            static void AddingPlayer(Player_Typ plyrtyp)
            {
                //variables
                int TAssists = 0;
                int TGoals = 0, Truns = 0, THomeRuns = 0, fldGoals = 0, TPointers = 0;
                bool vlid = true;

                Console.Write("\nEnter a player Name : ");
                string plyrName = Console.ReadLine();
                Console.Write("Enter a Team_Name : ");
                string tm_Nme = Console.ReadLine();

                int gmsPlyd = 0;

                while (vlid)
                {
                    Console.Write("Enter a total games Played: ");

                    bool gplayed = Int32.TryParse(Console.ReadLine(), out gmsPlyd);
                    if (gplayed && gmsPlyd >= 0)
                    {
                        vlid = false;
                    }
                    else
                    {
                        Console.WriteLine("Invalid, Enter valid number(0 or positive only)");
                        vlid = true;
                    }
                }
                //add hockey 
                if (plyrtyp == Player_Typ.HckyPlyr)
                {
                    vlid = true;
                    while (vlid)
                    {
                        Console.Write("Enter TAssists: ");
                        bool gplayed = Int32.TryParse(Console.ReadLine(), out TAssists);
                        if (gplayed && TAssists >= 0)
                        { vlid = false; }
                        else
                        {
                            Console.WriteLine("Invalid ,  Enter valid number(0 or positive only)");
                            vlid = true;
                        }
                    }
                    vlid = true;
                    while (vlid)
                    {
                        Console.Write("Enter TGoals: ");
                        bool gplayed = Int32.TryParse(Console.ReadLine(), out TGoals);
                        if (gplayed && TGoals >= 0)
                        {
                            vlid = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ,  Enter valid number(0 or positive only) ");
                            vlid = true;
                        }
                    }
                    Player p = new HckyPlyr(cnt++, plyrtyp, plyrName, tm_Nme, gmsPlyd, TAssists, TGoals);
                    players.Add(p);
                }
                //add baseball
                if (plyrtyp == Player_Typ.BsBallPlyr)
                {
                    vlid = true;
                    while (vlid)
                    {
                        Console.Write("Enter Truns: ");
                        bool gplayed = Int32.TryParse(Console.ReadLine(), out Truns);
                        if (gplayed && Truns >= 0)
                        {
                            vlid = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid,   Enter valid number(0 or positive only)");
                            vlid = true;
                        }
                    }
                    vlid = true;
                    while (vlid)
                    {
                        Console.Write("Enter home runs please: ");
                        bool gplayed = Int32.TryParse(Console.ReadLine(), out THomeRuns);
                        if (gplayed && THomeRuns >= 0)
                        {
                            vlid = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid ,  Enter valid number(0 or positive only) ");
                            vlid = true;
                        }
                    }
                    Player p = new HckyPlyr(cnt++, plyrtyp, plyrName, tm_Nme, gmsPlyd, Truns, THomeRuns);
                    players.Add(p);
                }
                //add basket ball 
                if (plyrtyp == Player_Typ.BsktBallPlyr)
                {
                    vlid = true;
                    while (vlid)
                    {
                        Console.Write("please Enter field TGoals: ");
                        bool gplayed = Int32.TryParse(Console.ReadLine(), out fldGoals);
                        if (gplayed && fldGoals >= 0)
                        {
                            vlid = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid,  Enter valid number(0 or positive only)");
                            vlid = true;
                        }
                    }
                    vlid = true;
                    while (vlid)
                    {
                        Console.Write("please Enter three pointers: ");
                        bool gplayed = Int32.TryParse(Console.ReadLine(), out TPointers);
                        if (gplayed && TPointers >= 0)
                        {
                            vlid = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid : Enter valid number(0 or positive only)");
                            vlid = true;
                        }
                    }
                    Player p = new HckyPlyr(cnt++, plyrtyp, plyrName, tm_Nme, gmsPlyd, fldGoals, TPointers);
                    players.Add(p);
                }

                //after adding player 
                Console.WriteLine("\nNew Player is Added");
                Console.WriteLine("\nView All ");
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                ViewPlayer(plyrtyp);
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\nPress any key to go to menu ");
                Console.ReadKey();
                Console.Clear();//clear 
                AddPlyrInfo();//back to add player menu 

            }
            return null;
        }

        //method to edit information of player 
        private static Player EdePlyr_info()
        {   //menu for edit
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine("Edit Player: \n\n");
            Console.WriteLine(" 1 - Edit Hockey Player Information    |\n\t");
            Console.WriteLine(" 2 - Edit BasketBall Player Information |\n\t");
            Console.WriteLine(" 3 - Edit BaseBall Player Information   |\n\t");
            Console.WriteLine(" 4 - Back to Main Menu Information      |\n");
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Player_Typ plyrtyp = Player_Typ.HckyPlyr;

            bool Menu_playershw = true;

            while (Menu_playershw)
            { Menu_playershw = EdtMnu(); }
            //for edit menu
            bool EdtMnu()
            {
                Console.Write("\nEnter your Number please: ");
                //switch statement to edit information of player of particular sport 
                switch (Console.ReadLine())
                {

                    case "1":
                        plyrtyp = Player_Typ.HckyPlyr;
                        Console.WriteLine("\nEditing Hockey Player Information");
                        EdtingPlyr_info(plyrtyp);
                        return true;
                    case "2":
                        plyrtyp = Player_Typ.BsktBallPlyr;
                        Console.WriteLine("\nEditing BasketBall Player Information");

                        EdtingPlyr_info(plyrtyp);

                        return false;
                    case "3":
                        plyrtyp = Player_Typ.BsBallPlyr;
                        Console.WriteLine("\nEditing BaseBall Player Information");
                        EdtingPlyr_info(plyrtyp);

                        return false;
                    case "4":
                        Console.Clear();

                        Mn_Menu();
                        return false;

                    default:
                        Console.WriteLine("\nInvalid,Please enter valid number .");
                        return true;
                }

            }
            //editing player information 
            static void EdtingPlyr_info(Player_Typ plyrtyp)
            {

                ViewPlayer(plyrtyp);
                bool chck = true;

                do
                {
                    Console.Write("\nplease Enter ID of Player: ");
                    int P_index = Convert.ToInt32(Console.ReadLine());
                    if (P_index < players.Count && P_index > 0)
                    {
                        if (players[P_index - 1].Player_Typ == plyrtyp)
                        {

                            int TAssists = 0, TGoals = 0, Truns = 0, THomeRuns = 0, fldGoals = 0, TPointers = 0;
                            bool vlid = true;

                            Console.Write("\nEnter New Name : ");
                            string plyrName = Console.ReadLine();

                            Console.Write("Enter new Team Name : ");
                            string tm_Nme = Console.ReadLine();

                            int gmsPlyd = 0;// 

                            while (vlid)
                            {
                                Console.Write("Enter total games Played: ");

                                bool gplayed = Int32.TryParse(Console.ReadLine(), out gmsPlyd);
                                if (gplayed && gmsPlyd >= 0)
                                {
                                    vlid = false;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid ,  Enter valid number(0 or positive only)");
                                    vlid = true;
                                }
                            }
                            //FOR HOCKEY
                            if (plyrtyp == Player_Typ.HckyPlyr)
                            {
                                vlid = true;
                                while (vlid)
                                {
                                    Console.Write("Enter TAssists: ");
                                    bool gplayed = Int32.TryParse(Console.ReadLine(), out TAssists);
                                    if (gplayed && TAssists >= 0)
                                    {
                                        vlid = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid , Enter valid number(0 or positive only)");
                                        vlid = true;
                                    }
                                }

                                vlid = true;

                                while (vlid)
                                {
                                    Console.Write("Enter TGoals: ");
                                    bool gplayed = Int32.TryParse(Console.ReadLine(), out TGoals);
                                    if (gplayed && TGoals >= 0)
                                    {
                                        vlid = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ,  Enter valid number(0 or positive only)");
                                        vlid = true;
                                    }
                                }
                                players[P_index - 1] = new HckyPlyr(P_index, plyrtyp, plyrName, tm_Nme, gmsPlyd, TAssists, TGoals);
                            }
                            //FOR BASEBALL
                            if (plyrtyp == Player_Typ.BsBallPlyr)
                            {
                                vlid = true;
                                while (vlid)
                                {
                                    Console.Write("Enter Truns: ");
                                    bool gplayed = Int32.TryParse(Console.ReadLine(), out Truns);
                                    if (gplayed && Truns >= 0)
                                    {
                                        vlid = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ,  Enter valid number(0 or positive only)");
                                        vlid = true;
                                    }
                                }

                                vlid = true;
                                while (vlid)
                                {
                                    Console.Write("Enter home Truns: ");
                                    bool gplayed = Int32.TryParse(Console.ReadLine(), out THomeRuns);
                                    if (gplayed && THomeRuns >= 0)
                                    {
                                        vlid = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ,  Enter valid number(0 or positive only)");
                                        vlid = true;
                                    }
                                }
                                players[P_index - 1] = new HckyPlyr(P_index, plyrtyp, plyrName, tm_Nme, gmsPlyd, Truns, THomeRuns);
                            }
                            //FOR BASKETBALL 
                            if (plyrtyp == Player_Typ.BsktBallPlyr)
                            {
                                vlid = true;
                                while (vlid)
                                {
                                    Console.Write("Enter field TGoals: ");


                                    bool gplayed = Int32.TryParse(Console.ReadLine(), out fldGoals);
                                    if (gplayed && fldGoals >= 0)
                                    {
                                        vlid = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ,  Enter valid number(0 or positive only)");
                                        vlid = true;
                                    }
                                }

                                vlid = true;
                                while (vlid)
                                {
                                    Console.Write(" please Enter three pointers ");
                                    bool gplayed = Int32.TryParse(Console.ReadLine(), out TPointers);
                                    if (TPointers >= 0 && gplayed)
                                    {
                                        vlid = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Invalid ,  Enter valid number(0 or positive only)");
                                        vlid = true;
                                    }
                                }
                                players[P_index - 1] = new HckyPlyr(P_index, plyrtyp, plyrName, tm_Nme, gmsPlyd, fldGoals, TPointers);
                            }
                            Console.WriteLine($"\n\nPlayer ID = {P_index} Updated||");
                            Console.Write("\n\n\t\t\t\t|| View all players || ");
                            ViewPlayer(plyrtyp);
                            chck = false;
                        }
                        else
                        {
                            Console.WriteLine("Wrong Id");
                            chck = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Wrong Id");
                        chck = true;
                    }

                } while (chck);
                Console.WriteLine("\n Press any key:");
                Console.ReadKey();
                Console.Clear();
                EdePlyr_info();
            }
            return null;
        }

        //DELTE PLAYER 
        private static Player DeltPlyr_info()
        {
            Console.Clear();//clear
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" Delete Player: \n");
            Console.WriteLine(" 1 - Delete Hockey Player Information        |\n\t\t");
            Console.WriteLine(" 2 - Delete BasketBall Player Information    | \n\t\t");
            Console.WriteLine(" 3 - Delete BaseBall Player Information      | \n\t\t");
            Console.WriteLine(" 4 - Back to Main Menu Information           |\n\t\t");
            Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
            Player_Typ plyrtyp = Player_Typ.HckyPlyr;

            bool Menu_playershw = true;

            do { Menu_playershw = DeleteMenu(); } while (Menu_playershw);
            bool DeleteMenu()
            {
                Console.Write("\nEnter your Number: ");
                //switch statement to choose particular sport 
                switch (Console.ReadLine())
                {

                    case "1":
                        plyrtyp = Player_Typ.HckyPlyr;
                        Console.WriteLine("all hockey players  ");
                        DltingPlyr_info(plyrtyp);
                        return false;
                    case "2":
                        plyrtyp = Player_Typ.BsktBallPlyr;
                        Console.WriteLine(" all basketball players");
                        DltingPlyr_info(plyrtyp);
                        return false;
                    case "3":
                        plyrtyp = Player_Typ.BsBallPlyr;
                        Console.WriteLine("Baseball all players ");
                        DltingPlyr_info(plyrtyp);

                        return false;
                    case "4":
                        Console.Clear();
                        Mn_Menu();
                        return false;

                    default:
                        Console.WriteLine("Invalid Number. Please do it again.");
                        return true;
                }

            }
            //method to delete player from particular sport 
            static void DltingPlyr_info(Player_Typ plyrtyp)
            {

                ViewPlayer(plyrtyp);
                bool chck = true;
                while (chck)
                {
                    int P_index = -1;
                    int P_get_Ind = -1;
                    bool vlid = true;


                    while (vlid)
                    {
                        Console.Write("\n\n Enter ID of Player that you want to delete it: ");
                        bool gplayed = Int32.TryParse(Console.ReadLine(), out P_index);
                        if (gplayed)
                        {
                            vlid = false;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Id:");
                            vlid = true;
                        }
                    }
                    P_get_Ind = players.FindIndex(p => p.PlyrId == P_index);

                    if (P_get_Ind != -1)
                    {
                        if (players[P_get_Ind].Player_Typ == plyrtyp)
                        {
                            players.RemoveAt(P_get_Ind);
                            Console.WriteLine($"\nPlayer with ID = {P_index} Deleted\n\nView all ");
                            ViewPlayer(plyrtyp);
                            Console.Write("\nPress any key");
                            Console.ReadKey();
                            chck = false;

                        }
                        else
                        {
                            Console.WriteLine($"\nNo {plyrtyp} with  Id = {P_index}.\nPress any key to back to Delete menu.");
                            Console.ReadKey();
                            chck = false;
                        }

                    }
                    else
                    {
                        Console.WriteLine("\n No information found.\n Press any key to back to Delete menu");
                        Console.ReadKey();
                        chck = false;
                    }
                }
                DeltPlyr_info();//delete menu 
            }
            return null;
        }

        //method to search player 
        private static void SrchPlyr_info()
        {
            Console.WriteLine("\n\t Search Players");
            Console.Write("\n\t Enter player name to search: ");

            string srcval = Console.ReadLine();


            var SrcRes = from player in players where player.Plyr_Name.Contains(srcval, StringComparison.OrdinalIgnoreCase) select player;

            if (SrcRes.Count() > 0)
            {
                Console.WriteLine($"\n All players list whose name match with it : {srcval}.\n");
                foreach (var x in SrcRes)
                {
                    //for hockey
                    if (x.Player_Typ == Player_Typ.HckyPlyr)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("||Hockey Players||\n");
                        Console.WriteLine($"{ "Player_Type",-23}{" Player_ID",+15} {"Player_Name",-27} {"Team_Name",-28} {"Games_Played",+19    }\t{"g_Assit",+15}\t{"T_Gols",+19}\t{"pts",+10}\n");
                        Console.WriteLine(x);//print player name  
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\n\n\n");

                    }
                    //for basketball
                    if (x.Player_Typ == Player_Typ.BsktBallPlyr)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\n\n\n\n");

                        Console.WriteLine("||BasketBall Players||\n");
                        Console.WriteLine($"{ "Player_Type",-23}{" Player_ID",+15} {"Player_Name",-27} {"Team_Name",-28} {"Games_Played",+19}\t{"Field T_Gols",+15}\t{"Three_Pointers",+19}\t{"pts",+10}\n");
                        Console.WriteLine(x);//print player name  
                        Console.ForegroundColor = ConsoleColor.White;


                    }
                    //for baseball
                    if (x.Player_Typ == Player_Typ.BsBallPlyr)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\n\n\n");

                        Console.WriteLine("||BaseBall Players||\n");
                        Console.WriteLine($"{ "Player_Type",-23}{" Player_ID",+15} {"Player_Name",-27} {"Team_Name",-28} {"Games_Played",+19}\t{"T_Runs",+15}\t{"Home T_Runs",+19}\t{"pts",+10}\n");
                        Console.WriteLine(x);//print player name  
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n\n\n\n");
                    }
                }
            }
            else
            {
                Console.WriteLine("\n\n\t No data exist:");
            }
            Console.Write("\n Press any key");
            Console.ReadKey();
            Mn_Menu();//back to main 
        }
        //method to view all players 
        private static void ViwPlyrs()
        {



            Console.WriteLine("\n\t View Players from all sports \n\n");

            ViewPlayer(Player_Typ.HckyPlyr);
            Console.WriteLine("\n\n\n");
            ViewPlayer(Player_Typ.BsktBallPlyr);
            Console.WriteLine("\n\n\n");

            ViewPlayer(Player_Typ.BsBallPlyr);
            Console.Write("\nPress any key");
            Console.ReadKey();
            Mn_Menu();
        }
        //view player of particular sport
        static void ViewPlayer(Player_Typ plyrtyp)
        {
            //hockey player 
            var hckyPlyers = from player in players where player.Player_Typ == Player_Typ.HckyPlyr select player;
            //basketball players 
            var bsktBolPlyrs = from player in players where player.Player_Typ == Player_Typ.BsktBallPlyr select player;
            //baseball players 
            var BsBllPlyrs = from player in players where player.Player_Typ == Player_Typ.BsBallPlyr select player;
            //hockey 
            if (plyrtyp == Player_Typ.HckyPlyr)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n\t\t\t\t|| Hockey Players ||\n");

                Console.WriteLine($"{ "Player_Type",-23}{" Player_ID",+15} {"Player_Name",-27} {"Team_Name",-28} {"Games_Played",+19    }\t{"g_Assit",+15}\t{"T_Gols",+19}\t{"pts",+10}\n");
                foreach (var x in hckyPlyers)
                    Console.WriteLine(x);//print player name  
                Console.ForegroundColor = ConsoleColor.Red;

            }
            //basketball
            if (plyrtyp == Player_Typ.BsktBallPlyr)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n\t\t\t\t|| BasketBall Players ||\n");

                Console.WriteLine($"{ "Player_Type",-23}{" Player_ID",+15} {"Player_Name",-27} {"Team_Name",-28} {"Games_Played",+19}\t{"Field T_Gols",+15}\t{"Three_Pointers",+19}\t{"pts",+10}\n");
                foreach (var x in bsktBolPlyrs)
                    Console.WriteLine(x);//print player name  

                Console.ForegroundColor = ConsoleColor.Red;
            }
            //baseball
            if (plyrtyp == Player_Typ.BsBallPlyr)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\n------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\n\t\t\t\t|| BaseBall Players ||\n");

                Console.WriteLine($"{ "Player_Type",-23}{" Player_ID",+15} {"Player_Name",-27} {"Team_Name",-28} {"Games_Played",+19}\t{"T_Runs",+15}\t{"Home_T_Runs",+19}\t{"pts",+10}\n");
                foreach (var x in BsBllPlyrs)
                    Console.WriteLine(x);//print player name  
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\n\n\n------------------------------------------------------------------------------------------------------------------------");

            }
        }

    }
}
