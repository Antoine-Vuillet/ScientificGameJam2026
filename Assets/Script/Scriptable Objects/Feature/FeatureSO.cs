using UnityEngine;
using System.Collections.Generic;
using System;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Feature", menuName = "Feature/Feature")]
public class FeatureSO : ScriptableObject
{
    public bool isDark;
    [Header("Objectifs")]
    [Range(0, 10)]
    public int autonomy;
    [Range(0, 10)]
    public int social;
    [Range(0, 10)]
    public int competence;
}