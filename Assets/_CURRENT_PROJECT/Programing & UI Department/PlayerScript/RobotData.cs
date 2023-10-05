using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Scriptable Objects/RobotData")]
public class RobotData : ScriptableObject
{
    public int playerHealth;
    public int playerSpeed;

    public int punchDamage;
    public float punchCooldown;

    public int rocketDamage;
    public int rocketSpeed;
    public float rocketCooldown;

}
