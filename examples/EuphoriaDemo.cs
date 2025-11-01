using GTA;
using System.Windows.Forms;

namespace EuphoriaDemo
{
    /// <summary>
    /// Script that demonstrates Euphoria physics interactions on the player character in GTA V.
    /// </summary>
    /// <remarks>
    /// Allows triggering different physics-based animations using keyboard keys:
    /// <list type="bullet">
    /// <item>
    /// <description>Press J: Perform an arm windmill animation while maintaining balance.</description>
    /// </item>
    /// <item>
    /// <description>Press K: Apply a strong forward impulse to knock the player back.</description>
    /// </item>
    /// <item>
    /// <description>Press L: Trigger a fall-to-knees animation.</description>
    /// </item>
    /// </list>
    /// </remarks>
    public class EuphoriaDemo : Script
    {
        public EuphoriaDemo()
        {
            KeyDown += EuphoriaDemo_KeyDown;
        }

        private void EuphoriaDemo_KeyDown(object sender, KeyEventArgs e)
        {
            Ped playerPed = Game.LocalPlayerPed;

            if (e.KeyCode == Keys.J)
            {
                // Make sure all arguments have their default value
                playerPed.Euphoria.ArmsWindmillAdaptive.ResetArguments();

                // Set all the arguments used for the message
                // IntelliSense shows a list of available arguments
                playerPed.Euphoria.ArmsWindmillAdaptive.AngSpeed = 10f;
                playerPed.Euphoria.ArmsWindmillAdaptive.BodyStiffness = 0f;
                playerPed.Euphoria.ArmsWindmillAdaptive.Amplitude = 2f;
                playerPed.Euphoria.ArmsWindmillAdaptive.LeftElbowAngle = 6f;
                playerPed.Euphoria.ArmsWindmillAdaptive.RightElbowAngle = 6f;
                playerPed.Euphoria.ArmsWindmillAdaptive.DisableOnImpact = false;
                playerPed.Euphoria.ArmsWindmillAdaptive.BendLeftElbow = true;
                playerPed.Euphoria.ArmsWindmillAdaptive.BendRightElbow = true;

                // Start the windmill message and run it for 5 seconds
                playerPed.Euphoria.ArmsWindmillAdaptive.Start(5000);

                // Start body balance so pedestrian does not fall over
                // Since we already have a message running, we do not need to put a time in this message
                playerPed.Euphoria.BodyBalance.Start();

            }
            else if (e.KeyCode == Keys.K)
            {
                // Make sure all arguments have their default value
                playerPed.Euphoria.ApplyImpulse.ResetArguments();

                // Set the magnitude and direction of the Impulse in world coordinates
                // In this example its just the direction the pedestrian is facing
                playerPed.Euphoria.ApplyImpulse.Impulse = playerPed.ForwardVector * 1000;

                // Start the message and run it for 2 seconds
                playerPed.Euphoria.ApplyImpulse.Start(2000);

                // No need for the body balance helper on this, since the pedestrian would fall over anyway
            }
            else if (e.KeyCode == Keys.L)
            {
                playerPed.Euphoria.ShotFallToKnees.ResetArguments();

                playerPed.Euphoria.ShotFallToKnees.FallToKnees = true;
            }
        }
    }
}
