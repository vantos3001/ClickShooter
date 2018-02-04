using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ClickShooter
{
    public class Message
    {
        #region Fields

        string text;
        SpriteFont font;
        Vector2 center;
        Vector2 position;

        #endregion

        #region Constructors

        public Message(string text, SpriteFont font, Vector2 center)
        {
            this.text = text;
            this.font = font;
            this.center = center;

            //calculate position from text and center
            float textWidth = font.MeasureString(text).X;
            float textHeight = font.MeasureString(text).Y;
            position = new Vector2(center.X - textWidth / 2, center.Y - textHeight / 2);
        }
        #endregion

        #region Properties

        public string Text
        {
            set
            {
                text = value;
                //changing text could change text location
                float textWidth = font.MeasureString(text).X;
                float textHeight = font.MeasureString(text).Y;
                position.X = center.X - textWidth / 2;
                position.Y = center.Y - textHeight / 2;
            }
        }

        #endregion



        #region Methods

        public void Draw (SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, Color.White);
        }

        #endregion 


    }
}
