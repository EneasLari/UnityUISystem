using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveInactiveColors : MonoBehaviour
{
    [SerializeField]
    public List<PlayerStats> Graphics;

    [Serializable]
    public struct PlayerStats
    {
        public Graphics movementSpeed;
        public Color hitPoints;
        public Color hasHealthPotion;
    }
    [SerializeField]
    private PlayerStats stats;
}
