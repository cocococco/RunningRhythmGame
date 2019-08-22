using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleAutoDie : MonoBehaviour
{
    private ObjectPool inst_ObjectPool;
    private string poolItemName;

    private void Start()
    {
        inst_ObjectPool = ObjectPool.GetInstance();
        if (gameObject.name == "MonsterDieFX")
        {
            poolItemName = "MonsterDieFX";
        }
        else
        {
            poolItemName = "ItemFX";
        }
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
        inst_ObjectPool.PushToPool(poolItemName, this.gameObject);
    }
}