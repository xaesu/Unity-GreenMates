using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public List<Transform> LPos = new List<Transform>();
    public List<GameObject> LPrefab = new List<GameObject>();

    //public new AudioSource audio;

    void Start()
    {
        StartCoroutine(WaitAndSpawn());
    }

    IEnumerator WaitAndSpawn()
    {
        while (true)
        {
            // 대기 시간 랜덤 설정
            float waitTime = Random.Range(2.0f, 4.0f);

            // 코루틴 시간 지연
            yield return new WaitForSeconds(waitTime);

            for (int i = 0; i < 3; i++)
            {
                // 랜덤 위치, 프리팹 설정
                int iPos = Random.Range(0, LPos.Count);
                int iPrefab = Random.Range(0, LPrefab.Count);

                // 랜덤 위치, 프리팹을 사용해 게임 오브젝트 생성
                GameObject Obj = Instantiate(LPrefab[iPrefab], LPos[iPos].position, Quaternion.identity);

                // 5초 후 게임 오브젝트 파괴
                Destroy(Obj, 5f);

                // 생성된 오브젝트가 위를 향해 이동
                Rigidbody Rb = Obj.GetComponent<Rigidbody>();
                Rb.AddForce(Vector3.up * Random.Range(4.0f, 10.0f), ForceMode.VelocityChange);
            }

            
        }
    }

    void Update()
    {
        
    }
}
