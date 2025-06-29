using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BattleActionMenuUI : MonoBehaviour
{
    public BattleActionMenuContainerSO rootMenu;
    public GameObject buttonPrefab; // A prefab of with a UnityEngine.UI.Button component

    public BattleFieldMB battleField;
    public Transform buttonParent;

    public string backText = "< Back";
    public string firstPerformerName;

    public TextMeshProUGUI currentUnitName;
    //Scack where you are currently located in the menu
    private Stack<BattleActionMenuContainerSO> menuStack = new Stack<BattleActionMenuContainerSO>();


    void SetUnit(GameObject unit)
    {
        UnitMB unitMB = unit.GetComponent<UnitMB>();
        UnitSO unitSO = unitMB.data;


    }

    void Start()
    {
        //Will add buttons as child game objects of current object
        buttonParent = transform;
        OpenMenu(rootMenu);
    }

    // Update is called once per frame
    void Update()
    {

    }




    void ClearChildren(string tag)
    {
        foreach (Transform child in buttonParent)
        {
            if (child.CompareTag(tag))
            {
                Destroy(child.gameObject);
            }

        }
    }


    void OpenMenu(BattleActionMenuContainerSO menu)
    {

        ClearChildren("SpawnUIButton");
        print($"Making menu for :{menu.name} ");
        // If not at the root, add back button
        if (menuStack.Count > 0)
        {
            GameObject backButtonObj = Instantiate(buttonPrefab, buttonParent);
            SetButtonText(backButtonObj, backText);
            print($"Created backwards button for :{backButtonObj} ");
            backButtonObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                OpenMenu(menuStack.Pop());
            });

        }
        string itemsText = string.Join<BattleActionMenuItemSO>(", ", menu.items);
        print($"Start create items for :{itemsText} ");
        foreach (var item in menu.items)
        {
            if (item == null)
            {
                continue;
            }
            GameObject buttonObj = Instantiate(buttonPrefab, buttonParent);
            print($"Created button for :{buttonObj} ");
            SetButtonText(buttonObj, item.name);

            if (item is BattleActionMenuContainerSO submenu)
            {
                buttonObj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    menuStack.Push(menu);
                    print($"menuStack.Push :{menu} ");
                    OpenMenu(submenu);
                });


            }
            else if (item is BattleActionMenuItemSingleSO singleItem)
            {
                buttonObj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    ExecuteSelectionAction(singleItem.action);
                });
            }


        }
    }// end of OpenMenu

    void ExecuteSelectionAction(AbstractBattleActionSO action)
    {
        // Placeholder: Integrate with battle system
        Debug.Log($"Executing action: {action.name}");
        action.SelectActionForBattleField(battleField);
    }


    void SetButtonText(GameObject buttonObj, string text)
    {
        Transform textTransform = buttonObj.transform.Find("Text (TMP)");
        TextMeshProUGUI tmpText = textTransform.GetComponent<TextMeshProUGUI>();
        tmpText.text = text;

    }

    public void SetCurrentUnitName(string text)
    {
        Transform unitNameTraunform = transform.Find("CurrentUnitName");
        //Debug.Log($"SetCurrentUnitName : unitNameTraunform: {unitNameTraunform}");
        TextMeshProUGUI tmpText = unitNameTraunform.GetComponent<TextMeshProUGUI>();
        //Debug.Log($"SetCurrentUnitName : tmpText: {tmpText.name}");
        //tmpText.text = text;
    }

}
