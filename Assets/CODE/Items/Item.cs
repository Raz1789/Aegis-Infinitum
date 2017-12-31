using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {

    #region Text
    public string itemType = string.Empty;
    public string itemName = string.Empty;
    [Space]
    [TextArea(15, 20)]
    public string itemDescription = string.Empty;
    #endregion
    [Space]
    public int itemID = 0;
    [Space]
    #region Stats
    [Header("Stats")]
    public int healthRestore = 0;
    public int healthBuff = 0;
    public int staminaRestore = 0;
    public int staminaBuff = 0;
    public int calorieRestore = 0;
    public int calorieBuff = 0;
    public int willBuff = 0;
    public int willRestore = 0;
    public int speedBuff = 0;
    #endregion
}
