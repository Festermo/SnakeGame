using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Mouth : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject snake;

    private IEnumerator SoakFood(GameObject food)
    {
        while (food != null && food.transform.position.z > transform.position.z)
        {
            food.transform.position -=  new Vector3(0, 0, 0.1f);
            yield return new WaitForSeconds(0.01f);
        }
        Destroy(food);
        snake.GetComponent<Tail>().AddPart();
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Crystal")
        {
            Destroy(collision.gameObject);
            gameManager.EatCrystal();
        }
        if (collision.collider.tag == "Food")
        {
            if (snake.GetComponent<Snake>().inFever == true || //if in fever
            snake.gameObject.GetComponent<MeshRenderer>().material.color == collision.gameObject.GetComponent<MeshRenderer>().material.color) //or if the same color
            {
                gameManager.increaseFoodScore();
                StartCoroutine(SoakFood(collision.gameObject));
            }
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); //wrong color
        }
        if (collision.collider.tag == "Changer") //change color of whole snake
        {
            snake.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<MeshRenderer>().material;
            for (int i = 0; i < snake.GetComponent<Tail>().snakeParts.Count; i++)
            {
                snake.GetComponent<Tail>().snakeParts[i].gameObject.GetComponent<MeshRenderer>().material = collision.gameObject.GetComponent<MeshRenderer>().material;
            }
        }
        if (collision.collider.tag == "End")
            gameManager.ShowEndPanel();
    }
}
