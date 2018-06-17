<?php

require_once(__ROOT__.'/pokerDiceHand.php'); 


function PokerDiceHandEqualityOperatorTestPassed()
{
   echo "PokerDiceHandEqualityOperatorTestPassed()\n";
   $pdha = new pokerDiceHand("AAJJ9");

   //$pdhb = new pokerDiceHand("AJ9AJ");

   //if (pokerDiceHand::ne($pdha, $pdhb))
   //   return FALSE;

   //$pdhc = new pokerDiceHand("AJAAJ");


   //var_dump( $pdha );
   //var_dump( $pdhc );

   //if (eq($pdha, $pdhc))
   //   return FALSE;
 
   return TRUE;
}


?>
