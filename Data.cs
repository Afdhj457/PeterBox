using UnityEngine;

public class PhysicsLoader : MonoBehaviour
{
    [Header("物理设置")]
    public float gravityScale = 1f;      // 重力缩放
    public bool enablePhysics = true;    // 是否启用物理

    private Rigidbody rb;

    void Start()
    {
        // 1. 全局物理设置
        Physics.gravity = new Vector3(0, -9.81f * gravityScale, 0);
        Physics.autoSimulation = enablePhysics;

        // 2. 给当前物体添加刚体组件（加载物理）
        rb = gameObject.GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // 3. 配置刚体参数
        rb.mass = 1f;                          // 质量
        rb.drag = 0.1f;                        // 空气阻力
        rb.angularDrag = 0.05f;                // 角阻力
        rb.useGravity = true;                  // 受重力影响
        rb.isKinematic = false;                // 非运动学（受物理控制）
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous; // 连续碰撞检测

        // 4. 添加碰撞体（如果没有）
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }

        Debug.Log("物理系统已加载");
    }

    void FixedUpdate()
    {
        // 施加一个向前的力（物理更新在 FixedUpdate 中）
        if (rb != null && !rb.isKinematic)
        {
            rb.AddForce(Vector3.forward * 10f, ForceMode.Force);
        }
    }

    // 手动暂停/恢复物理
    public void TogglePhysics(bool on)
    {
        Physics.autoSimulation = on;
        if (rb != null) rb.isKinematic = !on;
    }
}