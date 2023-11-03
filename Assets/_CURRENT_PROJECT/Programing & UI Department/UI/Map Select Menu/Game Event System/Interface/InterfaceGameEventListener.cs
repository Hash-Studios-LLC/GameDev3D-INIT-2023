//Used for list of listeners for a game event

public interface InterfaceGameEventListener<T>
{
   public void OnEventRaised(T item);
}
