using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BudgetWindow : MonoBehaviour
{
    [SerializeField] private GameScript gameManager;
    private TextMeshProUGUI budgetText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        budgetText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateBudget(Component sender, object data)
    {
        budgetText.text = (gameManager.maxMoney - gameManager.usedMoney).ToString() + "€";
    }
}