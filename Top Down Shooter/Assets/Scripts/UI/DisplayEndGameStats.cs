using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayEndGameStats : MonoBehaviour {

    private TextMeshProUGUI endGameStatsText;

    private void Start()
    {
        endGameStatsText = GetComponent<TextMeshProUGUI>();

        //TODO add stats and score multipliers
    }
}
