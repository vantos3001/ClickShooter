using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClickShooter
{
    public static class GameConstants
    {
        //resolution
        public const int WINDOW_WIDTH = 800;
        public const int WINDOW_HEIGHT = 600;

        // player characteristics

        // default characteristics
        public const int DEFAULT_MAX_HEALTH_PLAYER = 100;
        public const int DEFAULT_MAX_AMMO_IN_CAGE_PLAYER = 30;
        public const string DEFAULT_COLOR_ENAMY = "yellow";


        // in milleseconds
        public const int RELOAD_TIME_OF_WEAPONS = 1500;

        // enemies characteristics
            //little circle
        public const int DAMAGE_LITTLE_CIRCLE = 5;
        public const int MONEY_FOR_LITTLE_CIRCLE = 1;
        public const int MAX_HEALTH_LITTLE_CIRCLE = 1;
        public const int NUMBER_OF_LITTLE_CIRCLE = 4;

        //big circle
        public const int DAMAGE_BIG_CIRCLE = 10;
        public const int MONEY_FOR_BIG_CIRCLE = 2;
        public const int MAX_HEALTH_BIG_CIRCLE = 2;
        public const int NUMBER_OF_BIG_CIRCLE = 3;

        //different with circles
        //when big circle dead Spawn new little circles
        public const int MAX_COUNT_LITTLE_CIRCLE_AFTER_KILL_BIG_CIRCLE = 3;
        public const float SPEED_MIN_LITTLE_CIRCLE_AFTER_KILL_BIG_CIRCLE = 0.2f;
        public const float SPEED_RANGE_CIRCLE_AFTER_KILL_BIG_CIRCLE = 0.15f;



        //display support
        public const int TOP_MENUBUTTON_OFFSET = 100;
        public const int HORIZONTAL_MENUBUTTON_OFFSET = WINDOW_WIDTH / 2;
        public const int VERTICAL_MENUBUTTON_SPACING = 125;
        //back button support
        public const int HORIZONTAL_BACK_MENUBUTTON_OFFSET = HORIZONTAL_MENUBUTTON_OFFSET + WINDOW_WIDTH / 2 - 150;
        public const int VERTICAL_BACK_MENUBUTTON_OFFSET = 500;

        //shop button support
        public const int IMAGES_PER_ROW_FOR_SHOP_BUTTON = 3;
        public const int VERTICAL_SHOPBUTTON_OFFSET = TOP_MENUBUTTON_OFFSET;
        public const int VERTICAL_SHOPBUTTON_SPACING = VERTICAL_MENUBUTTON_SPACING;
        public const int HORIZONTAL_SHOPBUTTON_OFFSET = HORIZONTAL_MENUBUTTON_OFFSET;
        public const int HORIZONTAL_SHOPBUTTON_SPACING = 85;
        public const int HORIZONTAL_SHOPBUTTON_ADD_MAXHEALTH_OFFSET = HORIZONTAL_SHOPBUTTON_OFFSET + 170;

        //color shop button support
        public const string COLOR_ENAMY_GREEN = "green";
        public const string COLOR_ENAMY_RED = "red";
        public const string COLOR_ENAMY_SECRET= "secret";

        //cost support
        public const int COST_MONEY_CIRCLE = 100;
        public const int COST_MONEY_SECRET_CIRCLE = 150;
        public const int COST_MONEY_UP_MAX_HEALTH = 50;

        //message support
        public const string HEALTH_MESSAGE_PREFIX = "Health: ";
        public const string CASH_MESSAGE_PREFIX = "Cash: ";
        public const string TEXT_GAME_OVER = "GAME OVER";
        //massage placement
        public const int VERTICAL_HEALTH_MESSAGE_OFSSET = 25;
        public const int HORIZONTAL_HEALTH_MESSAGE_OFSSET = 100;
        public const int VERTICAL_CASH_MESSAGE_OFFSET = 2* VERTICAL_HEALTH_MESSAGE_OFSSET;
        public const int HORIZONTAL_CASH_MESSAGE_OFFSET = HORIZONTAL_HEALTH_MESSAGE_OFSSET;
        public const int VERTICAL_GAME_OVER_OFFSET = WINDOW_HEIGHT / 2;
        public const int HORIZONTAL_GAME_OVER_OFFSET = WINDOW_WIDTH / 2;

        //shop message support
        public const string TEXT_FIRST_COLOR_MESSAGE_SHOP = "Change Color:";
        public const string TEXT_MAXHEALTH_MESSAGE_SHOP = "Add Max Health - 50";
        public const string TEXT_SECOND_COLOR_MESSAGE_SHOP = "100 -  the ordinary color \n  150 - the secret color";

        //shop message placement
        public const int VERTICAL_COLOR_MESSAGE_SHOP_OFSSET = 100;
        public const int HORIZONTAL_COLOR_MESSAGE_SHOP_OFSSET = 170;
        public const int VERTICAL_COLOR_MESSAGE_SHOP_SPACING = 40;
        public const int VERTICAL_MAXHEALTH_MESSAGE_SHOP_OFSSET = 220;



        //spawn random location support
        public const int SPAWN_BORDER_SIZE = 100;
        public const int SPAWN_OUTSIDE_WINDOW = -700;
            //speed settings
        public const float SPEED_MIN_LITTLE_CIRCLE = 0.25f;
        public const float SPEED_MIN_BIG_CIRCLE = 0.15f;
        public const float SPEED_RANGE_CIRCLE = 0.15f;



    }
}
