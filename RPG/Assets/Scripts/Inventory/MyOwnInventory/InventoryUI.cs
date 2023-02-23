using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject _cellSample;

    private Inventory _inventory;

    private void Awake()
    {
        _inventory = new Inventory(9);
        gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        //Debug.Log("Inventory enabled");
        InstantiateInventoryUI();
        transform.GetChild(0).gameObject.SetActive(false); // Disable CellTemplate.
    }

    public void InstantiateInventoryUI()
    {
        Clear();
        // Вообще здесь надо продумать. Будем ли мы пересоздавать UI при каждом открытии, или же будем менять UI при каждом подборе предмета.
        #region Test Area
        //[SerializeField] private GameObject[] _itemsPrefabs;
        //foreach (var item in _itemsPrefabs)
        //{
        //    bool success;
        //    _inventory.TryAdd(item.GetComponent<Item>(), out success);
        //}
        #endregion
        // У нас есть инвентарь, который хранит данные о ячейках.
        // На основе этих данных нам нужно создать GameObject'ы, которые будут отображать данные соответствующей ячейки.
        // Для этого у нас есть префаб ячейки, в котором нам нужно изменить данные.

        // Для каждой ячейки нужно получить следующую информацию: Sprite предмета, количество вещей в ячейке.

        foreach (CellInventory cell in _inventory.Cells)
        {
            if (cell.IsEmpty) continue;

            _cellSample.GetComponentInChildren<Image>().sprite = cell.ItemData.Sprite;
            _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = Convert.ToString(cell.CurrentAmount);

            Instantiate(_cellSample, this.transform);
            Debug.Log("Instantiated");
        }
        _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = "8"; // What is it?
    }

    /// <summary>
    /// Clears all inventory UI.
    /// </summary>
    /// make private!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    public void Clear()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        // Starting from 1 because 1st children is a CellSample.
        // UPD: Starting from 5 to avoid deleting of CellTemplate.

        // Здесь почему-то всё равно первая шаблонная ячейка удаляется.
        // Так-то вроде нет смысла её хранить, потому что можно брать любую ячейку и на её основе делать новую. Донор всё равно потом перереспавнится.
        // Но сверху возникнет баг в случае, когда мы подобрали что-то (и шаблонная ячейка удалилась), потом выбросили (инвентарь пуст) и снова подобрали.

        // Т.к. GetComponentsInChildren лезет в глубину, то отрывает куски шаблона (детей). Надо сделать так, чтобы они оставались жить. Баг возникает при включении ещё до того, как что-то подобрали
        // UPD: Пофикшено. Шаблонная ячейка не пропадает.
        
        // Теперь появился новый баг. Подобрали несколько предметов, включи инвентарь - всё ок. Отключили и включили ещё раз - на одну ячейку больше. !!!!!!!!!!!!!!!!!!!!!!!!!!
        // Очень странная штука. При i = 4 удаляется текст у шаблона, а при i = 5 не удаляется первая обычная ячейка.
        for (int i = 5; i < children.Length; i++)
        {
            Destroy(children[i].gameObject);
        }
    }

    //public void GenerateInventoryUI()
    //{
    //    GameObject[] cellsUI = new GameObject[4]; // 4!
    //    int index = 0;




    //    foreach (CellInventory cell in _inventory.Cells)
    //    {
    //        //if (_cellSample.GetComponentInChildren<SpriteRenderer>().sprite == null)
    //        //{
    //        //    Debug.Log("1st empty");
    //        //}
    //        //if (cell.Item.ItemData.Sprite == null)
    //        //{
    //        //    Debug.Log("2nd empty");
    //        //}
    //        _cellSample.GetComponentInChildren<SpriteRenderer>().sprite = cell.Item._itemData.Sprite; //!!!!!!!!!!!!!!
    //        _cellSample.GetComponentInChildren<TextMeshProUGUI>().text = cell.CurrentAmount.ToString();
    //        cellsUI[index] = _cellSample;
    //        Debug.Log("Сгенерирован " + index);
    //        index++;
    //    }

    //    foreach (var cell in cellsUI)
    //    {
    //        Instantiate(cell, this.transform);
    //    }
    //}
}
