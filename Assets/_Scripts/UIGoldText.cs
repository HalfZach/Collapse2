using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class UIGoldText : MonoBehaviour
{
    //public string stringText;
    //public Color fontColor;
    private TextMeshProUGUI matchesText;
    

    // Start is called before the first frame update
    void Start()
    {
        matchesText = GetComponent<TextMeshProUGUI>();
        // matchesText.color = fontColor;
    }

    // Update is called once per frame
    void Update()
    {
        matchesText.text = PlayerStats.Instance.Gold.ToString();
    }
}
