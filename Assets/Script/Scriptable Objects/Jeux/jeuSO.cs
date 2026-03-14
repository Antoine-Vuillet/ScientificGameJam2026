using UnityEngine;
using System.Collections.Generic;
using System;
using NaughtyAttributes;

[CreateAssetMenu(fileName = "Jeu", menuName = "Jeux/Jeu")]
public class jeuSO : ScriptableObject
{
    public int budget;
    [Header("Objectifs")]
    [Range(1, 10)]
    public int autonomy;
    [Range(1, 10)]
    public int social;
    [Range(1, 10)]
    public int competence;
}
