using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the transitions of tab buttons through three stages(idle,hover,active).
/// Also manages the pages need to be swapped after tab clicking. Assumes that for every 
/// index there is a page tab that matches tab's index.
/// </summary>
public class TabGroup : MonoBehaviour
{
    public List<TabButton> tabButtons;

    //if we use sprites for different button states
    public Sprite tabIdle;
    public Sprite tabHover;
    public Sprite tabActive;

    //if we use colors for different button states
    public Color ctabIdle;
    public Color ctabHover;
    public Color ctabActive;

    public TabButton selectedTab;

    //pages to swap through tabs
    public List<GameObject> objectsToSwap;

    ///<summary>
    ///</summary>
    public void Subscribe(TabButton button) {
        if (tabButtons == null) {
            tabButtons = new List<TabButton>();
        }
        tabButtons.Add(button);
    }

    ///<summary>
    ///</summary>
    public void OnTabEnter(TabButton button) {
        ResetTabs();
        if (button != selectedTab) {
            button.background.sprite = tabHover;
            button.background.color = ctabHover;
        }

    }

    ///<summary>
    ///</summary>
    public void OnTabExit(TabButton button) {
        ResetTabs();
    }

    ///<summary>
    ///</summary>
    public void OnTabSelected(TabButton button) {
        if (selectedTab!=null) {
            selectedTab.Deselect();
        }

        selectedTab = button;
        //invoke callbacks that 
        selectedTab.Select();

        ResetTabs();
        button.background.sprite = tabActive;
        button.background.color = ctabActive;
        //tabs must have same index with pages
        int index = button.transform.GetSiblingIndex();
        for (int i = 0; i < objectsToSwap.Count; i++) {
            if (i == index) {
                objectsToSwap[i].SetActive(true);
            } else {
                objectsToSwap[i].SetActive(false);
            }
        }
    }

    ///<summary>
    ///</summary>
    public void ResetTabs() {
        foreach (TabButton button in tabButtons) {
            if (selectedTab != null && button == selectedTab) {
                continue;
            }
            button.background.sprite = tabIdle;
            button.background.color = ctabIdle;
        }
    }

}
