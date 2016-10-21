using UnityEngine;
using System.Collections;

public abstract class state
{
	public abstract void changeToMyState(TrainMover t);
}

public class backwardstate : state
{
	public override void changeToMyState(TrainMover t)
	{
		t.move = new backward ();
	}
}

public class forwardstate : state
{
	public override void changeToMyState(TrainMover t)
	{
		t.move = new forward ();
	}
}

public class stopstate : state
{
	public override void changeToMyState(TrainMover t)
	{
		t.move = new stop ();
	}
}


public class trainstate : MonoBehaviour {

	state mystate;

	state holderforward = new forwardstate();
	state holderbackward = new backwardstate();
	state holderstop = new stopstate();

	public TrainMover t;
	public int which = 0;

	void Update () {
		switch (which){
		case 0:
			mystate = holderforward;
			mystate.changeToMyState(t);
			break;
		case 1:
			mystate = holderbackward;
			mystate.changeToMyState(t);
			break;
		case 2:
			mystate = holderstop;
			mystate.changeToMyState(t);
			break;
		}
	}
}