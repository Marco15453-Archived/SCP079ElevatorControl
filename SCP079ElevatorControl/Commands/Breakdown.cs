using CommandSystem;
using Exiled.API.Enums;
using Exiled.API.Extensions;
using Exiled.API.Features;
using MEC;
using RemoteAdmin;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCP079ElevatorControl.Commands
{
    [CommandHandler(typeof(ClientCommandHandler))]
    public class Breakdown : ICommand
    {
        public string Command { get; } = "breakdown";
        public string[] Aliases { get; } = { };
        public string Description { get; } = "Breakdown an Elevator as SCP-079";

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            Player p = Player.Get((CommandSender)sender);

            if(p == null)
            {
                response = "This Command can only be run by a Player";
                return false;
            }
            
            if(!p.IsScp || p.Role != RoleType.Scp079)
            {
                response = "You can only run this Command as SCP-079";
                return false;
            }

            ElevatorType Elevator = ExtraMethods.GetElevatorTypeByCameraName(p.Camera.cameraName);
            if(Elevator == ElevatorType.Unknown)
            {
                response = "You cannot use the command in this Camera! Needs to be a Camera with an Elevator!";
                return false;
            }

            if(SCP079ElevatorControl.Instance.disabledElevators.Contains(Elevator))
            {
                response = "This Elevator is already broken down!";
                return false;
            }

            if(p.Energy < SCP079ElevatorControl.Instance.Config.PowerRequirement || p.Level < SCP079ElevatorControl.Instance.Config.LevelRequirement)
            {
                response = $"You need to be Access Tier {SCP079ElevatorControl.Instance.Config.LevelRequirement} and atleast {SCP079ElevatorControl.Instance.Config.PowerRequirement} Power!";
                return false;
            }

            if(SCP079ElevatorControl.Instance.activeCooldowns.ContainsKey(p))
            {
                DateTime lastUsed = SCP079ElevatorControl.Instance.activeCooldowns[p] + TimeSpan.FromSeconds(SCP079ElevatorControl.Instance.Config.BreakdownCooldown);
                if (DateTime.Now < lastUsed)
                {
                    response = SCP079ElevatorControl.Instance.Config.OnCooldownMessage.Replace("%TIME_REMAINING%", Math.Round((lastUsed - DateTime.Now).TotalSeconds).ToString());
                    return false;
                }
                else SCP079ElevatorControl.Instance.activeCooldowns.Remove(p);
            }

            p.Energy -= SCP079ElevatorControl.Instance.Config.PowerRequirement;
            p.Experience += SCP079ElevatorControl.Instance.Config.BreakdownExperience;
            Timing.RunCoroutine(ExtraMethods.DisableElevator(p, Elevator));

            response = $"You used your Power to breakdown Elevator {ExtraMethods.ElevatorToString(Elevator)}";
            return true;
        }
    }
}
