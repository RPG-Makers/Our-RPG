using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConfirmationWindow : MonoBehaviour
{
    //[Header("Inventory")]
    //[SerializeField] private GameObject _inventoryGO;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI _howMany;

    [SerializeField] private Slider _slider;
    [SerializeField] private TextMeshProUGUI _currentValue;
    [SerializeField] private TextMeshProUGUI _maxValue;

    [SerializeField] private Button _drop;

    [SerializeField] private Toggle _toggle;

    private Inventory _inventory;

    private CellUIMovler _cell;

    private void Awake()
    {
        _inventory = this.transform.parent.GetComponentInChildren<InventoryUI>().Inventory;
    }

    private void OnEnable()
    {
        //
    }

    private void OnDisable()
    {
        // ��������, OnDisable() ������ ������� �������� ����. � ����� ������ ����� ������� ������ �� ������� �����.
    }

    public void InitializeValues(int indexOfCell, CellUIMovler inputCell)
    {
        _cell = inputCell;

        CellInventory cell = _inventory.GetCell(indexOfCell);

        _howMany.text = $"How many {cell.ItemType} do you want to drop?";

        _maxValue.text = cell.CurrentAmount.ToString();
        _slider.maxValue = Convert.ToInt32(_maxValue.text);
        _currentValue.text = _slider.value.ToString();
    }

    public void Drop()
    {
        if (_toggle.isOn)
        {
            // �������������� ���� �������������.


        }
        else
        {
            // �����������.
        }
    }

    public void ChangeCurrentValue()
    {
        _currentValue.text = _slider.value.ToString();
    }

    public void Close()
    {
        _cell.ReturnToStart();

        Destroy(this.gameObject);
    }
}
