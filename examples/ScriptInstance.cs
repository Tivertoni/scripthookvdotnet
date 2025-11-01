using System;
using System.Windows.Forms;
using GTA;
using GTA.UI;

namespace ScriptInstance
{
    
    /// <summary>
    /// This example consists of two scripts. This is the first one, which manages the AI pedestrian scripts using key presses.
    /// </summary>
    /// <remarks>
    /// Key controls:
    /// <list type="bullet">
    /// <item><description>T: Spawn or reset AIone.</description></item>
    /// <item><description>Y: Spawn or reset AItwo.</description></item>
    /// <item><description>G: Toggle AIone's animation between "Jump" and "HandsUp".</description></item>
    /// <item><description>H: Set the wait time for AItwo's next action (6000ms in this example).</description></item>
    /// <item><description>J: Pause or resume AIone.</description></item>
    /// </list>
    /// The script automatically runs every 1000ms to process key events and manage AI spawning.
    /// </remarks>
    ///
    public class Main : Script
    {
        private AI AIone = null;
        private AI AItwo = null;

        public Main()
        {
            KeyDown += OnKeyDown;

            Interval = 1000;
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            //Creates or aborts AI Script and stores it as AIone.
            if (e.KeyCode == Keys.T)
            {
                SpawnAI(ref AIone, 1);
                return;
            }

            //Creates or aborts AI Script and stores it as AItwo.
            if (e.KeyCode == Keys.Y)
            {
                SpawnAI(ref AItwo, 2);
                return;
            }

            //Changes the animation of AIone between "Jump" and "HandsUp".
            if (e.KeyCode == Keys.G)
            {
                if (AIone != null)
                {
                    if (AIone.Animation == "Jump")
                    {
                        AIone.Animation = "HandsUp";
                    }
                    else
                    {
                        AIone.Animation = "Jump";
                    }

                    Notification.PostTicker($"AI-1: Now playing animation \"{AIone.Animation}\"", true);
                }

                return;
            }

            // Sets Wait() for AI-2
            if (e.KeyCode == Keys.H)
            {
                AItwo.SetWait(6000);

                return;
            }

            //Toggles between Pause() and Resume() for AI-1
            if (e.KeyCode == Keys.J)
            {
                if (AIone.IsPaused)
                {
                    AIone.Resume();
                    return;
                }

                AIone.Pause();
                return;
            }
        }

        public void SpawnAI(ref AI ai, int index)
        {
            if (ai != null || ai.IsRunning)
            {
                ai.Abort();

                // Instead of setting AI to null, you can also check its status with 'IsRunning'
                ai = null;

                Notification.PostTicker($"{nameof(SpawnAI)}: Aborted AI-{index};", true);

                return;
            }

            ai = InstantiateScript<AI>();

            if (ai == null || !ai.IsRunning)
            {
                return;
            }

            Notification.PostTicker($"{nameof(SpawnAI)}: Instantiated AI-{index};", true);
        }
    }

    /// <summary>
    /// This example consists of two scripts. This is the second one, which represents an AI pedestrian script that performs actions and animations.
    /// </summary>
    /// <remarks>
    /// - Creates a ped in front of the player if none exists.
    /// - Executes the selected animation repeatedly while the ped is alive.
    /// - Supports a wait timer for delaying actions.
    /// - Cleans up the ped when the script is aborted.
    /// - Animation options:
    ///   <list type="bullet">
    ///     <item><description>"HandsUp": Ped raises hands for 1 second.</description></item>
    ///     <item><description>"Jump": Ped performs a jump task.</description></item>
    ///   </list>
    /// </remarks>
    [ScriptAttributes(NoDefaultInstance = true)]
    public class AI : Script
    {
        private Ped ped = null;
        private int wait = -1;
        public string Animation = "HandsUp";

        public AI()
        {
            Tick += OnTick;
            Aborted += OnShutdown;

            Interval = 3000;
        }

        private void OnTick(object sender, EventArgs e)
        {
            if (wait > -1)
            {
                Wait(wait);

                wait = -1;
            }

            if (ped == null)
            {
                ped = World.CreatePed(PedHash.Beach01AMY, Game.LocalPlayerPed.Position + (GTA.Math.Vector3.RelativeFront * 3));
            }

            // Repeat animation if alive
            if (ped != null && ped.IsAlive)
            {
                if (Animation == "HandsUp")
                {
                    ped.Task.HandsUp(1000);
                }
                else if (Animation == "Jump")
                {
                    ped.Task.Jump();
                }
            }
        }

        private void OnShutdown(object sender, EventArgs e)
        {
            // Clear pedestrian on script abort
            ped?.Delete();
        }

        /// <summary>
        /// If ms is greater than the current wait time, set wait time to ms.
        /// </summary>
        /// <param name="ms">Wait time in ms.</param>
        public void SetWait(int ms)
        {
            if (ms > wait)
            {
                wait = ms;
            }
        }
    }
}
