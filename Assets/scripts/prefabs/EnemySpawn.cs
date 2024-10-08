using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //[SerializeField]
    //GameObject prefabs;
    [SerializeField]
    List<GameObject> listPrefabs;
    [SerializeField]
    int period;

    [SerializeField]
    List<int> spawnRates;

    [SerializeField]
    int maxCount; //pool size

    [SerializeField]
    bool enableExtend;

    [SerializeField]
    Vector3 defaultPosition;

    [SerializeField]
    Transform leftPosition;

    [SerializeField]
    Transform rightPosition;

    float time;

    List<GameObject> enemyPool;

    private int currentCount;

    public int CurrentCount
    {
        get { return currentCount; }
        set { currentCount = value; }
    }

    private int RandomType(params int[] args)
    {
        if (args.Length >1)
        {
            int number = Random.Range(0, 100);
            int start = 0, count = 0;
            foreach (int n in args)
            {
                if (number <= start + n)
                {
                    return count;
                } else
                {
                    start += n;
                    count++;
                }
            }
        }
        return 0;
    }

    // Start is called before the first frame update
    void Start()
    {
        time = 0;
        currentCount = 0;
        //Khoi tao pool
        enemyPool = new List<GameObject>();
        //Tao san enemy trong pool
        for (int i = 0; i < maxCount*listPrefabs.Count; i++)
        {
            int n = i/maxCount;
            AddToPool(listPrefabs[n]);
        }
    }
     
    private GameObject AddToPool(GameObject prefabs)
    {
        GameObject newEnemy = Instantiate(prefabs);
        newEnemy.SetActive(false);
        enemyPool.Add(newEnemy);
        return newEnemy;
    }
    private GameObject GetFreeEnemy()
    {
        //int[] rates;
        //foreach(GameObject gameObj in listPrefabs)
        //{
            
        //}
        int type = RandomType(spawnRates.ToArray());

        for (int i = type * maxCount; i < (type + 1) * maxCount; i++)
        {
            if (enemyPool[i]!=null && enemyPool[i].activeSelf == false)
            {
                return enemyPool[i];
            }
        }
        //foreach (GameObject newEnemy in enemyPool)
        //{
        //    if (newEnemy.activeSelf == false)
        //    {
        //        return newEnemy;
        //    }
        //    if (enableExtend)
        //    {
        //        return AddToPool();
        //    }
        //}
        return null;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > period && currentCount < maxCount)
        {
            defaultPosition = leftPosition.position;
            defaultPosition.x = Random.Range(leftPosition.position.x + 0.5f, rightPosition.position.x - 0.5f);
            GameObject newEnemy = GetFreeEnemy();
            if (newEnemy != null)
            {
                newEnemy.SetActive(true);
                newEnemy.transform.position = defaultPosition;
                newEnemy.GetComponent<EnemyMovement>().InputScript = this;
                currentCount++;
                time = 0;
            }

        }

    }
}
