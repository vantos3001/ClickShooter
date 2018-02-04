using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClickShooter
{
    abstract public class Enamy
    {
        #region Fields

        protected bool active = true;

        //drawing support
        protected Texture2D sprite;
        protected Rectangle drawRectangle;

        // velocity information
        protected Vector2 velocity = new Vector2(0, 0);

        //enamy characteristics
        protected int maxHealth;
        protected int currentHealth;
        protected int damage;
        protected int moneyForPlayer;

        // exit from down of window
        bool isExitDownBorder = false;




        #endregion

        #region Constructors

        protected Enamy(ContentManager contentManager, string spriteName, int x, int y, Vector2 velocity)
        {
            // load sprite from load content
            LoadContent(contentManager, spriteName, x, y);

            this.velocity = velocity;

        }

        #endregion

        #region Properties

        public bool Active
        {
            get { return active; }
            set { active = value; }
        }

        public bool IsExitDownBorder
        {
            get { return isExitDownBorder; }
        }

        public Rectangle DrawRectangle
        {
            get { return drawRectangle; }
        }

        #endregion

        #region Public methods

        public void Update(GameTime gameTime, MouseState mouse)
        {
            //move circles
            drawRectangle.X += (int)(velocity.X * gameTime.ElapsedGameTime.Milliseconds);
            drawRectangle.Y += (int)(velocity.Y * gameTime.ElapsedGameTime.Milliseconds);

            // kill circles
            if (drawRectangle.Contains(mouse.X, mouse.Y))
            {
                if (Game1.ClickReleased && mouse.LeftButton == ButtonState.Pressed)
                {
                    Game1.ClickReleased = false;
                    Game1.ClickStarted = true;
                    currentHealth -= 1;
                }
                else if (Game1.ClickStarted && mouse.LeftButton == ButtonState.Released)
                {
                    Game1.ClickStarted = false;
                    Game1.ClickReleased = true;

                }
            }

            if (currentHealth == 0)
            {
                active = false;
                // add money for death enamies
                Player.AddCashForEnamies(moneyForPlayer);
                
            }


            //bounce as necessary
            BounceLeftRight();
            //exit from down window
            ExitFromDownWindow();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //draw sprite
            if (active == true)
                spriteBatch.Draw(sprite, drawRectangle, Color.White);
        }

        //player give damage
        public int GiveDamage(int currentHealth)
        {
            return currentHealth - damage;
        }

        #endregion

        #region Private Methods

        private void LoadContent(ContentManager contentManager, string spriteName, int x, int y)
        {
            //load content and set remainder of draw rectangle
            sprite = contentManager.Load<Texture2D>(spriteName);
            drawRectangle = new Rectangle(x - sprite.Width / 2,
                y - sprite.Height / 2, sprite.Width,
                sprite.Height);

        }

        // bounce left and right 
        private void BounceLeftRight()
        {

            if (drawRectangle.X < 0)
            {
                // bounce off left
                drawRectangle.X = 0;
                velocity.X *= -1;

            }
            else if (drawRectangle.X + drawRectangle.Width > GameConstants.WINDOW_WIDTH)
            {
                // bounce off right
                drawRectangle.X = GameConstants.WINDOW_WIDTH - drawRectangle.Width;
                velocity.X *= -1;

            }
        }

        // exit down for remove enamies 
        // and inactive this enamies

        private void ExitFromDownWindow()
        {
            if (drawRectangle.Y > GameConstants.WINDOW_HEIGHT)
            {
                active = false;
                isExitDownBorder = true;
            }
        }



        #endregion




    }
}
