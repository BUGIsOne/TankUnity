using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;


public class UserDefine : MonoBehaviour, IUserDefinedTargetEventHandler{
	public ImageTargetBehaviour imageTargetTemplate;	// image模板
	private UserDefinedTargetBuildingBehaviour targetBuildingBehaviour;
	private ObjectTracker objectTracker; // 捕获地image
	private DataSet dataSet;
	private int targetCounter = 0;
	public ImageTargetBuilder.FrameQuality currentQuality;

	public void OnInitialized(){// vuforia is initialized
		objectTracker = TrackerManager.Instance.GetTracker<ObjectTracker> ();
		if (objectTracker != null) {
			dataSet = objectTracker.CreateDataSet ();
			objectTracker.ActivateDataSet (dataSet);
		}
	}

	// Use this for initialization
	void Start () {
		targetBuildingBehaviour = this.GetComponent <UserDefinedTargetBuildingBehaviour> ();
		targetBuildingBehaviour.RegisterEventHandler(this);
	}

	public void BuildNewTarget(){
		string targetName = string.Format (imageTargetTemplate.TrackableName + targetCounter);
		targetBuildingBehaviour.BuildNewTarget (targetName, imageTargetTemplate.GetSize ().x);
	}

	public void OnNewTrackableSource(TrackableSource trackableSource){
		targetCounter++;
		objectTracker.DeactivateDataSet (dataSet);
		ImageTargetBehaviour imageTargetCopy = Instantiate (imageTargetTemplate);
		imageTargetCopy.gameObject.name = "UserTarget-" + targetCounter;
		dataSet.CreateTrackable (trackableSource, imageTargetCopy.gameObject);
		objectTracker.ActivateDataSet (dataSet);
	}

	public void OnFrameQualityChanged(ImageTargetBuilder.FrameQuality frameQuality){
		currentQuality = frameQuality;
	}

	
	// Update is called once per frame
	void Update () {
		
	}
}
