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
    public class MenuButton
    {
        #region Fields

        //field for button image
        protected Texture2D sprite;
        protected  int ImagesPerRow = 2;
        protected int buttonWidth;

        // fields for drawing
        protected Rectangle drawRectangle;
        protected Rectangle sourceRectangle;

        // click processing
        protected GameState clickState;
        #endregion


        #region Constructors 

        public MenuButton(Texture2D sprite, Vector2 center, GameState clickState)
        {
            this.sprite = sprite;
            this.clickState = clickState;
            // intialize button
            Initialize(center);
        }
        #endregion

        #region Public methods

        public void Update(MouseState mouse)
        {

            if (drawRectangle.Contains(mouse.X, mouse.Y))
            {
                // highlight button
                sourceRectangle.X = buttonWidth;
                CheckClickForChangeButton(mouse);
            }
            else
            {
                sourceRectangle.X = 0;
            }
        }

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(sprite, drawRectangle, sourceRectangle, Color.White);
        }

        #endregion

        #region Protected methods
        protected void Initialize(Vector2 center)
        {
            buttonWidth = sprite.Width / ImagesPerRow;

            drawRectangle = new Rectangle((int)(center.X - buttonWidth / 2), (int)(center.Y - sprite.Height / 2), buttonWidth, sprite.Height);

            sourceRectangle = new Rectangle(0, 0, buttonWidth, sprite.Height);

        }

        virtual protected void CheckClickForChangeButton(MouseState mouse)
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
                    Game1.ChangeState(clickState);
                    Game1.ClickStarted = false;

                }
            }
        }

        #endregion

    }


}
