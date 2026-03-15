using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "Treat Data", menuName = "Sources informations/RS/Treat Data")]
public class treatDataSO : ScriptableObject
{
    public string treatName;
    public int treatCost;
    public bool isDark;
    [Range(0, 100)]
    public int autonomy;
    [Range(0, 100)]
    public int social;
    [Range(0, 100)]
    public int competence;
}
