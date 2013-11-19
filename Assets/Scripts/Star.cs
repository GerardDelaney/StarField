using UnityEngine;
using System.Collections;

public class Star : MonoBehaviour {

    private Vector3 target;
    private bool isMoving = false;
    private float speed;

	void Update () {
        if (isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);

            if (transform.position == target) {
                isMoving = false;
            }
        }
	}

    public Star Generate() {
        SetTargetPosition();
        SetSpeed();

        return this;
    }

    private void SetTargetPosition() {
        target = Camera.main.transform.position;
        target.x += Random.Range(-100f, 100f);
        target.y += Random.Range(-100f, 100f);
        target.z -= 100f;
    }

    public void SetSpeed() {
        speed = Random.Range(25f, 75f);
    }

    public void Launch() {
        isMoving = true;
        transform.LookAt(Camera.main.transform.position);
    }
}
