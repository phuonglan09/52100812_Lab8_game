using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorIDScript : MonoBehaviour
{
    /*public int speedID;

    void Awake()
    {
        speedID = Animator.StringToHash("Speed");
    }
    */
    public int idleStateID;
    public int locomotionStateID;
    public int speedParamID;

    void Awake()
    {
        // Gán giá trị cho các biến ID sử dụng hàm StringToHash
        idleStateID = Animator.StringToHash("Idle");
        locomotionStateID = Animator.StringToHash("Locomotion");
        speedParamID = Animator.StringToHash("Speed");
    }

}
