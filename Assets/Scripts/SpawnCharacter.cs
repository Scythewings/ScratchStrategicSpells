using finished3;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SpawnCharacter : MonoBehaviour
{
    [SerializeField] private GameObject[] charPrefabs;
    int test;
    private CharacterDetail character;

    

    // Start is called before the first frame update
    void Start()
    {
        //Spawns();
    }

    // Update is called once per frame
    public void Spawns()
    {
        RaycastHit2D? hit = GetRandomTile();

        OverlayTile tile = hit.Value.collider.gameObject.GetComponent<OverlayTile>();


        foreach (GameObject chracters in charPrefabs)
        {
            var newChar = Instantiate(chracters);
            character = newChar.GetComponent<CharacterDetail>();
        }
    }

    private void PositionCharacterOnLine(OverlayTile tile)
    {
        character.transform.position = new Vector3(tile.transform.position.x, tile.transform.position.y + 0.0001f, tile.transform.position.z);
        character.GetComponent<SpriteRenderer>().sortingOrder = tile.GetComponent<SpriteRenderer>().sortingOrder;
        character.standingOnTile = tile;
    }

    private static RaycastHit2D? GetRandomTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);

        if (hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }

        return null;
    }
}
