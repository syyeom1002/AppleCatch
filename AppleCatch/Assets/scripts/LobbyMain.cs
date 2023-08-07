using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BasketsController : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> baskets;

    [SerializeField]
    private Button btnStartGame;
    public GameObject buttonGo;
    // Start is called before the first frame update
    void Start()
    {
        this.btnStartGame.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });
        buttonGo = GameObject.Find("Button");
        buttonGo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float maxDistance = 10f;
            Debug.DrawRay(ray.origin, ray.direction * maxDistance, Color.green, 1f);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxDistance))
            {
               
                
                GameObject foundBasketGo = this.baskets.Find(x => x == hit.collider.gameObject);
                
                buttonGo.SetActive(true);
                //int index = -1;
                //for(int i = 0; i < this.baskets.Count; i++)
                //{
                //    if (foundBasketGo == this.baskets[i])
                //    {
                //        index = i;
                //        break;
                //    }
                //}

                int selectedBasketType = this.baskets.IndexOf(foundBasketGo); //찾아주는 메서드
                InfoManager.instance.selectedBasketType = selectedBasketType;

                foreach(var go in this.baskets)
                {
                    if (go != foundBasketGo)
                    {
                        go.SetActive(false);// 비활성화
                    }
                }
            }
        }
    }
    
}
