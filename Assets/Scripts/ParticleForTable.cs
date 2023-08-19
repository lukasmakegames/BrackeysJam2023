using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleForTable : MonoBehaviour
{
    public List<GameObject> temporaryParticlies = new List<GameObject>();
    public List<GameObject> endlessParticlies = new List<GameObject>();

    public float coldownTime = 2f;

    private IEnumerator CreateTemporaryParticlies()
    {
        while (true)
        {
            foreach (GameObject particle in temporaryParticlies)
            {
                Vector2 randomPosition = new Vector2(Screen.width, Screen.height);

                Instantiate(particle, Camera.main.ScreenToWorldPoint(new Vector3(randomPosition.x, randomPosition.y, 0)), Quaternion.identity);
            }

            yield return new WaitForSeconds(coldownTime);
        }
    }

    private IEnumerator CreateEndlessParticlies()
    {
        while (true)
        {
            foreach (GameObject particle in endlessParticlies)
            {
                Vector2 randomPosition = new Vector2(Screen.width, Screen.height);

                var newParticle = Instantiate(particle, Camera.main.ScreenToWorldPoint(new Vector3(randomPosition.x, randomPosition.y, 0)), Quaternion.identity);
                Destroy(newParticle.gameObject, 2f);
            }
            yield return new WaitForSeconds(1f);
        }
    }

    void Start()
    {
        StartCoroutine(CreateTemporaryParticlies());
        StartCoroutine(CreateEndlessParticlies());
    }
}
