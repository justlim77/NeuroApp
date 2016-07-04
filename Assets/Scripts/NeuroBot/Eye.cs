using UnityEngine;

public class Eye : MonoBehaviour
{
    public float defaultDistance = 1.0f;
    public float zoomedDistance = 2.0f;

    public enum DistanceType { Default, Zoom }
    public DistanceType distanceType;

    [SerializeField] float _distance;

    void OnEnable()
    {
        Core.SubscribeEvent("OnToggleCranial", OnToggleCranial);
    }

    void OnDisable()
    {
        Core.UnsubscribeEvent("OnToggleCranial", OnToggleCranial);
    }

    object OnToggleCranial(object sender, object args)
    {
        if (args is float)
        {
            float delta = (float)args;
            _distance = delta;
        }

        return null;
    }

    void Update ()
    {
        //transform.position = Vector2.MoveTowards(transform.position, Input.mousePosition, _distance);
	}

    public void SwitchDistanceType(DistanceType type)
    {
        switch (type)
        {
            case DistanceType.Default:
                _distance = defaultDistance;
                break;
            case DistanceType.Zoom:
                _distance = zoomedDistance;
                break;
        }
    }
}
