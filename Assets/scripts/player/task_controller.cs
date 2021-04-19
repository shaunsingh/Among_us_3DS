using UnityEngine;
using UnityEngine.UI;
using System;

public class task_controller : MonoBehaviour {


	[Header("text + slider to tell what tasks to do and the progress")]
	public Slider progress;
	public Text progressText;
	public Text[] taskHolders;

	[Header("the task list + which one is used")]
	public string[] tasks;
	public double randomTasks;

	[Header("makes sure no double tasks exist")]
	public int[] tasksAssigned;
	public bool noDoubles = false;

	// Use this for initialization
	void Start () {
		selectRandomTasks();
	}

	void selectRandomTasks()
	{
		genRandomNumber();
	}

	void genRandomNumber()
	{
		if (tasksAssigned[0] <= 0)
		{
			randomTasks = System.Math.Round(UnityEngine.Random.Range(0f, tasks.Length));
			tasksAssigned[0] = (int)randomTasks;
		}
		if (tasksAssigned[1] <= 0)
		{
			randomTasks = System.Math.Round(UnityEngine.Random.Range(0f, tasks.Length));
			tasksAssigned[1] = (int)randomTasks;
		}
		if (tasksAssigned[2] <= 0)
		{
			randomTasks = System.Math.Round(UnityEngine.Random.Range(0f, tasks.Length));
			tasksAssigned[2] = (int)randomTasks;
		}
		if (tasksAssigned[3] <= 0)
		{
			randomTasks = System.Math.Round(UnityEngine.Random.Range(0f, tasks.Length));
			tasksAssigned[3] = (int)randomTasks;
		}

		checkDoubles();
		if (noDoubles)
		{
			setText();
		}
	}

	void checkDoubles()
	{
		if (tasksAssigned[0] == tasksAssigned[1] || tasksAssigned[0] == tasksAssigned[2] || tasksAssigned[0] == tasksAssigned[3])
		{
			tasksAssigned[0] = 0;
			genRandomNumber();
		}
		else if (tasksAssigned[1] == tasksAssigned[0] || tasksAssigned[1] == tasksAssigned[2] || tasksAssigned[1] == tasksAssigned[3])
		{
			tasksAssigned[1] = 0;
			genRandomNumber();
		}
		else if (tasksAssigned[2] == tasksAssigned[0] || tasksAssigned[2] == tasksAssigned[1] || tasksAssigned[0] == tasksAssigned[3])
		{
			tasksAssigned[2] = 0;
			genRandomNumber();
		}
		else if (tasksAssigned[3] == tasksAssigned[0] || tasksAssigned[3] == tasksAssigned[1] || tasksAssigned[3] == tasksAssigned[2])
		{
			tasksAssigned[3] = 0;
			genRandomNumber();
		}
		else
		{
			noDoubles = true;
		}
	}

	void setText()
	{
		taskHolders[0].text = tasks[tasksAssigned[0]];
		taskHolders[1].text = tasks[tasksAssigned[1]];
		taskHolders[2].text = tasks[tasksAssigned[2]];
		taskHolders[3].text = tasks[tasksAssigned[3]];
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
