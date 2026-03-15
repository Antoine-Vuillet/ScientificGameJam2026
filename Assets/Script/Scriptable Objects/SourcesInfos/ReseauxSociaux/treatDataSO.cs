using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "Treat Data", menuName = "Sources informations/RS/Treat Data")]
public class treatDataSO : ScriptableObject
{
    public string treatName;
    public int treatCost;
    public bool isDark;
    [Header("Stats treated (0: autonomy, 1: social, 2: competence)")]
    public List<bool> treatedStats = new List<bool>() { false, false, false };
}
