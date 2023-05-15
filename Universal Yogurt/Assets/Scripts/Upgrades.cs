using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Upgrade", menuName = "Yogurt Upgrade")]
public class Upgrades : ScriptableObject
{

    public string upgradeName;
    public uint upgradePrice;
    
    public uint upgradeClickNumber;
    public uint upgradeAutoNumber;

    public string[] upgradeDescription;
    
}
