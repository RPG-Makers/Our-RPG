using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DropWindow : MonoBehaviour
{
    //[Header("Inventory")]
    //[SerializeField] private GameObject _inventoryGO;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _mainText;

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _currentValue;
    [SerializeField] private TextMeshProUGUI _maxValue;

    [SerializeField] private Button _drop;
    [SerializeField] private TextMeshProUGUI _dropText;

    [SerializeField] private Toggle _toggle;

    [SerializeField] private GameObject _confirmationWindow;

    private InventoryUI _inventoryUI;
    private Inventory _inventory;

    private CellUIMovler _UIcell;
    private int _indexOfCell;

    private void Awake()
    {
        _inventoryUI = this.transform.parent.GetComponentInChildren<InventoryUI>();
        _inventory = _inventoryUI.Inventory;
    }

    private void OnEnable()
    {
        //
    }

    private void OnDisable()
    {
        // Возможно, OnDisable() вызван кнопкой закрытия окна. В таком случае нужно вернуть ячейку на прежнее место.
    }

    public void InitializeValues(int indexOfCell, CellUIMovler inputCell)
    {
        _UIcell = inputCell;
        _indexOfCell = indexOfCell;

        CellInventory cell = _inventory.GetCell(indexOfCell);

        _mainText.text = $"How many {cell.ItemType} do you want to drop?";

        _maxValue.text = cell.CurrentAmount.ToString();
        _slider.maxValue = Convert.ToInt32(_maxValue.text);
        _currentValue.text = _slider.value.ToString();
    }

    public void Drop()
    {
        if (_toggle.isOn)
        {
            Instantiate(_confirmationWindow, this.transform.parent).
                GetComponent<ConfirmationWindow>().
                InitializeValues(this.gameObject, _inventoryUI, _inventory, _UIcell, _indexOfCell, Convert.ToInt32(_currentValue));
            this.gameObject.SetActive(false);
        }
        else
        {
            if (_inventory.DecreaseAmount(_indexOfCell, Convert.ToInt32(_currentValue.text)))
            {
                Debug.Log("DropedOut successfully");
                _inventoryUI.InstantiateInventoryUI();
                Destroy(_UIcell.gameObject);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.LogWarning("An error occured while dropping an item!");
            }
        }
    }

    public void ChangeCurrentValue()
    {
        _currentValue.text = _slider.value.ToString();
        _dropText.text = $"Drop {_currentValue.text} items";
    }

    public void Close()
    {
        _UIcell.ReturnToStart();

        Destroy(this.gameObject);
    }
}
