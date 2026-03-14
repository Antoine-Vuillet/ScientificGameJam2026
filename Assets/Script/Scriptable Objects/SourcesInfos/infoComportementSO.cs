using UnityEngine;

[CreateAssetMenu(fileName = "Profil Comportement", menuName = "Sources informations/Profil Comportement")]
public class infoComportementSO : ScriptableObject
{
    public string infoName;
    public string description;
    public Color color;
    public int cost;
    public bool isDark;

    [Range(0, 100)]
    public int autonomy;
    [Range(0, 100)]
    public int social;
    [Range(0, 100)]
    public int competence;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
