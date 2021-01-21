using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    Rigidbody2D reaper;
    int score = 0;
    bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        reaper = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !dead)
        {
            reaper.velocity = new Vector2(0,8.5f);
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void OnCollisionEnter2D()
    {
        dead = true;
        score = 0;
        scoreText.text = "0";
    }
    void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.tag == "PointTrigger")
        {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
