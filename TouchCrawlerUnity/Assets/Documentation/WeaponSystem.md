# Weapon System
## Description
The weapon system handles all interactions between the player and the world through their weapons. This includes things like the weapons themselves, any projectiles the weapon may need to utilize and the effects these two have on the world around them. By utilizing the system we have in place, it allows for weapons to be built and customized without the need to write more code.

## How to Use
The weapon system is set up in parts. The first of which are the weapons themselves. Any weapon you wish to create in the game can be first setup as a prefab in Unity. These prefabs must have the Weapon script attached as a component in the editor. After which, the designer will be prompeted to add any critical components to the weapon. This includes things like triggers, cooldowns, and fire patterns. Afterwhich, they will be able to add additional components such as on hit effects that modify a weapons behavior.
