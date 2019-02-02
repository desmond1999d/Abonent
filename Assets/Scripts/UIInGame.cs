using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIInGame : MonoBehaviour {
    [SerializeField]
    private UIInGame2 uiInGame2;
    public GameObject menu;
    [SerializeField]
    private SwitchCamera swithCamera;
    //[SerializeField]
    //private UIController uiController;
    private Dictionary<string, string> map = new Dictionary<string, string>();

    [SerializeField] private Text selectedObject;

    public void SetText(string text)
    {
        foreach (KeyValuePair<string, string> kvp in map)
        {
            if (kvp.Key == text)
            {
                selectedObject.text = kvp.Value;
                this.gameObject.SetActive(true);
                uiInGame2.gameObject.SetActive(false);
                return;
            }
        }
        this.gameObject.SetActive(false);
        uiInGame2.gameObject.SetActive(false);
    }
    void Start()
    {
        map.Add("machta", "Чтобы открыть справку по телескоической мачте");
        map.Add("AparatDoor1", "Чтобы открыть дверь");
        map.Add("AparatDoor2", "Чтобы открыть дверь");
        map.Add("AparatDoor3", "Чтобы открыть дверь");
        map.Add("AparatDoor4", "Чтобы открыть дверь");
        map.Add("AparatDoor5", "Чтобы открыть дверь");
        map.Add("AparatDoor6", "Чтобы открыть дверь");
        map.Add("AparatDoor7", "Чтобы открыть дверь");
        map.Add("AparatDoor8", "Чтобы открыть дверь");

        map.Add("RoomDoor", "Чтобы открыть дверь");
        map.Add("AparatDoor", "Чтобы открыть дверь");
        map.Add("osnovaPricepa", "Чтобы открыть справку по тендовому прицепу");
        map.Add("kabel", "Чтобы открыть справку по кабельному имуществу");
        map.Add("aparat1", "Чтобы открыть справку по аппаратной машине");
        map.Add("aparat2", "Чтобы открыть справку по аппаратной машине");
        map.Add("aparat3", "Чтобы открыть справку по аппаратной машине");
        map.Add("aparat4", "Чтобы открыть справку по аппаратной машине");

        map.Add("reflectometer", "Чтобы открыть справку по мини-рефлектометру");
        map.Add("kanal", "Чтобы открыть справку по cредстваv каналообразования");
        map.Add("mpc", "Чтобы открыть справку по первичному цифровому мультиплексору");
        map.Add("smd", "Чтобы открыть справку по мультиплексору доступа");
        map.Add("r24-1", "Чтобы открыть справку по цифровой радиорелейной станции Р-424");
        map.Add("r24-2", "Чтобы открыть справку по цифровой радиорелейной станции Р-424");
        map.Add("r29-1", "Чтобы открыть справку по цифровой радиорелейной станции Р-429");
        map.Add("r29-2", "Чтобы открыть справку по цифровой радиорелейной станции Р-429");
        map.Add("bg90-1", "Чтобы открыть справку по блоку питания");
        map.Add("bg90-2", "Чтобы открыть справку по блоку питания");
        map.Add("bg90-3", "Чтобы открыть справку по блоку питания");
        map.Add("bg90-4", "Чтобы открыть справку по блоку питания");
        map.Add("bg90-5", "Чтобы открыть справку по блоку питания");
        map.Add("bg90-6", "Чтобы открыть справку по блоку питания");
        map.Add("megatrans-1", "Чтобы открыть справку по аппаратуре цифровой системы передачи MEGATRANS-3M");
        map.Add("megatrans-2", "Чтобы открыть справку по аппаратуре цифровой системы передачи MEGATRANS-3M");
        map.Add("cm-1", "Чтобы открыть справку по аппаратуре цифровой системы передачи ЦМ-Е1");
        map.Add("cm-2", "Чтобы открыть справку по аппаратуре цифровой системы передачи ЦМ-Е1");
        map.Add("NetXpert", "Чтобы открыть справку по коммутатору локальной сети NetXpert");
        map.Add("NPort", "Чтобы открыть справку по преобразователю NPort");
        map.Add("skm", "Чтобы открыть справку по мобильному кроссовому cтативу");
        map.Add("skm2", "Чтобы открыть справку по мобильному кроссовому cтативу");
        map.Add("AFK3", "Чтобы открыть справку по анализатору первичного сетевого стыка");
        map.Add("pk1", "Чтобы открыть справку по панельной ЭВМ");
        map.Add("pk2", "Чтобы открыть справку по панельной ЭВМ");
        map.Add("pult", "Чтобы открыть справку по пульту антенно-поворотного устройства");
        map.Add("nout", "Чтобы открыть справку по ноутбуку");
        map.Add("telephone", "Чтобы открыть справку по телефону");
        map.Add("pultTel", "Чтобы открыть справку по пульту телефонной связи");
        map.Add("pultTel2", "Чтобы открыть справку по пульту телефонной связи");
        map.Add("grom1", "Чтобы открыть справку по громкоговорящему оборудованию");
        map.Add("grom2", "Чтобы открыть справку по громкоговорящему оборудованию");
        map.Add("ismer", "Чтобы открыть справку по измерительному прибору");

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            swithCamera.PauseGame();
            //uiController.PauseGame();
            menu.SetActive(true);
            var allAnims = FindObjectsOfType<Animation>();
            foreach(var anim in allAnims) {
                anim.Stop();
            }
        }
    }
}
