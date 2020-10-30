using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>
/// This class manages the  tab buttons
/// </summary>
[RequireComponent(typeof(Image))]
public class TabButton : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    ///<summary>
    ///</summary>
    public TabGroup tabGroup;
    ///<summary>
    ///</summary>
    public Image background;
    ///<summary>
    ///</summary>
    public UnityEvent onTabSelected;
    ///<summary>
    ///</summary>
    public UnityEvent onTabDeselected;



    //IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler implementations

    ///<summary>
    ///Implements IPointerClickHandler method
    ///</summary>
    public void OnPointerClick(PointerEventData eventData) {
        tabGroup.OnTabSelected(this);
    }

    ///<summary>
    ///Implements IPointerEnterHandler method
    ///</summary>
    public void OnPointerEnter(PointerEventData eventData) {
        tabGroup.OnTabEnter(this);
    }

    ///<summary>
    ///Implements IPointerExitHandler method
    ///</summary>
    public void OnPointerExit(PointerEventData eventData) {
        tabGroup.OnTabExit(this);
    }

    ///<summary>
    ///</summary>
    public void Select() {
        if (onTabSelected!=null) {
            onTabSelected.Invoke();
        }     
    }

    ///<summary>
    ///</summary>
    public void Deselect() {
        if (onTabDeselected != null) {
            onTabDeselected.Invoke();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
