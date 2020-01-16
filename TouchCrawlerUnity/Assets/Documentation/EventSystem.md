# Observer Event System

## NOTE: Unit has it's own event system which is different then an Observer Event System!!!!

## Description

An event system is a decoupling pattern (a pattern which allows two objects to communicate with eachother without knowing about eachother). It allows the designers to reduce maintnance on their application by allowing designers to refactor some systems without needing to refactor other systems. It also provides a conveinant way to communicate with objects where you don't have a reference.

In more theoretical terms, and event broadcast is an abstraction of a method call with some advantages

1. The sender doesn't need a reference to the receiver.
2. The sender can call methods on multiple receivers.
3. There is information hiding between the sender and receiver.
4. It reduces the knowladge load on the programmers so multiple programmers can work together.

Note: You don't need to put an event system in your scene, it will be created automatically the first time you call a method on it.

## How To Use

The event system is split into channels, and subchannels. Objects in the program register themselves with a channel and a subchannel, and will receive every event on every channel they are registered in.

When an object wants to trigger an event it does so by Broadcasting that event on the channel and subchannel that it wants to notify.

Objects which listen on event channels for events must impliment the IEventListener interface

All event objects must impliment the IEvent interface.

To add an event listener to an event channel call the method:

    EventSystem.AddEventListener(channel, subchannel, eventListener)

To remove an event listener from an event channel call the method:

    EventSystem.RemoveEventListener(channel, subchannel, eventListener)

Make sure that all event listeners remove themselves when they are destroyed.

To broadcast an event on an event channel call the method:

    EventSystem.Broadcast(channel, subchannel, event)

To receive an event implimenet the method AcceptEvent on the IEventListener initerface. For Example

    public void class MyEventListener : IEventListener{

        public void AcceptEvent(IEvent e){
            if(e is MyEventType myEvent){
                DoSomething(myEvent);
            }
        }
    }

## When to use an ovserver event system

For making buttons work independant of their logic. The buttons broadcast a ButtonPressEvent into the event system on the (UI, MyUIComponentName) channel and subchannel. Then, an event listener on the same channel receives the button press and executes some logic.

For sending inputs from the input system to the player. The input system broadcasts an InputEvent on the (Input, PlayerInput) channel and subchannel, and the player receives the input because it's listening on the same channel. The player then puts the input in an EventQueue and unloads the event queue on the next frame.

## When NOT to use an observer event system.

An object needs to know about another object, such as when an object needs to talk to it's components. A method call is better.

An object needs an immediate response from the other object. A method call is better.

Implementing the event system is more complicated then implimenting a method call.