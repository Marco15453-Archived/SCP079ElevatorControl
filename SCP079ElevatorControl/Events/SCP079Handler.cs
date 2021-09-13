using Exiled.API.Extensions;
using Exiled.API.Features;
using Exiled.Events.EventArgs;

namespace SCP079ElevatorControl.Events
{
    internal sealed class SCP079Handler
    {
        public void onGainingLevel(GainingLevelEventArgs ev)
        {
            if (!ev.Player.IsScp || ev.Player.Role != RoleType.Scp079) return;
            if (ev.NewLevel == SCP079ElevatorControl.Instance.Config.LevelRequirement && SCP079ElevatorControl.Instance.Config.ReachingLevelHintTime > 0)
                ev.Player.ShowHint(SCP079ElevatorControl.Instance.Config.ReachingLevelHintMessage.Replace("%REQUIRED_LEVEL%", SCP079ElevatorControl.Instance.Config.LevelRequirement.ToString()), SCP079ElevatorControl.Instance.Config.ReachingLevelHintTime);
        }

        public void onGainingExperience(GainingExperienceEventArgs ev)
        {
            if (!SCP079ElevatorControl.Instance.Config.TestingMode) return;
            if (!ev.Player.IsScp || ev.Player.Role != RoleType.Scp079) return;
            ev.Player.Experience += 500;
        }

        public void onChangingCamera(ChangingCameraEventArgs ev)
        {
            if (!ev.Player.IsScp || ev.Player.Role != RoleType.Scp079) return;

            if (SCP079ElevatorControl.Instance.Config.allowedElevators.Contains(ExtraMethods.GetElevatorTypeByCameraName(ev.Camera.cameraName)) && 
                SCP079ElevatorControl.Instance.Config.OnCameraToBreakdownHintTime > 0 && ev.Player.Level >= SCP079ElevatorControl.Instance.Config.LevelRequirement)
                ev.Player.ShowHint(SCP079ElevatorControl.Instance.Config.OnCameraToBreakdownHintMessage, SCP079ElevatorControl.Instance.Config.OnCameraToBreakdownHintTime);
        }
        
        public void onElevatorTeleporting(ElevatorTeleportingEventArgs ev)
        {
            if (!ev.Player.IsScp || ev.Player.Role != RoleType.Scp079) return;

            if (SCP079ElevatorControl.Instance.Config.allowedElevators.Contains(ExtraMethods.GetElevatorTypeByCameraName(ev.Player.Camera.cameraName)) &&
                SCP079ElevatorControl.Instance.Config.OnCameraToBreakdownHintTime > 0 && ev.Player.Level >= SCP079ElevatorControl.Instance.Config.LevelRequirement)
                ev.Player.ShowHint(SCP079ElevatorControl.Instance.Config.OnCameraToBreakdownHintMessage, SCP079ElevatorControl.Instance.Config.OnCameraToBreakdownHintTime);
        }
    }
}
