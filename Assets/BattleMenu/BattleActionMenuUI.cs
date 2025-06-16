using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BattleActionMenuUI : MonoBehaviour
{
    public BattleActionMenuContainerSO rootMenu;
    public GameObject buttonPrefab; // A prefab of with a UnityEngine.UI.Button component
    public Transform buttonParent;
    //Scack where you are currently located in the menu
    private Stack<BattleActionMenuContainerSO> menuStack = new Stack<BattleActionMenuContainerSO>();



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


    void ClearButtons()
    {
        foreach (Transform child in buttonParent)
        {
            Destroy(child.gameObject);
        }
    }


    void OpenMenu(BattleActionMenuContainerSO menu)
    {

        ClearButtons();
        // If not at the root, add back button
        if (menuStack.Count > 0)
        {
            GameObject backButtonObj = Instantiate(buttonPrefab, buttonParent);
            backButtonObj.GetComponentInChildren<Text>().text = "< Back";
            backButtonObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                menuStack.Pop();
                OpenMenu(menuStack.Peek());
            });

        }

        foreach (var item in menu.items)
        {
            GameObject buttonObj = Instantiate(buttonPrefab, buttonParent);
            Text buttonText = buttonObj.GetComponentInChildren<Text>();
            buttonText.text = item.name;
            if (item is BattleActionMenuContainerSO submenu)
            {
                buttonObj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    menuStack.Push(submenu);
                    OpenMenu(submenu);
                });


            }
            else if (item is BattleActionMenuItemSingleSO singleItem)
            {
                buttonObj.GetComponent<Button>().onClick.AddListener(() =>
                {
                    ExecuteBattleAction(singleItem.action);
                });
            }


        }
    }// end of OpenMenu
    
    void ExecuteBattleAction(AbstractBattleActionSO action)
    {
        // Placeholder: Integrate with battle system
        Debug.Log($"Executing action: {action.name}");
    }

}
