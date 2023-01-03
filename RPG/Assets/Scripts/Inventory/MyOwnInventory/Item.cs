using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item : MonoBehaviour, IITEM
{
    [SerializeField] public int MaxAmount { get; private set; }

    [SerializeField] private string _name;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private bool _stackable;
    public bool Stackable => _stackable;
    public string Name => _name;
    public Sprite Sprite => _sprite;

    public Action OnCellInventoryClicked;

    public abstract void Use();

    private void OnMouseDown()
    {
        //OldInventory.Instance.Add(this);
        Destroy(gameObject);
    }
}