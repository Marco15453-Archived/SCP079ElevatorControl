using Exiled.API.Enums;
using Exiled.API.Features;
using MEC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SCP079ElevatorControl
{
    public static class ExtraMethods
    {
        public static ElevatorType GetElevatorTypeByCameraName(string name)
        {
            foreach(var item in SCP079ElevatorControl.Instance.RoomNameToElevator)
            {
                if (item.Key == name) return item.Value;
            }
            return ElevatorType.Unknown;
        }

        public static void BlackoutRoom(Room room)
        {
            room.TurnOffLights(SCP079ElevatorControl.Instance.Config.BlackoutTime);
            room.LockDown(SCP079ElevatorControl.Instance.Config.BlackoutTime, DoorLockType.Lockdown079);
        }

        public static string ElevatorToString(ElevatorType elevator)
        {
            foreach(var item in SCP079ElevatorControl.Instance.Config.ElevatorStrings)
            {
                if (elevator == item.Key) return item.Value;
            }
            return "";
        }

        public static string CassieReadable(ElevatorType elevator)
        {
            foreach (var item in SCP079ElevatorControl.Instance.Config.CassieStrings)
            {
                if (elevator == item.Key) return item.Value;
            }
            return "";
        }

        public static IEnumerator<float> DisableElevator(Player p, ElevatorType elevator) {
            SCP079ElevatorControl.Instance.disabledElevators.Add(elevator);
            SCP079ElevatorControl.Instance.activeCooldowns.Add(p, DateTime.Now);
            if (SCP079ElevatorControl.Instance.Config.BlackoutTime > 0) BlackoutRoom(p.CurrentRoom);

            if(SCP079ElevatorControl.Instance.Config.CassieMessage != null)
                Cassie.Message(SCP079ElevatorControl.Instance.Config.CassieMessage.Replace("%ELEVATOR%", CassieReadable(elevator)));
            if (SCP079ElevatorControl.Instance.Config.GlobalBroadcastTime > 0 && SCP079ElevatorControl.Instance.Config.GlobalBroadcastMessage != null)
                Map.Broadcast(SCP079ElevatorControl.Instance.Config.GlobalBroadcastTime, SCP079ElevatorControl.Instance.Config.GlobalBroadcastMessage.Replace("%ELEVATOR%", ElevatorToString(elevator)), Broadcast.BroadcastFlags.Normal, true);

            yield return Timing.WaitForSeconds(SCP079ElevatorControl.Instance.Config.BreakdownTime);

            if (SCP079ElevatorControl.Instance.Config.CassieMessageReactivated != null)
                Cassie.Message(SCP079ElevatorControl.Instance.Config.CassieMessageReactivated.Replace("%ELEVATOR%", CassieReadable(elevator)));
            if (SCP079ElevatorControl.Instance.Config.GlobalBroadcastTime > 0 && SCP079ElevatorControl.Instance.Config.GlobalBroadcastMessageReactivated != null)
                Map.Broadcast(SCP079ElevatorControl.Instance.Config.GlobalBroadcastTime, SCP079ElevatorControl.Instance.Config.GlobalBroadcastMessageReactivated.Replace("%ELEVATOR%", ElevatorToString(elevator)), Broadcast.BroadcastFlags.Normal, true);

            SCP079ElevatorControl.Instance.disabledElevators.Remove(elevator);
        }
    }
}
