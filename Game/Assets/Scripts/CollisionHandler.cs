using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
    
    void OnCollisionEnter(Collision other) 
    {

        

        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You Finished!");
                LoadNextLevel();
                break;
            case "Friendly":
                Debug.Log("This thing is Friendly");
                break;
            default:
                Debug.Log("You Exploded");
                ReloadLevel();
                break;
        }
    }

    void ReloadLevel()
    {   
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex + 1);
    }
}
