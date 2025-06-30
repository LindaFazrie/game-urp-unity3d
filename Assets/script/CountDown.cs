using System.Collections;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    public float Waktu = 60;
    public TMP_Text CountDownText;
    public bool isTimeOut = false; // Penanda waktu habis

    private void Start()
    {
        StartCoroutine(Mulai());
    }

    private IEnumerator Mulai()
    {
        while (Waktu > 0)
        {
            CountDownText.text = Mathf.Ceil(Waktu).ToString();
            yield return new WaitForSeconds(1f);
            Waktu--;
        }

        isTimeOut = true; // Waktu habis
    }
}
