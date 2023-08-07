using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private float elasedTime;//경과시간
    private float spawnTime = 1f; //1초에 한번씩
    public GameObject applePrefab;
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //시간 재기
        //변수에 Time.deltaTime을 더해라
        this.elasedTime += Time.deltaTime;
        if (this.elasedTime >= this.spawnTime)
        {
            this.CreateItem();
            //초기화
            this.elasedTime = 0;
        }

    }
    private void CreateItem()
    {
        //사과 똫는 폭탄
        int rand=Random.Range(0, 11);// 1~10사과가 나오는 횟수를 더 늘리고싶음
        GameObject itemGo = null;
        if (rand>3)
        {
            itemGo= Instantiate<GameObject>(this.applePrefab);
        }
        else 
        {
            itemGo= Instantiate<GameObject>(this.bombPrefab);
        }
        //위치설정
        //x:-1,1
        //Z:-1,1
        int x= Random.Range(-1, 2);//-1,0,1
        int z = Random.Range(-1, 2);
        itemGo.transform.position=new Vector3(x, 3.5f, z);
    }
}
