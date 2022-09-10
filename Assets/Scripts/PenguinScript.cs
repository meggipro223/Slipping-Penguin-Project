using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PenguinScript : MonoBehaviour
{

    private Rigidbody2D myBody;
    private int forceX, forceX2, forceY, forceY2;
    private Animator myAnim;
    private AudioSource explosionSound;

    public Text scoreText;
    public Text numberText;
    public AudioClip kickSound;
    private int score;

 
    // Use this for initialization
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();

        forceX = -1200;
        forceX2 = -1500;

        forceY = 300;
        forceY2 = 270;
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("CheckingScore", 0.1f);
        StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame()
    {
        if (myBody.IsSleeping())
        {
            ScrollingBG.instance.isScrolling = false;
            myAnim.SetBool("PenguinDied", true);

            yield return new WaitForSeconds(2.5f);

            Destroy(gameObject);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void CheckingScore()
    {
        Vector3 temp = transform.position;

        if(temp.x < 4.7f)
        {
            if (!myBody.IsSleeping())
            {
                if (PlayerPrefs.GetInt("highscoreNumber") < score)
                    PlayerPrefs.SetInt("highscoreNumber", score);

                score++;
                scoreText.text = score + " M";
            }

            if (myBody.IsSleeping())
            {
                ScrollingBG.instance.isScrolling = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int RandomizeX = Random.Range(forceX, forceX2);
        int RandomizeY = Random.Range(forceY, forceY2);

        if(collision.tag == "mace")
        {
            ScrollingBG.instance.isScrolling = true;

            AudioSource.PlayClipAtPoint(kickSound, transform.position);

            myBody.velocity = new Vector2(0f, 0f);
            myBody.AddForce(new Vector2(RandomizeX, RandomizeY));

            numberText.text = "" + RandomizeX.ToString() + " F";

            if(RandomizeX <= -1200)
            {
                myBody.MoveRotation(183f);
            }


        }

        if(collision.tag == "Bomb")
        {
            int randomize2X = Random.Range(-25, -40);
            int randomize2Y = Random.Range(155, 175);

            explosionSound.Play();

            myBody.AddForce(new Vector2(randomize2X, randomize2Y));
            collision.gameObject.SetActive(false);
        }
    }

}