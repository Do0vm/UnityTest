using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class ProgressBar: MonoBehaviour
{

    [SerializeField] GameObject playerGO;
    [SerializeField] GameObject finishGO;
    Image progressBar;
    float maxDistance;
    void Start()
    {

        progressBar = GetComponent<Image>();
        maxDistance = finishGO.transform.position.x;
    }

    void Update()
    {

        if (progressBar.fillAmount < 1)
        {

            progressBar.fillAmount = playerGO.transform.position.x / maxDistance;
        }
    }

}