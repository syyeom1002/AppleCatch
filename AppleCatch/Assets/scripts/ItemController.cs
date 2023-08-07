using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
    [SerializeField]
    public float moveSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //translate는 기본이 로컬좌표로 이동이다
        this.transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);//(0,-1,0)
        if (this.transform.position.y <= 0)
        {
            Destroy(this.gameObject);//Destroy(this)는 완전히 다른의미이다.
        }
    }
}
