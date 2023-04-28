using UnityEngine;
public class PlayerController : MonoBehaviour
{
    public float axisPositionY;
    private Vector3 _playerPosition;
    public bool player;
    public bool cpu;
    public Transform ballPosition;
    void Start()
    {
        _playerPosition = transform.position;
    }

    void Update()
    {
        _playerPosition.y = axisPositionY;
        transform.position = _playerPosition;
        if(Input.GetKeyDown(KeyCode.Return) && player)
        {
            cpu = cpu ? false : true;
        }
        if (cpu && ballPosition.transform.position.x > 0f)
        {
            axisPositionY = Mathf.Lerp(axisPositionY, ballPosition.transform.position.y, 0.07f);
        }
        else
        {
            // Definição do Player por parte da code engine
            KeyCode keyUp;
            KeyCode keyDown;
            if (player)
            {
                keyUp = KeyCode.UpArrow;
                keyDown = KeyCode.DownArrow;
            }
            else
            {
                keyUp = KeyCode.W;
                keyDown = KeyCode.S;
            }
            
            // Controlador das Raquetes
            if (Input.GetKey(keyUp) && _playerPosition.y < 5.49f)
            {
                axisPositionY += 5f * Time.deltaTime;
            } else if (Input.GetKey(keyDown) && _playerPosition.y > -5.49f)
            {
                axisPositionY -= 5f * Time.deltaTime;
            }
        }
    }
}
