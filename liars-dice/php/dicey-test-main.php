<?php

define('__ROOT__', dirname(__FILE__)); 
require_once(__ROOT__.'/unitTester.php'); 


function runAll() {
    echo "runAll()";

    $allOkay = FALSE;
    for ($i = 0; $i < 1; $i++)
    {
        if (!PokerDiceHandEqualityOperatorTestPassed()) break;
        //if (!permutationsCalculatorTestPassed()) break;
        //if (!handKindsIdentifyTestPassed()) break;
        //if (!pokerDiceHandStringValidatorTestPassed()) break;
        //if (!PokerDiceHandGreaterLessThanOperatorsTestPassed()) break;
        //if (!rerollerFacesRemainderTestPassed()) break;
        //if (!GameEngineNewGameTestPassed()) break;
        //if (!GameEngineSampleGameTestPassed()) break;
        //if (!GameEngineStalemateRoundTestPassed()) break;
        //if (!GameNotFoundErrorTestPassed()) break;
        $allOkay = TRUE;
    }
    if (!$allOkay)
        echo "......Fail";
    else
        echo "......Pass";
}

runAll();

?>
