using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveTime = 1f;

    public GameObject iBattleManager;

    private BattleManager iBattleScript;

    public Material grass;
    public Material highlight;

    public Entity player;

    public bool moved;

    private void Awake()
    {
        iBattleManager = GameObject.Find("Battle Manager");
        iBattleScript = iBattleManager.GetComponent<BattleManager>();

        grass = Resources.Load<Material>("Textures/Grass");
        highlight = Resources.Load<Material>("Textures/Outline");

        moved = false;
    }

    private void Update()
    {
        if (iBattleScript.action == Action.MOVE)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100f))
            {
                GameObject clickedTile = hit.collider.gameObject;
                MeshRenderer clickedTexture = clickedTile.GetComponent<MeshRenderer>();

                if (Tile.selectedTile != null)
                {
                    Tile.selectedTile.GetComponent<MeshRenderer>().material = Tile.previousMaterial;
                }
                Tile.previousMaterial = clickedTexture.material;
                Tile.selectedTile = clickedTile;

                clickedTexture.material = highlight;

                if (Input.GetMouseButtonDown(0))
                {
                    Vector3 clickedLocation = clickedTile.transform.position;
                    Vector3 playerLocation = player.transform.position;

                    float mDistance = Mathf.Abs(playerLocation.x - clickedLocation.x);
                    mDistance += Mathf.Abs(playerLocation.z - clickedLocation.z);

                    if (mDistance <= player.currentActionPoints)
                    {
                        player.transform.position = new Vector3(clickedLocation.x, clickedLocation.y + 0.8f, clickedLocation.z);

                        player.currentActionPoints -= mDistance;
                    }

                    moved = true;

                    if (player.currentActionPoints <= 0)
                        StartCoroutine(iBattleScript.EnemyTurn());
                }
            }
        }
    }

    public IEnumerator movePlayer()
    {
        yield return new WaitUntil(() => moved = true);
    }
}