using UnityEngine;

public class BoosterController : MonoBehaviour
{
    public static BoosterController Instance;

    [SerializeField] bool _canApplyBooster;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
    }
    private void Start()
    {
        BoosterBase.OnBoosterCollided += InstantiateNewBooster;
    }

    private void OnDestroy()
    {
        BoosterBase.OnBoosterCollided -= InstantiateNewBooster;
    }

    private void InstantiateNewBooster(BoosterBase booster, Collider collider)
    {
        if (!_canApplyBooster)
            return;
        if (collider.GetComponent<Player>() == null)
            return;

        var player = collider.gameObject.GetComponent<Player>();
        booster.OnBoosterActivated(player);

        GameObject newBooster = Instantiate(booster.gameObject, new Vector3(Random.Range(-180f, 55f), 5, Random.Range(-33f, 215f)), Quaternion.identity);
        Destroy(booster.gameObject);
    }
}
