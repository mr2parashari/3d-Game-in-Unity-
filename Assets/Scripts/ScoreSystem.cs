using UnityEngine;
using TMPro;

public class CollisionScoreHandler : MonoBehaviour
{
    public int score = 10;
    public TextMeshProUGUI scoreText;
    public GameObject gameOverPanel;
    public AudioSource audioSource;
    public AudioClip cubeClip;
    public AudioClip sphereClip;
    public AudioClip capsuleClip;
    public AudioClip cylinderClip;
    private int totalObjectsToCollide = 8;
    private int collidedCount = 0;

    void Start()
    {
        UpdateScoreUI();
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (!IsBlueTag(tag) && !IsRedTag(tag)) return;

        // Prevent multiple collisions
        other.gameObject.tag = "Untagged";
        collidedCount++;
        if (IsBlueTag(tag))
        {
            score += 10;  // increasing when blue 
        }
        else if (IsRedTag(tag))
        {
            score -= 5;  // decreasing when red
        }

        PlayObjectSound(tag);
        UpdateScoreUI();

        Destroy(other.gameObject,2f); //  Remove object after collision 2f delay

        if (collidedCount >= totalObjectsToCollide)
        {
            if (gameOverPanel != null)
                gameOverPanel.SetActive(true);
        }
    }

    void PlayObjectSound(string tag)
    {
        if (audioSource == null)
        {
            Debug.LogWarning("AudioSource not assigned.");
            return;
        }
        Debug.Log("Playing sound for tag: " + tag);
        // checking  tags logic for sound 
        if (tag.Contains("Cube") && cubeClip != null)
            audioSource.PlayOneShot(cubeClip);
        else if (tag.Contains("Sphere") && sphereClip != null)
            audioSource.PlayOneShot(sphereClip);
        else if (tag.Contains("Capsule") && capsuleClip != null)
            audioSource.PlayOneShot(capsuleClip);
        else if (tag.Contains("Cylinder") && cylinderClip != null)
            audioSource.PlayOneShot(cylinderClip);
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    bool IsBlueTag(string tag)
    {   // checking  tags logic blue 
        return tag == "BlueCube" || tag == "BlueSphere" ||
               tag == "BlueCapsule" || tag == "BlueCylinder";
    }

    bool IsRedTag(string tag)
    {      // checking  tags logic red
        return tag == "RedCube" || tag == "RedSphere" ||
               tag == "RedCapsule" || tag == "RedCylinder";
    }
}
