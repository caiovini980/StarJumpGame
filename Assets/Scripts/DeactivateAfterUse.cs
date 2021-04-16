using System.Collections;
using UnityEngine;

public class DeactivateAfterUse : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitToDeactivate(0.5f));
    }

    IEnumerator WaitToDeactivate(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
