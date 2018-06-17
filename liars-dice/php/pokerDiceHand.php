<?php

//require_once(__ROOT__.'/config.php'); 


abstract class HandKind 
{
   const fiveOfKind  = 7;
   const fourOfKind  = 6;
   const fullHouse   = 5;
   const straight    = 4;
   const threeOfKind = 3;
   const twoPairs    = 2;
   const pair        = 1;
   const none        = 0;
}


class pokerDiceHand{

   public static function isValidFacesString($facesString){
      //string s = string.Empty;
      $s = "";

      //foreach(char c in facesString)
      $chararray = str_split($your_string);
      foreach ($chararray as $c){
         $i = Index($c);
         if ($i < 0)
            return FALSE;
      }
      return TRUE;
   }


   //public pokerDiceHand(String fiveFacesString)
   public function __construct($fiveFacesString){
      //int[] facesCounts = new int[FacesCount()];
      echo "__construct()\n";
      echo '$fiveFacesString=' . $fiveFacesString . "\n";
      //for (int j= FacesCount() - 1; j>-1; j--) 
      for ($j = $this->FacesCount() - 1; $j > -1; $j--) {
         //countFaces(fiveFacesString, Face(j), ref facesCounts[j]);
         pokerDiceHand::countFaces($fiveFacesString, pokerDiceHand::Face($j), $facesCounts[$j]);

         //for (int i = 0; i < facesCounts[j]; i++)
         for ($i = 0; $i < $facesCounts[$j]; $i++){
            //faces += Face(j);
            $this->$facesString .= pokerDiceHand::Face($j);
         }
      }
      echo '$this->$facesString= ' . $this->$facesString . "\n";
      $this->SetHashCode($facesCounts);
      echo '$this->$hashcode = '. $this->$hashcode ."\n";
      $this->SetHandKind($facesCounts);
      echo '$this->$handKind = '. $this->$handKind . "\n";
      $this->RefineHandKind($facesCounts);
      echo '$this->$primaryFaceNum = ' .   $this->$primaryFaceNum . "\n";
      echo '$this->$secondaryFaceNum = ' . $this->$secondaryFaceNum . "\n";
   }


   //public HandKind getHandKind()
   public function getHandKind() {
      return $this->$handKind;
   }


   //public string getFacesOrderedByRank()
   public function getFacesOrderedByRank() {
      return $this->$faces;
   }


   //public override bool Equals(object obj)
   public function Equals(pokerDiceHand $obj) {

      //pokerDiceHand p = obj as pokerDiceHand;
      //if ((System.Object)p == null)
      if (is_null($obj))
         return FALSE;

      return ($this->$faces == $obj->$faces);
   }


   //public bool Equals ( pokerDiceHand obj )
   //public bool Equals ( pokerDiceHand obj )
   //{
   //         if (ReferenceEquals(obj, null))
   //             return false;
   //
   //         if (obj.faces == faces)
   //             return true;
   //         return false;
   //}


   //public static bool operator == (pokerDiceHand lhs, pokerDiceHand rhs)
   // NOTE see function eq() below - taken outside of class.

   //public static bool operator !=(pokerDiceHand lhs, pokerDiceHand rhs)
   public static function ne(pokerDiceHand $lhs, pokerDiceHand $rhs)
   {
      return !(pokerDiceHand::eq($lhs, $rhs));
   }


   //private static bool gt(pokerDiceHand lhs, pokerDiceHand rhs)
   private static function gt(pokerDiceHand $lhs, pokerDiceHand $rhs)
   {
      if ($lhs->$handKind != $rhs->$handKind)
         return $lhs->$handKind < $rhs->$handKind;

      if ($lhs->$primaryFaceNum != $rhs->$primaryFaceNum)
         return $lhs->$primaryFaceNum > $rhs->$primaryFaceNum;
      if ($lhs->$secondaryFaceNum != $rhs->$secondaryFaceNum)
         return $lhs->$secondaryFaceNum > $rhs->$secondaryFaceNum;
      return $lhs->$hashcode > $rhs->$hashcode;
   }


   //public static bool operator > (pokerDiceHand lhs, pokerDiceHand rhs)
   //{
   //   return gt(lhs, rhs);
   //}

   //public static bool operator < (pokerDiceHand lhs, pokerDiceHand rhs)
   //{
   //   if (lhs==rhs)
   //      return false;
   //   return (!gt(lhs, rhs));
   //}

   //public override int GetHashCode()
   public function GetHashCode()
   {
      return $this->$hashcode;
   }


   //private void SetHashCode( int[] facesCounts)
   private function SetHashCode( $facesCountsArray )
   {
      $this->$hashcode = 0;
      $multiplier = 1;

      for ($i=0; $i<count($facesCountsArray); $i++)
      {
         $this->$hashcode += $multiplier * $facesCountsArray[$i];
         $multiplier *= 10;
         //echo '$this->$hashcode ='. $this->$hashcode ."\n";
      }
   }


   //private static void countFaces(String fiveFacesString, string faceKind, ref int counterToIncrement)
   private static function countFaces($fiveFacesString, $faceKindString, &$counterToIncrement)
   {
      //int faceVal = System.Char.ConvertToUtf32(faceKind, 0);
      $faceVal = ord($faceKindString);
      $counterToIncrement = 0;
      for ($i = 0; $i < 5; $i++)
      {
         //if (fiveFacesString[i] == faceVal)
         if (ord( substr($fiveFacesString, $i, 1) ) == $faceVal)
            $counterToIncrement++;
      }
   }


   //private void SetHandKind(int[] facesCounts)
   private function SetHandKind($facesCountsArray)
   {
      //List<int> fc = new List<int>();
      $fc = array();
      for ($i = 0; $i < count($facesCountsArray); $i++)
         //fc.Add(facesCounts[i]);
         $fc[$i] = $facesCountsArray[$i];

      //List<int> unsortedFaceCounts = new List<int>();
      //unsortedFaceCounts = fc.ToList();
      $unsortedFaceCounts = $fc;

      //fc.Sort();
      //fc.Reverse();
      rsort($fc);

      switch ($fc[0])
      {
         case 5:
            $this->$handKind = HandKind::fiveOfKind; break;
         case 4:
            $this->$handKind = HandKind::fourOfKind; break;
         case 3:
            $this->$handKind = ($fc[1] == 2 ? HandKind::fullHouse : HandKind::threeOfKind); break;
         case 2:
            $this->$handKind = ($fc[1] == 2 ? HandKind::twoPairs : HandKind::pair); break;
         case 1:
            if ($unsortedFaceCounts[ Index("T")] == 0 || 
                $unsortedFaceCounts[ Index("J")] == 0 ||
                $unsortedFaceCounts[ Index("Q")] == 0 ||
                $unsortedFaceCounts[ Index("K")] == 0
               )
               $this->$handKind = HandKind::none;
            else
               $this->$handKind = HandKind::straight;
            break;
      }
   }


   //private void RefineHandKind(int[] facesCounts)
   private function RefineHandKind($facesCountsArray)
   {
      echo "RefineHandKind()\n";
      echo '$facesCountsArray = '." \n";
      var_dump($facesCountsArray);
      echo "\n";
      switch($this->$handKind)
      {
         case HandKind::fiveOfKind:
            $this->$primaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 5);
            break;

         case HandKind::fourOfKind:
            $this->$primaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 4);
            $this->$secondaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 1);
            break;

         case HandKind::fullHouse:
            $this->$primaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 3);
            $this->$secondaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 2);
            break;

         case HandKind::straight:

         case HandKind::threeOfKind:
            $this->$primaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 3);
            $this->$secondaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 1);
            break;

         case HandKind::twoPairs:
            echo 'HandKind::twoPairs'."\n";

            $rva = pokerDiceHand::FindRepeatedFace($facesCountsArray, 2);
            echo 'returned is: '. $rva . "\n";
            $this->$primaryFaceNum = 5; //$rva;

            $rvb = pokerDiceHand::FindRepeatedFace($facesCountsArray, 2, $this->$primaryFaceNum);
            echo 'returned is: '. $rvb . "\n";
            $this->$secondaryFaceNum = 2; //$rvb;

            echo '$this->$primaryFaceNum = ' . $this->$primaryFaceNum . "\n";
            echo '$this->$secondaryFaceNum = ' . $this->$secondaryFaceNum . "\n";
            break;

         case HandKind::pair:
            $this->$primaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 2);
            $this->$secondaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 1, $this->$primaryFaceNum);
            break;

         case HandKind::none:
            $this->$primaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 1);
            $this->$secondaryFaceNum = pokerDiceHand::FindRepeatedFace($facesCountsArray, 1, $this->$primaryFaceNum);
            break;
      }
   }


   //private static int FindRepeatedFace(int[] facesCounts,  int frequency, int? excludeA=null, int? excludeB=null )
   private static function FindRepeatedFace($facesCountsArray,  $frequency, $excludeA=null, $excludeB=null )
   {
      echo "FindRepeatedFace()\n";
      echo '$facesCountsArray = '.$facesCountsArray."\n";
      echo '$frequency = '.$frequency."\n";
      echo '$excludeA = '.$excludeA."\n";
      echo '$excludeB = '.$excludeB."\n";

      for ($j = pokerDiceHand::FacesCount() - 1; $j > -1; $j--)
      {
         echo '$j = '. $j . "\n";
         echo '$facesCountsArray[$j] = '. $facesCountsArray[$j] . "\n";
         if($facesCountsArray[$j]==$frequency)
         {
            echo "a\n";
            if (($excludeA == null && $excludeB == null)
                        || (($excludeA == null) && ($excludeB != $j))
                        || (($excludeB == null) && ($excludeA != $j))
                        || (($excludeA != $j) && ($excludeB != $j))
                        )
            {
               echo "b\n";
               return $j;
            }
         }
      }
      return -1;
   }

   private $handKind = HandKind::none; 
   private $hashcode = 0;
   //private String faces = "";
   private $facesString = "";
   private $primaryFaceNum = null;
   private $secondaryFaceNum = null;


   //private static string Face(int facenum)
   private static function Face($facenum){
      switch($facenum){
         case 0: $retval = "9"; break;
         case 1: $retval = "T"; break;
         case 2: $retval = "J"; break;
         case 3: $retval = "Q"; break;
         case 4: $retval = "K"; break;
         case 5: $retval = "A"; break;
      }
      return $retval;
   }


   private static function Index($facestring){
      $i = 0;
      $s = "";
      do {
         $s = pokerDiceHand::Face($i);
         if ($s == $facestring)
            return $i;
         $i++;
      }
      while (strlen($s) > 0);

      return -1;
   }


   private static function FacesCount()
   {
      return (pokerDiceHand::Index("A")+1);
   }

}


function eq(pokerDiceHand $lhs, pokerDiceHand $rhs)
{
   echo "eq()\n";
   //var_dump($lhs);
   //var_dump($rhs);
   //if (ReferenceEquals(lhs, null) && ReferenceEquals(rhs, null))
   //   return true;
   //if (ReferenceEquals(lhs, null))
   //   return false;
   //if (ReferenceEquals(rhs, null))
   //   return false;
   //if (ReferenceEquals(lhs, rhs))
   //   return true;
   //if (lhs.faces == rhs.faces)
   //   return true;
   //return false;
   if(is_null($lhs) && is_null($rhs))
   {
      echo "a";
      return TRUE;
   }
   if(is_null($lhs) )
   {
      echo "b";
      return FALSE;
   }
   if(is_null($rhs) )
   {
      echo "c";
      return FALSE;
   }
   if( $lhs === $rhs )
   {
      echo "d";
      return TRUE;
   }
   if( $lhs->$facesString == $rhs->$facesString)
   {
      echo "e\n";
      echo $lhs->$facesString . "\n"; 
      echo $rhs->$facesString . "\n"; 
      return TRUE;
   }
   return FALSE;
}

?>
