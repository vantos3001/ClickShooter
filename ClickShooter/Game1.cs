using System;
using System.Collections.Generic;


using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ClickShooter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        // declare and set current state
        static GameState currentState = GameState.Menu;

        // declare Player
        Player player = new Player();


        // lists of enamies
        List<LittleCircle> littleCircles = new List<LittleCircle>();
        List<BigCircle> bigCircles = new List<BigCircle>();
        List<Message> messages = new List<Message>();

        // menu buttons
        Texture2D backButtonSprite;
        Texture2D newGameButtonSprite;
        Texture2D shopButtonSprite;
        List<MenuButton> menuButtons = new List<MenuButton>();

        // shop nuttons
        List<ShopButton> shopButtons = new List<ShopButton>();

        //messages

        static Message playerHealthMessage;
        static Message playerCashMessage;
        static Message textGameOver;
        static Message shopColorMessage;
        static Message shopContinueColorMessage;
        static Message shopMaxHealthMessage;

        // text display support
        SpriteFont font;


        // when first inter to the resultState
        // or when first inter to the menuState
        //!!! every time update when inter to the menuState
        static bool firstTimeState = false;



        // mouse support for global control
        static bool clickStarted = false;
        static bool clickReleased = true;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //set resolution and make visible mouse
            graphics.PreferredBackBufferWidth = GameConstants.WINDOW_WIDTH;
            graphics.PreferredBackBufferHeight = GameConstants.WINDOW_HEIGHT;

            IsMouseVisible = true;

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            RandomNumberGerator.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);



            // load sprite backButton
            backButtonSprite = Content.Load<Texture2D>(@"graphics\gameButtons\backMenuButton");

            // load sprite newGameButton
            newGameButtonSprite = Content.Load<Texture2D>(@"graphics\gameButtons\newGameMenuButton");

            // load sprite shopButton
            shopButtonSprite = Content.Load<Texture2D>(@"graphics\gameButtons\shopMenuButton");

            //load shopButtons
            //add color shop buttons
            int horizontalMenuButtonSpacing = 0;
            shopButtons.Add(new ShopButton(Content.Load<Texture2D>(@"graphics\shopButtons\shopCircleGreen"), new Vector2(GameConstants.HORIZONTAL_SHOPBUTTON_OFFSET + horizontalMenuButtonSpacing, GameConstants.VERTICAL_SHOPBUTTON_OFFSET), GameState.Shop, GameConstants.COST_MONEY_CIRCLE, ShopButtonState.Color, GameConstants.COLOR_ENAMY_GREEN));
            horizontalMenuButtonSpacing = horizontalMenuButtonSpacing + GameConstants.HORIZONTAL_SHOPBUTTON_SPACING;
            shopButtons.Add(new ShopButton(Content.Load<Texture2D>(@"graphics\shopButtons\shopCircleRed"), new Vector2(GameConstants.HORIZONTAL_SHOPBUTTON_OFFSET + horizontalMenuButtonSpacing, GameConstants.VERTICAL_SHOPBUTTON_OFFSET), GameState.Shop, GameConstants.COST_MONEY_CIRCLE, ShopButtonState.Color, GameConstants.COLOR_ENAMY_RED));
            horizontalMenuButtonSpacing = horizontalMenuButtonSpacing + GameConstants.HORIZONTAL_SHOPBUTTON_SPACING;
            shopButtons.Add(new ShopButton(Content.Load<Texture2D>(@"graphics\shopButtons\shopCircleYellow"), new Vector2(GameConstants.HORIZONTAL_SHOPBUTTON_OFFSET + horizontalMenuButtonSpacing, GameConstants.VERTICAL_SHOPBUTTON_OFFSET), GameState.Shop, GameConstants.COST_MONEY_CIRCLE, ShopButtonState.Color, GameConstants.DEFAULT_COLOR_ENAMY));
            horizontalMenuButtonSpacing = horizontalMenuButtonSpacing + GameConstants.HORIZONTAL_SHOPBUTTON_SPACING;
            shopButtons.Add(new ShopButton(Content.Load<Texture2D>(@"graphics\shopButtons\shopCircleSecret"), new Vector2(GameConstants.HORIZONTAL_SHOPBUTTON_OFFSET + horizontalMenuButtonSpacing, GameConstants.VERTICAL_SHOPBUTTON_OFFSET), GameState.Shop, GameConstants.COST_MONEY_SECRET_CIRCLE, ShopButtonState.Color, GameConstants.COLOR_ENAMY_SECRET));

            //add maxhealth shop button
            shopButtons.Add(new ShopButton(Content.Load<Texture2D>(@"graphics\shopButtons\shopMaxHealth"), new Vector2(GameConstants.HORIZONTAL_SHOPBUTTON_ADD_MAXHEALTH_OFFSET, GameConstants.VERTICAL_SHOPBUTTON_OFFSET + GameConstants.VERTICAL_SHOPBUTTON_SPACING), GameState.Shop, GameConstants.COST_MONEY_UP_MAX_HEALTH, ShopButtonState.AddHealth, ""));
            //texture2d maxhealthshopbuttonsprite;


            //load sprite font , create messages for player and add to list
            font = Content.Load<SpriteFont>(@"fonts\Arial20");
            playerHealthMessage = new Message(GameConstants.HEALTH_MESSAGE_PREFIX + player.CurrentHealth, font, new Vector2(GameConstants.HORIZONTAL_HEALTH_MESSAGE_OFSSET, GameConstants.VERTICAL_HEALTH_MESSAGE_OFSSET));
            playerCashMessage = new Message(GameConstants.CASH_MESSAGE_PREFIX + player.CashPlayer, font, new Vector2(GameConstants.HORIZONTAL_CASH_MESSAGE_OFFSET, GameConstants.VERTICAL_CASH_MESSAGE_OFFSET));
            textGameOver = new Message(GameConstants.TEXT_GAME_OVER, font, new Vector2(GameConstants.HORIZONTAL_GAME_OVER_OFFSET, GameConstants.VERTICAL_GAME_OVER_OFFSET));
            shopColorMessage = new Message(GameConstants.TEXT_FIRST_COLOR_MESSAGE_SHOP, font, new Vector2(GameConstants.HORIZONTAL_COLOR_MESSAGE_SHOP_OFSSET, GameConstants.VERTICAL_COLOR_MESSAGE_SHOP_OFSSET));
            shopContinueColorMessage = new Message(GameConstants.TEXT_SECOND_COLOR_MESSAGE_SHOP, font, new Vector2(GameConstants.HORIZONTAL_COLOR_MESSAGE_SHOP_OFSSET, GameConstants.VERTICAL_COLOR_MESSAGE_SHOP_OFSSET + GameConstants.VERTICAL_COLOR_MESSAGE_SHOP_SPACING));
            shopMaxHealthMessage = new Message(GameConstants.TEXT_MAXHEALTH_MESSAGE_SHOP, font, new Vector2(GameConstants.HORIZONTAL_COLOR_MESSAGE_SHOP_OFSSET, GameConstants.VERTICAL_MAXHEALTH_MESSAGE_SHOP_OFSSET));

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            // mouse state
            MouseState mouse = Mouse.GetState();

            //update menu buttons when game state == menu

            if (currentState == GameState.Menu)
            {
                if (!firstTimeState)
                {
                    // clear menu buttons
                    menuButtons.Clear();

                    //create all menu buttons
                    int menuButtonDistance = GameConstants.TOP_MENUBUTTON_OFFSET;
                    // create "new game" button and add to list
                    MenuButton newGameButton = new MenuButton(newGameButtonSprite, new Vector2(GameConstants.HORIZONTAL_MENUBUTTON_OFFSET, menuButtonDistance), GameState.Play);
                    menuButtons.Add(newGameButton);

                    menuButtonDistance = menuButtonDistance + GameConstants.VERTICAL_MENUBUTTON_SPACING;
                    // create "shop" button and add to list
                    MenuButton shopButton = new MenuButton(shopButtonSprite, new Vector2(GameConstants.HORIZONTAL_MENUBUTTON_OFFSET, menuButtonDistance), GameState.Shop);
                    menuButtons.Add(shopButton);


                    //clear messages
                    messages.Clear();



                    firstTimeState = true;
                }

                foreach (MenuButton menuButton in menuButtons)
                {
                    menuButton.Update(mouse);
                }
            }


            //update enamies when game state == play
            if (currentState == GameState.Play)
            {
                if (!firstTimeState)
                {
                    //when change state set current health 
                    player.StartGame();

                    //clear messages
                    messages.Clear();
                    //add all massages
                    messages.Add(playerHealthMessage);
                    messages.Add(playerCashMessage);
                    //update messages
                    playerHealthMessage.Text = GameConstants.HEALTH_MESSAGE_PREFIX + player.CurrentHealth;
                    playerCashMessage.Text = GameConstants.CASH_MESSAGE_PREFIX + player.CashPlayer;

                    //clear enemy lists
                    littleCircles.Clear();
                    bigCircles.Clear();

                    //spawn new enamies
                    // spawn all circles
                    for (int i = 0; i < GameConstants.NUMBER_OF_LITTLE_CIRCLE; i++)
                        SpawnLittleCircle();

                    for (int i = 0; i < GameConstants.NUMBER_OF_BIG_CIRCLE; i++)
                        SpawnBigCircle();

                    firstTimeState = true;
                }
                // update circles

                foreach (LittleCircle littleCircle in littleCircles)
                {
                    littleCircle.Update(gameTime, mouse);

                }

                foreach (BigCircle bigCircle in bigCircles)
                {
                    bigCircle.Update(gameTime, mouse);
                }

                // player give damage
                foreach (LittleCircle littleCircle in littleCircles)
                {
                    if (littleCircle.IsExitDownBorder)
                    {
                        player.CurrentHealth = littleCircle.GiveDamage(player.CurrentHealth);
                        playerHealthMessage.Text = GameConstants.HEALTH_MESSAGE_PREFIX + player.CurrentHealth;
                    }
                }

                foreach (BigCircle bigCircle in bigCircles)
                {
                    if (bigCircle.IsExitDownBorder)
                    {
                        player.CurrentHealth = bigCircle.GiveDamage(player.CurrentHealth);
                        playerHealthMessage.Text = GameConstants.HEALTH_MESSAGE_PREFIX + player.CurrentHealth;
                    }

                }


                // clean out inactive little circles
                for (int i = 0; i < littleCircles.Count; i++)
                {
                    if (!littleCircles[i].Active)
                        littleCircles.RemoveAt(i);
                }

                // clean out inactive big circles



                for (int i = 0; i < bigCircles.Count; i++)
                {
                    if (!bigCircles[i].Active)
                    {
                        //after big circle dead
                        // spawn new little Circles from 0 to 2
                        SpawnLittleCircle(bigCircles[i].DrawRectangle);
                        bigCircles.RemoveAt(i);
                    }
                }

                // add new little circles 

                while (littleCircles.Count < GameConstants.NUMBER_OF_LITTLE_CIRCLE)
                {
                    SpawnLittleCircle();
                }


                // add new big circles
                while (bigCircles.Count < GameConstants.NUMBER_OF_BIG_CIRCLE)
                {
                    SpawnBigCircle();
                }

                //change state from Play to DisplayingResult
                if (player.CurrentHealth <= 0)
                    ChangeState(GameState.DisplayingResult);


                // mouse left click state
                // after enamy.Update because we check reaction enamy on click and then click on only window
                if (mouse.LeftButton == ButtonState.Pressed)
                    clickReleased = false;
                else
                {
                    clickReleased = true;
                }
            }


            if (currentState == GameState.DisplayingResult)
            {
                if (!firstTimeState)
                {
                    // clear menu buttons
                    menuButtons.Clear();
                    //create backButton and add to menuButtons
                    MenuButton backButton = new MenuButton(backButtonSprite, new Vector2(GameConstants.HORIZONTAL_BACK_MENUBUTTON_OFFSET, GameConstants.VERTICAL_BACK_MENUBUTTON_OFFSET), GameState.Menu);
                    menuButtons.Add(backButton);

                    //set default click support
                    // !!!ВАЖНО НАВЕРНО убирает баг: когда наводишь на кнопку "назад" в displayingResult State САМА иногда кликается
                    clickReleased = true;
                    clickStarted = false;

                    firstTimeState = true;

                    //clear messages
                    messages.Clear();
                    //add "game over" message
                    messages.Add(textGameOver);
                }
                foreach (MenuButton menuButton in menuButtons)
                {
                    menuButton.Update(mouse);
                }
            }

            if (currentState == GameState.Shop)
            {
                if (!firstTimeState)
                {
                    // clear menu buttons
                    menuButtons.Clear();
                    //create backButton and add to menuButtons
                    MenuButton backButton = new MenuButton(backButtonSprite, new Vector2(GameConstants.HORIZONTAL_BACK_MENUBUTTON_OFFSET, GameConstants.VERTICAL_BACK_MENUBUTTON_OFFSET), GameState.Menu);
                    menuButtons.Add(backButton);

                    //set default click support
                    // !!!ВАЖНО НАВЕРНО убирает баг: когда наводишь на кнопку "назад" в displayingResult State САМА иногда кликается
                    clickReleased = true;
                    clickStarted = false;

                    firstTimeState = true;

                    //set messages
                    messages.Clear();
                    //add all massages
                    messages.Add(playerHealthMessage);
                    messages.Add(playerCashMessage);
                    messages.Add(shopColorMessage);
                    messages.Add(shopContinueColorMessage);
                    messages.Add(shopMaxHealthMessage);
                    //update messages
                    playerHealthMessage.Text = GameConstants.HEALTH_MESSAGE_PREFIX + player.MaxHealth;
                    playerCashMessage.Text = GameConstants.CASH_MESSAGE_PREFIX + player.CashPlayer;

                }

                foreach (MenuButton menuButton in menuButtons)
                {
                    menuButton.Update(mouse);
                }
                foreach (ShopButton shopButton in shopButtons)
                {
                    shopButton.Update(mouse);
                }

            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();

            // draw menu buttons when state == menu
            if (currentState == GameState.Menu || currentState == GameState.DisplayingResult)
            {
                foreach (MenuButton menuButton in menuButtons)
                {
                    menuButton.Draw(spriteBatch);
                }
                //draw messages when state == dispaying result
                foreach (Message message in messages)
                {
                    message.Draw(spriteBatch);
                }

            }



            //draw enamies when game state == play
            if (currentState == GameState.Play)
            {
                foreach (LittleCircle littleCircle in littleCircles)
                {
                    littleCircle.Draw(spriteBatch);
                }

                foreach (BigCircle bigCircle in bigCircles)
                {
                    bigCircle.Draw(spriteBatch);
                }

                //draw messages when state == play
                foreach (Message message in messages)
                {
                    message.Draw(spriteBatch);
                    
                }
            }

            if (currentState == GameState.Shop)
            {
                foreach (MenuButton menuButton in menuButtons)
                {
                    menuButton.Draw(spriteBatch);
                }

                foreach (ShopButton shopButton in shopButtons)
                {
                    shopButton.Draw(spriteBatch);
                }
                foreach (Message message in messages)
                {
                    message.Draw(spriteBatch);
                }
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }
        #region Private methods

        // maybe spawn big and little circle
        // сделать перегрузку функций
        private void SpawnLittleCircle()
        {
            //random x and y
            int randomLocationX = GetRandomLocation(GameConstants.SPAWN_BORDER_SIZE, GameConstants.WINDOW_WIDTH - 2 * GameConstants.SPAWN_BORDER_SIZE);
            // generate outside window
            int randomLocationY = GameConstants.SPAWN_OUTSIDE_WINDOW + GetRandomLocation(GameConstants.SPAWN_BORDER_SIZE, GameConstants.WINDOW_HEIGHT - 2 * GameConstants.SPAWN_BORDER_SIZE);

            //random velocity
            float speedLittleCircle = GameConstants.SPEED_MIN_LITTLE_CIRCLE + RandomNumberGerator.NextFloat(GameConstants.SPEED_RANGE_CIRCLE);
            float angleLittleCircle = RandomNumberGerator.NextFloat((float)(2 * Math.PI));

            // use sin for x and don't use for y
            Vector2 velocity = new Vector2(speedLittleCircle * (float)Math.Sin((double)angleLittleCircle), speedLittleCircle);

            if (velocity.Y == 0)
                velocity.Y = velocity.X;

            if (velocity.Y < 0)
                velocity.Y *= -1;

            string spriteName = @"graphics\littleCircle\" + player.ColorEnamy + "LittleCircle";
            LittleCircle newLittleCircle = new LittleCircle(Content, spriteName, randomLocationX, randomLocationY, velocity);
            littleCircles.Add(newLittleCircle);

        }

        private void SpawnLittleCircle(Rectangle drawRectangleBigCircle)
        {
            //random x and y
            // i>1 because RandomNumberGerator.Next() spawn from 1 to max
            // possibility that loop does not work
            for (int i = RandomNumberGerator.Next(GameConstants.MAX_COUNT_LITTLE_CIRCLE_AFTER_KILL_BIG_CIRCLE); i >= 1; i--)
            {
                int randomLocationX = GetRandomLocation(drawRectangleBigCircle.X, 60);
                // generate outside window
                int randomLocationY =GetRandomLocation(drawRectangleBigCircle.Y, 60);

                //random velocity
                float speedLittleCircle = GameConstants.SPEED_MIN_LITTLE_CIRCLE_AFTER_KILL_BIG_CIRCLE + RandomNumberGerator.NextFloat(GameConstants.SPEED_RANGE_CIRCLE_AFTER_KILL_BIG_CIRCLE);
                float angleLittleCircle = RandomNumberGerator.NextFloat((float)(2 * Math.PI));

                // use sin for x and don't use for y
                Vector2 velocity = new Vector2(speedLittleCircle * (float)Math.Sin((double)angleLittleCircle), speedLittleCircle);

                if (velocity.Y == 0)
                    velocity.Y = velocity.X;

                if (velocity.Y < 0)
                    velocity.Y *= -1;

                string spriteName = @"graphics\littleCircle\" + player.ColorEnamy + "LittleCircle";
                LittleCircle newLittleCircle = new LittleCircle(Content, spriteName, randomLocationX, randomLocationY, velocity);
                littleCircles.Add(newLittleCircle);
            }
        }

        private void SpawnBigCircle()
        {
            int randomLocationX = GetRandomLocation(GameConstants.SPAWN_BORDER_SIZE, GameConstants.WINDOW_WIDTH - 2 * GameConstants.SPAWN_BORDER_SIZE);
            // generate outside window
            int randomLocationY = GameConstants.SPAWN_OUTSIDE_WINDOW + GetRandomLocation(GameConstants.SPAWN_BORDER_SIZE, GameConstants.WINDOW_HEIGHT - 2 * GameConstants.SPAWN_BORDER_SIZE);


            //random velocity
            float speedBigCircle = GameConstants.SPEED_MIN_BIG_CIRCLE + RandomNumberGerator.NextFloat(GameConstants.SPEED_RANGE_CIRCLE);
            float angleBigCircle = RandomNumberGerator.NextFloat((float)(2 * Math.PI));
            // use sin for x and don't use for y
            Vector2 velocity = new Vector2(speedBigCircle * (float)Math.Sin((double)angleBigCircle), speedBigCircle);

            if (velocity.Y == 0)
            {
                velocity.Y = velocity.X;
            }

            if (velocity.Y < 0)
            {
                velocity.Y *= -1;
            }

            string spriteName = @"graphics\bigCircle\" + player.ColorEnamy + "BigCircle";
            BigCircle newBigCircle = new BigCircle(Content, spriteName, randomLocationX, randomLocationY, velocity);
            bigCircles.Add(newBigCircle);

        }

        // get random location(int)
        private int GetRandomLocation(int min, int range)
        {
            return min + RandomNumberGerator.Next(range + 1);
        }



        #endregion

        #region Public methods

        public static void ChangeState(GameState newState)
        {
            currentState = newState;

            // for create new buttons
            if (firstTimeState)
            {
                firstTimeState = false;

                
            }
        }



        #endregion

        #region Properties

        public static bool ClickStarted
        {
            get { return clickStarted; }
            set { clickStarted = value; }
        }

        public static bool ClickReleased
        {
            get { return clickReleased; }
            set { clickReleased = value; }
        }

        public static Message PlayerCashMessage
        {
            get { return playerCashMessage; }
            set { playerCashMessage = value; }
        }

        public static Message PlayerHealthMessage
        {
            get { return playerHealthMessage; }
            set { playerHealthMessage = value; }
        }
        

        #endregion

    }
}
