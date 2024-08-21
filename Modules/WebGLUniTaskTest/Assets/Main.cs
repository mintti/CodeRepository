using System.Diagnostics;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Debug = UnityEngine.Debug;

public class Main : MonoBehaviour
{
    public InfiniteRotate Rotate;
    public InfiniteRotate Rotate2;
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
        
        Rotate2.Run();
        await BusyWait(5);
        
        // Thread.Sleep(5000); // 동기로 대기 (프리징) // Web GL 지원 안함 
        Debug.Log("Thread Sleep 5초가 지남"); 
        return true;
    }
    
    async UniTask BusyWait(float seconds)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        while (stopwatch.Elapsed.TotalSeconds < seconds)
        {
            // 계속 루프를 돌면서 시간을 확인
            await UniTask.Yield(); // yield return null 같은 존재로 없을 경우, 멈춤
        }

        stopwatch.Stop();
    }
}
