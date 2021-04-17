using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LCRApp.ViewModel
{
    class lcrVM : BaseClass
    {
        public RelayCommand diceRollCommand { get; set; }

        public RelayCommand ResetCommand { get; set; }
        
        Random random = new Random();

        private int _trunCounter=1;

        public int trunCounter
        {
            get { return _trunCounter; }
            set
            {
                _trunCounter = value;
                OnPropertyChanged();
            }
        }

        private bool _isEnable =true;

        public bool isEnable
        {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }


        
        #region Dice Properties
        private string _Dice1;

        public string Dice1
        {
            get { return _Dice1; }
            set
            {
                _Dice1 = value;
                OnPropertyChanged();
            }
        }


        private string _Dice2;

        public string Dice2
        {
            get { return _Dice2; }
            set
            {
                _Dice2 = value;
                OnPropertyChanged();
            }
        }

        private string _Dice3;

        public string Dice3
        {
            get { return _Dice3; }
            set
            {
                _Dice3 = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Chip Counter properties

        private int _Chip1 = 3;

        public int Chip1
        {
            get { return _Chip1; }
            set
            {
                _Chip1 = value;
                OnPropertyChanged();
            }
        }

        private int _Chip2 = 3;

        public int Chip2
        {
            get { return _Chip2; }
            set
            {
                _Chip2 = value;
                OnPropertyChanged();
            }
        }


        private int _Chip3 = 3;

        public int Chip3
        {
            get { return _Chip3; }
            set
            {
                _Chip3 = value;
                OnPropertyChanged();
            }
        }

        private int _Chip4 = 3;

        public int Chip4
        {
            get { return _Chip4; }
            set
            {
                _Chip4 = value;
                OnPropertyChanged();
            }
        }

        private int _centerChip = 0;

        public int CenterChip
        {
            get { return _centerChip; }
            set
            {
                _centerChip = value;
                OnPropertyChanged();
            }
        }



        #endregion


        #region user properties

        private string _winner ;

        public string winner
        {
            get { return _winner; }
            set
            {
                _winner = value;
                OnPropertyChanged();
            }
        }



        private string _user1 = "JOHN";

        public string user1
        {
            get { return _user1; }
            set
            {
                _user1 = value;
                OnPropertyChanged();
            }
        }


        private string _user2 = "Albert";

        public string user2
        {
            get { return _user2; }
            set
            {
                _user2 = value;
                OnPropertyChanged();
            }
        }


        private string _user3 = "Mac";

        public string user3
        {
            get { return _user3; }
            set
            {
                _user3 = value;
                OnPropertyChanged();
            }
        }


        private string _user4 = "JOSH";

        public string user4
        {
            get { return _user4; }
            set
            {
                _user4 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region background properties
        private string _background1 = "LightBlue";

        public string background1
        {
            get { return _background1; }
            set
            {
                _background1 = value;
                OnPropertyChanged();
            }
        }


        private string _background2 = "LightPink";

        public string background2
        {
            get { return _background2; }
            set
            {
                _background2 = value;
                OnPropertyChanged();
            }
        }


        private string _background3 = "LightPink";

        public string background3
        {
            get { return _background3; }
            set
            {
                _background3 = value;
                OnPropertyChanged();
            }
        }


        private string _background4 = "LightPink";

        public string background4
        {
            get { return _background4; }
            set
            {
                _background4 = value;
                OnPropertyChanged();
            }
        }
        #endregion

        public lcrVM()
        {
            diceRollCommand = new RelayCommand(o => diceCommand());
            ResetCommand = new RelayCommand(o => refreshCommand());
        }

        private void refreshCommand()
        {
            Dice1 = string.Empty;
            Dice2 = string.Empty;
            Dice3 = string.Empty;

            Chip1 = 3;
            Chip2 = 3;
            Chip3 = 3;
            Chip4 = 3;
            CenterChip = 0;

            trunCounter = 1;

            isEnable = true;

            background1 = "LightBlue";
            background2 = "LightPink";
            background3 = "LightPink";
            background4 = "LightPink";

        }

        private void diceCommand()
        {
            lcrVM obllcr = new lcrVM();
            Dice1 = string.Empty;
            Dice2 = string.Empty;
            Dice3 = string.Empty;

            // nextturn();

            WinnerCheck();


            if (trunCounter == 1 )
            {
                if (Chip1 > 0)
                {
                    lcrRule(trunCounter);
                }               
                background1 = "LightPink";
                background2 = "LightBlue";
                background3 = "LightPink";
                background4 = "LightPink";
                trunCounter++;                
                return;
            }
            
            if (trunCounter == 2)
            {
                if (Chip2 > 0)
                {
                    lcrRule(trunCounter);
                }
                
                background1 = "LightPink";
                background2 = "LightPink";
                background3 = "LightBlue";
                background4 = "LightPink";
                trunCounter++;

                return;
            }

           
            if (trunCounter == 3 )
            {
                if (Chip3 > 0)
                {
                    lcrRule(trunCounter);
                }
                
                background1 = "LightPink";
                background2 = "LightPink";
                background3 = "LightPink";
                background4 = "LightBlue";
                trunCounter++;
                return;
            }
            
            if (trunCounter == 4 )
            {
                if (Chip4 > 0)
                {
                    lcrRule(trunCounter);
                }
                
                background1 = "LightBlue";
                background2 = "LightPink";
                background3 = "LightPink";
                background4 = "LightPink";
                trunCounter = 1;
                               
                return;
            }
                                  
        }

        private void WinnerCheck()
        {
            int win = 0;
            int winneruser = 0;
            lcrVM obllcr = new lcrVM();
            for (int i = 1; i <= 4; i++)
            {
                var chip = "Chip" + i;
                var val = Convert.ToInt16(GetType().GetProperty(chip).GetValue(this, null));
                if (val<=0)
                {
                    win++;
                }
                else
                {
                    winneruser = i;
                }
            }

            if (win==3)
            {
                var winuser = "user" + winneruser;
                var val = GetType().GetProperty(winuser).GetValue(this, null);
                winner =  val + " is winner";
                isEnable = false;
                
            }

        }

      
        private void lcrRule(int turnCounter)
        {
            switch (turnCounter)
            {
                case 1:
                    var chip1count = Chip1;
                    if (chip1count>=3)
                    {
                        diceRoll3();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice3), turnCounter);
                    }
                    if (chip1count == 2)
                    {
                        diceRoll2();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                    }

                    if (chip1count == 1)
                    {
                        diceRoll1();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                    }


                    break;
                case 2:
                    var chip2count = Chip2;
                    if (chip2count >= 3)
                    {
                        diceRoll3();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice3), turnCounter);
                    }
                    if (chip2count == 2)
                    {
                        diceRoll2();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                    }

                    if (chip2count == 1)
                    {
                        diceRoll1();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                    }


                    break;
                case 3:
                    var chip3count = Chip3;
                    if (chip3count >= 3)
                    {
                        diceRoll3();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice3), turnCounter);
                    }
                    if (chip3count == 2)
                    {
                        diceRoll2();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                    }

                    if (chip3count == 1)
                    {
                        diceRoll1();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                    }

                    break;
                case 4:
                    var chip4count = Chip4;
                    if (chip4count >= 3)
                    {
                       diceRoll3();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice3), turnCounter);
                    }
                    if (chip4count == 2)
                    {
                        diceRoll2();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                        dicecommonrule(Convert.ToInt32(Dice2), turnCounter);
                    }

                    if (chip4count == 1)
                    {
                        diceRoll1();
                        dicecommonrule(Convert.ToInt32(Dice1), turnCounter);
                    }

                    break;

            }
            
        }

        private void dicecommonrule(int diceNo,int turncount)
        {
            switch (diceNo)
            {
                case 4:
                    // code block 
                    if (turncount==1)
                    {
                        Chip1 = Chip1 - 1;
                        Chip2 = Chip2 + 1;
                    }
                    if (turncount == 2)
                    {
                        Chip2 = Chip2 -1;
                        Chip3 = Chip3 + 1;
                    }
                    if (turncount == 3)
                    {
                        Chip3 = Chip3 - 1;
                        Chip4 = Chip4 + 1;
                    }
                    if (turncount == 4)
                    {
                        Chip4 = Chip4 - 1;
                        Chip1 = Chip1 + 1;
                    }
                   

                    break;
                case 5:
                    if (turncount == 1)
                    {
                        Chip1 = Chip1 - 1;
                        CenterChip = CenterChip + 1;
                    }
                    if (turncount == 2)
                    {
                        Chip2 = Chip2 - 1;
                        CenterChip = CenterChip + 1;
                    }
                    if (turncount == 3)
                    {
                        Chip3 = Chip3 - 1;
                        CenterChip = CenterChip + 1;
                    }
                    if (turncount == 4)
                    {
                        Chip4 = Chip4 - 1;
                        CenterChip = CenterChip + 1;
                    }

                    

                    break;
                case 6:
                    if (turncount == 1)
                    {
                        Chip1 = Chip1 - 1;
                        Chip4 = Chip4 + 1;
                    }
                    if (turncount == 2)
                    {
                        Chip2 = Chip2 - 1;
                        Chip1 = Chip1 + 1;
                    }
                    if (turncount == 3)
                    {
                        Chip3 = Chip3 - 1;
                        Chip2 = Chip2 + 1;
                    }
                    if (turncount == 4)
                    {
                        Chip4 = Chip4 - 1;
                        Chip3 = Chip3 + 1;
                    }

                    break;
                default:
                    break;
            }
        }

        private void diceRoll3()
        {
            Dice1 = random.Next(1, 6).ToString();
            Dice2 = random.Next(1, 6).ToString();
            Dice3 = random.Next(1, 6).ToString();
        }

        private void diceRoll2()
        {
            Dice1 = random.Next(1, 6).ToString();
            Dice2 = random.Next(1, 6).ToString();
           
        }

        private void diceRoll1()
        {
            Dice1 = random.Next(1, 6).ToString();            
        }
    }
}
