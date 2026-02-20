# Apartado A:

Para que la bola se mueva, primero tenemos que instalar el Input System.
Luego añadirle al player los componentes de rigidBody, Player Input y finalmente un Script para controlarlo.

El input por defecto estará vacio por lo que tendremos que añadir uno presionando en "Create Actions". Ahí nos mostrará una ventana para guardar un archivo, recomiendo crear una carpeta Input y guardar alli el archivo.

Finalmente, el Script de movimiento debe ser algo parecido a esto:

```
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using System;


public class PlayerController : MonoBehaviour
{
    // Rigidbody of the player.
    private Rigidbody rb; 
   

    // Movement along X and Y axes.
    private float movementX;
    private float movementY;

    // Speed at which the player moves.
    public float speed = 10; 

    // Start is called before the first frame update.
    void Start()
    {
        // Get and store the Rigidbody component attached to the player.
        Debug.Log("Player");
        rb = GetComponent<Rigidbody>();
    }
 
    // This function is called when a move input is detected.
    void OnMove(InputValue movementValue)
    {
        // Convert the input value into a Vector2 for movement.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Store the X and Y components of the movement.
        movementX = movementVector.x; 
        movementY = movementVector.y; 
    }
   
    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate() 
    {
        // Create a 3D movement vector using the X and Y inputs.
        Vector3 movement = new Vector3 (movementX, 0.0f, movementY);
    
        // Apply force to the Rigidbody to move the player.
        rb.AddForce(movement * speed); 
    }
```
Si no os gusta la velocidad se puede ajustar desde el propio inspector de Unity.

Una vez la bola se mueve, le creo un tag personalizado al cubo y en el script de la bola uso la siguiente función para detectar la colisión:
```
private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cubo"))
            {
                Debug.Log("Toco al cubo");
        }    
    }
```

También se puede hacer de otras maneras, como por ejemplo:

Recojer la posición del cubo y compararlo la posición del player entre otros métodos, pero es complicarse de manera innecesaria.

# Apartado B:

Para que el cubo persiga a la bola primero hay que instalar el AI Navigation.

Una vez instalado le agregamos al plano un componente Mesh Nav surface y al cubo le agregamos un Mesh Nav Agent.

Una vez esto este listo, en el plano presionamos el botón "Bake" que aparece en el componente que le agregamos.

Para finalizar le agregamos al cubo, un script con el siguiente código:

```
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{

    public Transform player;
    private NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
       {    
           navMeshAgent.SetDestination(player.position);
       }
    }
}

```

Volvemos a Unity y debería aparecer, como opciones del Script, un apartado player donde debemos arrastrar el objeto de la bola.
Con esto la bola ya debería ser perseguida por el cubo.

Para el cambio de estado consite en agregar estas dos variables debajo de la variable Player:
```
    private float disntacia;
    public String estado;
```
Y agregar este código dentro del if de la función Update:

```
disntacia = Vector3.Distance(player.position,transform.position);
           if (disntacia > 10)
            {
                estado = "Lejos";
            }
            else
            {
                estado = "Cerca";
            }
```