using System.Collections.Generic;
using UnityEngine;
/*Base Game event class is abstract so all game event classes should derive from this*/
public abstract class BaseGameEvent<T> : ScriptableObject
{
   private readonly List<InterfaceGameEventListener<T>> eventListeners = new List<InterfaceGameEventListener<T>>(); /*interface game event listener is a list of all listeners accessing
                                                                                                                     this game event.
                                                                                                                     */

    public void Raise(T item) //when event is raised append every piece of data to the list of event listeners.
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--) 
        {
            eventListeners[i].OnEventRaised(item);
        }
    }
       public void RegisterListener(InterfaceGameEventListener<T> listener) //if event listeners does not contain a type listener add a listener
       {
           if(!eventListeners.Contains(listener))
           {
               eventListeners.Add(listener);
           }
       }
       public void UnregisterListener(InterfaceGameEventListener<T> listener) //if event listener does contain a type listener remove a listener
       {
           if(eventListeners.Contains(listener))
           {
               eventListeners.Remove(listener);
           }
       }
}