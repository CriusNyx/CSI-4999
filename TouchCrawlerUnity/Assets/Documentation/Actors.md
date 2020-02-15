#Actors

##Overview

An actor is anything in the game that can 'act' such as the player and enemies. The big distinction made in this implementation the PlayActor and NPCActor which is essential a distinction between the player and everyother actor. The player will listen for input events generated from the event system because of a user input while the enemy movement is determined by the EnemyAIController. This implementation allows for less redundancy in the code since both types of actors move in the same way they just take their queues on when and how to move differently.

It is mandatory for each actor game object to have a MovementController component attached to it.

It is mandatory for each NPCActor game object to have an EnemyAIController component attached to it.

##Movement Controller

Each actor's MovementController is updated every frame and has a default state of being stopped. The actor starts moving when Move() is called which will set the destination for the MovementController. On each frame after that method call the MovementController will first test if it has reached its destination and if it hasn't then it will set its velocity on the vector that intersects the object's current location and its destination scaled to the max velocity. Once it reaches its destination it will set its destination to its next location which will ensure the velocity is set to zero.

##Enemy AI Controller

The EnemeyAIController has three states which will cause the actor to behave differently. The states are wander, patrol, and attack. Whenever a wandering or patroling enemy is attacked by the player they switch to attacking. There is no way for an attacking enemy to become a wanderer or a patroler even if they started of as one.

The behavior is determined by the booleans isWandering and isPatrolling. If both isWandering and isPatrolling is set to true then isWandering takes priority. If both are false then the enemy will attack.

###1. Wander

The next location of the enemy is randomly selected point that is no longer than three units of distance away from the current location. If a wall or another object is in the way of the destination then the actor will stop. The enemy will wait to select its next destination for however many frames stopDuration is set to.

###2. Patrol

The next location of the enemy is set by iterating through the array patrolPath from 0 to n and back to 0. The enemy will wait until going to the next patrol locatoin for as many frames as stopDuration is set to.

###3. Attack

The enemy locks on to the player and moves towards him. How close the needs to get to the enemy before attacking is set by attackDistance and how close the enemy needs to get before stopping is set by stopDistance.
