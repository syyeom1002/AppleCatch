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
        //���콺 ���� Ŭ���ϸ� ȭ���� Ŭ���ϸ� 
        //ray�� ������ 
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            float maxDistance = 10f;
            Debug.DrawRay(ray.origin, ray.direction* maxDistance, Color.green, 1f);
            //out�Ű������� ����Ϸ��� ���� ���Ǹ��� ���� �ؾ��Ѵ�.
            RaycastHit hit;
            //outŰ���带 ����ؤä� ���ڷ� �־��
            //Raycast �޼��忡�� ����� ����� hit�� �־���
            if(Physics.Raycast(ray, out hit, maxDistance))
            {
                Debug.Log(hit.point);
                //�ٱ��� ��ġ�� �浹�� �������� �̵� 
                // this.gameObject.transform.position = hit.point;
                //x,z ��ǥ�� �ݿø�
                float x = Mathf.RoundToInt(hit.point.x);
                float z = Mathf.RoundToInt(hit.point.z);
                //���ο� ��ǥ�� �����
                this.transform.position=new Vector3(x, 0, z);
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.tag);
        if (other.tag == "apple")
        {
            Debug.Log("�����߰�");
            this.audioSource.PlayOneShot(this.appleSfx);
            this.gameDirector.IncreaseScore(100);
        }
        else
        {
            Debug.Log("����");
            this.audioSource.PlayOneShot(this.bombSfx);
            this.gameDirector.DecreaseScore(50);
        }
        this.gameDirector.UpdateScoreUI();
        Destroy(other.gameObject);
    }
}
