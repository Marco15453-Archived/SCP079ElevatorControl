using Exiled.API.Extensions;
using Exiled.Events.EventArgs;

namespace SCP079ElevatorControl.Events
{
    internal sealed class PlayerHandler
    {
        public void onInteractingElevator(InteractingElevatorEventArgs ev)
        {
            if (!SCP079ElevatorControl.Instance.disabledElevators.Contains(ev.Lift.Type())) return;

            if (SCP079ElevatorControl.Instance.Config.ElevatorBreakdownTime > 0)
                ev.Player.ShowHint(SCP079ElevatorControl.Instance.Config.ElevatorBreakdownMessage, SCP079ElevatorControl.Instance.Config.ElevatorBreakdownTime);

            ev.IsAllowed = false;
        }
    }
}
