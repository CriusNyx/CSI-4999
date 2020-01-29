# Input System Controller

## Description:

An Input System takes input from the player and sends it to the event system, allowing the event system to react to the player's input. In Touch Crawler's case, there are two Input Systems necessary for PC and Mobile. The PC version uses clicks as input, and the Mobile version uses touches.

## Basic Overview:

Both of the Input Controllers contain a method called Private Void Update() which will update every single frame the game is running.

At the most basic level, in each frame this code will update to see if there is a touch or click. If there is, it will be converted to an "event", either an attack or move event, and then send it to the event system to be used as necessary.

## Registering for the Input System:

The Input System Controllers both broadcast to the Event Channel "player" and the subchannel "input." To get input events, call this code (where eventListener is an event listener, which listens to the input events - either attack or move.)

    EventSystem.AddEventListener(player, input, eventListener)

## Attack or Move Events:

Attack Input Events take input of type "Attackable" and Move Input Events take input of type "Ray". To call them, use these. Attackable is a type created for this project, Ray is a built in type for Unity with properties "direction" and "origin." origin should be the spot where the app is clicked or touched, and direction should be the direction of the camera whenever used in this project.

    AttackInputEvent(Attackable attackable)
    MoveInputEvent(Ray ray)
For sending inputs from the input system to the player. The input system broadcasts an InputEvent on the (Input, PlayerInput) channel and subchannel, and the player receives the input because it's listening on the same channel. The player then puts the input in an EventQueue and unloads the event queue on the next frame.

## When NOT to use an observer event system.

An object needs to know about another object, such as when an object needs to talk to it's components. A method call is better.

An object needs an immediate response from the other object. A method call is better.

Implementing the event system is more complicated then implimenting a method call.