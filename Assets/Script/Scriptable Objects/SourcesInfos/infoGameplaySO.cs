using UnityEngine;

[CreateAssetMenu(fileName = "Info Gameplay", menuName = "Sources informations/Info Gameplay")]
public class infoGameplaySO : ScriptableObject
{
    public string message;
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
