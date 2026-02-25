using UnityEngine;

public class TreeSorting : MonoBehaviour
{
    public Transform player;             // Arrastra aquí el jugador
    public Transform treeBase;           // Empty en la base del árbol
    private SpriteRenderer sr;

    public int orderWhenPlayerBelow = 5; // Jugador adelante
    public int orderWhenPlayerAbove = 20; // Árbol adelante

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        if (treeBase == null)
            treeBase = transform; // Por si no lo asignas
    }

    void Update()
    {
        if (player == null) return;

        // Si el jugador está más arriba que la base del árbol
        if (player.position.y > treeBase.position.y)
        {
            sr.sortingOrder = orderWhenPlayerAbove;
        }
        else
        {
            sr.sortingOrder = orderWhenPlayerBelow;
        }
    }
}
