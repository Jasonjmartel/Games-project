using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Game1
{
    // Stores the current gamestate (are you in level setup? the menu? what's the score? did you click a button?)
    public class GameState
    {
        #region datamembers
        // ints to keep track of what's going on (how far in game starting you are)
        public int stage, count;
        // stores if you picked a valid location (for displaying text)
        public bool incorcheck;
        // Scene Manager storing entities
        private SceneManager mSceneManager;
        // boolean to check if you clicked an exit button
        protected bool mexit;
        //check the score
        private int mx,my,tx,ty;
        // check if you clicked the pause button
        public bool pause;

        //getters for exit/score (assigning is only done internally so no setters)
        public bool exit
        {
            get
            {
                return mexit;
            }
        }
        #endregion

        public GameState(SceneManager pMan) {
            // initialise/store variables
            mSceneManager = pMan;
            mexit = false;
            mx = 1;
            my = 1;
            tx = 1;
            ty = 1;
            stage = 0;
            pause = false;
            
        }

        private void shiftpause() {
            //change pause's state to the opposite of the current one
            if (pause == true) pause = false; else pause = true;

        }

        // mouse listener
        public virtual void OnNewInput(object source, MouseEventArgs args)
        {
            //reacts differently depending in how far through the game start you are
            switch (stage)
            {
                // case 0 is the not having anything selected, case 1 is having something selected
                case 0:
                    if (args.Mouse.Position.X < mx*100 && args.Mouse.Position.X > (mx-1)*100)
                    {
                        if (args.Mouse.Position.Y < my * 100 && args.Mouse.Position.Y > (my - 1) * 100)
                        {
                            stage = 1;
                        }
                    }
                    break;

                case 1:
                    //check pressed on turret button
                    if (args.Mouse.Position.X > 0)
                    {
                        tx = 1;
                    }
                    if (args.Mouse.Position.X > 100)
                    {
                        tx = 2;
                    }
                    if (args.Mouse.Position.X > 200)
                    {
                        tx = 3;
                    }
                    if (args.Mouse.Position.X > 300)
                    {
                        tx = 4;
                    }
                    if (args.Mouse.Position.X > 400)
                    {
                        tx = 5;
                    }
                    if (args.Mouse.Position.X > 500)
                    {
                        tx = 6;
                    }
                    if (args.Mouse.Position.X > 600)
                    {
                        tx = 7;
                    }
                    if (args.Mouse.Position.X > 700)
                    {
                        tx = 8;
                    }
                    if (args.Mouse.Position.Y > 0)
                    {
                        ty = 1;
                    }
                    if (args.Mouse.Position.Y > 100)
                    {
                        ty = 2;
                    }
                    if (args.Mouse.Position.Y > 200)
                    {
                        ty = 3;
                    }
                    if (args.Mouse.Position.Y > 300)
                    {
                        ty = 4;
                    }
                    if (args.Mouse.Position.Y > 400)
                    {
                        ty = 5;
                    }
                    if (args.Mouse.Position.Y > 500)
                    {
                        ty = 6;
                    }
                    if (args.Mouse.Position.Y > 600)
                    {
                        ty = 7;
                    }
                    if (args.Mouse.Position.Y > 700)
                    {
                        ty = 8;
                    }
                    if ((ty != my && mx == tx) || (tx != mx && ty == my))
                    {
                        Vector2 pass = new Vector2((100 * tx) - 50, (100 * ty) - 50);
                        mSceneManager.placeturret(count, pass);
                        mx = tx;
                        my = ty;
                        stage = 0;
                    }
                    if (ty != my || tx != mx)
                    {
                        stage = 0;
                    }
                    break;            
            }
        }

        private bool checktrack(MouseEventArgs args)
        {
            // check the turret is in a valid space on the screen. It can't be on top of the track
            // or on the sidebar UI, etc

            //left/right of screen
            if (args.Mouse.Position.X < 60 || args.Mouse.Position.X > 1140)
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
    }
}
