using UnityEngine;

[RequireComponent(typeof(PlayerQuest))]
public class PlayerQuestUI : MonoBehaviour
{
    [SerializeField] private GameObject _UI;

    public void ActiveUI()
    {
        _UI.SetActive(true);
    }
}
