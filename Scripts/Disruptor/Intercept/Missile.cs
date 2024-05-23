using UnityEngine;

public abstract class Missile : MonoBehaviour
{
    // 미사일의 성격 작동 발사 착탄

    public abstract void Launch();

    protected abstract void GetTarget();
    

    void Hit()
    {
        // 충돌하면 미사일에 맞는 효과를 발생시킴. 이는 자식클래스에서 효과를 구현.
    }

   

}
