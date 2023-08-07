using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    [SerializeField]
    public ItemGenerator itemGenerator;
    [SerializeField]
    private List<GameObject> basketPrefabs;

    private BasketController basketController;
    // Start is called before the first frame update
    void Start()
    {
        var director = GameObject.Find("GameDirector");
        Debug.LogFormat("director: <color=yellow>{0}</color>", director);
        this.CreateBasket();
    }

    private void CreateBasket()
    {
        Debug.Log("CreateBasket");
        GameObject prefab = this.basketPrefabs[InfoManager.instance.selectedBasketType];
        GameObject basketGo = Instantiate(prefab);
        basketGo.transform.position = Vector3.zero;

        Debug.LogFormat("<color=red>basketGo.transform.position: {0}</color>", basketGo.transform.position);
        this.basketController = basketGo.GetComponent<BasketController>();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
