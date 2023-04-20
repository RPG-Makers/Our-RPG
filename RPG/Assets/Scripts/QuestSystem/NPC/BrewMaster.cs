using UnityEngine;

public class BrewMaster : QuestGiver
{
    protected override void GiveQuest(GameObject player)
    {
        if (givedQuest) { return; }

        Task[] tasks = new Task[8] { 
            new GoTask
            ("Хорошо тебя отдубасили, иди и помоги несчастной женщине!",
                "Квест №5 найти реликвию пострадавшей у таверны", _placeManager.GetComponent<PlacesLinks>().Money1), 
            new GoTask
            ("Находим женщину и говорим с ней",
                "узнаём точное место преступления", _placeManager.GetComponent<PlacesLinks>().Money2), 
            new GoTask
            ("Пришли на место",
                "нашли улику, идём говорить с трактирщиком", _placeManager.GetComponent<PlacesLinks>().Money3), 
            new GoTask
            ("трактирщик отправляет нас к кузнецу, так как улика от кузнеца",
                "кузнец даёт список имён для опроса", _placeManager.GetComponent<PlacesLinks>().Hat),
            new GoTask
            ("говорим с первым подозреваемым",
                "получаем люлей или нет, смотря как базарим и идём ко 2", _placeManager.GetComponent<PlacesLinks>().Iron),
            new GoTask
            ("говорим со вторым подозреваемым",
                "получаем люлей или нет, смотря как базарим и идём ко 3", _placeManager.GetComponent<PlacesLinks>().Bow),
            new GoTask
            ("говорим с 3 подозреваемым",
                "получаем люлей или нет", _placeManager.GetComponent<PlacesLinks>().Book1),
            new GoTask
            ("появляется UI с журналом диалогов, а затем таймер 15 секунд и 3 портрета, надо выбрать кто напал на женщину",
                "если правильно, вин, если нет, то тоже что-нибудь и ачивка", _placeManager.GetComponent<PlacesLinks>().Book2),
        };
        _quest = new Quest("Find items!", "Talk", tasks);
        base.GiveQuest(player);
    }
}
