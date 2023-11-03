using UnityEngine;
using UnityEngine.Events;

/*Base Game event listener class is abstract so all game event listener classes should derive from this*/

public abstract class BaseGameEventListener<T, E, UER> : MonoBehaviour, InterfaceGameEventListener<T> where E : BaseGameEvent<T> where UER : UnityEvent<T>
{
    [SerializeField] private E gameEvent;
    public E GameEvent { get { return gameEvent; } set { gameEvent = value; } }
    [SerializeField] private UER unityEventResponse;

    private void OnEnable()
    {
        if (gameEvent == null) { return; }
        GameEvent.RegisterListener(this);
    }
    private void OnDisable()
    {
        if (gameEvent == null) { return; }
        GameEvent.UnregisterListener(this);
    }
    public void OnEventRaised(T item)
    {
        if (unityEventResponse != null) {
            unityEventResponse.Invoke(item);
        }
    }
}
