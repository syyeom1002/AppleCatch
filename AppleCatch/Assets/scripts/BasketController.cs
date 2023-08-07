using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasketController : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip appleSfx;
    [SerializeField]
    private AudioClip bombSfx;

    public GameDirector gameDirector;
    // Start is called before the first frame update
    void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 왼쪽 클릭하면 화면을 클릭하면 
        //ray를 만들자 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float maxDistance = 10f;
            Debug.DrawRay(ray.origin, ray.direction* maxDistance, Color.green, 1f);
            //out매개변수를 사용하려면 변수 정의르르 먼저 해야한다.
            RaycastHit hit;
            //out키워드를 사용해ㅓㅅ 인자로 넣어라
            //Raycast 메서드에서 연산된 결과를 hit에 넣어줌
            if(Physics.Raycast(ray, out hit, maxDistance))
            {
                Debug.Log(hit.point);
                //바구니 위치를 충돌한 지점으로 이동 
                // this.gameObject.transform.position = hit.point;
                //x,z 좌표의 반올림
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                //새로운 좌표를 만든다
                this.transform.position=new Vector3(x, 0, z);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "apple")
        {
            Debug.Log("점수추가");
            this.audioSource.PlayOneShot(this.appleSfx);
            this.gameDirector.IncreaseScore(100);
        }
        else
        {
            Debug.Log("감점");
            this.audioSource.PlayOneShot(this.bombSfx);
            this.gameDirector.DecreaseScore(50);
        }
        this.gameDirector.UpdateScoreUI();
        Destroy(other.gameObject);
    }
}
