
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private float _bounceForce;
    [SerializeField] private float _bounceRadius;

    public void Breake()
    {
        PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

        foreach(PlatformSegment segment in platformSegments)
        {
            segment.Bounce(_bounceForce, transform.position, _bounceRadius);
            segment.gameObject.layer = LayerMask.NameToLayer("Trash");
        }
    }
}
