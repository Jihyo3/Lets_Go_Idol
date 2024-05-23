using UnityEngine;

public class Ladar : MonoBehaviour
{
    // 주변탐색, 가까운 오브젝트 판단을 담당하는 클래스

    Vector2 originPos;  // 탐색 원점
    float searchRadius;
    int targetLayerMask;
    Collider2D[] searchColliders;


    // 원점 _originPos와 _searchRadius의 반지름을 가진 원의 범위에서 _targetLayerMask를 가진 GameObject를 반환하는 메서드.
    public GameObject SearchClosestColliderInCircle(Vector2 _originPos, float _searchRadius, int _targetLayerMask)
    {
        GameObject closestObject = null;
        float closestDistance = Mathf.Infinity;

        searchColliders = Physics2D.OverlapCircleAll(_originPos, _searchRadius, _targetLayerMask);
        Debug.Log(searchColliders.Length);
        // 검색된 searchColliders의 거리 계산
        foreach(Collider2D collider in searchColliders)
        {
            float distance = Vector2.Distance(originPos, collider.transform.position);
            if ( distance < closestDistance ) 
            {
                closestDistance = distance;
                closestObject = collider.gameObject;
            }
        }
        return closestObject;
    }

    public Vector2 GetDirection(Vector2 _targetPos, Vector2 _originPos)
    {
        Vector2 direction_originTo_target = (_targetPos - _originPos).normalized;       
        return direction_originTo_target;
    }


   
}
