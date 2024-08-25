using UnityEngine;

public class BirdShoot : BaseShoot
{
    private KeyCode _keyShoot = KeyCode.G;

    private void Update()
    {
        if (Input.GetKeyDown(_keyShoot))
            Attack();
    }
}
