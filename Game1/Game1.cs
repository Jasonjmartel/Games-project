using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static int ScreenWidth, ScreenHeight;

        #region Data Members

        // Insert Data Members

        // Texture2D's hold the backgrounds (menu, map, etc)
        //private Texture2D background;
        // text object for announcements

        // Insert managers
        EntityManager mEntityManager;
        SceneManager mSceneManager;
        CollisionManager mCollManager;
        MouseManager mMouseManager;
        GameState mLoad;
        TDLevelManager cLevel;

        #endregion

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // Changing screen size
            graphics.PreferredBackBufferHeight = 800;
            graphics.PreferredBackBufferWidth = 800;

            this.IsMouseVisible = true;

            #region set screen to middle
            // Setting screen to middle
            //this.Window.Position = new Point(200, 50);

            // Setting screen to middle
            Window.Position = new Point
                ((GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / 2) -
                (graphics.PreferredBackBufferWidth / 2),
                (GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / 2) -
                (graphics.PreferredBackBufferHeight / 2));

            #endregion
        }

        #region methods
        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ScreenHeight = GraphicsDevice.Viewport.Height;
            ScreenWidth = GraphicsDevice.Viewport.Width;

            // Initialise managers
            mEntityManager = new EntityManager();
            mSceneManager = new SceneManager();
            mCollManager = new CollisionManager();
            mMouseManager = new MouseManager();
            mLoad = new GameState(mSceneManager);

            // subscribe the gamestate to the mouse manager
            mMouseManager.addListener(mLoad.OnNewInput);

            #region legacy entity creation(added to TDLevelManager)(from a stage between pong prototype and this)
            /*
            #region Create / Request Instance of entity class
            
            // Call entity manager to create the entities
            Ball mBall = mEntityManager.CreateInstance<Ball>();
            Paddle mPaddle1 = mEntityManager.CreateInstance<Paddle>();
            ProtoCholera chole = mEntityManager.CreateInstance<ProtoCholera>();

            mKeyManager.addListener(mPaddle1.OnNewInput);

            #region Load Ball and Paddle Texture         
            // grant entities their textures 
            mBall.Texture = Content.Load<Texture2D>("Assets/ball.png");
            mPaddle1.Texture = Content.Load<Texture2D>("Assets/paddle.png");
            chole.Texture = Content.Load<Texture2D>("Assets/paddle.png");
            #endregion

            #region Place ball and paddles into scenemanager
            // Also grant them their initial positions (ball Serve method means it will be set to centre
            // but it was put here as well for consistencies sake
            mSceneManager.Spawn(mBall, ScreenWidth/ 2 - 50, ScreenHeight / 2 - 50);
            mSceneManager.Spawn(mPaddle1, 0, ScreenHeight / 2 - 50);
            mSceneManager.Spawn(chole, 1550, ScreenHeight / 2 - 50);
            #endregion

            #region Place ball and paddles into collision manager
            // All 3 entities are moving elements, so they use addmobile method
            mCollManager.addmobile(mBall);
            mCollManager.addmobile(mPaddle1);
            mCollManager.addmobile(chole);
            #endregion
            
            #endregion
            */


            #endregion

            // initialise level manager and pass it needed information
            cLevel = new TDLevelManager(mSceneManager, mCollManager, mEntityManager, Content, ScreenWidth, ScreenHeight, mMouseManager);
            // generate level 1
            cLevel.addlevel1();
            

            #endregion

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

            // content load for menu and background
            //background = Content.Load<Texture2D>("Assets/background.png");
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
            // Exit game if requiremements are met
            // If either the esc key is pressed, or you click one of the exit buttons
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape)|| mLoad.exit == true)
                Exit();


            // call scenemanager to update (updates entities in scene)
            mSceneManager.Update();

            // run collision
            mCollManager.colcheck1();
            mCollManager.boundcheck();
            
            // removed for now, as still under testing
            //mCollManager.checkboxes();


            // Check for mouse events
            mMouseManager.Update();
            
            // Call base update
            base.Update(gameTime);
        }

        #region legacy mouse interaction (moved to GameState)
        /*
        private bool checkdistance(MouseEventArgs args)
        {
            Vector2 pass = new Vector2(args.Mouse.Position.X, args.Mouse.Position.Y);
            return mSceneManager.checkturret(count, pass); ;
        }
        private bool checktrack(MouseEventArgs args)
        {
            //left/right of screen
            if (args.Mouse.Position.X<60 || args.Mouse.Position.X > 1140)
            {
                return false;
            }
            //top/bottom of screen
            if (args.Mouse.Position.Y < 60 || args.Mouse.Position.Y > 840)
            {
                return false;
            }
            //first branch of track
            if (args.Mouse.Position.X > 194 && args.Mouse.Position.X < 314)
            {
                if (args.Mouse.Position.Y > 675)
                {
                    return false;
                }
            }
            //branch 2
            if (args.Mouse.Position.X > 194 && args.Mouse.Position.X < 795)
            {
                if (args.Mouse.Position.Y > 635 && args.Mouse.Position.Y < 755)
                {
                    return false;
                }
            }
            //3
            if (args.Mouse.Position.X > 675 && args.Mouse.Position.X < 795)
            {
                if (args.Mouse.Position.Y > 375 && args.Mouse.Position.Y < 755)
                {
                    return false;
                }
            }
            //4
            if (args.Mouse.Position.X > 440 && args.Mouse.Position.X < 795)
            {
                if (args.Mouse.Position.Y > 415 && args.Mouse.Position.Y < 535)
                {
                    return false;
                }
            }
            //5
            if (args.Mouse.Position.X > 440 && args.Mouse.Position.X < 560)
            {
                if (args.Mouse.Position.Y > 150 && args.Mouse.Position.Y < 535)
                {
                    return false;
                }
            }
            //6
            if (args.Mouse.Position.X > 440 && args.Mouse.Position.X < 970)
            {
                if (args.Mouse.Position.Y > 150 && args.Mouse.Position.Y < 270)
                {
                    return false;
                }
            }
            //7
            if (args.Mouse.Position.X > 810 && args.Mouse.Position.X < 930)
            {
                if (args.Mouse.Position.Y < 270)
                {
                    return false;
                }
            }
            return true;
        }

        public virtual void OnNewInput(object source, MouseEventArgs args)
        {
            //add code for mouse click here
            switch (stage) {
                case 0:
                    //if statement for start button
                    if (args.Mouse.Position.X > 570 && args.Mouse.Position.X < 986) {
                        if (args.Mouse.Position.Y > 406 && args.Mouse.Position.Y < 524)
                        {
                            stage = 1;
                        }
                    }
                    //if statement for end button
                    if (args.Mouse.Position.X > 570 && args.Mouse.Position.X < 986)
                    {
                        if (args.Mouse.Position.Y > 582 && args.Mouse.Position.Y < 700)
                        {
                            Exit();
                        }
                    }
                    break;
                case 1:
                    //check pressed on turret button
                    if (args.Mouse.Position.X > 1231 && args.Mouse.Position.X < 1339)
                    {
                        if (args.Mouse.Position.Y > 222 && args.Mouse.Position.Y < 325)
                        {
                            incorcheck = false;
                            stage = 2;
                        }
                    }
                    //if statent for end button
                    if (args.Mouse.Position.X > 1525 && args.Mouse.Position.X < 1583)
                    {
                        if (args.Mouse.Position.Y > 833 && args.Mouse.Position.Y < 873)
                        {
                            Exit();
                        }
                    }
                    break;
                case 2:
                    //call against track
                    bool check1 = checktrack(args);
                    //call against other turrets
                    bool check2 = checkdistance(args);
                    if (check1  == true && check2 == true)
                    {
                        Vector2 pass = new Vector2(args.Mouse.Position.X, args.Mouse.Position.Y);
                        mSceneManager.placeturret(count, pass);
                        stage = 1;
                        count += 1;
                        mscore = mscore - 100;
                        if (count == 3) stage = 3;
                    }
                    else {
                        incorcheck = true;
                        stage = 1;
                    }
                    //if statent for end button
                    if (args.Mouse.Position.X > 1525 && args.Mouse.Position.X < 1583)
                    {
                        if (args.Mouse.Position.Y > 833 && args.Mouse.Position.Y < 873)
                        {
                            Exit();
                        }
                    }

                    break;
                case 3:
                    //if statent for end button
                    if (args.Mouse.Position.X > 1525 && args.Mouse.Position.X < 1583)
                    {
                        if (args.Mouse.Position.Y > 833 && args.Mouse.Position.Y < 873)
                        {
                            Exit();
                        }
                    }
                    break;
            }            
        }
        */
        #endregion

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();

            // draw the map
            //spriteBatch.Draw(background, new Rectangle(0, 0, ScreenWidth, ScreenHeight), Color.White);

            // Draw the contents of the scenemanager
            mSceneManager.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
