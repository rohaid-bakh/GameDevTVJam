using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    [SerializeField] private float timeBeforeLoading = 1f;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(WaitBeforeExitingLevel());
        }
    }

    IEnumerator WaitBeforeExitingLevel()
    {
        yield return new WaitForSeconds(timeBeforeLoading);
        SceneManager.LoadScene("Win");
    }
}
