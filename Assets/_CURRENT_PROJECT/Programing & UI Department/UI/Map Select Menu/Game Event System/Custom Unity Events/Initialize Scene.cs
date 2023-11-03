using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//[CreateAssetMenu(fileName = "New Game Event Load Scene", menuName = "Game Events/Load Scene")]
public class InitializeScene<T> : BaseGameEvent<UnityEvent>
{
    /*
    public MapSelectScriptableObject mapSelectionConfirmation;
   // public MapSelectScriptableObject mapSelectionAsset { get { return mapSelectionConfirmation; }  set { mapSelectionConfirmation = value; } }
    private void CustomButtonClick()
    {
       if (mapSelectionConfirmation.mapSelectionBoolean == false)
        {
            mapSelectionConfirmation.mapSelectionBoolean = true;
        }

        if (mapSelectionConfirmation.mapSelectionBoolean)
        {
            SceneManager.LoadScene("mapOne", LoadSceneMode.Additive);
        }
    }
    */
}
