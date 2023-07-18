using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;
    [SerializeField] private Transform _movePoint;
    [SerializeField] private LayerMask _border;
        
    // Start is called before the first frame update
    void Start()
    {
        _movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _movePoint.position, _speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, _movePoint.position) == 0f)
        {

            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                if (!Physics2D.OverlapCircle(_movePoint.position + new Vector3(Input.GetAxisRaw("Horizontal") * 2, 0f, 0f), .2f, _border))
                {
                    _movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal") * 2, 0f, 0f);
                }
            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                if (!Physics2D.OverlapCircle(_movePoint.position + new Vector3(0f, Input.GetAxisRaw("Vertical") * 2, 0f), .2f, _border))
                {
                    _movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical") * 2, 0f);
                }
            }
        }
    }
}
