using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    private float elasedTime;//����ð�
    private float spawnTime = 1f; //1�ʿ� �ѹ���
    public GameObject applePrefab;
    public GameObject bombPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //�ð� ���
        //������ Time.deltaTime�� ���ض�
        this.elasedTime += Time.deltaTime;
        if (this.elasedTime >= this.spawnTime)
        {
            this.CreateItem();
            //�ʱ�ȭ
            this.elasedTime = 0;
        }

    }
    private void CreateItem()
    {
        //��� �m�� ��ź
        int rand=Random.Range(0, 11);// 1~10����� ������ Ƚ���� �� �ø������
        GameObject itemGo = null;
        if (rand>3)
        {
            itemGo= Instantiate<GameObject>(this.applePrefab);
        }
        else 
        {
            itemGo= Instantiate<GameObject>(this.bombPrefab);
        }
        //��ġ����
        //x:-1,1
        //Z:-1,1
        int x= Random.Range(-1, 2);//-1,0,1
        int z = Random.Range(-1, 2);
        itemGo.transform.position=new Vector3(x, 3.5f, z);
    }
}
