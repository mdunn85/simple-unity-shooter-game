using System;
using System.Threading.Tasks;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace Scripts
{
    public class GameManager : MonoBehaviour
    {
        public GameObject target;
        public GameObject winText;

        public Text scoreText;

        private int score = 50;
        private bool win = false;
        private bool lose = false;
        private Timer ticker;

        // Start is called before the first frame update
        void Start()
        {
            scoreText.text = score.ToString();
            Spawn();
            InvokeRepeating(nameof(DecreaseScore), 1f, 1f);
            //InvokeRepeating(nameof(Spawn), 1f, 2f);
        }

        // Update is called once per frame
        void Update()
        {
            if (lose || win)
            {
                CancelInvoke(nameof(DecreaseScore));
            }

            if (!win && !lose && Input.GetMouseButtonDown(0))
            {
                GetComponent<AudioSource>().Play();
            }
        }

        void Spawn()
        {
            float randomX = Random.Range(-6f, 6f);
            float randomY = Random.Range(-3f, 3f);

            Vector3 randomPosition = new Vector3(randomX, randomY, 0);

            Instantiate(target, randomPosition, Quaternion.identity);
        }

        public void IncrementScore()
        {
            score += 10;
            scoreText.text = score.ToString();

            if (score > 100)
            {
                win = true;
                winText.SetActive(true);
            }
            else
            {
                Spawn();
            }
        }

        void DecreaseScore()
        {
            if (score <= 0)
            {
                lose = true;
                winText.SetActive(true);
            }
            else
            {
                score--;
                scoreText.text = score.ToString();
            }
        }
    }
}