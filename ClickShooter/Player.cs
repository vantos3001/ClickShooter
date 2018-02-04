using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickShooter
{
    public class Player
    {
        #region Fields

        // player's Cash
        static int cashPlayer = 0;

        // player's Characteristics
        static int maxHealth = GameConstants.DEFAULT_MAX_HEALTH_PLAYER;
        int maxAmmoInCage = GameConstants.DEFAULT_MAX_AMMO_IN_CAGE_PLAYER;
        static string colorEnamy = GameConstants.DEFAULT_COLOR_ENAMY;

        // dinamic player's characteristics for Game
        int currentHealth;
        int currentCountAmmo;



        #endregion

        #region Constructors 

        public Player()
        {
            currentHealth = maxHealth;
        }

        #endregion



        #region Properties

        public string ColorEnamy
        {
            get { return colorEnamy; }
            set { colorEnamy = value; }
        }
        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        public int CurrentHealth
        {
            get { return currentHealth; }
            set { currentHealth = value; }
        }

        public int CashPlayer
        {
            get { return cashPlayer; }
            set { cashPlayer = value; }
        }


        #endregion 


        #region Methods

        //add money when player kill enamies

        public void StartGame()
        {
            currentHealth = maxHealth;
        }
        public static void AddCashForEnamies(int moneyForPlayer)
        {

            cashPlayer += moneyForPlayer;


            //show cash to the window
            Game1.PlayerCashMessage.Text = GameConstants.CASH_MESSAGE_PREFIX + cashPlayer;
        }

        //update characteristics
        public static void AddMaxHealth()
        {
            maxHealth = maxHealth += 10;

            //show maxHealth to the window
            Game1.PlayerHealthMessage.Text = GameConstants.HEALTH_MESSAGE_PREFIX + maxHealth;
        }
        public static void AddNewColor(string colorName)
        {
            colorEnamy = colorName; 
        }

        public static bool CheckPossibleToBuyUpdate(int costMoney)
        {
            if (costMoney > cashPlayer)
                return false;
            else
            {
                return true;
            }
        }


        #endregion 



    }
}
