using UnityEngine;

public class TrackGroundSpawn : MonoBehaviour
{
    [SerializeField]
    private GameObject TrackGround;
    [SerializeField]
    private TrackFiller trackFiller;

    [SerializeField]
    private int countOfTrack;

    private bool isFirstPlay = true;

    void Start()
    {
        PlayController.NewGameEvent += RespawnTrack;
    }

    void FixedUpdate()
    {
        var childCount = transform.childCount;
        if (childCount < countOfTrack)
        {
            GameObject trackToSpawn;
            trackToSpawn = Instantiate(TrackGround);
            trackToSpawn.transform.position = new Vector3(0, 0, childCount * 30);
            trackToSpawn.transform.SetParent(transform, false);
            trackFiller.FillTreack(trackToSpawn.transform);
        }
    }

    private void RespawnTrack()
    {
        if(isFirstPlay) 
        {
            isFirstPlay = false;
            return;
        }

        var childern = transform.GetComponentsInChildren<TrackMove>();
        foreach (var child in childern) 
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < countOfTrack; i++)
        {
            GameObject trackToSpawn;
            trackToSpawn = Instantiate(TrackGround);
            trackToSpawn.transform.position = new Vector3(0, 0, i * 30);
            trackToSpawn.transform.SetParent(transform, false);
            if(i != 0)
                trackFiller.FillTreack(trackToSpawn.transform);
        }
    }
}
