using UnityEngine;

public class GerakanPlayer : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * speed * Time.deltaTime;
    }
}
