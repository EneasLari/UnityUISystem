using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This class manages the transitions of tab buttons through three stages(idle,hover,active).
/// Also manages the pages need to be swapped after tab clicking. Assumes that for every 
/// index there is a page tab that matches tab's index.
/// </summary>
public class TabGroup1 : MonoBehaviour
{
    private List<TabButton1> _tabs=new List<TabButton1>();

    public bool tabSwapActiveGameObject;
    //pages to swap through tabs
    public GameObject[] gameObjectsToSwap;

    public PanelGroup panelGroup;

    [SerializeField]
    protected TabButton1 activeTab;

    public Action onTabSelectedCallBack;

    private void Start() {
        StartActiveTab();
    }

    public void StartActiveTab() {
        if (activeTab != null) {
            SetActiveTab(activeTab);
        }
    }

    ///<summary>
    ///</summary>
    public void Subscribe(TabButton1 button) {
        if (_tabs == null) {
            _tabs = new List<TabButton1>();
        }
        _tabs.Add(button);
    }

    public void Unsubscribe(TabButton1 tab) {
        _tabs.Remove(tab);
        if (activeTab==tab) {
            activeTab = null;
        }
    }

    ///<summary>
    ///</summary>
    public void SetActiveTab(TabButton1 tab) {
        foreach (TabButton1 t in _tabs) {
            t.Deselect();
        }
        activeTab = tab;
        activeTab.Select();

        if (onTabSelectedCallBack != null) {
            onTabSelectedCallBack();
        }
        if (tabSwapActiveGameObject) {
            SwapGameObject();
        }
        if (panelGroup != null) {
            panelGroup.SetPageIndex(tab.transform.GetSiblingIndex());
        }

    }

    public void SetActiveTab(int siblingIndex) {
        foreach (TabButton1 t in _tabs) {
            if (t.transform.GetSiblingIndex()==siblingIndex) {
                SetActiveTab(t);
                return;
            }
        }
    }



    void SwapGameObject() {
        for (int i = 0; i < gameObjectsToSwap.Length; i++) {
            gameObjectsToSwap[i].SetActive(false);
        }
        if (activeTab.transform.GetSiblingIndex() < gameObjectsToSwap.Length) {
            gameObjectsToSwap[activeTab.transform.GetSiblingIndex()].SetActive(true);
        }
    }

    public void DisableTab(int index) {
        if (_tabs.Count>index) {
            _tabs[index].Deselect();
        }
    }

    public void EnableTab(int index) {
        if (_tabs.Count > index) {
            _tabs[index].Select();
        }
    }
}
