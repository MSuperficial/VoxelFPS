using System.Linq;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
    public GameObject enemyType;
    public float interval;
    public float radius;
    public int maxNum;
    public int initialNum;
    public Transform player;
    private Transform trans;
    private float timer = 0f;
    private int currentNum;

    private void Awake() {
        trans = this.transform;
    }
    
    private void Start() {
        for (int i = 0; i < initialNum; i++) {
            Generate();
        }
    }

    private void Update() {
        currentNum = GameObject.FindGameObjectsWithTag(enemyType.tag).Count();
        if(timer >= interval && currentNum < maxNum) {
            Generate();
            timer = 0f;
        }
        timer += Time.deltaTime;
    }

    private void Generate() {
        Vector3 offset = new Vector3(Random.Range(-radius, radius), 0f, Random.Range(-radius, radius));
        Quaternion rotation = Quaternion.Euler(0f, Random.Range(0, 360), 0f);
        GameObject enemy = GameObject.Instantiate(enemyType, trans.position + offset, rotation);
        enemy.GetComponent<Enemy>().player = player;
        if (enemy.GetComponent<Zombie_AI>()) {
            enemy.GetComponent<Zombie_AI>().player = player;
        }
        if (enemy.GetComponent<Spider_AI>()) {
            enemy.GetComponent<Spider_AI>().player = player;
        }
    }
}