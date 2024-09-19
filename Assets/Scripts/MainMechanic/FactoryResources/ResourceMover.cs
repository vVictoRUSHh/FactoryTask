using System.Collections;
using UnityEngine;
namespace MainMechanic.FactoryResources
{
    public class ResourceMover
    {
        public IEnumerator MoveResource(GameObject resource, Vector3 targetPosition, float duration)
        {
            Vector3 startPosition = resource.transform.position;
            float elapsedTime = 0f;

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                resource.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            resource.transform.position = targetPosition;
            Object.Destroy(resource);
        }
    }
}