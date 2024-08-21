using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class Main : MonoBehaviour
{
    public InfiniteRotate Rotate;
    // Start is called before the first frame update
    void Start()
    {
        CallType1();
        
        Debug.Log($"Rotate ON");
        Rotate.Run();
    }

    private void CallType1()
    {
        DelayEvent();
    }

    private async void CallType2()
    {
        if (await DelayEvent())
        {
            Debug.Log($"End Delay Event");
        }
    }
    

    async UniTask<bool> DelayEvent()
    {
        await UniTask.Delay(5000); // 비동기로 5초 대기
        Debug.Log("UniTask 5초가 지남");
        
        await UniTask.Yield(); // yield return null 같은 존재  
        
        Thread.Sleep(5000); // 동기로 대기 (프리징) 
        Debug.Log("Thread Sleep 5초가 지남"); 
        return true;
    }
}
