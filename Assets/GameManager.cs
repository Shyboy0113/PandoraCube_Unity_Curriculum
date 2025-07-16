using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 1. 자기 자신 타입의 static 변수를 선언합니다. 이것이 바로 전역 접근점입니다.
    public static GameManager Instance { get; private set; }

    // 게임 데이터 예시
    public int score;

    // 2. 게임이 시작될 때 Awake() 함수가 가장 먼저 호출됩니다.
    private void Awake()
    {
        // 3. Instance가 아직 할당되지 않았다면 (최초의 인스턴스라면)
        if (Instance == null)
        {
            // 이 인스턴스를 전역 접근점인 Instance에 할당합니다.
            Instance = this;

            // (선택) 씬이 바뀌어도 이 게임 오브젝트가 파괴되지 않게 합니다.
            DontDestroyOnLoad(gameObject);
        }
        // 4. 만약 Instance에 이미 다른 값이 할당되어 있다면 (중복된 인스턴스라면)
        else
        {
            // 새로 생성된 자기 자신을 파괴하여 유일성을 보장합니다.
            Destroy(gameObject);
        }
    }

    // 이제 다른 스크립트에서 GameManager.Instance.AddScore(10); 와 같이 쉽게 접근 가능
    public void AddScore(int newScore)
    {
        score += newScore;
    }
}