using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class DialogueForPlay : MonoBehaviour
{
    public DialogManager dialogManager;
    void Start()
    {
        DialogData dialogData = new DialogData("Thank you, God! I see you survived these monsters that destroy our home. They appeared so suddenly from space. We need to fight back and return peace to our planet. I think you can help me with that purpose. Our air forces have a special space ship that can destroy enemies. I show you how to manage it. I want to destroy them, but It's impossible due to my poor eyesight, so I hope you do it instead of me. <Tap to the text>", "Survival");
        dialogManager.Show(dialogData);
        
        

    }

   
}
