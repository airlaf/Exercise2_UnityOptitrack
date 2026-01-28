using UnityEngine;

public class BallCollect : MonoBehaviour
{
    [Header("Collection Settings")]
    [Tooltip("The name of the object that can collect this sphere (e.g., 'BlueCube')")]
    public string collectorName = "BlueCube";
    
    [Tooltip("The distance at which the sphere will be collected")]
    public float collectDistance = 2.0f;
    
    private GameObject collector;
    private bool isCollected = false;

    void Start()
    {
        // Find the collector object by name
        collector = GameObject.Find(collectorName);
        
        if (collector == null)
        {
            Debug.LogWarning($"BallCollect: Could not find object named '{collectorName}'. Make sure the name matches exactly.");
        }
    }

    void Update()
    {
        // Only check if not already collected and collector exists
        if (!isCollected && collector != null)
        {
            // Calculate distance between this sphere and the collector
            float distance = Vector3.Distance(transform.position, collector.transform.position);
            
            // If within collection distance, collect the sphere
            if (distance <= collectDistance)
            {
                CollectSphere();
            }
        }
    }

    void CollectSphere()
    {
        isCollected = true;
        
        // Make the sphere disappear (deactivate instead of destroy to allow re-enabling if needed)
        gameObject.SetActive(false);
        
        Debug.Log($"Sphere '{gameObject.name}' collected by '{collectorName}'!");
    }
    
    // Optional: Visualize the collection radius in the editor
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, collectDistance);
    }
}
