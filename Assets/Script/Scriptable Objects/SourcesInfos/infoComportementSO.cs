using UnityEngine;

[CreateAssetMenu(fileName = "Profil Comportement", menuName = "Sources informations/Profil Comportement")]
public class infoComportementSO : ScriptableObject
{
    public string infoName;
    public string infoStat;
    public int infoPercentage;
    public Color infoColor;
}
