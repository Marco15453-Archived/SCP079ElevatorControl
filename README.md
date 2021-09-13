# SCP-079 Elevator Control
A complex plugin that allows SCP-079 to take down an Elevators for a specific Time with a simple command

***CURRENTLY BLACKOUT ISN'T WORKING CORRECTLY IT WILL ONLY TURN OFF THE LIGHTS! THIS WILL BE FIXED LATER!***

# Commands
Name | Permission | Description | CommandType
---- | ---------- | ----------- | -----------
breakdown | -/- | Breakdown an Elevator as SCP-079 | ClientConsole

# Config
Name | Type | Description | Default
---- | ---- | ----------- | -------
is_enabled | bool | Should the plugin be enabled? | true
testing_mode | bool | Should the Testing Mode be enabled? (WARNING: THIS WILL GIVE SCP-079 ON ALL INTERACTION 500 EXPERIENCE! ONLY USE THIS FOR TESTING PURPOSE!) | false
auto_update | bool | Should the plugin automaticly update? | true
level_requirement | int | Level Requirements, use 0-4 for the Tiers. 0 = 1, 1 = 2, 2 = 3, 3 = 4, 4 = 5 | 3
power_requirement | int | Power required to activate the command? | 100
breakdown_experience | int | How much Experience should SCP-079 gets when breaking down an Elevator? | 25
breakdown_time | int | For how long should the Elevator breakdown? | 60
breakdown_cooldown | int | How long should SCP-079 be unavailable to breakdown an Elevator again? (Cooldown) | 60
on_cooldown_message | string | What Message should be displayed when SCP-079 tries to breakdown an Elevator while on Cooldown? %TIME_REMAINING% will be replaced with remaining time until cooldown is over! | <color=red>You are currently still on cooldown!</color><color=blue>Please wait %TIME_REMAINING% Seconds before breaking down an Elevator again!</color>
blackout_time | int | For how long should the room blackout when SCP-079 breaks down an Elevator? | 15
cassie_message | string | Cassie Message when Elevator gets broke down! %ELEVATOR% is replaced with the Elevator Name | Elevator %ELEVATOR% shut down
cassie_message_reactivated | string | Cassie Message when Elevator is back online! %ELEVATOR% is replaced with the Elevator Name | Elevator %ELEVATOR% is back in operational mode
global_broadcast_time | int | For how long should a global broadcast shows that an elevator has been breakdowned by SCP-079 (-1 = Disabled) | 3
global_broadcast_message | string | What message should be global broadcasted when SCP-079 breaks down an Elevator? %ELEVATOR% will be replaced with the Elevator Name | Elevator %ELEVATOR% has been broken down by SCP-079
global_broadcast_message_reactivated | string | What message should be global broadcasted when an Elevator gets back online! %ELEVATOR% will be replaced with the Elevator Name | Elevator %ELEVATOR% is back in operational mode!
elevator_breakdown_time | int | How long should a hint be displayed when a Player tries to use/call an broken down Elevator? (-1 = Disabled) | 3
elevator_breakdown_message | string | What hint should be displayed when a Player tries to use/call an broken down Elevator? | <color=red>This Elevator has a malfunction</color>
reaching_level_hint_time | int | How long should a hint be displayed when SCP-079 reaches the Level to be allowed to breakdown an Elevator? (-1 = Disabled) | 20
reaching_level_hint_message | string | What hint should be displayed when SCP-079 reaches the Level to be allowed to breakdown an Elevator? | You have reached Level %REQUIRED_LEVEL%! You are now allowed to breakdown Elevators \nUse '.breakdown' inside your Client Console!\nYou must be in an Camera with an Elevator!
on_camera_to_breakdown_hint_time | int | How long should a hint be displayed when SCP-079 switches to an Camera where he can break an Elevator? (-1 = Disabled) | 3
on_camera_to_breakdown_hint_message | string | What Hint should be displayed when SCP-079 switches to an Camera where he can break an Elevator? | You are currently in a Camera where you can break the Elevator down! \n Use '.breakdown' inside your Client Console to break it down!
elevator_strings | Dictionary | Replacements for ElevatorType | Gate A, Gate B, Light Containment Zone A, Light Containment Zone B, Nuke, SCP-049
cassie_strings | Dictionary | Cassie Replacements for ElevatorType | Gate A, Gate B, Light Containment Zone A, Light Containment Zone B, Nuke, SCP 0 4 9

# Default Config
```yml
s_c_p079_elevator_control:
  # Should the plugin be enabled?
  is_enabled: true
  # Should the Testing Mode be enabled? (WARNING: THIS WILL GIVE SCP-079 ON ALL INTERACTION 500 EXPERIENCE! ONLY USE THIS FOR TESTING PURPOSE!)
  testing_mode: false
  # Should the plugin automaticly update?
  auto_update: true
  # Level Requirements, use 0-4 for the Tiers. 0 = 1, 1 = 2, 2 = 3, 3 = 4, 4 = 5
  level_requirement: 3
  # Power required to activate the command?
  power_requirement: 100
  # How much Experience should SCP-079 gets when breaking down an Elevator?
  breakdown_experience: 25
  # For how long should the Elevator breakdown?
  breakdown_time: 60
  # How long should SCP-079 be unavailable to breakdown an Elevator again? (Cooldown)
  breakdown_cooldown: 60
  # What Message should be displayed when SCP-079 tries to breakdown an Elevator while on Cooldown? %TIME_REMAINING% will be replaced with remaining time until cooldown is over!
  on_cooldown_message: <color=red>You are currently still on cooldown!</color><color=blue>Please wait %TIME_REMAINING% Seconds before breaking down an Elevator again!</color>
  # For how long should the room blackout when SCP-079 breaks down an Elevator?
  blackout_time: 15
  # Cassie Message when Elevator gets broke down! %ELEVATOR% is replaced with the Elevator Name
  cassie_message: Elevator %ELEVATOR% shut down
  # Cassie Message when Elevator is back online! %ELEVATOR% is replaced with the Elevator Name
  cassie_message_reactivated: Elevator %ELEVATOR% is back in operational mode
  # For how long should a global broadcast shows that an elevator has been breakdowned by SCP-079 (-1 = Disabled)
  global_broadcast_time: 3
  # What message should be global broadcasted when SCP-079 breaks down an Elevator? %ELEVATOR% will be replaced with the Elevator Name
  global_broadcast_message: Elevator %ELEVATOR% has been broken down by SCP-079
  # What message should be global broadcasted when an Elevator gets back online! %ELEVATOR% will be replaced with the Elevator Name
  global_broadcast_message_reactivated: Elevator %ELEVATOR% is back in operational mode!
  # How long should a hint be displayed when a Player tries to use/call an broken down Elevator? (-1 = Disabled)
  elevator_breakdown_time: 3
  # What hint should be displayed when a Player tries to use/call an broken down Elevator?
  elevator_breakdown_message: <color=red>This Elevator has a malfunction</color>
  # How long should a hint be displayed when SCP-079 reaches the Level to be allowed to breakdown an Elevator? (-1 = Disabled)
  reaching_level_hint_time: 20
  # What hint should be displayed when SCP-079 reaches the Level to be allowed to breakdown an Elevator?
  reaching_level_hint_message: >-
    You have reached Level %REQUIRED_LEVEL%! You are now allowed to breakdown Elevators 

    Use '.breakdown' inside your Client Console!

    You must be in an Camera with an Elevator!
  # How long should a hint be displayed when SCP-079 switches to an Camera where he can break an Elevator? (-1 = Disabled)
  on_camera_to_breakdown_hint_time: 3
  # What Hint should be displayed when SCP-079 switches to an Camera where he can break an Elevator?
  on_camera_to_breakdown_hint_message: >-
    You are currently in a Camera where you can break the Elevator down! 

    Use '.breakdown' inside your Client Console to break it down!
  # Replacements for ElevatorType
  elevator_strings:
    GateA: Gate A
    GateB: Gate B
    LczA: Light Containment Zone A
    LczB: Light Containment Zone B
    Nuke: Nuke
    Scp049: SCP-049
  # Cassie Replacements for ElevatorType
  cassie_strings:
    GateA: Gate A
    GateB: Gate B
    LczA: Light Containment Zone A
    LczB: Light Containment Zone B
    Nuke: Nuke
    Scp049: SCP 0 4 9
```

# Credits
- Code by Me
- Plugin Idea by Skillz