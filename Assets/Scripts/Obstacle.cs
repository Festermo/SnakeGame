using UnityEngine.SceneManagement;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Head") //if head hits the obstacle
        {
            if (collision.gameObject.GetComponent<Snake>().inFever == false)
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            else
                Destroy(gameObject);
        }
    }
}
