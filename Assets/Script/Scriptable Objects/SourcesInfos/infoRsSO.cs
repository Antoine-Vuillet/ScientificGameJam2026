using UnityEngine;

[CreateAssetMenu(fileName = "Info RS", menuName = "Sources informations/Info RS")]
public class infoRsSO : ScriptableObject
{
    public Sprite commentProfilePicture;
    public string commentUserName;
    public string commentMessage;
    public Color commentColor;

    [Header("Stats")]
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
