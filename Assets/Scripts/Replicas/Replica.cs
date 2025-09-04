using UnityEngine;

public class Replica : MonoBehaviour
{
	[SerializeField]
	private Subtitles _subtitles;

	public void ShowReplica(int id)
	{
		_subtitles.ShowText(id);
	}
}