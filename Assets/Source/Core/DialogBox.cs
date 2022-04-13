using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBox : MonoBehaviour
{

    [SerializeField] public GameObject moveSelector;
    [SerializeField] public List<Text> MoveTexts;
    [SerializeField] public Color highlightedColor = Color.blue;


    public void EnableMoveSelector(bool enabled)
    {
        moveSelector = GameObject.Find("ActionSelector");
        moveSelector.SetActive(enabled);
    }

    public void UpdateActionSelection(int selectionAction)
    {
        moveSelector = GameObject.Find("ActionSelector");
        MoveTexts = GameObject.Find("DialogBox").GetComponents<DialogBox>()[0].MoveTexts;
        for (int i = 0; i < MoveTexts.Count; i++)
        {
            if (i == selectionAction)
            {
                MoveTexts[i].color = highlightedColor;
            }
            else
            {
                MoveTexts[i].color = Color.black;
            }
        }
    }
}
