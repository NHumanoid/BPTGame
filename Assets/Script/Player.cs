using UnityEngine;

namespace BioProject { 
    public class Player : MonoBehaviour
    {
        #region Var
        [SerializeField]
        private float playerspeed;

        private bool isTouchTop;
        private bool isTouchBottom;
        private bool isTouchRight;
        private bool isTouchLeft;
        #endregion

        #region Unity Event Mathod

        private void Update()
        {
            Move ();
        }

        private void OnTriggerEnter2D(Collider2D collision) //트리거에 맞았을 때 실행하는 유니티 이벤트 함수입니다. 
        {
            if (collision.gameObject.tag == "Border")
            {
                switch (collision.gameObject.name) 
                {
                    case "Top":
                        isTouchTop = true;
                        break;
                    case "Bottom":
                        isTouchBottom = true;
                        break;
                    case "Right":
                        isTouchRight = true;
                        break;
                    case "Left":
                        isTouchLeft = true;
                        break;

                }
            }
        }

        private void OnTriggerExit2D(Collider2D collision) //트리거에 나갔을 때 실행하는 유니티 이벤트 합수입니다.
        {
            if (collision.gameObject.tag == "Border")
            {
                switch (collision.gameObject.name)
                {
                    case "Top":
                        isTouchTop = false;
                        break;
                    case "Bottom":
                        isTouchBottom = false;
                        break;
                    case "Right":
                        isTouchRight = false;
                        break;
                    case "Left":
                        isTouchLeft = false;
                        break;

                }
            }
        }

        #endregion

        #region Costum Mathod
        //플레이어를 움직이게 하는 함수입니다.
        private void Move() 
        {
            float h = Input.GetAxisRaw("Horizontal"); //양옆의 이동키에따라 -1,0,1으로 입력되게 합니다.

            if((isTouchRight && h == 1) || (isTouchLeft && h == -1)) 
            {
                h = 0; //좌우로 움직이지 않게 값을 초기화하여 값을 제한합니다.
            }

            float v = Input.GetAxisRaw("Vertical"); //이하동문

            if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            {
                v = 0; // 이하동문
            }

            Vector3 curPos = this.transform.position;
            Vector3 nextPos = new Vector3(h,v,0f) * playerspeed *Time.deltaTime;
            
            //이런 아래의 식으로도 변경이 가능합니다.
            //transform.position += new Vector3(h, v, 0f) * playerspeed * Time.deltaTime;

            this.transform.position = nextPos + curPos;
        }
        #endregion
    }
}
