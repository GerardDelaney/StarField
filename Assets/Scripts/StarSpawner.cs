using UnityEngine;
using System.Collections;

public class StarSpawner : MonoBehaviour {

    public Star[] starPrefabs;
    public int starCount;

    private Screenshooter shooter;
    private Star[] stars;
    private int prefabCount;

    void Start() {
        shooter = FindObjectOfType(typeof(Screenshooter)) as Screenshooter;

        prefabCount = starPrefabs.Length;
        GenerateStars();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            LaunchStars();
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            Reset();
        }
    }

    private void Reset() {
        shooter.Deactivate();
        DestroyStars();
        GenerateStars();
    }

    private void DestroyStars() {
        for (int i = 0; i < starCount; i++) {
            Destroy(stars[i].gameObject);
        }
    }

    private void GenerateStars() {
        stars = new Star[starCount];
        for (int i = 0; i < starCount; i++) {
            Star starPrefab = starPrefabs[Random.Range(0, prefabCount - 1)];
            stars[i] = (Instantiate(starPrefab, transform.position, new Quaternion()) as Star).Generate();
        }
    }

    private void LaunchStars() {
        shooter.Activate();
        for (int i = 0; i < starCount; i++) {
            stars[i].Launch();
        }
    }
}
