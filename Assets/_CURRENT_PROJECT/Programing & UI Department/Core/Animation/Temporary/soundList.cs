using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundList : MonoBehaviour
{
    public AudioSource[] sound;
   public AudioClip[] list;
    public void playPunch()
    {
        sound[0].clip=(list[0]);
        sound[0].Play();
    }
    public void playShoot()
    {
        sound[1].clip = (list[1]);
        sound[1].Play();
    }
}
