using Exiled.API.Enums;
using Exiled.API.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace SCP079ElevatorControl
{
    public sealed class Config : IConfig
    {
        [Description("Should the plugin be enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("Should the Testing Mode be enabled? (WARNING: THIS WILL GIVE SCP-079 ON ALL INTERACTION 500 EXPERIENCE! ONLY USE THIS FOR TESTING PURPOSE!)")]
        public bool TestingMode { get; set; } = false;

        [Description("Should the plugin automaticly update?")]
        public bool AutoUpdate { get; set; } = true;

        [Description("Level Requirements, use 0-4 for the Tiers. 0 = 1, 1 = 2, 2 = 3, 3 = 4, 4 = 5")]
        public int LevelRequirement { get; set; } = 3;

        [Description("Power required to activate the command?")]
        public int PowerRequirement { get; set; } = 100;

        [Description("How much Experience should SCP-079 gets when breaking down an Elevator?")]
        public int BreakdownExperience { get; set; } = 25;

        [Description("For how long should the Elevator breakdown?")]
        public int BreakdownTime { get; set; } = 60;

        [Description("How long should SCP-079 be unavailable to breakdown an Elevator again? (Cooldown)")]
        public int BreakdownCooldown { get; set; } = 60;

        [Description("What Message should be displayed when SCP-079 tries to breakdown an Elevator while on Cooldown? %TIME_REMAINING% will be replaced with remaining time until cooldown is over!")]
        public string OnCooldownMessage { get; set; } = "<color=red>You are currently still on cooldown!</color><color=blue>Please wait %TIME_REMAINING% Seconds before breaking down an Elevator again!</color>";

        [Description("For how long should the room blackout when SCP-079 breaks down an Elevator?")]
        public int BlackoutTime { get; set; } = 15;

        [Description("Cassie Message when Elevator gets broke down! %ELEVATOR% is replaced with the Elevator Name")]
        public string CassieMessage { get; set; } = "Elevator %ELEVATOR% shut down";

        [Description("Cassie Message when Elevator is back online! %ELEVATOR% is replaced with the Elevator Name")]
        public string CassieMessageReactivated { get; set; } = "Elevator %ELEVATOR% is back in operational mode";

        [Description("For how long should a global broadcast shows that an elevator has been breakdowned by SCP-079 (-1 = Disabled)")]
        public ushort GlobalBroadcastTime { get; set; } = 3;

        [Description("What message should be global broadcasted when SCP-079 breaks down an Elevator? %ELEVATOR% will be replaced with the Elevator Name")]
        public string GlobalBroadcastMessage { get; set; } = "Elevator %ELEVATOR% has been broken down by SCP-079";

        [Description("What message should be global broadcasted when an Elevator gets back online! %ELEVATOR% will be replaced with the Elevator Name")]
        public string GlobalBroadcastMessageReactivated { get; set; } = "Elevator %ELEVATOR% is back in operational mode!";

        [Description("How long should a hint be displayed when a Player tries to use/call an broken down Elevator? (-1 = Disabled)")]
        public int ElevatorBreakdownTime { get; set; } = 3;

        [Description("What hint should be displayed when a Player tries to use/call an broken down Elevator?")]
        public string ElevatorBreakdownMessage { get; set; } = "<color=red>This Elevator has a malfunction</color>";

        [Description("How long should a hint be displayed when SCP-079 reaches the Level to be allowed to breakdown an Elevator? (-1 = Disabled)")]
        public int ReachingLevelHintTime { get; set; } = 20;

        [Description("What hint should be displayed when SCP-079 reaches the Level to be allowed to breakdown an Elevator?")]
        public string ReachingLevelHintMessage { get; set; } = "You have reached Level %REQUIRED_LEVEL%! You are now allowed to breakdown Elevators \nUse '.breakdown' inside your Client Console!\nYou must be in an Camera with an Elevator!";

        [Description("How long should a hint be displayed when SCP-079 switches to an Camera where he can break an Elevator? (-1 = Disabled)")]
        public int OnCameraToBreakdownHintTime { get; set; } = 3;

        [Description("What Hint should be displayed when SCP-079 switches to an Camera where he can break an Elevator?")]
        public string OnCameraToBreakdownHintMessage { get; set; } = "You are currently in a Camera where you can break the Elevator down! \nUse '.breakdown' inside your Client Console to break it down!";

        [Description("Replacements for ElevatorType")]
        public Dictionary<ElevatorType, string> ElevatorStrings { get; set; } = new Dictionary<ElevatorType, string>
        {
            { ElevatorType.GateA, "Gate A" },
            { ElevatorType.GateB, "Gate B" },
            { ElevatorType.LczA, "Light Containment Zone A" },
            { ElevatorType.LczB, "Light Containment Zone B" },
            { ElevatorType.Nuke, "Nuke" },
            { ElevatorType.Scp049, "SCP-049" }
        };

        [Description("Cassie Replacements for ElevatorType")]
        public Dictionary<ElevatorType, string> CassieStrings { get; set; } = new Dictionary<ElevatorType, string>
        {
            { ElevatorType.GateA, "Gate A" },
            { ElevatorType.GateB, "Gate B" },
            { ElevatorType.LczA, "Light Containment Zone A" },
            { ElevatorType.LczB, "Light Containment Zone B" },
            { ElevatorType.Nuke, "Nuke" },
            { ElevatorType.Scp049, "SCP 0 4 9" }
        };

        [Description("Allowed Elevators that SCP-079 can breakdown! Check ... for all Elevators")]
        public HashSet<ElevatorType> allowedElevators = new HashSet<ElevatorType>
        {
            ElevatorType.GateA,
            ElevatorType.GateB,
            ElevatorType.LczA,
            ElevatorType.LczB,
            ElevatorType.Nuke,
            ElevatorType.Scp049
        };
    }
}
