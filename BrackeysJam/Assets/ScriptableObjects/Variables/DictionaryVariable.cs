using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Dictionary Variable", menuName = "Variables/Dictionary")]
public class DictionaryVariable : ScriptableObject
{
    public Dictionary<string, int> stringIntDictionary = new Dictionary<string, int>();

    public void AddItem(string _stringKey, int _int)
    {
        if (!stringIntDictionary.ContainsKey(_stringKey)) stringIntDictionary.Add(_stringKey, _int);
    }
    
    public void RemoveItem(string _stringKey, int _int)
    {
       if (stringIntDictionary.ContainsKey(_stringKey)) stringIntDictionary.Remove(_stringKey);
    }
}
