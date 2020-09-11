using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CharaCurrectScale
{
    public enum Currect
    {
        Body = 0,
        Head = 1
    }

    public class CharaPartCur : MonoBehaviour
    {

        [Header("Выбирите нужный вам обьект")]
        public Currect Currects = Currect.Body;

        private void Start()
        {
            if (Currects == Currect.Body) PlayerLibrary.Body = gameObject; else PlayerLibrary.Head = gameObject;
        }

        public void ScaleUpdate(float value,bool i)
        {
            if (i)
                GetComponent<CoverShooter.BodyPartHealth>().DamageScale += value;
            else
            {
                GetComponent<CoverShooter.BodyPartHealth>().DamageScale -= value;
            }

        }
    }
}
