using System.Collections.Generic;
using System.Linq;
using Unity.Burst.Intrinsics;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowPool:MonoBehaviour
{
    public GameObject arrow;
    public int poolSize = 5;
    private List<GameObject> arrows;

    private void Start()
    {
        arrows = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject arr = Instantiate(arrow);
            arr.SetActive(false);
            arrows.Add(arr);
            Destroy(arr,15f);
        }
    }
    public GameObject getArrow()
    {
        foreach(GameObject arr in arrows)
        {
            if (!arr.IsDestroyed() && !arr.activeInHierarchy)
            {
                return arr;
            }
        }
        // Optionally, expand the pool if needed
        GameObject newArrow = Instantiate(arrow);
        newArrow.SetActive(false);
        arrows.Add(newArrow);
        Destroy(newArrow, 15f);

        //Destroy(arrows[0]);
        //arrows.RemoveAt(0);
        return newArrow;
    }
}