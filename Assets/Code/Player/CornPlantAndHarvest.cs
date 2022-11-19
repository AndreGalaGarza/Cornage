using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CornPlantAndHarvest : MonoBehaviour
{
	private SpriteRenderer sRenderer;
	public Sprite SoilEmpty;
	public Sprite SoilWithKernels;
	
	private bool hasKernels;
	private int cornGrown = 0;
	private float cornGrownFloat = 0f;
	private const int CORN_PLANTED = 25;
	private const int MAX_CORN_GROWN = 75;
	private float cornGrowthMultiplier = 0f;
	
	public GameObject CornGrowthBarOutside;
	public GameObject CornGrowthBarInside;
	public GameObject CornFullyGrownIcon;
	private GameObject NewCornGrowthBarOutside;
	private GameObject NewCornGrowthBarInside;
	private GameObject NewCornFullyGrownIcon;
	private const float CORN_GROWTH_BAR_MAX_LENGTH = 0.82f;
	private const float CORN_GROWTH_BAR_WIDTH = 0.12f;
	private float cornGrowthBarLength;
	
	private AudioSource audioSource;
	private AudioClip CornPlant;
	private AudioClip CornHarvest;
	
	private bool PlayerOverlaps()
	{
		return Physics2D.BoxCast(transform.position, transform.localScale, 0f, Vector2.down,
		0.1f, LayerMask.GetMask("Player"));
	}
	
	void Start()
	{
		sRenderer = GetComponent<SpriteRenderer>();
		hasKernels = false;
		cornGrown = 0;
		
		NewCornGrowthBarOutside = Instantiate(CornGrowthBarOutside,
			transform.position, Quaternion.identity);
		NewCornGrowthBarInside = Instantiate(CornGrowthBarInside,
			transform.position, Quaternion.identity);
		NewCornFullyGrownIcon = Instantiate(CornFullyGrownIcon,
			transform.position, Quaternion.identity);
		
		NewCornGrowthBarOutside.transform.parent = transform;
		NewCornGrowthBarInside.transform.parent = transform;
		NewCornFullyGrownIcon.transform.parent = transform;
		
		NewCornGrowthBarOutside.SetActive(false);
		NewCornGrowthBarInside.SetActive(false);
		NewCornFullyGrownIcon.SetActive(false);
		
		audioSource = GetComponent<AudioSource>();
		CornPlant = Resources.Load<AudioClip>("Audio/CornPlant");
		CornHarvest = Resources.Load<AudioClip>("Audio/CornHarvest");
	}
	
    void Update()
	{
		// Press Space to plant or harvest corn
		if (PlayerOverlaps() && Input.GetKeyDown(KeyCode.Space)
			&& GlobalVariables.harvestCooldownTimer == 0f) {
			GlobalVariables.harvestCooldownTimer =
				GlobalVariables.HARVEST_COOLDOWN;
			if (hasKernels) {
				// Harvest corn from soil
				audioSource.PlayOneShot(CornHarvest, 0.7f);
				NewCornGrowthBarOutside.SetActive(false);
				NewCornGrowthBarInside.SetActive(false);
				NewCornFullyGrownIcon.SetActive(false);
				hasKernels = false;
				GlobalVariables.playerCorn += (CORN_PLANTED + cornGrown);
				sRenderer.sprite = SoilEmpty;
			}
			else if (GlobalVariables.playerCorn >= CORN_PLANTED) {
				// Plant kernels into soil
				audioSource.PlayOneShot(CornPlant, 0.7f);
				NewCornGrowthBarOutside.SetActive(true);
				NewCornGrowthBarInside.SetActive(true);
				NewCornFullyGrownIcon.SetActive(false);
				hasKernels = true;
				GlobalVariables.playerCorn -= CORN_PLANTED;
				sRenderer.sprite = SoilWithKernels;
			}
			else {
				DisplayMoreCornPrompt.NeedMoreCorn(ref DisplayMoreCornPrompt.fadeoutTime,
					ref DisplayMoreCornPrompt.alpha, ref DisplayMoreCornPrompt.audioSource,
					ref DisplayMoreCornPrompt.Buzzer);
			}
		}
		
		// Display progress bar of corn growth
		NewCornGrowthBarInside.transform.localScale =
					new Vector3(cornGrowthBarLength,
					CORN_GROWTH_BAR_WIDTH, 1f);
		NewCornGrowthBarInside.transform.localScale =
					new Vector3(cornGrowthBarLength,
					CORN_GROWTH_BAR_WIDTH, 1f);
	}
	
	void FixedUpdate() {
		// Corn growth
		if (hasKernels) {
			if (cornGrown < MAX_CORN_GROWN - 0.1f) {
				cornGrowthMultiplier += Time.deltaTime;
				// Corn growth function:
				// Sigmoid curve takes cornGrown from 0 to 75
				// in approximately 61.335 seconds
				cornGrownFloat = GlobalFunctions.Sigmoid(cornGrowthMultiplier,
					(float)(MAX_CORN_GROWN + 10f), -0.1f, 40f, -1f);
				cornGrown = (int)(cornGrownFloat);
			}
			else {
				cornGrowthMultiplier = 0f;
				cornGrownFloat = (float)(MAX_CORN_GROWN);
				cornGrown = MAX_CORN_GROWN;
				// Display CornFullyGrownIcon
				NewCornGrowthBarOutside.SetActive(false);
				NewCornGrowthBarInside.SetActive(false);
				NewCornFullyGrownIcon.SetActive(true);
			}
			// Set length of corn growth progress bar
			cornGrowthBarLength = CORN_GROWTH_BAR_MAX_LENGTH *
				(cornGrownFloat / MAX_CORN_GROWN);
		}
		else {
			cornGrown = 0;
			cornGrownFloat = 0f;
			cornGrowthBarLength = 0;
			cornGrowthMultiplier = 0f;
		}
	}
}