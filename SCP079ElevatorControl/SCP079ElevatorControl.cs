using Exiled.API.Features;
using Exiled.API.Enums;
using System;
using MEC;
using SCP079ElevatorControl.Events;
using System.Collections.Generic;

namespace SCP079ElevatorControl
{
    public class SCP079ElevatorControl : Plugin<Config>
    {
        internal static SCP079ElevatorControl Instance;

        public override string Name => "SCP079ElevatorControl";
        public override string Author => "Marco15453";
        public override Version Version => new Version(1, 1, 0);
        public override Version RequiredExiledVersion => new Version(3, 0, 0);

        public Dictionary<string, ElevatorType> RoomNameToElevator = new Dictionary<string, ElevatorType> {
            { "LCZ @ A", ElevatorType.LczA },
            { "LCZ @ B", ElevatorType.LczB },
            { "HCZ @ A", ElevatorType.LczA },
            { "HCZ @ B", ElevatorType.LczB },
            { "WARHEAD HALL", ElevatorType.Nuke },
            { "HEAD TOP", ElevatorType.Nuke },
            { "SCP-049 HALL", ElevatorType.Scp049 },
            { "049 ELEVATOR", ElevatorType.Scp049 },
            { "049 HALL 1", ElevatorType.Scp049 },
            { "GATE A", ElevatorType.GateA },
            { "GATE B", ElevatorType.GateB }
        };

        public HashSet<ElevatorType> disabledElevators = new HashSet<ElevatorType>();
        public Dictionary<Player, DateTime> activeCooldowns = new Dictionary<Player, DateTime>();

        private PlayerHandler playerHandler;
        private SCP079Handler scp079Handler;

        public override void OnEnabled()
        {
            Instance = this;
            RegisterEvents();
            base.OnEnabled();
        }

        public override void OnDisabled()
        {
            UnregisterEvents();
            base.OnDisabled();
        }

        private void RegisterEvents()
        {
            playerHandler = new PlayerHandler();
            scp079Handler = new SCP079Handler();

            // SCP-079
            Exiled.Events.Handlers.Scp079.GainingLevel += scp079Handler.onGainingLevel;
            Exiled.Events.Handlers.Scp079.ChangingCamera += scp079Handler.onChangingCamera;
            Exiled.Events.Handlers.Scp079.GainingExperience += scp079Handler.onGainingExperience;
            Exiled.Events.Handlers.Scp079.ElevatorTeleporting += scp079Handler.onElevatorTeleporting;

            // Player
            Exiled.Events.Handlers.Player.InteractingElevator += playerHandler.onInteractingElevator;
        }

        private void UnregisterEvents()
        {
            // SCP-079
            Exiled.Events.Handlers.Scp079.GainingLevel -= scp079Handler.onGainingLevel;
            Exiled.Events.Handlers.Scp079.ChangingCamera -= scp079Handler.onChangingCamera;
            Exiled.Events.Handlers.Scp079.GainingExperience -= scp079Handler.onGainingExperience;
            Exiled.Events.Handlers.Scp079.ElevatorTeleporting -= scp079Handler.onElevatorTeleporting;

            // Player
            Exiled.Events.Handlers.Player.InteractingElevator -= playerHandler.onInteractingElevator;

            playerHandler = null;
            scp079Handler = null;
        }
    }
}
