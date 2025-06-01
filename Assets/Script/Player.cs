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

        private void OnTriggerEnter2D(Collider2D collision) //Ʈ���ſ� �¾��� �� �����ϴ� ����Ƽ �̺�Ʈ �Լ��Դϴ�. 
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

        private void OnTriggerExit2D(Collider2D collision) //Ʈ���ſ� ������ �� �����ϴ� ����Ƽ �̺�Ʈ �ռ��Դϴ�.
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
        //�÷��̾ �����̰� �ϴ� �Լ��Դϴ�.
        private void Move() 
        {
            float h = Input.GetAxisRaw("Horizontal"); //�翷�� �̵�Ű������ -1,0,1���� �Էµǰ� �մϴ�.

            if((isTouchRight && h == 1) || (isTouchLeft && h == -1)) 
            {
                h = 0; //�¿�� �������� �ʰ� ���� �ʱ�ȭ�Ͽ� ���� �����մϴ�.
            }

            float v = Input.GetAxisRaw("Vertical"); //���ϵ���

            if ((isTouchTop && v == 1) || (isTouchBottom && v == -1))
            {
                v = 0; // ���ϵ���
            }

            Vector3 curPos = this.transform.position;
            Vector3 nextPos = new Vector3(h,v,0f) * playerspeed *Time.deltaTime;
            
            //�̷� �Ʒ��� �����ε� ������ �����մϴ�.
            //transform.position += new Vector3(h, v, 0f) * playerspeed * Time.deltaTime;

            this.transform.position = nextPos + curPos;
        }
        #endregion
    }
}
