using UnityEngine;

[CreateAssetMenu(fileName = "Info RS", menuName = "Sources informations/Info RS")]
public class infoRsSO : ScriptableObject
{
    public Sprite profilePicture;
    public string name;
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
