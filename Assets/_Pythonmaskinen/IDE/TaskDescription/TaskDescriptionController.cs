﻿using UnityEngine;
using UnityEngine.UI;
using PM;

public class TaskDescriptionController : MonoBehaviour, IPMLevelChanged, IPMCompilerStarted
{
	public Animator IconAnimator;

	[Header("Big task description")]
	public GameObject BigTaskDescription;
	public Text BigTaskDescriptionHead;
    public Text BigTaskDescriptionBody;

	[Header("Small task description")]
	public GameObject SmallTaskDescription;
	public GameObject ReadMoreButton;
	public Text SmallTaskDescriptionText;

	[Header("Positive Feedback")]
	public GameObject PositiveParent;
	public Text PositiveText;

	[Header("Positive Feedback")]
	public GameObject NegativeParent;
	public Text NegativeText;

	private Animator anim;
	private bool hasShownBigTaskDescription = false;

	private void Awake()
	{
		anim = IconAnimator;
	}

	public void SetTaskDescription (string header, string body)
	{
		BigTaskDescription.SetActive (false);
		if (header.Length < 1)
		{
			SmallTaskDescription.SetActive (false);
		}
		else
		{
			SetSmallTaskDescription(header, body);

			hasShownBigTaskDescription = false;

			if (!hasShownBigTaskDescription)
			{
				SetBigTaskDescription(header, body);
			}
		}
	}

	private void SetSmallTaskDescription(string header, string body)
	{
		SmallTaskDescription.SetActive(true);
		SmallTaskDescriptionText.text = header;
		if (string.IsNullOrEmpty(body))
			ReadMoreButton.SetActive(false);
		else
			ReadMoreButton.SetActive(true);
	}

	private void SetBigTaskDescription(string header, string body)
	{
		BigTaskDescription.SetActive(true);
		BigTaskDescriptionHead.text = header;
		BigTaskDescriptionBody.text = body;
		hasShownBigTaskDescription = true;
	}

	public void ShowTaskError(string message)
	{
		NegativeParent.SetActive(true);
		NegativeText.text = message;

		anim.SetTrigger("Shake");
	}

	public void HideTaskFeedback()
	{
		NegativeParent.SetActive(false);
		PositiveParent.SetActive(false);

	}

	public void ShowPositiveMessage(string message)
	{
		PositiveParent.SetActive(true);
		PositiveText.text = message;

		anim.SetTrigger("Jump");
	}

	public void OnPMLevelChanged()
	{
		HideTaskFeedback();
	}
	public void OnPMCompilerStarted()
	{
		HideTaskFeedback();
	}
}
