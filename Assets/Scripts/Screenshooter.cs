using UnityEngine;
using System.Collections;

public class Screenshooter : MonoBehaviour {

    private int count = 0;
    private int cycle = 0;
    public float delay = 0.1f;

    public void Activate() {
        StartCoroutine(ShotLoop());
    }

    public void Deactivate() {
        cycle++;
        StopAllCoroutines();
    }

    private IEnumerator ShotLoop() {
        Application.CaptureScreenshot(cycle + "_" + count + "screenshot.png");
        count++;
        yield return new WaitForSeconds(delay);

        StartCoroutine(ShotLoop());
    }
}
