using UnityEngine;
using System.Collections.Generic;

public class ObjectsPrefabsPool : MonoBehaviour
{
    public GameObject prefab;
    private Stack<GameObject> inactivePrefabs = new Stack<GameObject>();

    public GameObject GetObject()
    {
		GameObject prefabInstance;

		if (inactivePrefabs.Count > 0)
        {
			prefabInstance = inactivePrefabs.Pop();
        }
        else
        {
			prefabInstance = (GameObject)GameObject.Instantiate(prefab);

			PooledObject pooledObject = prefabInstance.AddComponent<PooledObject>();
            pooledObject.pool = this;
        }

		prefabInstance.SetActive(true);
		return prefabInstance;
    }

    public void ReturnPrefabInstance(GameObject returnedPrefab)
    {
		PooledObject pooledObject = returnedPrefab.GetComponent<PooledObject>();

        if (pooledObject != null && pooledObject.pool == this)
        {
			returnedPrefab.SetActive(false);
			inactivePrefabs.Push(returnedPrefab);
        }
        else
        {
			Destroy(returnedPrefab);
        }
    }
}

public class PooledObject : MonoBehaviour
{
	public ObjectsPrefabsPool pool;
}