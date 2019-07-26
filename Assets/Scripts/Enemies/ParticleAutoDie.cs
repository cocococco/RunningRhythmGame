using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDie : MonoBehaviour
{
    private ObjectPool inst_ObjectPool;
    private const string poolItemName = "MonsterDieFX";

    private void Start()
    {
        inst_ObjectPool = ObjectPool.GetInstance();
    }

    private void Update()
    {
        if (gameObject.activeInHierarchy)
        {
            StartCoroutine(Deactivate());
        }
    }

    public IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("vanish monster die fx");
        inst_ObjectPool.PushToPool(poolItemName, this.gameObject);
    }
}