using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Catch : MonoBehaviour
{
    public new Camera camera;

    public int PScore = 3;             // Plus Tag 점수 할당
    public int MScore = -5;            // Minus Tag 점수 할당

    public GameObject PEffect;         // Plus Tag 파괴효과
    public GameObject MEffect;         // Minus Tag 파괴효과

    public AudioSource PAudio;         // Plus Tag 효과음
    public AudioSource MAudio;         // Minus Tag 효과	

    GameManager gameManager;        // 게임 매니저
    RaycastHit hit;                 // 레이 캐스트 충돌 정보 저장

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void CatchTrash()
    {
        RaycastHit hit;
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {

            // 분리배출쓰레기를 잡았을 때
            if (hit.transform.tag == "Plus")
            {
                Destroy(hit.transform.gameObject);

                // 파괴효과
                if (PEffect != null)
                    Instantiate(PEffect, hit.point, Quaternion.LookRotation(hit.normal));

                if (PAudio != null) PAudio.Play();

                // 점수 추가
                gameManager.AddScore(PScore);
            }

            // 일반쓰레기를 잡았을 때
            else if (hit.transform.tag == "Minus")
            {
                Destroy(hit.transform.gameObject);

                // 파괴효과
                if (MEffect != null)
                    Instantiate(MEffect, hit.point, Quaternion.LookRotation(hit.normal));

                if (MAudio != null) MAudio.Play();

                // 점수 감점
                gameManager.AddScore(MScore);
            }
        }
    }

    void Update()
    {
        // 터치 이벤트 감지
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            // 터치 상태 시작 or 지속 중일 때
            if (touch.phase == TouchPhase.Began)
            {
                CatchTrash();
            }
        }
    }
}
