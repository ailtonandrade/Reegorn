using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float torque;
    public float torqueRotation;
    public Vector3 movement;
    public float direction;
    CharacterController controller; 
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        torque = 6;
        torqueRotation = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (movement.magnitude >= 0.1f) 
        {     //mathf.atan2 retorna o resultado do calculo de angulo do movimento olhando em uma
              //perspectiva 2d topdown do personagem(x e y) lastreado pelo resultado do getaxis h/v
              //ex? (x = 0,7 , y = 0,7 ) = 0,785398
              // utilizando mathf.rad2deg ele transformará radius em graus. trazendo 45
              //sendo assim, ele estará rotacionando para 45 graus
            float targetAngle = Mathf.Atan2(movement.x, movement.z) * Mathf.Rad2Deg;
            //recebe a rotação no eixo Y virando para o local correto     
            transform.rotation = Quaternion.Euler(0, targetAngle, 0);     
            direction = targetAngle;
            controller.Move(movement* torqueRotation * Time.deltaTime); 
        }
        movement = new Vector3 (Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        this.transform.position += movement * torque * Time.deltaTime;
    }
}
