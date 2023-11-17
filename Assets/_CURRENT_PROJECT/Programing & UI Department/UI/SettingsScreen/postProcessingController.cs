using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField] private PostProcessVolume _postProcessVolume;
    private AmbientOcclusion _ambientOcclusion;

private void Start()
{
    _postProcessVolume.profile.TryGetSettings(out _ambientOcclusion);
}

public void AmbientOcclusionOnOff(bool value)
{
    _ambientOcclusion.active = value;
     
}

}
