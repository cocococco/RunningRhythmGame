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
        StartCoroutine(Deactivate());
    }

    private IEnumerator Deactivate()
    {
        yield return new WaitForSeconds(1);
        inst_ObjectPool.PushToPool(poolItemName, this.gameObject);
    }
}