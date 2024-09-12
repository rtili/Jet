using System.Collections;
using UnityEngine;

public class ExplosionDisable : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Disable());
    }

    private IEnumerator Disable()
    {
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
