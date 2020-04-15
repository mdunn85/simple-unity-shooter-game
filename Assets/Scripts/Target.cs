using UnityEngine;

namespace Scripts
{
    public class Target : MonoBehaviour
    {
        public GameManager gameManager;

        // Start is called before the first frame update
        void Start()
        {
            gameManager = GameObject.Find(nameof(GameManager)).GetComponent<GameManager>();
            //Destroy(gameObject, 2f);
        }

        // Update is called once per frame
        void Update()
        {
        }

        private void OnMouseDown()
        {
            gameManager.IncrementScore();
            Destroy(gameObject);
        }
    }
}