using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI pointText;
    [SerializeField] private TextMeshProUGUI pointTextGameOver;

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "0";
        pointTextGameOver.text = "0";
    }

    public void IncrementPoints()
    {
        var point = int.Parse(pointText.text) + 1;
        pointText.text = point.ToString();
        pointTextGameOver.text = pointText.text;
    }
}
