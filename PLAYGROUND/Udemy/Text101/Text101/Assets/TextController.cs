using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    //instantiates the variable that holds the copy
    public Text myText;
    //instantiates the enumeration
    private enum States {
                            cell,
                            mirror,
                            sheets_0,
                            lock_0,
                            sheets_1,
                            lock_1,
                            cell_mirror,
                            corridor_0,
                            corridor_1,
                            done
                        };
    //instantiate a variable used to assign different states
    private States myState;

	// Use this for initialization
	void Start () {
        myState = States.cell;
    }
	
	// Update is called once per frame
	void Update () {
        print(myState);
        if(myState == States.cell) { Cell(); }
        if(myState == States.sheets_0){ Sheets_0(); }
        if(myState == States.sheets_1){ Sheets_1(); }
        if(myState == States.lock_0){ Lock_0(); }
        if(myState == States.lock_1){ Lock_1(); }
        if(myState == States.mirror) { Mirror(); }
        if(myState == States.cell_mirror){ Cell_Mirror(); }
        if(myState == States.corridor_0){ Corridor_1(); }
        if (myState == States.done) { Done(); }
    }

    void Cell()
    {
        myText.text = "Hello, you have awoken inside a prison with no recollection " +
                      "of why and how you got there at all. You feel sick and confused " +
                      "but you're first order of business is find out why you are there.\n\n" +
                      "To continue press S to view your sheets, M to view your mirror or L to view the lock.";
        if (Input.GetKey(KeyCode.S)){myState = States.sheets_0;}
        if (Input.GetKey(KeyCode.M)){ myState = States.mirror;}
        if (Input.GetKey(KeyCode.L)) { myState = States.lock_0; }
    }

    void Mirror()
    {
        myText.text = "You look in the mirror and you don't recognize yourself " +
                      "that's when you hear footsteps approaching near your cell. \n\n" +
                      "Press R to return to your cell or press S to view your sheets.";
        if (Input.GetKey(KeyCode.R)) { myState = States.cell; }
        if (Input.GetKey(KeyCode.S)) { myState = States.sheets_0; }
    }

    void Sheets_0()
    {
        myText.text = "The guard arrives telling you to get your sheets prepared " +
                      "today's laundry day he says with an evil smirk on his face. \n\n" +
                      "Press G to grab your sheets or press R to return to your cell.";
        if (Input.GetKey(KeyCode.G)){myState = States.sheets_1;}
        if (Input.GetKey(KeyCode.R)) { myState = States.cell; }
    }

    void Sheets_1()
    {
        myText.text = "You pick up your sheets but notice that something has fallen out of them " +
                      "It looks like a key, but for what? \n\n" +
                      "Press R to return to your cell or L to to look at the locks.";
        if (Input.GetKey(KeyCode.R)) { myState = States.cell; }
        if (Input.GetKey(KeyCode.L)) { myState = States.lock_0; }
    }

    void Lock_0()
    {
        myText.text = "You check the lock and it looks like the key might work " +
                      "but who would leave this for you? Was it the guard? " +
                      "What else could this key open?\n\n"+
                      "Press R to return to your cell or press S to find out more about this key or F to take your chances.";
        if (Input.GetKey(KeyCode.R)) { myState = States.cell; }
        if (Input.GetKey(KeyCode.S)) { myState = States.lock_1; }
        if (Input.GetKey(KeyCode.F)) { myState = States.corridor_0; }
    }

    void Lock_1()
    {
        myText.text = "This key looks to be the same key that the guards use, this could " +
                      "definitely be my way to freedom. \n\n" +
                      "Press F to consider leaving or press R to return to your cell.";
        if (Input.GetKey(KeyCode.R)) { myState = States.cell; }
        if (Input.GetKey(KeyCode.F)) { myState = States.corridor_0; }
    }

    void Cell_Mirror()
    {
        myText.text = "The guard arrives telling you to get your sheets prepared " +
                      "today's laundry day he says with an evil smirk on his face. \n\n" +
                      "Press space";
        if (Input.GetKey(KeyCode.S)) { myState = States.sheets_0; }
    }

    void Corridor_1()
    {
        myText.text = "You're in a corridor " +
                      "it to escape prison by pressing E or press R to return to your cell. \n\n";
        if (Input.GetKey(KeyCode.R)) { myState = States.cell; }
        if (Input.GetKey(KeyCode.E)) { myState = States.done; }
    }

    void Done()
    {
        myText.text = "You have escaped, your cell but now it's time to find your way out of the prison. \n\n" +
                      "Press R to play again.";
        if (Input.GetKey(KeyCode.R)) { myState = States.cell; }
    }
}