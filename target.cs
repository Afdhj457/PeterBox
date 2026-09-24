using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [Header("生成设置")]
    public GameObject prefab;        // 拖入预制体（可选）
    public Transform spawnPoint;     // 生成位置（可选）
    public float spawnInterval = 1f; // 生成间隔

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObject();
        }
    }

    public void SpawnObject()
    {
        // 决定生成位置
        Vector3 pos = spawnPoint != null
            ? spawnPoint.position
            : transform.position + transform.forward * 2f;

        GameObject obj;

        if (prefab != null)
        {
            // ✅ 推荐：用预制体实例化
            obj = Instantiate(prefab, pos, Quaternion.identity);
        }
        else
        {
            // 从零创建一个基础物体
            obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = pos;
        }

        // 命名并组织层级
        obj.name = "Spawned_" + Time.frameCount;
        obj.transform.SetParent(transform);

        // 加个颜色区分
        var renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
            renderer.material.color = Random.ColorHSV();

        Debug.Log($"创建了对象：{obj.name}");
    }
}