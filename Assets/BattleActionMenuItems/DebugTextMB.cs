using UnityEngine;
using TMPro;

public class DebugTextMB : MonoBehaviour
{

    public BattleFieldMB battleField;
    TextMeshProUGUI tmpText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        tmpText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        tmpText.text = battleField.fieldState.ToString();
    }
}
