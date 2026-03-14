using UnityEngine;
using UnityEngine.UI;

public class FeatureScript : MonoBehaviour
{
    [SerializeField] private FeatureChoiceScript generalScript;
    public FeatureSO feature;
    Toggle toggle;
    
    void Awake()
    {
        toggle = GetComponent<Toggle>();
    }

    public void OnToggleValueChanged(bool value)
    {
        generalScript.OnToggleValueChanged(toggle.isOn,toggle);
    }
}
