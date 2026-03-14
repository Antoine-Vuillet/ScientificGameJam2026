using UnityEngine;
using System.Collections.Generic;
using System;
using NaughtyAttributes;

[Serializable]
public class feature
{
    public string featureName;
    public string description;
    public bool isDark;
    [Range(0, 100)]
    public int autonomy;
    [Range(0, 100)]
    public int social;
    [Range(0, 100)]
    public int competence;
}

[CreateAssetMenu(fileName = "Jeu", menuName = "Jeux/Jeu")]
public class jeuSO : ScriptableObject
{
    public List<feature> features;
    public int budget;
    [Header("Objectifs")]
    [Range(0, 100)]
    public int autonomy;
    [Range(0, 100)]
    public int social;
    [Range(0, 100)]
    public int competence;
}
