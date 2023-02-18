using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Custom Asset/Dialogue")]
public class Dialogue : ScriptableObject
{
    public string characterName;
    public string[] lines;
}
