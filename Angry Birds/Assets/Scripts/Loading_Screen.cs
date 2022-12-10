using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading_Screen : MonoBehaviour
{

    [SerializeField] public GameObject loadingScreen;

    private void Start()
    {
        StartCoroutine(show());
    }

    IEnumerator show()
    {
        yield return new WaitForSeconds(2f);
        loadingScreen.SetActive(false);
    }
}
