using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClickShooter
{
    class ShopButton : MenuButton
    {
        #region Fields

        int costMoney;
        ShopButtonState buttonState;
        string colorName;
        #endregion

        #region Constructors

        public ShopButton (Texture2D sprite, Vector2 center, GameState clickState, int costMoney, ShopButtonState buttonState, string colorName): base(sprite, center, clickState)
        {
            ImagesPerRow = GameConstants.IMAGES_PER_ROW_FOR_SHOP_BUTTON;
            this.sprite = sprite;
            this.clickState = clickState;
            this.costMoney = costMoney;
            this.buttonState = buttonState;
            this.colorName = colorName;

            //initialize button
            Initialize(center);
        }

        #endregion

        #region Public methods

        public new void Update(MouseState mouse)
        {

            if (drawRectangle.Contains(mouse.X, mouse.Y))
            {
                // highlight button
                if( Player.CheckPossibleToBuyUpdate(costMoney))
                    sourceRectangle.X = 2 * buttonWidth;
                else
                {
                    sourceRectangle.X =  buttonWidth;
                }
                CheckClickForChangeButton(mouse);
            }
            else
            {
                sourceRectangle.X = 0;
            }

        }

        #endregion

        #region Private methods

        override protected void CheckClickForChangeButton(MouseState mouse)
        {
            if (Game1.ClickReleased && mouse.LeftButton == ButtonState.Pressed)
            {
                Game1.ClickReleased = false;
                Game1.ClickStarted = true;
            }
            else if (mouse.LeftButton == ButtonState.Released)
            {
                Game1.ClickReleased = true;
                if (Game1.ClickStarted)
                {
                    //remove player's cash
                    if (Player.CheckPossibleToBuyUpdate(costMoney))
                    {
                        Player.AddCashForEnamies(costMoney * (-1));
                        if (ShopButtonState.AddHealth == buttonState)
                        {
                            Player.AddMaxHealth();
                        }
                        if (ShopButtonState.Color == buttonState)
                        {
                            Player.AddNewColor(colorName);
                        }
                    }
                    Game1.ClickStarted = false;

                }
            }
        }

        #endregion




    }
}
