using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{
   public float delayTime = 0.5f;
   public AudioClip explosion;
   public AudioClip success;

   AudioSource audioSource;

   public ParticleSystem explosionParticles;
   public ParticleSystem successParticles;
   

   bool isTransitioning = false;

   void Start() 
   {
    audioSource = GetComponent<AudioSource>();
   }
    void OnCollisionEnter(Collision other) 
    {

        if (isTransitioning)
        {
            return;
        }

        switch (other.gameObject.tag)
        {
            case "Finish":
                Debug.Log("You Finished!");
                StartSuccessSequence();
                break;
            case "Friendly":
                Debug.Log("This thing is Friendly");
                break;
            default:
                Debug.Log("You Exploded");
                StartCrashSequence();
                break;
        }
    }

    void StartSuccessSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(success);
        successParticles.Play();
        Invoke("LoadNextLevel",delayTime);
    }

    void StartCrashSequence()
    {
        isTransitioning = true;
        audioSource.Stop();
        GetComponent<Movement>().enabled = false;
        audioSource.PlayOneShot(explosion);
        explosionParticles.Play();
        Invoke("ReloadLevel",delayTime);
    }
    void ReloadLevel()
    {   
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentIndex);
    }

    void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;
        if (nextIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextIndex = 0;
        }
        SceneManager.LoadScene(nextIndex);
        
    }
}
