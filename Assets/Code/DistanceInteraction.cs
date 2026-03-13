using UnityEngine;

public class RotateTrigger : MonoBehaviour
{
    public GameObject infoText;

    void Start()
    {
        infoText.SetActive(false);
    }

    void Update()
    {
        float yRot = transform.eulerAngles.y;

        if (yRot > 30 && yRot < 330) // simple check
            infoText.SetActive(true);
        else
            infoText.SetActive(false);
    }
}