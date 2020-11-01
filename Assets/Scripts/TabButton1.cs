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
public class TabButton1 : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    ///<summary>
    ///</summary>
    public TabGroup1 tabGroup;
    ///<summary>
    ///</summary>
    public Image background;

    [Header("Colors")]
    public List<Graphic> Graphics;
    public List<Color> ActiveColors;
    public List<Color> InactiveColors;

    [Header("GameObjects")]
    public List<GameObject> ShowOnSelected;
    public List<GameObject> HideOnDeselected;

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
        tabGroup.SetActiveTab(this);
    }

    ///<summary>
    ///Implements IPointerEnterHandler method
    ///</summary>
    public void OnPointerEnter(PointerEventData eventData) {
        //tabGroup.OnTabEnter(this);
        //Deselect();
    }

    ///<summary>
    ///Implements IPointerExitHandler method
    ///</summary>
    public void OnPointerExit(PointerEventData eventData) {
        //tabGroup.OnTabExit(this);
        //Deselect();
    }

    ///<summary>
    ///</summary>
    public void Select() {
        if (onTabSelected!=null) {
            onTabSelected.Invoke();
        }
        this.Graphics[0].color = this.ActiveColors[0];
        this.Graphics[1].color = this.ActiveColors[1];
    }

    ///<summary>
    ///</summary>
    public void Deselect() {
        if (onTabDeselected != null) {
            onTabDeselected.Invoke();
        }
        this.Graphics[0].color = this.InactiveColors[0];
        this.Graphics[1].color = this.InactiveColors[1];
    }

    // Start is called before the first frame update
    void Start()
    {
        background = GetComponent<Image>();
        tabGroup.Subscribe(this);
        this.Graphics[0].color = this.InactiveColors[0];
        this.Graphics[1].color = this.InactiveColors[1];
    }
}
