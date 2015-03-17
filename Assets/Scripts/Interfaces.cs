using System;
using System.Collections.Generic;


interface IAdjustedDifficulty
{
    void AdjustForDifficulty();
    void Easy();
    //Normal not covered because its the default setting
    void Hard();
    //Endless not covered for same reason (its a change over time, not difficulty)
}

