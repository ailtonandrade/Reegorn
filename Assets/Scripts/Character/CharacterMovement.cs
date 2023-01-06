using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    BroadcastingService brodcasting = new BroadcastingService();
    public float torque;
    public float torqueRotation;
    public Vector3 movement;
    private float direction;
    private float nextTime = 0;
    private int interval = 1;
    // Start is called before the first frame update
    void Start()
    {
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

            //variavel apenas para acompanhamento
            direction = targetAngle;
        }
        movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        Vector3 old_pos = this.transform.position;
        this.transform.position += movement * torque * Time.deltaTime;
    }
}
