using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI pointText;

    // Start is called before the first frame update
    void Start()
    {
        pointText.text = "0";
    }

    public void IncrementPoints()
    {
        var point = int.Parse(pointText.text) + 1;
        pointText.text = point.ToString();
    }
}
