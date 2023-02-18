using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orbs
{
    NONE,
    VIOLET,
    YELLOW
}

[CreateAssetMenu(fileName = "Current Orb", menuName = "Variables/Current Orb")]
public class CurrentOrb : ScriptableObject
{
    [SerializeField] public Orbs orbType = Orbs.NONE;
}
