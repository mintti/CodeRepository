using UnityEngine;

public class InfiniteRotate : MonoBehaviour
{
    private bool _flag;
    public float rotationSpeed = 100f; // 회전 속도를 조절할 수 있는 변수

    public void Run()
    {
        _flag = true;
    }

    public void Update()
    {
        if (_flag)
        {
            // Time.deltaTime을 사용하여 부드러운 회전 구현
            transform.Rotate(new Vector3(0, 0, rotationSpeed * Time.deltaTime));
        }
    }
}
