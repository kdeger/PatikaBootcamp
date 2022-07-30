using UnityEngine;

public class TransformMover : IMover
{
    private Player _player;
    public TransformMover(Player player)
    {
        _player = player;
    }

    public void Tick()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        _player.transform.position +=  new Vector3(horizontal, 0, vertical);
    }
}
