using UnityEngine;

public class MushroomJumpPad : MonoBehaviour
{
    public float jumpForce = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                Debug.Log("Player launched by jump pad!");
            }
        }
    }
}
