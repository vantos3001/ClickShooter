using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ClickShooter
{
    public class BigCircle: Enamy
    {
        #region Constructors
        public BigCircle(ContentManager contentManager, string spriteName, int x, int y, Vector2 velocity) : base (contentManager, spriteName,x, y, velocity)
        {

            currentHealth = GameConstants.MAX_HEALTH_BIG_CIRCLE;
            damage = GameConstants.DAMAGE_BIG_CIRCLE;
            moneyForPlayer = GameConstants.MONEY_FOR_BIG_CIRCLE;
        }
        #endregion
        #region Methods

        // разъединить большой круг на два маленьких
        public void SplitCircle()
        {
            
        }

        #endregion
    }
}
