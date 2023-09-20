using UnityEngine;

public class grabAmmo : MonoBehaviour
{
    public GameObject Object;
    public Gun g;

    private void Start()
    {
        g = GetComponent<Gun>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Object)
        {
            gameObject.SetActive(false);
            g.currentAmmo += 25;
        }
    }
}
