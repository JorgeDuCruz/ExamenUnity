# Apartado A:

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