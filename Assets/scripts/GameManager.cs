using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    public movement player;
    // Start is called before the first frame update

    [Header("Canvas")]
    [SerializeField] Canvas GameCanvas;
    [SerializeField] Canvas worlCanvas;

    [Header("Text Components")]
    [SerializeField] TextMeshProUGUI winText;
    [SerializeField] TextMeshProUGUI loseText;

        public void Update()
        {
            if (player.health <= 0)
            {
                //DestroyAllEnemies();
                GameCanvas.gameObject.SetActive(false);
                worlCanvas.gameObject.SetActive(true);
                loseText.gameObject.SetActive(true);
                winText.gameObject.SetActive(false);
            }


            // Check if there are no objects with the specified tag
            if (player.health > 0 && player.gems == 5)
            {
                GameCanvas.gameObject.SetActive(false);
                worlCanvas.gameObject.SetActive(true);
                winText.gameObject.SetActive(true);
                loseText.gameObject.SetActive(false);

            }
        }
}

