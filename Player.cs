using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed;
    public float rotateAmount;
    float rot;
    int score;
    public GameObject winText;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if (Input.GetMouseButton(0)) {

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (mousePos.x < 0) {
                rot = rotateAmount;
            } else {
                rot = -rotateAmount;
            }

            transform.Rotate(0, 0, rot);
        }
    }

    void FixedUpdate()
    {
        rb.velocity = transform.up * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Food") {
            Destroy(other.gameObject);
            score++;

            if (score >= 5) {
                Debug.Log("Level1 completed");
                winText.SetActive(true);
            }

        } else if (other.gameObject.tag == "Danger") {
            SceneManager.LoadScene("Game");
        }
    }
}
