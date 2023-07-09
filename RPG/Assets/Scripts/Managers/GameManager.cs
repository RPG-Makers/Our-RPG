using UnityEngine;

[RequireComponent(typeof(DialogueSystemManager), typeof(QuestDiaryManager))]
[RequireComponent(typeof(PlacesLinks))]
public class GameManager : MonoBehaviour
{
    #region Public
    
    public static GameManager Instance = null;
    public DialogueSystemManager DialogueSystemManager => dialogueSystemManager;
    public QuestDiaryManager QuestDiaryManager => questDiaryManager;
    public PlacesLinks PlacesLinks => placesLinks;
    public PlayerQuest PlayerQuest => playerQuest;
    
    #endregion
    
    [Header("Links")]
    [SerializeField] private PlayerQuest playerQuest;

    private DialogueSystemManager dialogueSystemManager;
    private QuestDiaryManager questDiaryManager;
    private PlacesLinks placesLinks;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(this);

        dialogueSystemManager = GetComponent<DialogueSystemManager>();
        questDiaryManager = GetComponent<QuestDiaryManager>();
        placesLinks = GetComponent<PlacesLinks>();
    }
}
