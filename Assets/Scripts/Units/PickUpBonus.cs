using System;
using UnityEngine;
using UnityEngine.UI;

public class PickUpBonus : MonoBehaviour
{
   [SerializeField] private Text _text;
   private int _bonusesInInventory;
   private int _bonusesAtBase;
   private Player _player;


   private void Start()
   {
      _player = ServiceLocator.Instance.GetService<Player>();
   }

   private void Update()
   {
      var transformPosition = _player.transform.position;
      if (transformPosition.z<-7)
      {
         _bonusesAtBase += _bonusesInInventory;
         _text.text = _bonusesAtBase.ToString();
         _bonusesInInventory = 0;
      }
   }
   
   private void OnTriggerEnter(Collider other)
   {
      var bonus = other.GetComponent<Bonus>();
      if (bonus != null)
      {
         other.gameObject.SetActive(false);
         _bonusesInInventory++;
      }
   }
}
